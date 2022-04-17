using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matriz : MonoBehaviour
{
    [Header("Matriz transform")]

    [SerializeField]
    Vector3 posicion;
    [SerializeField]
    Vector3 rotacion;
    [SerializeField]
    Vector3 escala;

    [Header("Drawing")]
    [SerializeField]
    float tamaño;
    [SerializeField]
    int total;
    [SerializeField]
    bool drawXY = true;
    [SerializeField]
    bool drawZX = true;
    [SerializeField]
    bool drawYZ = true;

    [SerializeField]
    Transform sphere;


    
    Matrix4x4 matrix;
    Vector3 otherObjectPosicionInicial;


    private void Start()
    {
        otherObjectPosicionInicial = sphere.position;
    }

    private void Update()
    {
        matrix = Matrix4x4.TRS(posicion, Quaternion.Euler(rotacion), escala);
        UpdateSphere();
        Base();
        Planos();
    }

    private void UpdateSphere()
    {
        if (sphere == null) return;
        sphere.position = otherObjectPosicionInicial;
        sphere.position = matrix.MultiplyPoint3x4(sphere.position);
    }

    private void Base()
    {
        Vector3 pos = matrix.GetColumn(3);
        Debug.DrawRay(pos, matrix.GetColumn(0), Color.red);
        Debug.DrawRay(pos, matrix.GetColumn(1), Color.green);
        Debug.DrawRay(pos, matrix.GetColumn(2), Color.blue);
    }

    private void Planos()
    {
        Vector3 pos = matrix.GetColumn(3);
        Vector3 xAxis = matrix.GetColumn(0);
        Vector3 yAxis = matrix.GetColumn(1);
        Vector3 zAxis = matrix.GetColumn(2);
        if (drawXY) DrawGrid(pos, xAxis, yAxis, escala.x, escala.y);
        if (drawZX) DrawGrid(pos, zAxis, xAxis, escala.z, escala.x);
        if (drawYZ) DrawGrid(pos, yAxis, zAxis, escala.y, escala.z);
    }

    private void DrawGrid(Vector3 pos, Vector3 xAxis, Vector3 yAxis, float scaleX, float scaleY)
    {
        for (int i = 1; i <= total; ++i)
        {
            Debug.DrawRay(pos + xAxis * tamaño * i, yAxis.normalized * tamaño * total * Mathf.Abs(scaleY));
            Debug.DrawRay(pos + yAxis * tamaño * i, xAxis.normalized * tamaño * total * Mathf.Abs(scaleX));
        }
    }
}
