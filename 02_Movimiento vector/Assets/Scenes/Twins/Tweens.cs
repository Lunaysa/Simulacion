using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curva;

    [SerializeField]
    private float duracion = 5;

    [SerializeField]
    private Vector3 posicionInicial;

    [SerializeField]
    private Vector3 posicionFinal = Vector3.one;


    private void Update()
    {
        float tiempo = Time.time / duracion;
        transform.position = Vector3.LerpUnclamped(posicionInicial, posicionFinal, curva.Evaluate(tiempo));
    }
}
