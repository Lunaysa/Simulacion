using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    [SerializeField]
    vector vector1 = new vector();
    [SerializeField]
    vector vector2 = new vector();

    [SerializeField]
    [Range(0, 1)]
    public float range = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        var myVector = new vector();
        
        var resultSuma = vector.Suma(vector1, vector2);

        var resultResta = vector.Resta(vector2, vector1);
    }

    // Update is called once per frame
    void Update()
    {
        vector1.Draw(vector1, Color.black);
        vector2.Draw(vector2, Color.blue);

        var restaVector = vector.Resta(vector1, vector2);
        restaVector = restaVector * (range);
        restaVector.Draw(restaVector, Color.red);
        restaVector.Draw(vector1, restaVector, Color.cyan);

        var lerp = vector.Lerp(vector1, vector2, range);
        lerp.Draw(lerp, Color.green);
    }
}
