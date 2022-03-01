using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{

    Vector3 aceleracion;
    Vector3 posicion;
    Vector3 velocity;
    [SerializeField] float dampFactor;
    [SerializeField] float mass;
    [SerializeField] float gravedad;

    [Range(0,1)]
    [SerializeField] float coeficienteF;

    private void Start()
    {
        posicion = transform.position;
        
    }

    
    private void Update()
    {
        aceleracion = Vector3.zero;   
        //ApplyForce(new Vector3(0, -9.8f, 0));
        ApplyForce(new Vector3(0, mass*gravedad, 0));
        ApplyForce(Friction(new Vector3(0, mass * gravedad, 0)));
        Move();
    }

    public void Move()
    {
        //Limits
        Vector3 posicion = transform.position;

        if ((posicion.x > 4.5 || posicion.x < -4.5))
        {
            if (posicion.x > 4.5) transform.position = new Vector3(4.5f, transform.position.y);
            if (posicion.x < -4.5) transform.position = new Vector3(-4.5f, transform.position.y);

            velocity.x = velocity.x * -1;
            velocity *= dampFactor;
        }
        else if ((posicion.y > 4.5 || posicion.y < -4.5))
        {
            if (posicion.y > 4.5) transform.position = new Vector3(transform.position.x, 4.5f);
            if (posicion.y < -4.5) transform.position = new Vector3(transform.position.x, -4.5f);

            velocity.y = velocity.y * -1;
            velocity *= dampFactor;
        }
        

        //matematicas
        velocity += aceleracion * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void ApplyForce(Vector3 force) {

        aceleracion += force / mass;
    }

    private Vector3 Friction(Vector3 force)
    {
        return velocity.normalized * (-coeficienteF) * force.magnitude;
    }

}
