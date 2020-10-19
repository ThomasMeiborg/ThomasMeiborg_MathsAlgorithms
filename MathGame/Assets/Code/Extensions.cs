using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ToUnity(this DevMath.Vector2 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static DevMath.Vector2 ToDevMath(this Vector2 v)
    {
        return new DevMath.Vector2(v.x, v.y);
    }

    public static Vector3 ToUnity(this DevMath.Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static DevMath.Vector3 ToDevMath(this Vector3 v)
    {
        return new DevMath.Vector3(v.x, v.y, v.z);
    }
    public static Vector4 ToUnity(this DevMath.Vector4 v)
    {
        return new Vector4(v.x, v.y, v.z, v.w);
    }

    public static DevMath.Vector4 ToDevMath(this Vector4 v)
    {
        return new DevMath.Vector4(v.x, v.y, v.z, v.w);
    }

    public static Matrix4x4 ToUnity(this DevMath.Matrix4x4 m)
    {
        return new Matrix4x4
            (
            new Vector4(m.m00, m.m10, m.m20, m.m30),
            new Vector4(m.m01, m.m11, m.m21, m.m31), 
            new Vector4(m.m02, m.m12, m.m22, m.m32), 
            new Vector4(m.m03, m.m13, m.m23, m.m33) 
            );
    }

    public static DevMath.Matrix4x4 ToDevMath(this Matrix4x4 m)
    {
        return new DevMath.Matrix4x4
        (
            new DevMath.Vector4(m.m00, m.m10, m.m20, m.m30),
            new DevMath.Vector4(m.m01, m.m11, m.m21, m.m31),
            new DevMath.Vector4(m.m02, m.m12, m.m22, m.m32),
            new DevMath.Vector4(m.m03, m.m13, m.m23, m.m33) 
        );
    }
}