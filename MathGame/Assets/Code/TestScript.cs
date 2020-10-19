using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    GameObject obj;

    DevMath.Vector2 testV1 = new DevMath.Vector2(0, 8);
    DevMath.Vector2 testV2 = new DevMath.Vector2(-8, 0);

    Matrix4x4 unityMatrix;
    DevMath.Matrix4x4 testMatrix;

    float[][] valuesToMatrix = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

    void Start()
    {
        Vector4 v4 = new Vector4(1, 2, 3, 4);
        valuesToMatrix[0] = new float[4] { v4.x, v4.y, v4.z, v4.w };
        valuesToMatrix[1] = new float[4] { 5, 6, 7, 8 };
        valuesToMatrix[2] = new float[4] { 9, 10, 11, 12 };
        valuesToMatrix[3] = new float[4] { 13, 14, 15, 16 };
        testMatrix.m = valuesToMatrix;
        //print(testMatrix.m[0][1] + ", " + testMatrix.m[3][4]);;

        print("Dot = " + DevMath.Vector2.Dot(testV1, testV2) + ", Normalized Dot = " + DevMath.Vector2.Dot(testV1.Normalized, testV2.Normalized) + ", AngleInRad = " + DevMath.Vector2.Angle(testV1, testV2) + ", AngleInDeg = " + DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(testV1, testV2)));
        print("DirectionFromAngle = (" + DevMath.Vector2.DirectionFromAngle(DevMath.Vector2.Angle(testV1, testV2)).x + ", " + DevMath.Vector2.DirectionFromAngle(DevMath.Vector2.Angle(testV1, testV2)).y + ")");
        //print("Normalized V1 = (" + testV1.Normalized.x + ", " + testV1.Normalized.y + ")");
        //print("Normalized V1 Magnitude = " + testV1.Normalized.Magnitude);
        //print("V1 Magnitude = " + testV1.Magnitude + ", V2 Magnitude = " + testV2.Magnitude);
        print(DevMath.DevMath.RadToDeg(Mathf.Acos(-68 / (testV1.Magnitude * testV2.Magnitude))));
        print(DevMath.DevMath.RadToDeg(Mathf.Acos(DevMath.Vector2.Dot(testV1, testV2) / (testV1.Magnitude * testV2.Magnitude))));
        print("Atan2: Is this " + DevMath.DevMath.RadToDeg(Mathf.Atan2(testV2.y - testV1.y, testV2.x - testV2.x)) + " the same as " + DevMath.DevMath.RadToDeg((Mathf.Atan2(testV2.y, testV2.x) - Mathf.Atan2(testV1.y, testV1.x))) + " ? Nope...");
        
    }
}