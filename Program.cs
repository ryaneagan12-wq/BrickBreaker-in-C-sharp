using System;
using System.Numerics;
using Raylib_cs;

namespace BB_Brick_Breaker
{
    class BrickBreaker
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(240, 260, "Blackberry Brick Breaker");
            Raylib.SetTargetFPS(60);
            Texture2D Background = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Background.png");
            Texture2D Conveyor = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Conveyor.png");
            Texture2D steel_ball = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Steel Ball.png");
            Texture2D Arrows = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Arrows.png");
            Texture2D line = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\line.png");
            Texture2D Iron_Brick = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Iron Brick.png");
            Texture2D Red_Brick = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Red Brick (100%).png");
            Texture2D Red_Brick_75 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Red Brick (75%).png");
            Texture2D Red_Brick_50 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Red Brick (50%).png");
            Texture2D Red_Brick_25 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Pinball Breaker!\\Asset files\\Red Brick (25%).png");

            int player_width = 14;
            int player_height = 14;
            int player_x = 60;
            int player_y = 100;
            int player_speed = 20;

            int player2_width = 106;
            int player2_height = 26;
            int player2_x = 60;
            int player2_y = 120;

            int arrow_width = 149;
            int arrow_height = 103;
            int arrow_x = 60;
            int arrow_y = 50;

            int enemy_width = 68;
            int enemy_height = 33;

            int enemy2_width = 67;
            int enemy2_height = 34;

            int enemy3_width = 63;
            int enemy3_height = 32;

            int enemy4_width = 66;
            int enemy4_height = 34;

            int ironenemy_width = 68;
            int ironenemy_height = 34;


            Color Black = new Color(0, 0, 0);


            int score = 0;
            bool game_over = false;
            bool fire = false;



            while (!Raylib.WindowShouldClose()) //needs physics here
            {
                Raylib.BeginDrawing();

                if (!game_over)
                {
                    Vector2 mousePos = Raylib.GetMousePosition();


                }
                Raylib.DrawTexture(Background, 0, 0, Color.White);

                Raylib.EndDrawing();
            }
        }
    }
}
