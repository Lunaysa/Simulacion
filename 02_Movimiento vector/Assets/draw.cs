using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public static class DrawVector2D
    {

        public static void DoDraw(Vector3 vector, Color color)
        {
            Debug.DrawLine(Vector3.zero, vector, color);
        }

        public static void DoDraw(Vector3 origin, Vector3 vector, Color color)
        {
            Debug.DrawLine(origin, origin + vector, color);
        }

        public static void Draw(this Vector3 vector, Color color)
        {
            DoDraw(vector, color);
        }

        /// <summary>
        /// This is to allow the draw of the vector but with a origin different than
        /// (0, 0)
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="origin"></param>
        /// <param name="color"></param>
        /// <example>
        /// <code>
        /// Vector2D myVector = new Vector2D(2, 2);
        /// myVector.Draw(origin, color);
        /// </code>
        /// </example>
        public static void Draw(this Vector3 vector, Vector3 origin, Color color)
        {
            DoDraw(origin, vector, color);
        }
    }

