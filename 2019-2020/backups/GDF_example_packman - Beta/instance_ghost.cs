using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class instance_ghost : Instance
    {
        public instance_ghost(uint id) : base(id) { }

        //nodig voor vrijlaten van spookjes
        public bool firstHit = true;
        public int countDown = 0;
        
        //snelheid waar de spookjes mee groeien/krimpen
        public float ghostExpand = 0.01f;

        //x en z-coordinaten van kruispunten waar spookjes een richting moeten kiezen
        public List<float> xcrossings = new List<float> { 3, 7, 13, 19, 25, 31, 37, 43, 49, 53 };
        public List<List<float>> zcrossings = new List<List<float>> {
            new List<float> { 11 },
            new List<float> { 53 },
            new List<float> { 3, 11, 17, 29, 41, 47 },
            new List<float> { 11, 29, 35, 41, 47 },
            new List<float> { 11, 23, 47, 59 },
            new List<float> { 11, 23, 47, 59 },
            new List<float> { 11, 29, 35, 41, 47 },
            new List<float> { 3, 11, 17, 29, 41, 47 },
            new List<float> { 53 },
            new List<float> { 11 } };

        protected override void Start()
        {
            this.Collider.SetSphere(2.8f);
            this.Model.SetMdl("ghost.mdl");
            this.Model.Size = Vector3.One * 1.0f;
            this.Speed.Z = room_main.ghostSpeed;
            this.FacingDirection = new Vector3(0, 0, 0);
        }

        protected override void Step()
        {
            //stop met bewegen als er geen levens meer zijn
            if (Game.CurrentRoom.Lives == 0)
            {
                this.Speed = Vector3.Zero;
            }
            
            //aftellen voor het vrijlaten van de spookjes
            if (countDown > 0 && room_main.ready)
            {
                countDown--;
            }
            
            //spookjes groter/kleiner laten worden
            if (this.Model.Size.X > 1.2f * room_main.ghostSize || this.Model.Size.X < room_main.ghostSize)
            {
                ghostExpand *= -1f;
            }
            this.Model.Size.X += ghostExpand;
            this.Model.Size.Y += ghostExpand;
            this.Model.Size.Z += ghostExpand;
            
            //botsing met muur
            if (this.DetectCollisions(typeof(instance_box), false).Length > 0)
            {
                if (firstHit) { firstHit = false; }
                this.Position = this.Position_previous;
                choose_direction();
            }
            
            //botsing met beginmuur: eerst heen en weer, dan open, dan standaardmuur
            else if (this.DetectCollisions(typeof(instance_gate)).Length > 0)
            {
                if (firstHit)
                {
                    if (countDown > 0)
                    {
                        this.Speed.Z = -this.Speed.Z;
                        this.FacingDirection = -this.FacingDirection;
                    }
                }
                else
                {
                    this.Position = this.Position_previous;
                    choose_direction();
                }
            }
            
            //teleportatiepunt
            else if (this.DetectCollisions(typeof(instance_teleport)).Length > 0)
            {
                if (this.Position.X > 50)
                {
                    this.Position = new Vector3(3.41f, room_main.ghostHeight, 29.01f);
                    this.FacingDirection.Y = 90;
                }
                else
                {
                    this.Position = new Vector3(52.61f, room_main.ghostHeight, 29.01f);
                    this.FacingDirection.Y = 270;
                }
            }
            
            //check of er een kruising is en kies dan een richting
            else
            {
                int i = 0;
                foreach (float f in xcrossings)
                {
                    if (this.Position.X <= f + 0.5 * this.Speed.Length && this.Position.X >= f - 0.5 * this.Speed.Length)
                    {
                        foreach (float g in zcrossings[i])
                        {
                            if (this.Position.Z <= g + 0.5 * this.Speed.Length && this.Position.Z >= g - 0.5 * this.Speed.Length)
                            {
                                choose_direction();
                                break;
                            }
                        }
                        break;
                    }
                    i++;
                }
            }
        }

        //bereken de afstand tot een muur in een gegeven richting: 90 betekent rechts, 270 links
        private float distance_to_wall(float direction)
        {
            Dictionary<Instance, Vector3> boxes = this.DetectRaycastIntersections(new Vector3(0, this._2D_Direction + direction, 0), typeof(instance_box), 65);
            if (boxes == null) { return -1f; }
            KeyValuePair<Instance, Vector3> boxNearest = boxes.FirstOrDefault();
            float dist = this._2D_DistanceToPoint(boxNearest.Value.X, boxNearest.Value.Z);
            float distTemp = 0;
            foreach (KeyValuePair<Instance, Vector3> boxs in boxes)
            {
                distTemp = this._2D_DistanceToPoint(boxs.Value.X, boxs.Value.Z);
                if (distTemp < dist)
                {
                    boxNearest = boxs;
                    dist = distTemp;
                }
            }
            return dist;
        }

        //kies een richting gebaseerd op waar de muren en speler zich bevinden
        private void choose_direction()
        {
            float distRight = distance_to_wall(90);
            float distLeft = distance_to_wall(270);
            float distFront = distance_to_wall(0);

            //minimale afstand tot muur
            float minDist = 0.5f * (this.Collider.Size.X + this.Collider.Size.Z) + 1.5f;
            
            //check waar de muren zijn en kies een richting
            if (distRight < minDist)
            {
                if (distLeft < minDist)
                {
                    if (distFront < minDist)
                    {
                        //rechts muur, links muur, voor muur
                        this.FacingDirection.Y += 180;
                        this._2D_Direction += 180;
                    }
                }
                else
                {
                    if (distFront < minDist)
                    {
                        //rechts muur, links geen muur, voor muur
                        this.FacingDirection.Y += 270;
                        this._2D_Direction += 270;
                    }
                    else
                    {
                        //rechts muur, links geen muur, voor geen muur
                        //check of links of voor de speler te zien is
                        Instance player_nearest_front = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 0, 0), typeof(instance_player_bottom));
                        if (player_nearest_front == null)
                        {
                            Instance player_nearest_left = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 270, 0), typeof(instance_player_bottom));
                            if (player_nearest_left == null)
                            {
                                //geen speler te zien, kies willekeurig links of voor
                                int rnd = new Random().Next(0, 2);
                                if (rnd == 0)
                                {
                                    this.FacingDirection.Y += 0;
                                    this._2D_Direction += 0;
                                }
                                else
                                {
                                    this.FacingDirection.Y += 270;
                                    this._2D_Direction += 270;
                                }
                            }
                            else
                            {
                                //links is de speler te zien
                                this.FacingDirection.Y += 270;
                                this._2D_Direction += 270;
                            }
                        }
                        else
                        {
                            //voor is de speler te zien
                            this.FacingDirection.Y += 0;
                            this._2D_Direction += 0;
                        }
                    }
                }
            }
            else
            {
                if (distLeft < minDist)
                {
                    if (distFront < minDist)
                    {
                        this.FacingDirection.Y += 90;
                        this._2D_Direction += 90;
                    }
                    else
                    {
                        Instance player_nearest_front = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 0, 0), typeof(instance_player_bottom));
                        if (player_nearest_front == null)
                        {
                            Instance player_nearest_right = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 90, 0), typeof(instance_player_bottom));
                            if (player_nearest_right == null)
                            {
                                int rnd = new Random().Next(0, 2);
                                if (rnd == 0)
                                {
                                    this.FacingDirection.Y += 0;
                                    this._2D_Direction += 0;
                                }
                                else
                                {
                                    this.FacingDirection.Y += 90;
                                    this._2D_Direction += 90;
                                }
                            }
                            else
                            {
                                this.FacingDirection.Y += 90;
                                this._2D_Direction += 90;
                            }
                        }
                        else
                        {
                            this.FacingDirection.Y += 0;
                            this._2D_Direction += 0;
                        }
                    }
                }
                else
                {
                    if (distFront < minDist)
                    {
                        Instance player_nearest_right = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 90, 0), typeof(instance_player_bottom));
                        if (player_nearest_right == null)
                        {
                            Instance player_nearest_left = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 270, 0), typeof(instance_player_bottom));
                            if (player_nearest_left == null)
                            {
                                int rnd = new Random().Next(0, 2);
                                if (rnd == 0)
                                {
                                    this.FacingDirection.Y += 90;
                                    this._2D_Direction += 90;
                                }
                                else
                                {
                                    this.FacingDirection.Y += 270;
                                    this._2D_Direction += 270;
                                }
                            }
                            else
                            {
                                this.FacingDirection.Y += 270;
                                this._2D_Direction += 270;
                            }
                        }
                        else
                        {
                            this.FacingDirection.Y += 90;
                            this._2D_Direction += 90;
                        }
                    }
                    else
                    {
                        Instance player_nearest_front = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 0, 0), typeof(instance_player_bottom));
                        if (player_nearest_front == null)
                        {
                            Instance player_nearest_left = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 270, 0), typeof(instance_player_bottom));
                            if (player_nearest_left == null)
                            {
                                Instance player_nearest_right = this.DetectNearestRaycastIntersection(new Vector3(0, this._2D_Direction + 90, 0), typeof(instance_player_bottom));
                                if (player_nearest_right == null)
                                {
                                    int rnd = new Random().Next(0, 3);
                                    if (rnd == 0)
                                    {
                                        this.FacingDirection.Y += 270;
                                        this._2D_Direction += 270;
                                    }
                                    else if (rnd == 1)
                                    {
                                        this.FacingDirection.Y += 90;
                                        this._2D_Direction += 90;
                                    }
                                    else
                                    {
                                        this.FacingDirection.Y += 0;
                                        this._2D_Direction += 0;
                                    }
                                }
                                else
                                {
                                    this.FacingDirection.Y += 90;
                                    this._2D_Direction += 90;
                                }
                            }
                            else
                            {
                                this.FacingDirection.Y += 270;
                                this._2D_Direction += 270;
                            }
                        }
                        else
                        {
                            this.FacingDirection.Y += 0;
                            this._2D_Direction += 0;
                        }
                    }
                }
            }
        }
         
    }
}
