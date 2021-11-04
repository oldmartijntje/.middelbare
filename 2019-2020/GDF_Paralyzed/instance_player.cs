using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDF;
using Urho;

namespace GDF_example_fps
{
    public class instance_player : Instance
    {
        public instance_player(uint id) : base(id)
        {
        }

        private int shootcounter = 0;

        protected override void Start()
        {
            this.Collider.SetBox(Vector3.One * 5f);

            this.Model.Delete();

            this.Y = 3f;
        }

        protected override void Step()
        {
            //als een bal je raakt (en je dus af bent)
            if(this.DetectCollision(typeof(instance_ball)))
            {
                //zorg ervoor dat de ballen niet meer in jouw richting bewegen
                foreach(Instance ball in Game.CurrentRoom.GetInstancesByType(typeof(instance_ball)))
                {
                    ball.DontUpdate();
                }

                //stel in dat je niet meer kunt schieten
                this.shootcounter = int.MinValue;

                //toon de gameover tekst in beeld (aangemaakt in room.start)
                Game.CurrentRoom.GetText2d("gameover").Visible = true;

                if(GetKeyPress(Key.Return))
                {
                    Game.CurrentRoom.Restart();
                }

                if(!Sounds.SoundLoopExists("laugh"))
                {
                    Sounds.AddSoundLoop("laugh", "evillaugh.wav");
                }
            }

            //pas de kijkrichting aan op de beweging van de muis
            this.FacingDirection.Y += Game.Input.MouseXchange * 5f;
            this.FacingDirection.X += Game.Input.MouseYchange * 5f;

            //zorg ervoor dat de speler niet te ver omhoog of naar beneden kijkt
            if (this.FacingDirection.X > 80 && this.FacingDirection.X < 180)
                this.FacingDirection.X = 80;
            if (this.FacingDirection.X < 270 && this.FacingDirection.X > 180)
                this.FacingDirection.X = 270;

            this.shootcounter++;

            //haal het plaatje van het wapen op, en stel de grootte ervan op 16 in
            Image2d weapon = Game.CurrentRoom.GetImage2d("weapon");
            weapon.Size = new Vector2(24, 16);

            if (this.shootcounter > 10 && Game.Input.MouseButtonLeft)
            {
                //maak het plaatje van het wapen iets grooter om zo een terugslageffect te maken
                weapon.Size = new Vector2(25, 17);

                this.shootcounter = 0;
                Sounds.Play("laser.ogg");

                //maak een variabele aan die de plek bewaart waar de kogel inslaat
                Vector3 intersection = Vector3.Zero;

                //schiet een lijn in de kijkrichting en geef een voorwerp terug waar die lijn doorheen gaat
                Instance rayInstance = this.DetectNearestRaycastIntersection(this.FacingDirection, typeof(Instance), out intersection, 500);

                //als er een voorwerp is raakgeschoten
                if (rayInstance != null)
                {
                    //als het voorwerp een instance_ball is, geef het dan een snelheid in de schietrichting
                    if(rayInstance.GetType() == typeof(instance_ball))
                    {
                        //hier komt jouw code...
                        //
                        instance_ball bal = (instance_ball)rayInstance;

                        bal.krimppercentage(1f);


                        


                    }

                    //speel een impactgeluid, en maak een instance_impact op de plek waar de lijn is ingeslagen
                    Sounds.Play("Slam.wav", intersection, this.Position, 150);
                    Game.CurrentRoom.InstanceCreate(intersection, typeof(instance_impact));

                    //als de vloer geraakt wordt, maak dan een instance_impactfloor op de plek waar de lijn is ingeslagen
                    if(rayInstance.GetType() == typeof(instance_floor))
                    {
                        Game.CurrentRoom.InstanceCreate(intersection, typeof(instance_impactfloor));
                    }
                }
            }
        }
    }
}
