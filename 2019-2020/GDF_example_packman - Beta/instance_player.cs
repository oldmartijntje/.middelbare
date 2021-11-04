using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class instance_player : Instance
    {
        public instance_player(uint id) : base(id) { }
        
        protected override void Start()
        {
            this.Collider.SetSphere(1.8f);
            this.Model.SetSphere();
            this.Model.Size= new Vector3(0, 0, 0);
            this.FacingDirection = new Vector3(0, 0, 0);
        }

        protected override void Step()
        {            
            //niets doen als er geen levens meer zijn of als het spel nog niet is gestart
            if (Game.CurrentRoom.Lives > 0 && room_main.ready)
            {
                //Bij een teleportatiepunt naar de ander kant van de level
                if (this.DetectCollision(typeof(instance_teleport)))
                {
                    if (this.Position.X > 50)
                    {
                        this.Position = new Vector3(3.41f, room_main.playerYPos, 29.01f);
                        this.FacingDirection.Y = 90;                        
                    }
                    else
                    {
                        this.Position = new Vector3(52.61f, room_main.playerYPos, 29.01f);
                        this.FacingDirection.Y = 270;
                    }
                    
                    //De positie en orientatie van het boven- en onderstuk zijn gekoppeld
                    Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
                    foreach (instance_player_top player_top in playerTop)
                    {
                        player_top.Position.X = this.Position.X;
                        player_top.Position.Z = this.Position.Z;
                        player_top.FacingDirection.Y = this.FacingDirection.Y;
                    }
                    Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
                    foreach (instance_player_bottom player_bottom in playerBottom)
                    {
                        player_bottom.Position.X = this.Position.X;
                        player_bottom.Position.Z = this.Position.Z;
                        player_bottom.FacingDirection.Y = this.FacingDirection.Y;
                    }
                }
                else if (this.DetectCollision(typeof(instance_ghost)))
                {
                    Game.CurrentRoom.Lives--;
                    Sounds.Play("life_lost.wav");
                    
                    //Ga naar beginpositie
                    this.Position = new Vector3(3, 0.9f, 3);
                    this.FacingDirection = new Vector3(0, 0, 0);

                    Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
                    foreach (instance_player_top player_top in playerTop)
                    {
                        player_top.Position = this.Position;
                        player_top.FacingDirection = new Vector3(0, 0, 0);
                    }
                    Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
                    foreach (instance_player_bottom player_bottom in playerBottom)
                    {
                        player_bottom.Position = this.Position;
                        player_bottom.FacingDirection = new Vector3(180, 0, 0);
                    }                   
                    
                    //Spookjes naar beginpositie
                    Instance[] ghosts = Game.CurrentRoom.GetInstancesByType(typeof(instance_ghost));
                    if (ghosts != null)
                    {
                        if (ghosts.Length > 0)
                        {
                            instance_ghost ghost = (instance_ghost)ghosts[0];
                            ghost.Position = new Vector3(24.81f, room_main.ghostHeight, 30.51f);
                            ghost.Speed = new Vector3(0, 0, room_main.ghostSpeed);
                            ghost.FacingDirection = new Vector3(0, 0, 0);
                            ghost.firstHit = true;
                            ghost.countDown = 5 * Game.Settings.MaxFPS;
                        }
                        if (ghosts.Length > 1)
                        {
                            instance_ghost ghost = (instance_ghost)ghosts[1];
                            ghost.Position = new Vector3(26.71f, room_main.ghostHeight, 29.51f);
                            ghost.Speed = new Vector3(0, 0, room_main.ghostSpeed);
                            ghost.FacingDirection = new Vector3(0, 0, 0);
                            ghost.firstHit = true;
                            ghost.countDown = 10 * Game.Settings.MaxFPS;
                        }
                        if (ghosts.Length > 2)
                        {
                            instance_ghost ghost = (instance_ghost)ghosts[2];
                            ghost.Position = new Vector3(29.31f, room_main.ghostHeight, 28.51f);
                            ghost.Speed = new Vector3(0, 0, room_main.ghostSpeed);
                            ghost.FacingDirection = new Vector3(0, 0, 0);
                            ghost.firstHit = true;
                            ghost.countDown = 15 * Game.Settings.MaxFPS;
                        }
                        if (ghosts.Length > 3)
                        {
                            instance_ghost ghost = (instance_ghost)ghosts[3];
                            ghost.Position = new Vector3(31.71f, room_main.ghostHeight, 27.51f);
                            ghost.Speed = new Vector3(0, 0, room_main.ghostSpeed);
                            ghost.FacingDirection = new Vector3(0, 0, 0);
                            ghost.firstHit = true;
                            ghost.countDown = 20 * Game.Settings.MaxFPS;
                        }
                    }
                    Game.CurrentRoom.Camera.FlowToNewPosition(20);
                }
                if (GetKey(Key.A)|| (GetKey(Key.Left)))
                {
                    this.FacingDirection.Y -= 3f;
                    Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
                    foreach (instance_player_top player_top in playerTop) { player_top.FacingDirection.Y -= 3f; }
                    Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
                    foreach (instance_player_bottom player_bottom in playerBottom) { player_bottom.FacingDirection.Y -= 3f; }
                }
                if (GetKey(Key.D) || (GetKey(Key.Right)))
                {
                    this.FacingDirection.Y += 3f;
                    Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
                    foreach (instance_player_top player_top in playerTop) { player_top.FacingDirection.Y += 3f; }
                    Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
                    foreach (instance_player_bottom player_bottom in playerBottom) { player_bottom.FacingDirection.Y += 3f; }
                }
                if (GetKey(Key.W) || (GetKey(Key.Up)))
                {   
                    this._2D_PositionAddAvoidCollision(typeof(instance_box), this.FacingDirection.Y, room_main.playerStepSize, true, 5, true);
                    this.bijten();
                }
                if (GetKey(Key.S)||(GetKey(Key.Down)))
                {                    
                    this._2D_PositionAddAvoidCollision(typeof(instance_box), this.FacingDirection.Y, -1.0f * room_main.playerStepSize, true, 5, true);
                    this.bijten();
                }
                if (GetKey(Key.W) && (GetKey(Key.Up)))
                {
                    this._2D_PositionAddAvoidCollision(typeof(instance_box), this.FacingDirection.Y, room_main.playerStepSize, true, 5, true);
                    this.bijten2();
                }
            }
        }

        private void bijten()
        {
            Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
            foreach (instance_player_top player_top in playerTop)
            {
                player_top.Position.X = this.Position.X;
                player_top.Position.Z = this.Position.Z;
                player_top.FacingDirection.Y = 0;
                player_top.FacingDirection.X += room_main.playerBiteStep;
                player_top.Position.Y -= 0.8f * (float)Math.Sin(room_main.playerBiteStep * Math.PI / 180);
                player_top.Position.Z += 0.8f - 0.8f * (float)Math.Cos(room_main.playerBiteStep * Math.PI / 180);
                player_top.FacingDirection.Y = this.FacingDirection.Y​;
            }

            Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
            foreach (instance_player_bottom player_bottom in playerBottom)
            {
                player_bottom.Position.X = this.Position.X;
                player_bottom.Position.Z = this.Position.Z;
                if (player_bottom.FacingDirection.X > 225 || player_bottom.FacingDirection.X < 180)
                {
                    room_main.playerBiteStep *= -1f;
                }
                player_bottom.FacingDirection.Y = 0;
                player_bottom.FacingDirection.X -= room_main.playerBiteStep;
                player_bottom.Position.Y += 0.8f * (float)Math.Sin(room_main.playerBiteStep * Math.PI / 180);
                player_bottom.Position.Z += 0.8f - 0.8f * (float)Math.Cos(room_main.playerBiteStep * Math.PI / 180);
                player_bottom.FacingDirection.Y = this.FacingDirection.Y​;
            }

        }
        private void bijten2()
        {
            Instance[] playerTop = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_top));
            foreach (instance_player_top player_top in playerTop)
            {
                player_top.Position.X = this.Position.X;
                player_top.Position.Z = this.Position.Z;
                player_top.FacingDirection.Y = 0;
                player_top.FacingDirection.X += room_main.playerBiteStep;
                player_top.Position.Y -= 0.8f * (float)Math.Sin(room_main.playerBiteStep * Math.PI / 180);
                player_top.Position.Z += 0.8f - 0.8f * (float)Math.Cos(room_main.playerBiteStep * Math.PI / 180);
                player_top.FacingDirection.Y = this.FacingDirection.Y​;
            }

            Instance[] playerBottom = Game.CurrentRoom.GetInstancesByType(typeof(instance_player_bottom));
            foreach (instance_player_bottom player_bottom in playerBottom)
            {
                player_bottom.Position.X = this.Position.X;
                player_bottom.Position.Z = this.Position.Z;
                if (player_bottom.FacingDirection.X > 225 || player_bottom.FacingDirection.X < 180)
                {
                    room_main.playerBiteStep *= -2f;
                }
                player_bottom.FacingDirection.Y = 0;
                player_bottom.FacingDirection.X -= room_main.playerBiteStep;
                player_bottom.Position.Y += 0.8f * (float)Math.Sin(room_main.playerBiteStep * Math.PI / 180);
                player_bottom.Position.Z += 0.8f - 0.8f * (float)Math.Cos(room_main.playerBiteStep * Math.PI / 180);
                player_bottom.FacingDirection.Y = this.FacingDirection.Y​;
            }
        }
    }
}

