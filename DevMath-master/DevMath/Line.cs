using System;

namespace DevMath
{
    public class Line
    {
        public Vector2 Position
        {
            get; set;
        }

        public Vector2 Direction
        {
            get; set;
        }

        public float Length
        {
            get; set;
        }
        
        public bool IntersectsWith(Circle circle, float intersectRadius = 0)
        {
            float radius = circle.Radius;

            Vector2 vectorPlayerToCircle = circle.Position - Position;
            //float distancePlayerToCircle = vectorPlayerToCircle.Magnitude - radius;
            Vector2 lineEndPoint = Position + Direction.Normalized * Length;
            
            Vector2 lineEndToStart = Position - lineEndPoint;
            Vector2 lineEndToCircle = circle.Position - lineEndPoint;
            float angle = Vector2.Angle(lineEndToStart, lineEndToCircle); // If using this instead of the lines below change the variable "lineStartToCircle" in the rejection scalar calculation to "lineEndToCircle" and vice versa...
            //Vector2 lineStartToEnd = lineEndPoint - Position;
            //Vector2 lineStartToCircle = circle.Position - Position;
            //float angle = Vector2.Angle(lineStartToEnd, lineStartToCircle);

            if (lineEndToCircle.Magnitude <= radius)
            {
                if (Vector2.Dot(Direction, vectorPlayerToCircle) > 0) // https://math.stackexchange.com/questions/1330210/how-to-check-if-a-point-is-in-the-direction-of-the-normal-of-a-plane
                {
                    float rejectionScalar = lineEndToCircle.Magnitude * (float)Math.Sin(angle);
                    if ((float)Math.Abs(rejectionScalar) <= circle.Radius + intersectRadius)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else if (Vector2.Dot(lineEndPoint - circle.Position, Position - circle.Position) < 0) //if the end point of the line is not on the same side of the circle as the player.
            {
                if (Vector2.Dot(Direction, vectorPlayerToCircle) > 0)
                {
                    float rejectionScalar = lineEndToCircle.Magnitude * (float)Math.Sin(angle);
                    if ((float)Math.Abs(rejectionScalar) <= circle.Radius + intersectRadius)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }

            //float scalarProjection = Vector2.Dot(lineEndToCircle, (lineEndToStart / Length));
            //float scalarProjection2 = Vector2.Dot(lineEndToCircle, lineEndToStart.Normalized);
            //float scalarProjection3 = lineEndToCircle.Magnitude * (float)Math.Acos(Length / lineEndToCircle.Magnitude);
            // The scalar projection * Direction.Normalized == 'the magnitude of the vector to/the point on' the Line closest to the center of the circle. 
            // The vector rejection is the vector from the projection point to the center of the circle.
            // Usefull link: https://stackoverflow.com/questions/1073336/circle-line-segment-collision-detection-algorithm
        }
    }
}