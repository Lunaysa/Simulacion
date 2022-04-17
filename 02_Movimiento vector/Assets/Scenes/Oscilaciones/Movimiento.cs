using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] private float amplitudX;

    [SerializeField] [Range(1, 5)] private float amplitudY;

    [SerializeField] [Range(1, 5)] private float factor;

    private void Start()
    {
        amplitudX = Random.Range(1, 5);
        amplitudY = Random.Range(1, 5);
        factor = Random.Range(1, 5);
    }

    void Update()
    {
        float x = amplitudX * Mathf.Sin(Time.time * factor);
        float y = amplitudY * Mathf.Sin(Time.time * factor);
        transform.position = new Vector3(x, y, 0);
    }
}
