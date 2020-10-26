using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float amountOfEnemies;
    public int amountHitByLine = 0;
    Projectile dummyProjectile;
    float projectileRadius;

    public static Game Instance
    {
        get; private set;
    }

    private Player player;

    private List<Enemy> enemies;

    private List<Projectile> projectiles;

    private Texture2D pixel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pixel = new Texture2D(1, 1);
        pixel.SetPixel(0, 0, Color.white);
        pixel.Apply();

        player = new Player();

        enemies = new List<Enemy>();
        for(int i = 0; i < amountOfEnemies; ++i)
        {
            enemies.Add(new Enemy(new DevMath.Vector2(Random.Range(.0f, Screen.width), Random.Range(.0f, Screen.height))));
        }

        projectiles = new List<Projectile>();
        dummyProjectile = new Projectile(new DevMath.Vector2(9999, 9999), new DevMath.Vector2(0, 0), 0, 0);
        projectileRadius = dummyProjectile.Circle.Radius;
    }

    private void OnGUI()
    {
        player?.Render();

        enemies.ForEach(e => e.Render());

        projectiles.ForEach(p => p.Render());

        if (player == null)
        {
            //Use Sin to animate the colour of the text (GUI.color) between alpha 0.5 and 1.0
            float sineWave = Mathf.Sin(Time.realtimeSinceStartup * 2); // returns value between -1 and 1.
            float alpha = DevMath.DevMath.Lerp(0.5f, 1, DevMath.DevMath.InverseLerp(-1, 1, sineWave));
            GUI.color = new Color(1, 1, 1, alpha);

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.UpperCenter;
            
            GUI.Label(new Rect(Screen.width * .5f - 250.0f, Screen.height * .5f - 50.0f, 500.0f, 100.0f), "YOU LOSE!", style);
        }

        if (amountOfEnemies == 0)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.UpperCenter;
            style.normal.textColor = new Color(Random.Range(0f, 1), Random.Range(0f, 1), Random.Range(0f, 1));
            GUI.Label(new Rect(Screen.width * .5f - 250.0f, Screen.height * .5f - 50.0f, 500.0f, 100.0f), "YOU WIN!", style);
        }

        else
		{
            if (Input.GetKey(KeyCode.Q))
            {
                

                foreach (var enemy in enemies)
                {
                    var direction = enemy.Position - player.Position;
                    var distance = direction.Magnitude;

                    var a = DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(new DevMath.Vector2(0, 0), direction));
                    GUIUtility.RotateAroundPivot(a, player.Position.ToUnity());

                    GUI.color = Color.magenta;

                    GUI.DrawTexture(new Rect(player.Position.x, player.Position.y, distance, 1), pixel);

                    GUI.matrix = Matrix4x4.identity;

                    GUI.color = Color.black;

                    var dot = DevMath.Vector2.Dot(direction.Normalized, player.Direction);

                    var textPos = player.Position + DevMath.Vector2.DirectionFromAngle(a) * (distance * .5f);
                    GUI.Label(new Rect(textPos.x, textPos.y, 200.0f, 200.0f), $"Distance: {distance}\nAngle: {a}\nDot: {dot}");
                }

                GUI.color = Color.white;
            }
		}
    }

    public void CreateProjectile(DevMath.Vector2 position, DevMath.Vector2 direction, float startVelocity, float acceleration)
    {
        projectiles.Add(new Projectile(position, direction, startVelocity, acceleration));
    }

    private void ScreenShake()
    {
        //Implement screen shake with Sin + Matrices
    }

    private void Update()
    {
        if (player == null) return;

        player.Update();

        enemies.ForEach(e => e.Update(player));

        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            projectiles[i].Update();
            if(projectiles[i].ShouldDie)
            {
                projectiles.RemoveAt(i);
            }
        }
        
        foreach (Enemy e in enemies)
        {
            if (e.Circle.CollidesWith(player.Circle))
            {
                player = null;
            }
            if (player.Line.IntersectsWith(e.Circle, projectileRadius))
            {
                if (!e.isHitByLine)
                {
                    amountHitByLine++;
                    e.isHitByLine = true;
                }
                player.projectileWillHit = true;
            }
            if (!player.Line.IntersectsWith(e.Circle, projectileRadius) && e.isHitByLine)
            {
                e.isHitByLine = false;
                amountHitByLine--;
                if (amountHitByLine < 1)
                {
                    player.projectileWillHit = false; 
                }

            }
        }

        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            for(int j = enemies.Count - 1; j >= 0; --j)
            {
                if(projectiles[i].Circle.CollidesWith(enemies[j].Circle))
                {
                    if (enemies[j].isHitByLine)
                    {
                        amountHitByLine--;
                        enemies[j].isHitByLine = false;
                    }
                    if (amountHitByLine < 1)
                    {
                        player.projectileWillHit = false;
                    }
                    enemies.RemoveAt(j);
                    amountOfEnemies--;
                    projectiles.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
