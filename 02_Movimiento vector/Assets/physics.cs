using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{

    Vector3 aceleracion;
    Vector3 posicion;
    Vector3 velocity;

    [SerializeField] float mass;
    
    private void Start()
    {
        posicion = transform.position;
        
    }

    
    private void Update()
    {
        aceleracion = Vector3.zero;
        ApplyForce(new Vector3(0, -9.8f, 0);
        ApplyForce(new Vector3(1, 0, 0));
        Move();
    }

    public void Move()
    {
        //Limits
        if ((posicion.x > 4.5) || (posicion.x < -4.5))
        {
            velocity.x = velocity.x * -0.9f;
        }
        if ((posicion.y > 4.5) || (posicion.y < -4.5))
        {
            velocity.y = velocity.y * -0.9f;
        }
        if (velocity.y < 0.01f && posicion.y <= -4.5)
        {
            aceleracion.y = 0;
        }
 

        //matematicas
        velocity += aceleracion * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void ApplyForce(Vector3 force) {

        aceleracion += force / mass;
    }

}
