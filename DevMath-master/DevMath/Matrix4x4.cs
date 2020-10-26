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

        //[column][row]
        public float m00; public float m10; public float m20; public float m30; 
        public float m01; public float m11; public float m21; public float m31;
        public float m02; public float m12; public float m22; public float m32;
        public float m03; public float m13; public float m23; public float m33;

        public Matrix4x4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
        // Also tried a jagged array as input but then it's possible to change the size (Columns x Rows) of the matrix.
        {
            m[0][0] = column1.x; m[1][0] = column1.y; m[2][0] = column1.z; m[3][0] = column1.w;
            m[0][1] = column2.x; m[1][1] = column2.y; m[2][1] = column2.z; m[3][1] = column2.w;
            m[0][2] = column3.x; m[1][2] = column3.y; m[2][2] = column3.z; m[3][2] = column3.w;
            m[0][3] = column4.x; m[1][3] = column4.y; m[2][3] = column4.z; m[3][3] = column4.w;

            m00 = m[0][0]; m10 = m[1][0]; m20 = m[2][0]; m30 = m[3][0];
            m01 = m[0][1]; m11 = m[1][1]; m21 = m[2][1]; m31 = m[3][1];
            m02 = m[0][2]; m12 = m[1][2]; m22 = m[2][2]; m32 = m[3][2];
            m03 = m[0][3]; m13 = m[1][3]; m23 = m[2][3]; m33 = m[3][3];
        }

        public static Matrix4x4 Identity
        {
            get 
            {
                return new Matrix4x4
                (
                    new Vector4(1, 0, 0, 0),
                    new Vector4(0, 1, 0, 0),
                    new Vector4(0, 0, 1, 0),
                    new Vector4(0, 0, 0, 1)
                );
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
                if (Determinant == 0)
                {
                    Console.WriteLine("This matrix does not have an Inverse.");
                    return new Matrix4x4
                    (
                        new Vector4(0, 0, 0, 0),
                        new Vector4(0, 0, 0, 0),
                        new Vector4(0, 0, 0, 0),
                        new Vector4(0, 0, 0, 0)
                    );
                }
                else
                {
                    return new Matrix4x4
                    (
                        new Vector4(1, 0, 0, 0),
                        new Vector4(0, 1, 0, 0),
                        new Vector4(0, 0, 1, 0),
                        new Vector4(0, 0, 0, 1)
                    );
                }
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
            return new Matrix4x4
            (
                new Vector4(1, 0, 0, translation.x),
                new Vector4(0, 1, 0, translation.y),
                new Vector4(0, 0, 1, translation.z),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen

            //return new Matrix4x4
            //(
            //    new Vector4((float)Math.Cos(rotation.y) + (float)Math.Cos(rotation.z), -(float)Math.Sin(rotation.z), (float)Math.Sin(rotation.y), 0),
            //    new Vector4((float)Math.Sin(rotation.z), (float)Math.Cos(rotation.x) + (float)Math.Cos(rotation.z), -(float)Math.Sin(rotation.x), 0),
            //    new Vector4(-(float)Math.Sin(rotation.y), (float)Math.Sin(rotation.x), (float)Math.Cos(rotation.x) + (float)Math.Cos(rotation.y), 0),
            //    new Vector4(0, 0, 0, 1)
            //);

            return new Matrix4x4
            (
                new Vector4((float)Math.Cos(rotation.z), -(float)Math.Sin(rotation.z), 0, 0),
                new Vector4((float)Math.Sin(rotation.z), (float)Math.Cos(rotation.z), 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1)
            ) 
            * new Matrix4x4
            (
                new Vector4((float)Math.Cos(rotation.y), 0, (float)Math.Sin(rotation.y), 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(-(float)Math.Sin(rotation.y), 0, (float)Math.Cos(rotation.y), 0),
                new Vector4(0, 0, 0, 1)
            ) 
            * new Matrix4x4
            (
                new Vector4(1, 0, 0, 0),
                new Vector4(0, (float)Math.Cos(rotation.x), -(float)Math.Sin(rotation.x), 0),
                new Vector4(0, (float)Math.Sin(rotation.x), (float)Math.Cos(rotation.x), 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            return new Matrix4x4
            (
                new Vector4(1, 0, 0, 0),
                new Vector4(0, (float)Math.Cos(rotation), -(float)Math.Sin(rotation), 0),
                new Vector4(0, (float)Math.Sin(rotation), (float)Math.Cos(rotation), 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            return new Matrix4x4
            (
                new Vector4((float)Math.Cos(rotation), 0, (float)Math.Sin(rotation), 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(-(float)Math.Sin(rotation), 0, (float)Math.Cos(rotation), 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            return new Matrix4x4
            (
                new Vector4((float)Math.Cos(rotation), -(float)Math.Sin(rotation), 0, 0),
                new Vector4((float)Math.Sin(rotation), (float)Math.Cos(rotation), 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            return new Matrix4x4
            (
                new Vector4(scale.x, 0, 0, 0),
                new Vector4(0, scale.y, 0, 0),
                new Vector4(0, 0, scale.z, 0),
                new Vector4(0, 0,    0   , 1)
            );
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            //return new Matrix4x4(new float[4][]
            //{ new float[4]
            //{
            //    lhs.m[0][0] * rhs.m[0][0] + lhs.m[0][1] * rhs.m[1][0] + lhs.m[0][2] * rhs.m[2][0] + lhs.m[0][3] * rhs.m[3][0],
            //    lhs.m[1][0] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[3][0],
            //    lhs.m[2][0] * rhs.m[0][0] + lhs.m[2][1] * rhs.m[1][0] + lhs.m[2][2] * rhs.m[2][0] + lhs.m[2][3] * rhs.m[3][0],
            //    lhs.m[3][0] * rhs.m[0][0] + lhs.m[3][1] * rhs.m[1][0] + lhs.m[3][2] * rhs.m[2][0] + lhs.m[3][3] * rhs.m[3][0],
            //},
            //new float[4]
            //{
            //    lhs.m[0][0] * rhs.m[0][1] + lhs.m[0][1] * rhs.m[1][1] + lhs.m[0][2] * rhs.m[2][1] + lhs.m[0][3] * rhs.m[3][1],
            //    lhs.m[1][0] * rhs.m[0][1] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[1][3] * rhs.m[3][1],
            //    lhs.m[2][0] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[3][1],
            //    lhs.m[3][0] * rhs.m[0][1] + lhs.m[3][1] * rhs.m[1][1] + lhs.m[3][2] * rhs.m[2][1] + lhs.m[3][3] * rhs.m[3][1],
            //},
            //new float[4]
            //{
            //    lhs.m[0][0] * rhs.m[0][2] + lhs.m[0][1] * rhs.m[1][2] + lhs.m[0][2] * rhs.m[2][2] + lhs.m[0][3] * rhs.m[3][2],
            //    lhs.m[1][0] * rhs.m[0][2] + lhs.m[1][1] * rhs.m[1][2] + lhs.m[1][2] * rhs.m[2][2] + lhs.m[1][3] * rhs.m[3][2],
            //    lhs.m[2][0] * rhs.m[0][2] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[2][3] * rhs.m[3][2],
            //    lhs.m[3][0] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[3][2],
            //},
            //new float[4]
            //{
            //    lhs.m[0][0] * rhs.m[0][3] + lhs.m[0][1] * rhs.m[1][3] + lhs.m[0][2] * rhs.m[2][3] + lhs.m[0][3] * rhs.m[3][3],
            //    lhs.m[1][0] * rhs.m[0][3] + lhs.m[1][1] * rhs.m[1][3] + lhs.m[1][2] * rhs.m[2][3] + lhs.m[1][3] * rhs.m[3][3],
            //    lhs.m[2][0] * rhs.m[0][3] + lhs.m[2][1] * rhs.m[1][3] + lhs.m[2][2] * rhs.m[2][3] + lhs.m[2][3] * rhs.m[3][3],
            //    lhs.m[3][0] * rhs.m[0][3] + lhs.m[3][1] * rhs.m[1][3] + lhs.m[3][2] * rhs.m[2][3] + lhs.m[3][3] * rhs.m[3][3]
            //} });

            //return new Matrix4x4(
            //new Vector4
            //(
            //    lhs.m[0][0] * rhs.m[0][0] + lhs.m[1][0] * rhs.m[0][1] + lhs.m[2][0] * rhs.m[0][2] + lhs.m[3][0] * rhs.m[0][3],
            //    lhs.m[0][1] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[0][3],
            //    lhs.m[0][2] * rhs.m[0][0] + lhs.m[1][2] * rhs.m[0][1] + lhs.m[2][2] * rhs.m[0][2] + lhs.m[3][2] * rhs.m[0][3],
            //    lhs.m[0][3] * rhs.m[0][0] + lhs.m[1][3] * rhs.m[0][1] + lhs.m[2][3] * rhs.m[0][2] + lhs.m[3][3] * rhs.m[0][3]
            //),                                                                                                           
            //new Vector4                                                                                                  
            //(                                                                                                            
            //    lhs.m[0][0] * rhs.m[1][0] + lhs.m[1][0] * rhs.m[1][1] + lhs.m[2][0] * rhs.m[1][2] + lhs.m[3][0] * rhs.m[1][3],
            //    lhs.m[0][1] * rhs.m[1][0] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[3][1] * rhs.m[1][3],
            //    lhs.m[0][2] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[1][3],
            //    lhs.m[0][3] * rhs.m[1][0] + lhs.m[1][3] * rhs.m[1][1] + lhs.m[2][3] * rhs.m[1][2] + lhs.m[3][3] * rhs.m[1][3]
            //),                                                                                                           
            //new Vector4                                                                                                  
            //(                                                                                                            
            //    lhs.m[0][0] * rhs.m[2][0] + lhs.m[1][0] * rhs.m[2][1] + lhs.m[2][0] * rhs.m[2][2] + lhs.m[3][0] * rhs.m[2][3],
            //    lhs.m[0][1] * rhs.m[2][0] + lhs.m[1][1] * rhs.m[2][1] + lhs.m[2][1] * rhs.m[2][2] + lhs.m[3][1] * rhs.m[2][3],
            //    lhs.m[0][2] * rhs.m[2][0] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[3][2] * rhs.m[2][3],
            //    lhs.m[0][3] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[2][3]
            //),                                                                                                           
            //new Vector4                                                                                                  
            //(                                                                                                            
            //    lhs.m[0][0] * rhs.m[3][0] + lhs.m[1][0] * rhs.m[3][1] + lhs.m[2][0] * rhs.m[3][2] + lhs.m[3][0] * rhs.m[3][3],
            //    lhs.m[0][1] * rhs.m[3][0] + lhs.m[1][1] * rhs.m[3][1] + lhs.m[2][1] * rhs.m[3][2] + lhs.m[3][1] * rhs.m[3][3],
            //    lhs.m[0][2] * rhs.m[3][0] + lhs.m[1][2] * rhs.m[3][1] + lhs.m[2][2] * rhs.m[3][2] + lhs.m[3][2] * rhs.m[3][3],
            //    lhs.m[0][3] * rhs.m[3][0] + lhs.m[1][3] * rhs.m[3][1] + lhs.m[2][3] * rhs.m[3][2] + lhs.m[3][3] * rhs.m[3][3]
            //));

            return new Matrix4x4(
            new Vector4
            (
                lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20 + lhs.m03 * rhs.m30,
                lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20 + lhs.m13 * rhs.m30,
                lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20 + lhs.m23 * rhs.m30,
                lhs.m30 * rhs.m00 + lhs.m31 * rhs.m10 + lhs.m32 * rhs.m20 + lhs.m33 * rhs.m30
            ),
            new Vector4
            (
                lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21 + lhs.m03 * rhs.m31,
                lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                lhs.m30 * rhs.m01 + lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31
            ),
            new Vector4
            (
                lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22 + lhs.m03 * rhs.m31,
                lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m31,
                lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m31,
                lhs.m30 * rhs.m02 + lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m31
            ),
            new Vector4
            (
                lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03 * rhs.m33,
                lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,
                lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,
                lhs.m30 * rhs.m03 + lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
            ));
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            return new Vector4
            (
                lhs.m[0][0] * rhs.x + lhs.m[1][0] * rhs.y + lhs.m[2][0] * rhs.z + lhs.m[3][0] * rhs.w,
                lhs.m[0][1] * rhs.x + lhs.m[1][1] * rhs.y + lhs.m[2][1] * rhs.z + lhs.m[3][1] * rhs.w,
                lhs.m[0][2] * rhs.x + lhs.m[1][2] * rhs.y + lhs.m[2][2] * rhs.z + lhs.m[3][2] * rhs.w,
                lhs.m[0][3] * rhs.x + lhs.m[1][3] * rhs.y + lhs.m[2][3] * rhs.z + lhs.m[3][3] * rhs.w
            );
        }
    }
}


// Rotate around pivot: gebruik quaternion.euler (zet euler angles om in een quternion)
//Rotation omzetten naar Quaternion: zoek unity rotation matrix to quaternion.

