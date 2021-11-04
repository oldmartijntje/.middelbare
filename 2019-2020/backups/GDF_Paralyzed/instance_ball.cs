using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDF;

namespace GDF_example_fps
{
    public class instance_ball : Instance
    {
        private float defaultSize = 5f;

        public instance_ball(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Collider.SetSphere(this.defaultSize);

            this.Model.SetSphere();
            this.Model.Size = Vector3.One * this.defaultSize;
            this.Model.SetTexture("clown.jpg");

            this.Gravity = 0.02f;
            this.Friction = 0.001f;
            
            //kijk in de richting van de player
            Instance player = Game.CurrentRoom.GetInstance(typeof(instance_player));
            this.FacingDirection.Y = Methods._2D_DirectionBetweenPoints(this.Position, player.Position) - 93;
        }

        protected override void Step()
        {
            //wat als instance_floor wordt geraakt
            if(this.DetectCollision(Game.CurrentRoom.GetInstance(typeof(instance_floor))))
            {
                //niet doen als dit voorwerp zich buiten het speelveld bevindt
                if(!this._2D_OutsideRoom)
                {
                    //flip de verticale snelheid
                    this.Speed.Y = -this.Speed.Y;

                    //spring terug naar de vorige positie (om vasthangen te voorkomen)
                    this.Position = this.Position_previous;

                    //verminder de snelheid met 20%
                    this.Speed *= 0.8f;
                }
            }

            //zorg ervoor dat deze bal langzaam in de richting van de speler verschuift
            Instance player = Game.CurrentRoom.GetInstance(typeof(instance_player));
            float directionToPlayer = Methods._2D_DirectionBetweenPoints(this.Position, player.Position);
            this._2D_PositionAdd(directionToPlayer, 0.02f);
        }
        public void krimppercentage(float krimppercentage)
        {
            if (this.Model.Size.X > 2.5f)
            {
                Instance player = Game.CurrentRoom.GetInstance(typeof(instance_player));
                float directionToPlayer = Methods._2D_DirectionBetweenPoints(this.Position, player.Position);
                this._2D_PositionAdd(directionToPlayer, -1f);
                this.Speed.Y = 0.5f;
                this.Model.Size.X -= krimppercentage;
                this.Model.Size.Y -= krimppercentage;
                this.Model.Size.Z -= krimppercentage;
                this.Collider.SetSphere(this.Model.Size.X);



            }
            if (this.Model.Size.X < 2.5f)
            {
                this.Destroy();
            }
            
            

            


        }
       
    }
}
