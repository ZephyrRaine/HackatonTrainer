using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera camera;
    public GameObject sphere;
    int nombreSphere;
    float timer; 
    

    void SpawnNewsphere()
    {
        float posX = Random.Range(-1f, 1f);
        Debug.Log(posX);
        float posY = Random.Range(-1f, 1f);
        Debug.Log(posX);
        float posZ = Random.Range(-1f, 1f);
        Debug.Log(posX);
        sphere = Instantiate(sphere, new Vector3(posX, posY, posZ), Quaternion.identity);

    }

    void Update()
        {
        timer += Time.deltaTime;
        Debug.Log(timer);

            
            if (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0)
            {
                RaycastHit hit;
                 Ray ray = camera.ViewportPointToRay(Vector3.one*0.5f);

                if (Physics.Raycast(ray, out hit))
                {
                Transform objectHit = hit.transform;
                Destroy(objectHit.gameObject);
                nombreSphere += 1;
                Debug.Log(nombreSphere);
                SpawnNewsphere();
                // Do something with the object that was hit by the raycast.
                }
            }
        }

}
