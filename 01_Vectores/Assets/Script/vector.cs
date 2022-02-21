using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class vector
{
    public float x;
    public float y;

    public vector(float x = 0, float y = 0)
    {
        this.x = x;
        this.y = y;
    }

    public static vector Suma(vector a, vector b)
    {
        var result = new vector(0,0);
        result.x = a.x + b.x;
        result.y = a.y + b.y;
        return result;
    }

    public static vector Resta(vector b, vector a)
    {
        var result = new vector(0,0);
        result.x = a.x - b.x;
        result.y = a.y - b.y;
        return result;
    }

    public static vector Escalar(vector a, float escalar)
    {
        var result = new vector();
        result.x = a.x * escalar;
        result.y = a.y * escalar;
        return result;
    }

    public float Magnitud()
    {
        float result = Mathf.Sqrt(Mathf.Pow(x, 2)+ Mathf.Pow(y, 2));
        return result;
    }

    public float Normalizar()
    {
        float result = x / Magnitud() + y / Magnitud();
        return result;
    }

    public static vector Lerp (vector inicio, vector final, float t)
    {
        vector end = vector.Resta(inicio, final);
        end = vector.Escalar(end, t);
        vector restaLerp = vector.Suma(end, inicio);
        return restaLerp;
    }

    public void Draw(vector vector, Color color)
    {
        Debug.DrawLine(new Vector2(), new Vector2(x, y), color);
    }

    public void Draw(vector origin, vector vector, Color color)
    {
        Debug.DrawLine(new Vector2(origin.x, origin.y), new Vector2(origin.x+x, origin.y+y), color);
    }

    //Operadores

    public static vector operator+ (vector a, vector b)
    {
        return new vector(a.x + b.x, a.y + b.y);
    }

    public static vector operator -(vector a, vector b)
    {
        return new vector(a.x - b.x, a.y - b.y);
    }

    public static vector operator *(vector a, float escalar)
    {
        return new vector(a.x * escalar, a.y * escalar);
    }

    public static vector operator *(float escalar, vector a )
    {
        return new vector(a.x * escalar, a.y * escalar);
    }

    public static vector operator /(float escalar, vector a)
    {
        return new vector(a.x / escalar, a.y / escalar);
    }




}
