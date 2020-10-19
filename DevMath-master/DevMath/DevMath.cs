using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
            if (t < 0)
            {
                t = 0;
            }

            if (t > 1)
            {
                t = 1;
            }
            float value = a + (b - a) * t;
            //or: float value = a * (1 - b) + b * t;
            return value;
        }

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            float distanceTraveled = startVelocity * time + (0.5f * acceleration * (float)Math.Pow(time, 2));
            return distanceTraveled;
            //acceleration = (finalVelocity-startVelocity) / (float)(Math.Pow(time, 2));
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }

            else if (value > max)
            {
                return max;
            }

            else
            {
                return value;
            }
        }

        public static float RadToDeg(float angle)
        {
            float angleInDeg = angle * (float)(180 / Math.PI);
            return angleInDeg;
        }

        public static float DegToRad(float angle)
        {
            float angleInRad = angle * (float)(Math.PI / 180);
            return angleInRad;
        }
    }
}

//VRAAGJES:
// Om met matrices met elkaar te kunnnen vermenigvuldigen moeten het aantal rijen van LHs gelijk zijn aan het aantal kolommen van RHS.
// Angle functie returns NaN.... er wordt gedeeld door 0...
