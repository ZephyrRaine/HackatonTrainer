using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public Camera camera;
    [FormerlySerializedAs("sphere")] public GameObject spherePrefab;
    private GameObject lastSphere;
    private GameObject Zone;
    float timer;
    private int instantiatedSpheres;
    private int killedSphere;
    [SerializeField] private TMP_Text ballsCounter;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text FeedbackText;
    [SerializeField] Bounds zoneSpawn;
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    private void Awake()
    {
        Invoke(nameof(SpawnNewsphere), 0.3f);
    }

    void SpawnNewsphere()
    {
        Vector3 pos = RandomPointInBounds(zoneSpawn);
        lastSphere = Instantiate(spherePrefab, pos, Quaternion.identity);
        instantiatedSpheres++;
        UpdateGUI();
        FeedbackText.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && lastSphere != null)
        {
            RaycastHit hit;
            Ray ray = camera.ViewportPointToRay(Vector3.one*0.5f);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Destroy(objectHit.gameObject);
                killedSphere += 1;
                UpdateGUI();

                Invoke(nameof(SpawnNewsphere), 0.3f);
                //  SpawnNewsphere();
                // Do something with the object that was hit by the raycast.
                FeedbackText.text = "Bravo !";
                FeedbackText.enabled = true;
            }
            else
            {
                Destroy(lastSphere);
                Invoke(nameof(SpawnNewsphere), 0.3f);
                FeedbackText.text = "Essaie encore !";
                FeedbackText.enabled = true;
            }
        }

        UpdateGUI();
    }

    void UpdateGUI()
    {
        ballsCounter.text = $"{killedSphere}/{instantiatedSpheres}";
        TimeSpan time = TimeSpan.FromSeconds(timer);

//here backslash is must to tell that colon is
//not the part of format, it just a character that we want in output
        string str = time .ToString(@"hh\:mm\:ss\:fff");
     //   timerText.text = str;
    }

    private void OnDrawGizmosSelected()
    {
        var c = Color.red;
        c.a = 0.25f;
        Gizmos.color = c;   
        Gizmos.DrawCube(zoneSpawn.center, zoneSpawn.size);
    }

}
