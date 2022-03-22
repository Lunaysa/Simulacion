using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looking : MonoBehaviour
{
    [SerializeField] private float aceleracion;

    void Update()
    {
        Vector3 mousePos = MousePosition();
        Vector3 posicion = transform.position;
        Vector3 direccion = (mousePos - posicion).normalized;
        var velocidad = direccion * aceleracion;
        Target(posicion + velocidad);
        Vector3 posicionFinal = new Vector3(velocidad.x, velocidad.y, 0);
        transform.position += posicionFinal * Time.deltaTime;
    }

    private Vector4 MousePosition() {

        Camera camara = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }

    private void rotacionZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
    private void Target(Vector3 targPos)
    {
        Vector3 mousePos = MousePosition();
        Vector3 diferencia = mousePos - transform.position;
        float radianes = Mathf.Atan2(diferencia.y, diferencia.x) - Mathf.PI / 2;
        rotacionZ(radianes);
    }


}
