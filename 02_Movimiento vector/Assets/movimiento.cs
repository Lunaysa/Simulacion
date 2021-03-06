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
        if ((posicion.y > 4.5) || (posicion.y < -4.5))
        {
            velocity.y = velocity.y * - 0.9f;
        }
        if (velocity.y < 0.01f && posicion.y <= -4.5)
        {
            aceleracion.y = 0;
        }

        //draw my vectors
        posicion.Draw(Color.white);
        velocity.Draw(posicion, Color.blue);

        //matematicas
        velocity += aceleracion * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }


    
}
