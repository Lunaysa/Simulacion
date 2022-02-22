using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField]
    Vector3 aceleracion;
    
    [SerializeField]
    Vector3 posicion;
    Vector3 velocity;

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
        if ((posicion.y > 5) || (posicion.y < -5))
        {
            velocity.y = velocity.y * - 0.9f;
        }
        if (velocity.y < 0.01f && posicion.y <= -5)
        {
            aceleracion.y = 0;
        }

        //draw my vectors
        posicion.Draw(Color.white);
        velocity.Draw(posicion, Color.blue);

        velocity += aceleracion * Time.deltaTime;
        posicion += velocity * Time.deltaTime;
        transform.position = posicion;
    }


    
}
