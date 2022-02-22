using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbita : MonoBehaviour
{
    [SerializeField] Vector3 aceleracion;
    [SerializeField] Vector3 posicion;
    [SerializeField] float aceleracionMagnitud;

    Vector3 velocity;

    [SerializeField] Transform bolita1;

    

    private void Start()
    {
        posicion = transform.position;
        
    }


    private void Update()
    {
        Move();
        
    }

    public void Move()
    {
        //if ((posicion.x > 5) || (posicion.x < -5))
        //{
        //    velocity.x =  -1;
        //}
        if ((posicion.y > 4.5) || (posicion.y < -4.5))
        {
            velocity.y = velocity.y * -0.9f;
        }
        if (velocity.y < 0.01f && posicion.y <= -4.5)
        {
            aceleracion.y = 0;
        }

        //draw my vectors
        posicion.Draw(Color.white);
        velocity.Draw(posicion, Color.blue);

        //matematicas

        aceleracion = (bolita1.position - transform.position).normalized * aceleracionMagnitud;
        velocity += aceleracion * Time.deltaTime;
        transform.position += velocity * Time.deltaTime; 
    }
}
