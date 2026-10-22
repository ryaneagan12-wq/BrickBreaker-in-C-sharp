using Raylib_cs;
using System.Numerics;

namespace BB_Brick_Breaker
{
    class BrickBreaker
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1420, 1065, "Blackberry Brick Breaker");
            Raylib.SetTargetFPS(60);
            Texture2D Background = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Background2.png");
            Texture2D Conveyor = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Conveyor.png");
            Texture2D steel_ball = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Steel Ball.png");
            Texture2D Arrows = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Arrows.png");
            Texture2D line = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\line.png");
            Texture2D Iron_Brick = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Iron Brick.png");
            Texture2D Red_Brick = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Red Brick (100%).png");
            Texture2D Red_Brick_75 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Red Brick (75%).png");
            Texture2D Red_Brick_50 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Red Brick (50%).png");
            Texture2D Red_Brick_25 = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Brick Breaker!\\Asset files\\Red Brick (25%).png");

            int player_width = 14;
            int player_height = 14;
            float player_x = 540.0f;
            float player_y = 915.0f;
            int player_speed = 20;

            int player2_width = 106;
            int player2_height = 26;
            int player2_x = 495;
            int player2_y = 930;
            int player2_speed = 20;

            int line_width = 5;
            int line_height = 48;
            int line_x = 550;
            int line_y = 920;

            int arrow_width = 149;
            int arrow_height = 103;
            int arrow_x = 475;
            int arrow_y = 960;
            int arrow_speed = 20;

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


            float wall_width = 896.0f;
            float wall_height = 950.0f;
            float wall_x = 70.0f;
            float wall_y = 130.0f;
            Rectangle wall = new Rectangle(wall_x, wall_y, wall_width, wall_height);


            Color Black = new Color(0, 0, 0);

            int score = 0;
            int HIScore = 0;
            int Lives = 3;
            float ball_dx = 3.0f;
            float ball_dy = 3.0f;
            bool game_over = false;
            bool fire = false;
            bool showtext = true;
            bool showline = true;
            float angle = 90;

            int Brick_count = 50;
            int[] Brick_x = new int[Brick_count];
            int[] Brick_Health = new int[Brick_count]; 
            int[] Brick_y = new int[Brick_count];
            int[] Brick_type = new int[Brick_count];

            for (int i = 0; i < Brick_count; i++)
            {
                int column = Raylib.GetRandomValue(0, 12);
                Brick_x[i] = Convert.ToInt32(wall_x) + column * 68;
                int row = Raylib.GetRandomValue(0, 19);
                Brick_y[i] = Convert.ToInt32(wall_y) + row * 33;
                Brick_type[i] = Raylib.GetRandomValue(0, 1);
                Brick_Health[i] = 100;
            }

            while (!Raylib.WindowShouldClose()) 
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Gray);

                if (!game_over)
                {
                    if (fire)
                    {
                        player_x -= ball_dx;
                        player_y -= ball_dy;

                        if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                        {

                            if (arrow_x - arrow_speed >= wall_x)
                            {
                                player2_x -= player2_speed;
                                arrow_x -= arrow_speed;
                            }
                            else
                            {
                                player2_x -= Convert.ToInt32(arrow_x - wall_x);
                                arrow_x -= Convert.ToInt32(arrow_x - wall_x);
                            }

                        }
                        if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                        {
                            if (arrow_x + arrow_width + arrow_speed <= 966)
                            {
                                player2_x += player2_speed;
                                arrow_x += arrow_speed;
                            }
                            else
                            {
                                player2_x += Convert.ToInt32(966 - arrow_x - arrow_width);
                                arrow_x += Convert.ToInt32(966 - arrow_x - arrow_width);
                            }
                        }
                        if (player_x - ball_dx <= wall_x)
                          {
                            ball_dx *= -1;
                            player_x = wall_x;
                          }
                        else if (player_y - ball_dy <= wall_y)
                          {
                            ball_dy *= -1;
                            player_y = wall_y;
                          }
                        else if (player_x + player_width >= wall_x + wall_width)
                          {
                            ball_dx *= -1;
                            player_x = (wall_x + wall_width) - player_width;
                          }
                        else if (player_y + player_height >= wall_y + wall_height)
                          {
                            Lives = Lives - 1;
                            ball_dx = 3.0f;
                            ball_dy = 3.0f;
                            player_x = 540.0f;
                            player_y = 915.0f;
                            player2_x = 495;
                            player2_y = 930;
                            arrow_x = 475;
                            arrow_y = 960;
                            fire = false;
                            showtext = true;
                            showline = true;
                          }

                        if ((player_x + player_width >= player2_x) && (player_x <= player2_x + enemy_width) && (player_y + player_height >= player2_y) && (player_y <= player2_y + player2_height))
                        {
                            ball_dy *= -1;
                            player_y = player2_y - player_height;
                        }
                    }
                    else
                    {
                        if (showline)
                        {
                            Vector2 mousePos = Raylib.GetMousePosition();
                            angle = 180 - (mousePos.X - wall_x) * (180 / wall_width);
                            ball_dx = (float) Math.Cos(angle * Math.PI / 180) * 3;
                            ball_dx *= -1;
                            ball_dy = (float) Math.Sin(angle * Math.PI / 180) * 3;
                            if (angle > 180)
                            {
                                angle = 180;
                            }
                            else if (angle < 0)
                            {
                                angle = 0;
                            }
                        }
                        if (Raylib.IsKeyPressed(KeyboardKey.F))
                        {
                            fire = true; 
                        }
                    }
                }
                Raylib.DrawTexture(Background, 0, 0, Color.White);
                Raylib.DrawTexture(Arrows, arrow_x, arrow_y, Color.White);
                Raylib.DrawTexture(Conveyor, player2_x, player2_y, Color.White);
                Raylib.DrawTexture(steel_ball, Convert.ToInt32(player_x), Convert.ToInt32(player_y), Color.White);

                for (int i = 0; i < Brick_count; i++)
                {
                    if (Brick_type[i] == 0 && Brick_Health[i] == 100)
                    {
                        Raylib.DrawTexture(Red_Brick, Brick_x[i], Brick_y[i], Color.White);
                    }
                    else if (Brick_type[i] == 0 && Brick_Health[i] == 75)
                    {
                        Raylib.DrawTexture(Red_Brick_75, Brick_x[i], Brick_y[i], Color.White);
                    }
                    else if (Brick_type[i] == 0 && Brick_Health[i] == 50)
                    {
                        Raylib.DrawTexture(Red_Brick_50, Brick_x[i], Brick_y[i], Color.White);
                    }
                    else if (Brick_type[i] == 0 && Brick_Health[i] == 25)
                    {
                        Raylib.DrawTexture(Red_Brick_25, Brick_x[i], Brick_y[i], Color.White);
                    }
                    else if (Brick_type[i] == 1)
                    {
                        Raylib.DrawTexture(Iron_Brick, Brick_x[i], Brick_y[i], Color.White);
                    }
                    if((Brick_type[i] == 0 || Brick_type[i] == 1) && player_x + player_width >= Brick_x[i] && player_y + player_height >= Brick_y[i] && player_x <= Brick_x[i] + enemy_width && player_y <= Brick_y[i] + enemy_height)
                    {
                        float overlap_x = Math.Min(player_x + player_width - Brick_x[i], Brick_x[i] + enemy_width - player_x);
                        float overlap_y = Math.Min(player_y + player_height - Brick_y[i], Brick_y[i] + enemy_height - player_y);
                        if (overlap_x < overlap_y)
                        {
                            ball_dx *= -1;
                        }
                        else
                        {
                            ball_dy *= -1;
                        }
                        Brick_Health[i] = Brick_Health[i] - 25;
                    }
                }

                if (Raylib.IsKeyPressed(KeyboardKey.F))
                {
                    showtext = false;
                    showline = false;
                }
                if (showtext)
                {
                    Raylib.DrawText($"Press 'F' to start the Game", 260, 600, 30, Color.Black);
                    Raylib.DrawText($"Move your cursor left to right to aim at the object at",100, 700, 30,Color.Black);
                }

                if (showline)
                {
                    Raylib.DrawTextureEx(line, new Vector2(line_x, line_y), 270 - angle, 1.0f, Color.White);
                }
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) 
                { 
                    Console.WriteLine(Raylib.GetMouseX() + ", " + Raylib.GetMouseY()); 
                }


                if (!game_over)
                {
                    Raylib.DrawText($"{score:F0}", 1230, 250, 100, Color.White);
                    Raylib.DrawText($"{Lives:F0}", 1230, 710, 100, Color.White);
                    Raylib.DrawText($"{HIScore:F0}", 1230, 940, 100, Color.White);
                }
                Raylib.EndDrawing();
            }
        }
    }
}