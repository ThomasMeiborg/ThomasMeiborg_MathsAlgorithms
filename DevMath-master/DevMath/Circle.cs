using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle, float collisionOffset = 1)
        {
            DevMath.Clamp(collisionOffset, 0, 1);
            Vector2 distanceToCol = circle.Position - Position;
            float distanceLength = (float)Math.Sqrt(Math.Pow(distanceToCol.x, 2) + Math.Pow(distanceToCol.y, 2)) - circle.Radius - (Radius * collisionOffset);
            //float distanceLength = (float)(Math.Pow(distanceToCol.x, 2) + (float)Math.Pow(distanceToCol.y, 2)) - (float)Math.Pow(circle.Radius, 2) - (float)Math.Pow(Radius, 2); //Same results as the commented line above but less processor clock cycles.
            if (distanceLength <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
