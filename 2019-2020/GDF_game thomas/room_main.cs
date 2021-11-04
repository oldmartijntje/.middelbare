using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GDF_start
{
    public class room_main : Room
    {
        private bool CamPos = false;
        private bool F5Pressed = false;
        public room_main(string name) : base(name) { }
        protected override void Start()
        {
            this.Lives = 3;
            //Removes Grid
            this.RemoveGrid();

            //maak de het spelervoorwerp en stel de camera in dat hij deze volgt
            Instance player = this.InstanceCreate(100, new Vector3(5, 2.5f, 5), typeof(instance_player));
            this.Camera.SetCameraMode_FirstPerson(player, 0.5f);

            //verander perspectief(still in dev)
        /*  if (Game.Input.GetKey(Urho.Key.F5))
            {
                if (this.CamPos == false)
                {
                    if (this.F5Pressed == false)
                    {
                        Console.WriteLine("R yes");
                        this.Camera.SetCameraMode_ThirdPerson(player, -1.5f, 3, 45);
                        this.CamPos = true;
                        this.F5Pressed = true;
                    }
                }
                else
                {
                    this.F5Pressed = false;
                }
                if (this.CamPos == true)
                {
                    if(F5Pressed == false)
                    {
                        Console.WriteLine("R yes");
                        this.Camera.SetCameraMode_FirstPerson(player, -0.5f);
                        this.CamPos = false;
                        this.F5Pressed = true;
                    }
                }
                else
                {
                    this.F5Pressed = false;
                }
            }
        */    
            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    //Floor
                    this.InstanceCreate(i, 10.5f, x, typeof(instance_block));
                    this.InstanceCreate( i , -0.5f,  x, typeof(instance_block));
                    this.InstanceCreate(i, -0.5f, x - 10, typeof(instance_block));
                    this.InstanceCreate(2.8f + x, 0.5f + i, 0, typeof(instance_block));
                    this.InstanceCreate(1 + x, 2.5f + i, 0, typeof(instance_block));
                    this.InstanceCreate(0, 0.5f + i, x, typeof(instance_block));
                    this.InstanceCreate(10, 0.5f + i, x, typeof(instance_block));
                    this.InstanceCreate(7, 0.5f, 10, typeof(instance_block));
                    this.InstanceCreate(7, 0.5f, 9.499f, typeof(instance_Guide1));
                    this.InstanceCreate(8, 0.5f, 10, typeof(instance_block));
                    this.InstanceCreate(8, 0.5f, 9.499f, typeof(instance_Guide2));
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    this.InstanceCreate(z + 5, -0.5f, i + 10, typeof(instance_block));
                }
            }
            //platforms
            this.InstanceCreate(5, 1.5f, 4.999f, typeof(instance_Guide3));
            this.InstanceCreate(5, 1.5f, 5, typeof(instance_block));

            this.InstanceCreate(6, -0.5f, 24.5f, typeof(instance_block));
            this.InstanceCreate(5, -0.5f, 24.5f, typeof(instance_block));
            this.InstanceCreate(6, -0.5f, 23.5f, typeof(instance_block));
            this.InstanceCreate(5, -0.5f, 23.5f, typeof(instance_block));
            this.InstanceCreate(7, -0.5f, 24.5f, typeof(instance_block));
            this.InstanceCreate(7, -0.5f, 23.5f, typeof(instance_block));

            this.InstanceCreate(6, -0.5f, 23.5f, typeof(instance_block));
            this.InstanceCreate(5, -0.5f, 23.5f, typeof(instance_block));


            //le secret aww man
            this.InstanceCreate(5, 2.6f, -4.549f, typeof(creepherhead));
            this.InstanceCreate(5, 2.6f, -5, typeof(creepercheek));
            this.InstanceCreate(5, 1.40f, -5, typeof(creeperbody));
            this.InstanceCreate(4.65f, 0.25f, -5, typeof(creeperfoot));
            this.InstanceCreate(5.35f, 0.25f, -5, typeof(creeperfoot));
            //UI
            this.Text2dCreate("BeginText", "Hallo, leuk dat je mijn spel speelt!", 16, 6, 0.5f);
            this.GetText2d("BeginText").Visible = true;
            this.GetText2d("BeginText").SetFont("montserrat-Regular.ttf");
            this.GetText2d("BeginText").SetHorizontalAlignmentCenter();
            this.GetText2d("BeginText").SetColor(Color.Black);

            this.Text2dCreate("BeginText2", "Druk op de spatiebalk om te spelen!", 16, 10, 0.5f);
            this.GetText2d("BeginText2").Visible = true;
            this.GetText2d("BeginText2").SetFont("montserrat-Regular.ttf");
            this.GetText2d("BeginText2").SetHorizontalAlignmentCenter();
            this.GetText2d("BeginText2").SetColor(Color.Black);

            this.Text2dCreate("Crossair", "x", 16, 8.5f, 0.25f);
            this.GetText2d("Crossair").Visible = false;
            this.GetText2d("Crossair").SetColor(Color.Black);
            this.GetText2d("Crossair").SetHorizontalAlignmentCenter();
            this.GetText2d("Crossair").SetFont("Montserrat-Bold.ttf");

            this.Image2dCreate("money", "money.png", 1, 2, 1, 1).Visible = false;
            this.Image2dCreate("live1", "heart.png", 1, 1, 1, 1).Visible = false;
            this.Image2dCreate("live2", "heart.png", 2.5f, 1, 1, 1).Visible = false;
            this.Image2dCreate("live3", "heart.png", 4.0f, 1, 1, 1).Visible = false;

            this.Text2dCreate("gameover1", "GAME OVER", 16, 5.9f, 3);
            this.GetText2d("gameover1").SetFont("Arcade.ttf");
            this.GetText2d("gameover1").SetColor(Color.Red);
            this.GetText2d("gameover1").SetHorizontalAlignmentCenter();
            this.GetText2d("gameover1").Visible = false;

            this.Text2dCreate("ResetGuide", "Druk op R om te Resetten", 19, 0, 3);
            this.GetText2d("ResetGuide").SetFont("Arcade.ttf", 25);
            this.GetText2d("ResetGuide").SetColor(Color.Black);
            this.GetText2d("ResetGuide").Visible = false;

            this.Text2dCreate("gameover2", "druk op enter om opnieuw te beginnen", 16, 12f, 1);
            this.GetText2d("gameover2").SetFont("Arcade.ttf");
            this.GetText2d("gameover2").SetColor(Color.Yellow);
            this.GetText2d("gameover2").SetHorizontalAlignmentCenter();
            this.GetText2d("gameover2").Visible = false;
        }      
        protected override void Step()
        {
            //Speler klikt op een toets om te beginnen
            if (Game.Input.GetKey(Urho.Key.Space))
            {
                this.GetText2d("ResetGuide").Visible = true;
                this.GetText2d("BeginText").Visible = false;
                this.GetText2d("BeginText2").Visible = false;
                this.GetText2d("Crossair").Visible = true;
                this.GetImage2d("live1").Visible = true;
                this.GetImage2d("live2").Visible = true;
                this.GetImage2d("live3").Visible = true;

            }
            //Lives = number of hearts
            this.GetImage2d("live1").Visible = this.Lives >= 1;
            this.GetImage2d("live2").Visible = this.Lives >= 2;
            this.GetImage2d("live3").Visible = this.Lives >= 3;

            if (this.Lives <= 0)
            {
                this.GetText2d("gameover1").Visible = true;
                this.GetText2d("gameover2").Visible = true;

                if (Game.Input.GetKey(Key.Return))
                {
                    Game.RoomRestart(this.Name);
                }
            }
            if (Game.Input.GetKey(Key.R) && (Game.Input.GetKey(Key.LeftShift)))
            {
                Game.RoomRestart(this.Name);
            }
            if (Game.Input.GetKey(Urho.Key.Esc) && Game.Input.GetKey(Urho.Key.LeftShift))
            {
                Game.Exit();
            }
        }
        /* platform functie
        static void platform(int width, int height, int lenght, int posX, int posY, int posZ, string instance)
        {
            for (int a = 0; a < width; a++)
            {
                for (int b = 0; b < height; b++)
                {
                    for (int c = 0; c < lenght; c++)
                    {
                        this.InstanceCreate( posX ,posY ,posZ , typeof());
                    }
                }
            }
        }
        */
            
    }
}
