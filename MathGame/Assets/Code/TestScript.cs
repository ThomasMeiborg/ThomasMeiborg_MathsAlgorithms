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
    DevMath.Matrix4x4 testMatrix2;

    float[][] valuesToMatrix = new float[6][] { new float[4], new float[4], new float[4], new float[4], new float[5], new float[6] };
    DevMath.Vector4[] vectorToMatrix = new DevMath.Vector4[4] { new DevMath.Vector4(1, 2, 3, 4), new DevMath.Vector4(5, 6, 7, 8), new DevMath.Vector4(9, 10, 11, 12), new DevMath.Vector4(13, 14, 15, 16) };
    Vector4[] unityVectorToMatrix = new Vector4[4] { new Vector4(1, 2, 3, 4), new Vector4(5, 6, 7, 8), new Vector4(9, 10, 11, 12), new Vector4(13, 14, 15, 16) };
    DevMath.Matrix4x4 multiplicationMatrix;
    DevMath.Matrix4x4 multiplicationMatrixDevUD;
    DevMath.Matrix4x4 multiplicationMatrixUDUD;
    Matrix4x4 multiplicationMatrixDUDU;
    Matrix4x4 multiplicationMatrixUDU;
    Matrix4x4 unityMPMatrix;

    void Start()
    {
        Vector4 v4 = new Vector4(1, 2, 3, 4);
        valuesToMatrix[0] = new float[4] { v4.x, v4.y, v4.z, v4.w };
        valuesToMatrix[1] = new float[4] { 5, 6, 7, 8 };
        valuesToMatrix[2] = new float[4] { 9, 10, 11, 12 };
        valuesToMatrix[3] = new float[4] { 13, 14, 15, 16 };
        valuesToMatrix[4] = new float[5] { 20, 21, 22, 23, 24 };
        valuesToMatrix[5] = new float[6] { 30, 31, 32, 33, 34, 35 };

        //DevMath.Vector4 mergeUAndDevMathVector = unityVectorToMatrix[1].ToDevMath();
        Vector4 mergeUAndDevMathVector = vectorToMatrix[3].ToUnity();
        print("DevMath Vector4" + mergeUAndDevMathVector);
        //print("DevMath Vector(" + mergeUAndDevMathVector.x + ", " + mergeUAndDevMathVector.y + ", " + mergeUAndDevMathVector.z + ", " + mergeUAndDevMathVector.w+ ")");

        unityMatrix = new Matrix4x4(unityVectorToMatrix[0], unityVectorToMatrix[1], unityVectorToMatrix[2], unityVectorToMatrix[3]);
        testMatrix = new DevMath.Matrix4x4(vectorToMatrix[0],vectorToMatrix[1],vectorToMatrix[2], vectorToMatrix[3]);
        
        //testMatrix2.m = valuesToMatrix;
        //print("values: " + testMatrix.ToUnity());
        
        multiplicationMatrix = testMatrix * testMatrix;
        multiplicationMatrixDevUD = testMatrix * unityMatrix.ToDevMath();
        multiplicationMatrixUDUD = unityMatrix.ToDevMath() * unityMatrix.ToDevMath();
        multiplicationMatrixDUDU = testMatrix.ToUnity() * testMatrix.ToUnity();
        multiplicationMatrixUDU = unityMatrix * testMatrix.ToUnity();
        unityMPMatrix = unityMatrix * unityMatrix;
        print("My DevMath matrix: " + testMatrix.ToUnity()); 
        print("My Unity matrix: " + unityMatrix);
        print("Multiplication Matrix DevDev: " + multiplicationMatrix.ToUnity());
        print("Multiplication Matrix DevUD  : " + multiplicationMatrixDevUD.ToUnity());
        print("Multiplication Matrix UDUD: " + multiplicationMatrixUDUD.ToUnity());
        print("Multiplication Matrix DUDU: " + multiplicationMatrixDUDU);
        print("Multiplication Matrix UDU: " + multiplicationMatrixUDU.ToDevMath().ToUnity());
        print("Multiplication Matrix UU    : " + unityMPMatrix);
        print("^^ ALL MATRICES ABOVE SHOULD BE EQUAL ^^");


        print("Dot = " + DevMath.Vector2.Dot(testV1, testV2) + ", Normalized Dot = " + DevMath.Vector2.Dot(testV1.Normalized, testV2.Normalized) + ", AngleInRad = " + DevMath.Vector2.Angle(testV1, testV2) + ", AngleInDeg = " + DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(testV1, testV2)));
        print("DirectionFromAngle = (" + DevMath.Vector2.DirectionFromAngle(DevMath.Vector2.Angle(testV1, testV2)).x + ", " + DevMath.Vector2.DirectionFromAngle(DevMath.Vector2.Angle(testV1, testV2)).y + ")");
        //print("Normalized V1 = (" + testV1.Normalized.x + ", " + testV1.Normalized.y + ")");
        //print("Normalized V1 Magnitude = " + testV1.Normalized.Magnitude);
        //print("V1 Magnitude = " + testV1.Magnitude + ", V2 Magnitude = " + testV2.Magnitude);
        print(DevMath.DevMath.RadToDeg(Mathf.Acos(-68 / (testV1.Magnitude * testV2.Magnitude))));
        print(DevMath.DevMath.RadToDeg(Mathf.Acos(DevMath.Vector2.Dot(testV1, testV2) / (testV1.Magnitude * testV2.Magnitude))));
        print("Atan2: Is this " + DevMath.DevMath.RadToDeg(Mathf.Atan2(testV2.y - testV1.y, testV2.x - testV2.x)) + " the same as " + DevMath.DevMath.RadToDeg((Mathf.Atan2(testV2.y, testV2.x) - Mathf.Atan2(testV1.y, testV1.x))) + " ? Nope...");

        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-5, -10, -7.5f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-10, -5, -7.5f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(5, 10, 7.5f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(10, 5, 7.5f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-5, 5, 0));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-10, 5, -2.5f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-5, -10, 80));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-10, -5, 80f));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-5, -10, -80));
        print("Inverse Lerp: " + DevMath.DevMath.InverseLerp(-10, -5, -80f));
    }
}