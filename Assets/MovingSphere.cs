using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingSphere : MonoBehaviour
{
    [SerializeField] Bounds b;
    private Vector3 target;
    [SerializeField] private float speed;
    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    private void Awake()
    {
        target = RandomPointInBounds(b);
    }

    private void OnDrawGizmos()
    {
        var c = Color.red;
        c.a = 0.5f;
        Gizmos.color = c;
        Gizmos.DrawCube(b.center, b.size);
    }

    private void FixedUpdate()
    {
        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target) < 0.2)
        {
            target = RandomPointInBounds(b);
        }
    }
}
