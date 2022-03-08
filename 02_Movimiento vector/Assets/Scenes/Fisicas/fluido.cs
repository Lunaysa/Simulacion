using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluido : MonoBehaviour
{
    Vector3 aceleracion;
    Vector3 velocity;

    private float gravity = -9.8f;

    [SerializeField]
    [Range(0, 1)]
    private float dampFactor;
    [SerializeField]
    private float mass = 1;
    [Range(0, 1)]
    [SerializeField] float coeficienteF;
    float frontalArea;

    private void Start()
    {
        frontalArea = transform.localScale.x;
    }

    private void Update()
    {
        
        aceleracion = Vector3.zero;

        
        ApplyForce(new Vector3(0, mass * gravity, 0));

        if (transform.position.y < 0)
        {
            // Calculo
            float speed = velocity.magnitude;
            float fluidFrictionScalarPart = -1f / 2f * speed * speed * frontalArea * coeficienteF;
            Vector3 fluidFriction = fluidFrictionScalarPart * velocity.normalized;
            ApplyForce(fluidFriction);
        }

        // Move the object
        Move();
        CheckLimits();
    }

    public void Move()
    {
        velocity += aceleracion * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        // Debug my vectors
        transform.position.Draw(Color.red);
        aceleracion.Draw(transform.position, Color.green);
        velocity.Draw(transform.position, Color.blue);
    }

    private void CheckLimits()
    {
        Vector3 position = transform.position;
        if ((position.x > 5 || position.x < -5))
        {
            if (position.x > 5) transform.position = new Vector3(5, transform.position.y);
            if (position.x < -5) transform.position = new Vector3(-5, transform.position.y);

            velocity.x = velocity.x * -1;
            velocity *= dampFactor;
        }
        else if (position.y > 5 || position.y < -5)
        {
            if (position.y > 5) transform.position = new Vector3(transform.position.x, 5);
            if (position.y < -5) transform.position = new Vector3(transform.position.x, -5);
            velocity.y = velocity.y * -1;
            velocity *= dampFactor;
        }
    }

    private void ApplyForce(Vector3 force)
    {
        aceleracion += force / mass;
    }
}
