﻿using DevMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class Player
{
    public bool projectileWillHit;
    private float distanceTraveled;

    private Texture2D visual;
    public DevMath.Vector2 Position
    {
        get { return Circle.Position; }
        set { Circle.Position = value; }
    }

    public DevMath.Vector2 Direction => DevMath.Vector2.DirectionFromAngle(Rotation);

    public DevMath.Circle Circle
    {
        get; private set;
    }
    public DevMath.Line Line
    {
        get; private set;
    }

    private Texture2D pixel;
    
    public float Rotation
    {
        get; private set;
    }

    private readonly float moveSpeed = 500.0f;

    private const float MAX_CHARGE_TIME = 1.0f;

    private const float MIN_PROJECTILE_START_VELOCITY = .0f;
    private const float MAX_PROJECTILE_START_VELOCITY = 10.0f;
    private const float MIN_PROJECTILE_START_ACCELERATION = 10.0f;
    private const float MAX_PROJECTILE_START_ACCELERATION = 20.0f;

    private float chargeTime;

    private DevMath.Rigidbody rigidbody;

    public Player()
    {
        visual = Resources.Load<Texture2D>("pacman");

        Circle = new DevMath.Circle();
        Circle.Radius = visual.width * .5f;

        pixel = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        pixel.SetPixel(0, 0, Color.white);
        pixel.Apply();

        Position = new DevMath.Vector2(Screen.width * .5f - visual.width * .5f, Screen.height * .5f - visual.height * .5f);

        rigidbody = new DevMath.Rigidbody()
        {
            mass = 1.0f,
            frictionCoefficient = .4f,
            normalForce = 9.81f
        };

        Line = new DevMath.Line();
    }

    public void Render()
    {
        GUIUtility.RotateAroundPivot(Rotation, Position.ToUnity());

        GUI.DrawTexture(new Rect(Position.x - Circle.Radius, Position.y - Circle.Radius, visual.width, visual.height), visual);

        float p = DevMath.DevMath.Clamp(chargeTime, .0f, MAX_CHARGE_TIME) / MAX_CHARGE_TIME;
        float fireVelocity = DevMath.DevMath.Lerp(MIN_PROJECTILE_START_VELOCITY, MAX_PROJECTILE_START_VELOCITY, p);
        float fireAcceleration = DevMath.DevMath.Lerp(MIN_PROJECTILE_START_ACCELERATION, MAX_PROJECTILE_START_ACCELERATION, p);

        distanceTraveled = DevMath.DevMath.DistanceTraveled(fireVelocity, fireAcceleration, Projectile.LIFETIME);

        //Implementeer de Line class met de IntersectsWith(Circle) functie en gebruik deze om de lijn rood te kleuren wanneer je een enemy zou raken
        if (projectileWillHit)
        {
            // When IntersectWith() in Game.cs returns true, projectileWillHit is set to true;
            pixel.SetPixel(0, 0, Color.red);
            pixel.Apply();
        }
        else
        {
            pixel.SetPixel(0, 0, Color.white);
            pixel.Apply();
        }

        GUI.DrawTexture(new Rect(Position.x, Position.y, distanceTraveled, 1.0f), pixel);

        GUI.matrix = UnityEngine.Matrix4x4.identity; //ERROR: ambiguous reference when UnityEngine is not specified?

        if (Input.GetKey(KeyCode.Q))
		{
            GUILayout.BeginVertical();
            GUILayout.Label($"Velocity X: {rigidbody.Velocity.x / Time.deltaTime}, Y: {rigidbody.Velocity.y / Time.deltaTime} pixels/second");
            GUILayout.Label($"Acceleration: {rigidbody.Acceleration / Time.deltaTime} pixels/second^2");
            GUILayout.EndVertical();
		}
    }

    private void UpdatePhysics()
    {
        DevMath.Vector2 forceDirection = new DevMath.Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));

        rigidbody.UpdateVelocityWithForce(forceDirection, 5.0f, Time.deltaTime);

        Position += rigidbody.Velocity;
    }

    public void Update()
    {
        UpdatePhysics();

        var mousePos = new DevMath.Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var mouseDir = (mousePos - Position).Normalized;

        Rotation = DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(new DevMath.Vector2(.0f, .0f), mouseDir));

        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            float p = DevMath.DevMath.Clamp(chargeTime, .0f, MAX_CHARGE_TIME) / MAX_CHARGE_TIME;

            Game.Instance.CreateProjectile(Position, Direction, DevMath.DevMath.Lerp(MIN_PROJECTILE_START_VELOCITY, MAX_PROJECTILE_START_VELOCITY, p), DevMath.DevMath.Lerp(MIN_PROJECTILE_START_ACCELERATION, MAX_PROJECTILE_START_ACCELERATION, p));

            chargeTime = .0f;
        }

        Line.Position = Position;
        Line.Direction = Direction;
        Line.Length = distanceTraveled;
    }
}
