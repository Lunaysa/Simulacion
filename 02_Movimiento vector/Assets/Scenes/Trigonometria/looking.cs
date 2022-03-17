using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = MousePosition();
        float angle = Mathf.Atan2(mousePos.y, mousePos.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        transform.localPosition = MousePosition();

    }

    private Vector4 MousePosition() {

        Camera camara = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }
}
