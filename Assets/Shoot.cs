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
    float timer;
    private int instantiatedSpheres;
    private int killedSphere;
    [SerializeField] private TMP_Text ballsCounter;
    [SerializeField] private TMP_Text timerText;
    private void Awake()
    {
        Invoke(nameof(SpawnNewsphere), 0.3f);
    }

    void SpawnNewsphere()
    {
        float posX = Random.Range(-6f, 6f);
        Debug.Log(posX);
        float posY = Random.Range(-2f, 2f);
        Debug.Log(posX);
        float posZ = Random.Range(1f, 6f);
        Debug.Log(posX);
        lastSphere = Instantiate(spherePrefab, new Vector3(posX, posY, posZ), Quaternion.identity);
        instantiatedSpheres++;
        UpdateGUI();
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
            }
            else
            {
                Destroy(lastSphere);
                Invoke(nameof(SpawnNewsphere), 0.3f);
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

}
