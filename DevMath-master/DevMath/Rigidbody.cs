using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DevMath
//{
//    public class Rigidbody
//    {
//        public Vector2 Velocity
//        {
//            get; private set;
//        }

//        public float mass = 1.0f;
//        public float force = 150.0f;
//        public float dragCoefficient = .47f;

//        public void AddForce(Vector2 forceDirection, float deltaTime)
//        {
//            float acceleration = force / mass;
//            float forceDirectionMagnitude = (float)Math.Sqrt(Math.Pow(forceDirection.x, 2) + Math.Pow(forceDirection.y, 2));

//            Velocity += forceDirection;
//            Velocity *= (1 / dragCoefficient) * (float)Math.Exp(-dragCoefficient / mass * deltaTime) * (dragCoefficient * forceDirectionMagnitude + mass * acceleration) - (mass * acceleration / dragCoefficient);
//            //normalize forceDirection vector here?
//        }
//    }
//}

namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        }

        public float Acceleration 
        {
            get; private set;
        }

        public float mass = 1.0f;

        public float frictionCoefficient;
        public float normalForce;

        public void UpdateVelocityWithForce(Vector2 forceDirection, float forceNewton, float deltaTime)
        {
            //deceleratie is alleen zolang de velocity groter dan 0 is.


            //NORMALIZE FORCE DIRECTION.

            //Vector2 normalForceVector = forceDirection.Normalized * forceNewton;
            float friction = frictionCoefficient * normalForce;
            float netForce;
            if (forceDirection.Magnitude > 0)
            {
                netForce = forceNewton - friction;
                Acceleration = netForce / mass;
                Velocity += new Vector2(Acceleration * forceDirection.Normalized.x * deltaTime, Acceleration * forceDirection.Normalized.y * deltaTime);
            }
            else
            {
                if (Velocity.Magnitude > 0.5)
                {
                    netForce = -friction; // DIT ALLEEN TOT VELOCITY.MAGNITUDE 0 EN NIET VERDER
                    Acceleration = netForce / mass;
                    Velocity += new Vector2(Acceleration * Velocity.x * deltaTime, Acceleration * Velocity.y * deltaTime);
                }
                else //if (Velocity.Magnitude <= 0.1)
                {
                    //netForce = 0;
                    //Acceleration = netForce / mass;
                    Acceleration = 0;
                    Velocity = new Vector2(0, 0);

                }
            }
            // forceDirection == 0 when deaccelerating so 0 * deceleration becomes 0

            // Acceleration = 1,076, Deceleration = - 3,924
        }
    }
}

// Normal Force = Contact Force in a perpandicular direction from the contact surface: https://www.khanacademy.org/science/physics/forces-newtons-laws/normal-contact-force/a/what-is-normal-force
// Net Force = mass * acceleration; ΣFy = vertical net force. The net force is the culmination of all the forces acting on the object.
// Acceleration = netForce / mass;
// If the normal force is completely counteracted by a force in the opposite direction (for example an upwards force counteracted by gravity Fg = mg), there is no acceleration and no net force.
// If the net force > 0 then there will be acceleration: Acceleration = NetForce / mass;
// If an object has a constant velocity, there is no net force acting upon it.
