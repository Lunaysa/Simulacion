using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitaNewton : MonoBehaviour
{
    [Header("Inicial")]
    [SerializeField] private Vector3 velocidad;
    [SerializeField] private float masa = 1;
    private Vector3 aceleracion;

    [Header("Other object")]
    [SerializeField] private Transform target;
    [SerializeField] private float targetMass = 2;

    void Update()
    {
        aceleracion = Vector3.zero;

        // Calculo
        Vector3 difference = target.position - transform.position;
        float distance = difference.magnitude;
        float attractionForceScalar = (masa * targetMass) / distance * distance;
        Vector3 force = attractionForceScalar * difference.normalized;
        ApplyForce(force);

        Move();
    }

    private void Move()
    {
        velocidad += aceleracion * Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
    }

    private void ApplyForce(Vector3 force)
    {
        aceleracion += force / masa;
    }
}
