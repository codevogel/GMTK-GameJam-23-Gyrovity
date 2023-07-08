using UnityEngine;

public static class Vector3Extensions
{
    public static bool Approx(this Vector3 a, Vector3 b, float delta)
    {
        return Vector3.Distance(a, b) <= delta;
    }
}
