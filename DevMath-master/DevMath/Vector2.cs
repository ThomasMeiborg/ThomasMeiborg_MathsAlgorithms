using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float Magnitude
        {
            get { return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)); }
        }

        public Vector2 Normalized
        {
            get { if (Magnitude > 0) { return this * (1 / Magnitude); } else { return new Vector2(0, 0); } }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
            // Het Dot Product is ook wel de sinus van de hoek tussen beide vectors: return (float)Math.Sin(Angle(lhs, rhs));
            // Wanneer het Dot product genormaliseerd is geldt:
            //  -1 : De vectors staan haaks tegenover elkaar.
            //   0 : De hoek tussen beide vectors is 90 graden.
            //   1 : De vectors wijzen in dezelfde richting. 

        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            if (t < 0)
            {
                t = 0;
            }

            if (t > 1)
            {
                t = 1;
            }

            return new Vector2( a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            //float angle = (float)Math.Atan2(rhs.y - lhs.y, rhs.x - lhs.x);
            float angle = (float)Math.Atan2(rhs.y, rhs.x) - (float)Math.Atan2(lhs.y, lhs.x);
            //Links that helped me: 
            // - https://stackoverflow.com/questions/21483999/using-atan2-to-find-angle-between-two-vectors
            // - https://answers.unity.com/questions/959277/how-to-find-the-angle-between-two-vectors.html

            if (angle > Math.PI) { angle -= 2 * (float)Math.PI; }
            else if (angle <= -Math.PI) { angle += 2 * (float)Math.PI; }
            // Normalizes to the range (-Pi, Pi] and -180 to 180 degrees.

            //if (angle < 0) { angle += 2 * (float)Math.PI; } 
            // Normalizes the angle to the range (0, 2Pi] and 0 to 360 degrees.

            return angle;

            // Other solution but returns NaN sometimes...
            // Law of Cosine (see also my dummy notes): https://www.khanacademy.org/math/linear-algebra/vectors-and-spaces/dot-cross-products/v/defining-the-angle-between-vectors
            //if (lhs.Magnitude > 0 && rhs.Magnitude > 0)
            //{
            //    return (float)Math.Acos(Dot(lhs.Normalized, rhs.Normalized) /* / (lhs.Normalized.Magnitude * rhs.Normalized.Magnitude) */); //Normalized magnitude is equal to 1 but I'm leaving it for my own understanding.
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            angle = DevMath.DegToRad(angle);
            // Normally you would multiply Cos(angle) or Sin(angle) by the magnitude/hypothemuse of the Vector,
            // however you can assume it is normalized and thus that the magnitude is equal to 1; it would not change the result.
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            // Returns normalized direction from angle.
            // https://www.khanacademy.org/math/precalculus/x9e81a4f98389efdf:vectors/x9e81a4f98389efdf:component-form/v/vector-components-from-magnitude-and-direction
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x * scalar, lhs.y * scalar);
        }
        
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            // Could add an extra check in case the scalar == 0 but I'm not sure that would help te code user in the long run.
            // Returning NaN might be clearer feedback that you shouldn't divide by 0 and it wouldn't return an unexpected value.
            return new Vector2(lhs.x / scalar, lhs.y / scalar);
        }
    }
}
