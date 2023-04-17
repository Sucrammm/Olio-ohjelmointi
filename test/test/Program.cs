using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Raylib_cs;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 1000;

            // Initialize window
            Raylib.InitWindow(screenWidth, screenHeight, "Space Invaders");

            // Initialize player
            Player player = new Player(new Vector2(screenWidth / 2, screenHeight - 50), 10, 100);

            // Initialize enemies
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < 5; i++)
            {
                Vector2 position = new Vector2(100 + i * 100, 100);
                Enemy enemy = new Enemy(position, 4, "enemy.png");
                enemies.Add(enemy);
            }

            // Game loop
            while (!Raylib.WindowShouldClose())
            {
                // Update entities
                player.Update(enemies);
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update();
                }

                // Draw entities
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.RAYWHITE);
                player.Draw();
                foreach (Enemy enemy in enemies)
                {
                    enemy.Draw();
                }
                Raylib.EndDrawing();
            }

            // Close window
            Raylib.CloseWindow();
        }

        // Player class
        public class Player
        {
            // Fields
            public Vector2 Position { get; private set; }
            public float Speed { get; private set; }
            public int Health { get; private set; }
            private List<Bullet> bullets = new List<Bullet>();
            private Texture2D texture;

            // Constructor
            public Player(Vector2 position, float speed, int health)
            {
                Position = position;
                Speed = speed / 30;
                Health = health;
                texture = Raylib.LoadTexture("player.png");
            }

            // Update method
            public void Update(List<Enemy> enemies)
            {
                // Move player left and right
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && Position.X < Raylib.GetScreenWidth() - 20)
                {
                    Position.X += Speed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && Position.X > 20)
                {
                    Position.X -= Speed;
                }

                // Fire bullets
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    Bullet bullet = new Bullet(new Vector2(Position.X, Position.Y - 20), new Vector2(0, -10));
                    bullets.Add(bullet);
                }

                // Update bullets
                for (int i = bullets.Count - 1; i >= 0; i--)
                {
                    Bullet bullet = bullets[i];
                    bullet.Update();

                    bool hitEnemy = false;
                    // Check for collisions with enemies
                    for (int j = enemies.Count - 1; j >= 0; j--)
                    {
                        Enemy enemy = enemies[j];
                        if (Raylib.CheckCollisionCircles(bullet.Position, 5, enemy.Position, 20))
                        {
                            // Reduce enemy health
                            enemy.Health -= 10;

                            bullets.RemoveAt(i);
                            hitEnemy = true;

                            if (enemy.Health <= 0)
                            {
                                enemies.RemoveAt(j);
                            }

                            break;
                        }
                    }

                    if (!hitEnemy && bullet.Position.Y < 0)
                    {
                        bullets.RemoveAt(i);
                    }
                }
                // Draw method
                public void Draw()
                {
                    Raylib.DrawRectangle((int)Position.X - 20, (int)Position.Y - 20, 40, 40, Color.RED);
                    Raylib.DrawTexture(texture, (int)Position.X - texture.width / 2, (int)Position.Y - texture.height / 2, Color.WHITE);
                }
                // Draw bullets
                foreach (Bullet bullet in bullets)
                {
                    bullet.Draw();
                }
            }

            
        }
    }

    // Enemy class
    public class Enemy
    {
        // Fields
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }
        public int Health { get; set; }
        private Texture2D texture;

        // Constructor
        public Enemy(Vector2 position, float speed, string texturePath)
        {
            Position = position;
            Speed = speed / 30;
            Health = 20;
            texture = Raylib.LoadTexture(texturePath);
        }

        // Update method
        public void Update()
        {
            Position.Y += Speed;
        }

        // Draw method
        public void Draw()
        {
            Raylib.DrawTexture(texture, (int)Position.X - texture.width / 2, (int)Position.Y - texture.height / 2, Color.WHITE);
        }
    }

    // Bullet class
    public class Bullet
    {
        // Fields
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }

        // Constructor
        public Bullet(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        // Update method
        public void Update()
        {
            Position += Velocity;
        }

        // Draw method
        public void Draw()
        {
            Raylib.DrawCircle((int)Position.X, (int)Position.Y, 5, Color.BLACK);
        }
    }
}