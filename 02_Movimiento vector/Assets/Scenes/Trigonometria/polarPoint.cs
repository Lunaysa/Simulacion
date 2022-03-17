using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarPoint : MonoBehaviour
{
    [SerializeField] float radio;
    [SerializeField] float tetha;


    [Header("Movement speed")]

    [SerializeField] private float radialSpeed = 1f;
    [SerializeField] private float angularSpeed = 1f;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tetha += angularSpeed * Time.deltaTime;
        radio += radialSpeed * Time.deltaTime;

        Vector3 cartesian = polarToCartesian(radio, tetha);
        transform.localPosition = cartesian;

        Debug.DrawLine(Vector3.zero, cartesian);

        if (radio >= 5 || radio <= -5)
        {
            radialSpeed *= -1;
            //radio -= radialSpeed * Time.deltaTime;
        }
        if (radio <= 5 || radio >= -5)
        {
            radialSpeed *= 1;
            //radio -= radialSpeed * Time.deltaTime;
        }

    }

    Vector3 polarToCartesian(float radio, float tetha)
    {
        return new Vector3(radio * Mathf.Cos(tetha), radio * Mathf.Sin(tetha));
    }
}
