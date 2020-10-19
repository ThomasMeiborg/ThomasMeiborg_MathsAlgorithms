using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4
        (
        //float m00, float m01, float m02, float m03,
        //float m10, float m11, float m12, float m13,
        //float m20, float m21, float m22, float m23,
        //float m30, float m31, float m32, float m33
        float[][] matrix
        )
        {
            matrix = m;
            //[row][column]
            //float m00 = m[0][0]; float m01 = m[0][1]; float m02 = m[0][2]; float m03 = m[0][3];
            //float m10 = m[1][0]; float m11 = m[1][1]; float m12 = m[1][2]; float m13 = m[1][3];
            //float m20 = m[2][0]; float m21 = m[2][1]; float m22 = m[2][2]; float m23 = m[2][3];
            //float m30 = m[3][0]; float m31 = m[3][1]; float m32 = m[3][2]; float m33 = m[3][3];

            float m00 = matrix[0][0]; float m01 = matrix[0][1]; float m02 = matrix[0][2]; float m03 = matrix[0][3];
            float m10 = matrix[1][0]; float m11 = matrix[1][1]; float m12 = matrix[1][2]; float m13 = matrix[1][3];
            float m20 = matrix[2][0]; float m21 = matrix[2][1]; float m22 = matrix[2][2]; float m23 = matrix[2][3];
            float m30 = matrix[3][0]; float m31 = matrix[3][1]; float m32 = matrix[3][2]; float m33 = matrix[3][3];
        }

        public static Matrix4x4 Identity
        {
            get 
            {
                //return new Matrix4x4
                //(
                // 1, 0, 0, 0,
                // 0, 1, 0, 0,
                // 0, 0, 1, 0,
                // 0, 0, 0, 1
                // ); 
                return new Matrix4x4(new float[4][] 
                { 
                    new float[4] { 1, 0, 0, 0 }, 
                    new float[4] { 0, 1, 0, 0 }, 
                    new float[4] { 0, 0, 1, 0 }, 
                    new float[4] { 0, 0, 0, 1 } 
                });
            }
        }

        public float Determinant
        {
            get { throw new NotImplementedException(); }
        }

        public Matrix4x4 Inverse
        {
            get
            {
                throw new NotImplementedException();
                //return new Matrix4x4
                //(-m[0][0], -m[0][1], -m[0][2], -m[0][3],
                // -m[1][0], -m[1][1], -m[1][2], -m[1][3],
                // -m[2][0], -m[2][1], -m[2][2], -m[2][3],
                // -m[3][0], -m[3][1], -m[3][2], -m[3][3]);
                //if (myMatrix.HasInverse)
                //{

                //    // Invert myMatrix. myMatrix is now 
                //    // equal to (-0.4, 0.2 , 0.3, -0.1, 1, -2) 
                //    myMatrix.Invert();

                //    // Return the inverted matrix.
                //    return myMatrix;
                //}
                //else
                //{
                //    throw new InvalidOperationException("The matrix is not invertible.");
                //}
            }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            //return new Matrix4x4
            //(
            //    lhs.m[0][0] * rhs.m[0][0] + lhs.m[0][1] * rhs.m[1][0] + lhs.m[0][2] * rhs.m[2][0] + lhs.m[0][3] * rhs.m[3][0],
            //    lhs.m[1][0] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[3][0],
            //    lhs.m[2][0] * rhs.m[0][0] + lhs.m[2][1] * rhs.m[1][0] + lhs.m[2][2] * rhs.m[2][0] + lhs.m[2][3] * rhs.m[3][0],
            //    lhs.m[3][0] * rhs.m[0][0] + lhs.m[3][1] * rhs.m[1][0] + lhs.m[3][2] * rhs.m[2][0] + lhs.m[3][3] * rhs.m[3][0],

            //    lhs.m[0][0] * rhs.m[0][1] + lhs.m[0][1] * rhs.m[1][1] + lhs.m[0][2] * rhs.m[2][1] + lhs.m[0][3] * rhs.m[3][1],
            //    lhs.m[1][0] * rhs.m[0][1] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[1][3] * rhs.m[3][1],
            //    lhs.m[2][0] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[3][1],
            //    lhs.m[3][0] * rhs.m[0][1] + lhs.m[3][1] * rhs.m[1][1] + lhs.m[3][2] * rhs.m[2][1] + lhs.m[3][3] * rhs.m[3][1],

            //    lhs.m[0][0] * rhs.m[0][2] + lhs.m[0][1] * rhs.m[1][2] + lhs.m[0][2] * rhs.m[2][2] + lhs.m[0][3] * rhs.m[3][2],
            //    lhs.m[1][0] * rhs.m[0][2] + lhs.m[1][1] * rhs.m[1][2] + lhs.m[1][2] * rhs.m[2][2] + lhs.m[1][3] * rhs.m[3][2],
            //    lhs.m[2][0] * rhs.m[0][2] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[2][3] * rhs.m[3][2],
            //    lhs.m[3][0] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[3][2],

            //    lhs.m[0][0] * rhs.m[0][3] + lhs.m[0][1] * rhs.m[1][3] + lhs.m[0][2] * rhs.m[2][3] + lhs.m[0][3] * rhs.m[3][3],
            //    lhs.m[1][0] * rhs.m[0][3] + lhs.m[1][1] * rhs.m[1][3] + lhs.m[1][2] * rhs.m[2][3] + lhs.m[1][3] * rhs.m[3][3],
            //    lhs.m[2][0] * rhs.m[0][3] + lhs.m[2][1] * rhs.m[1][3] + lhs.m[2][2] * rhs.m[2][3] + lhs.m[2][3] * rhs.m[3][3],
            //    lhs.m[3][0] * rhs.m[0][3] + lhs.m[3][1] * rhs.m[1][3] + lhs.m[3][2] * rhs.m[2][3] + lhs.m[3][3] * rhs.m[3][3]
            //);
            return new Matrix4x4(new float[4][]
            { new float[4]
            {
                lhs.m[0][0] * rhs.m[0][0] + lhs.m[0][1] * rhs.m[1][0] + lhs.m[0][2] * rhs.m[2][0] + lhs.m[0][3] * rhs.m[3][0],
                lhs.m[1][0] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[3][0],
                lhs.m[2][0] * rhs.m[0][0] + lhs.m[2][1] * rhs.m[1][0] + lhs.m[2][2] * rhs.m[2][0] + lhs.m[2][3] * rhs.m[3][0],
                lhs.m[3][0] * rhs.m[0][0] + lhs.m[3][1] * rhs.m[1][0] + lhs.m[3][2] * rhs.m[2][0] + lhs.m[3][3] * rhs.m[3][0],
            },
            new float[4]
            {
                lhs.m[0][0] * rhs.m[0][1] + lhs.m[0][1] * rhs.m[1][1] + lhs.m[0][2] * rhs.m[2][1] + lhs.m[0][3] * rhs.m[3][1],
                lhs.m[1][0] * rhs.m[0][1] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[1][3] * rhs.m[3][1],
                lhs.m[2][0] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[3][1],
                lhs.m[3][0] * rhs.m[0][1] + lhs.m[3][1] * rhs.m[1][1] + lhs.m[3][2] * rhs.m[2][1] + lhs.m[3][3] * rhs.m[3][1],
            },
            new float[4]
            {
                lhs.m[0][0] * rhs.m[0][2] + lhs.m[0][1] * rhs.m[1][2] + lhs.m[0][2] * rhs.m[2][2] + lhs.m[0][3] * rhs.m[3][2],
                lhs.m[1][0] * rhs.m[0][2] + lhs.m[1][1] * rhs.m[1][2] + lhs.m[1][2] * rhs.m[2][2] + lhs.m[1][3] * rhs.m[3][2],
                lhs.m[2][0] * rhs.m[0][2] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[2][3] * rhs.m[3][2],
                lhs.m[3][0] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[3][2],
            },
            new float[4]
            {
                lhs.m[0][0] * rhs.m[0][3] + lhs.m[0][1] * rhs.m[1][3] + lhs.m[0][2] * rhs.m[2][3] + lhs.m[0][3] * rhs.m[3][3],
                lhs.m[1][0] * rhs.m[0][3] + lhs.m[1][1] * rhs.m[1][3] + lhs.m[1][2] * rhs.m[2][3] + lhs.m[1][3] * rhs.m[3][3],
                lhs.m[2][0] * rhs.m[0][3] + lhs.m[2][1] * rhs.m[1][3] + lhs.m[2][2] * rhs.m[2][3] + lhs.m[2][3] * rhs.m[3][3],
                lhs.m[3][0] * rhs.m[0][3] + lhs.m[3][1] * rhs.m[1][3] + lhs.m[3][2] * rhs.m[2][3] + lhs.m[3][3] * rhs.m[3][3]
            } });
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            return new Vector4
            (
                lhs.m[0][0] * rhs.x + lhs.m[0][1] * rhs.y + lhs.m[0][2] * rhs.z + lhs.m[0][3] * rhs.w,
                lhs.m[1][0] * rhs.x + lhs.m[1][1] * rhs.y + lhs.m[1][2] * rhs.z + lhs.m[1][3] * rhs.w,
                lhs.m[2][0] * rhs.x + lhs.m[2][1] * rhs.y + lhs.m[2][2] * rhs.z + lhs.m[2][3] * rhs.w,
                lhs.m[3][0] * rhs.x + lhs.m[3][1] * rhs.y + lhs.m[3][2] * rhs.z + lhs.m[3][3] * rhs.w
            );
        }
    }
}


// Rotate around pivot: gebruik quaternion.euler (zet euler angles om in een quternion)
//Rotation omzetten naar Quaternion: zoek unity rotation matrix to quaternion.

