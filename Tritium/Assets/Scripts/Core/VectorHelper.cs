using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class VectorHelper
    {
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        public static Vector2 DegreeToVector2(float degree)
        {
            degree += +90f; // as default 0 means vector (1,0), but we use as default vector for 0 degree vector (0,1)
            // and we need to add 90 degree to compensate this difference

            return RadianToVector2(degree * Mathf.Deg2Rad);
        }
    }
}
