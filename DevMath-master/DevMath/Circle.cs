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

        public bool CollidesWith(Circle circle)
        {
            Vector2 distanceToCol = circle.Position - Position;
            //float distanceLength = Mathf.Sqrt(Mathf.Pow(distanceToCol.x, 2) + Mathf.Pow(distanceToCol.y, 2)) - circle.Radius - Radius;
            float distanceLength = (float)(Math.Pow(distanceToCol.x, 2) + Math.Pow(distanceToCol.y, 2)) - (float)Math.Pow(circle.Radius, 2) - (float)Math.Pow(Radius, 2); //Same results as the commented line above but less processor clock cycles.
            if (distanceLength <=0)
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
