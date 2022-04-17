using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilar : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject prefab;

    [Header("settings")]
    [SerializeField]
    private int instanciasTotales = 50;

    [SerializeField]
    [Range(0, 10)] private float factorSeparation = 0.5f;

   

    void Start()
    {
        for (int i = 0; i < instanciasTotales; i++)
        {
            Instantiate(prefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

        int i = 0;

        foreach (Transform child in transform)
        {
            float x = i * factorSeparation;
            
            child.transform.localPosition = new Vector3(x, Mathf.Sin(x + Time.time));
            ++i;
        }
    }
}
