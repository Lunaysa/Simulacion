using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(movimiento))]
public class boton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Click me please!!!"))
        {
            var castedTarget = target as movimiento;
            castedTarget.Move();
        }
    }
}
