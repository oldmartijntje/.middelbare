using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class room_main : Room
    {
        public room_main(string name) : base(name) { }

        //Diverse instellingen, eenvoudig beschikbaar in alle instances
        public static float ghostHeight = 0.7f;
        public static float ghostSize = 1f;
        public static float ghostSpeed = 0f;
        public static float playerStepSize = 0.2f;
        public static float playerBiteStep = 3f;
        public static float playerYPos = 0.9f;
        public static bool ready = false;

        protected override void Start()
        {
            //grootte van speelveld instellen
            this.Size = Vector3.One * 130;

            //muren en muntjes aanmaken
            build_level();

            //speler aanmaken: player registreert botsingen en leidt de camera. bottom en top zijn de happende delen
            instance_player player = (instance_player)this.InstanceCreate(new Vector3(3, playerYPos, 3), typeof(instance_player));
            instance_player_top playertop = (instance_player_top)this.InstanceCreate(new Vector3(3, playerYPos, 3), typeof(instance_player_top));
            instance_player_bottom playerbot = (instance_player_bottom)this.InstanceCreate(new Vector3(3, playerYPos, 3), typeof(instance_player_bottom));
            this.Camera.SetCameraMode_ThirdPerson(player, 5f, 15f, 25f, false, false);

            //teleportatieplekken 
            this.InstanceCreate(new Vector3(54.25f, 1.5f, 29f), typeof(instance_teleport));
            this.InstanceCreate(new Vector3(1.75f, 1.5f, 29f), typeof(instance_teleport));

            //spookjes aanmaken en hun ontsnappinsmoment instellen
            instance_ghost ghost1 = (instance_ghost)this.InstanceCreate(new Vector3(24.31f, ghostHeight, 30.51f), typeof(instance_ghost));
            ghost1.Model.SetColor(Color.Cyan);
            ghost1.countDown = 5 * Game.Settings.MaxFPS;
            instance_ghost ghost2 = (instance_ghost)this.InstanceCreate(new Vector3(26.71f, ghostHeight, 29.51f), typeof(instance_ghost));
            ghost2.Model.SetColor(Color.Red);
            ghost2.countDown = 10 * Game.Settings.MaxFPS;
            instance_ghost ghost3 = (instance_ghost)this.InstanceCreate(new Vector3(29.31f, ghostHeight, 28.51f), typeof(instance_ghost));
            ghost3.Model.SetColor(Color.Magenta);
            ghost3.countDown = 15 * Game.Settings.MaxFPS;
            instance_ghost ghost4 = (instance_ghost)this.InstanceCreate(new Vector3(31.71f, ghostHeight, 27.51f), typeof(instance_ghost));
            ghost4.Model.SetColor(Color.Green);
            ghost4.countDown = 20 * Game.Settings.MaxFPS;

            //aantal levens weergeven
            this.Lives = 3;
            this.Image2dCreate("live1", "pacman.png", 1f, 1f, 1f, 1f);
            this.Image2dCreate("live2", "pacman.png", 2.5f, 1f, 1f, 1f);
            this.Image2dCreate("live3", "pacman.png", 4.0f, 1f, 1f, 1f);

            //aantal overgebleven muntjes weergeven
            this.Image2dCreate("ball", "yellowball.png", 1f, 2.65f, 0.7f, 0.7f);
            int nCoins = this.GetInstancesByType(typeof(instance_coin)).Length;
            this.Text2dCreate("coinsleft", nCoins.ToString(), 2.2f, 2.2f, 0.9f);
            this.GetText2d("coinsleft").SetFont("data-latin.ttf");
            this.GetText2d("coinsleft").SetColor(Color.White);

            //scherm bij verliezen
            this.Text2dCreate("gameover1", "GAME OVER", 16f, 5.9f, 3f);
            this.GetText2d("gameover1").SetHorizontalAlignmentCenter();
            this.GetText2d("gameover1").SetFont("Arcade.ttf");
            this.GetText2d("gameover1").SetColor(Color.Red);
            this.GetText2d("gameover1").Visible = false;
            this.Text2dCreate("gameover2", "Druk op enter", 16f, 10.7f, 1f);
            this.GetText2d("gameover2").SetHorizontalAlignmentCenter();
            this.GetText2d("gameover2").SetFont("Arcade.ttf");
            this.GetText2d("gameover2").SetColor(Color.Yellow);
            this.GetText2d("gameover2").Visible = false;

            //scherm bij winnen
            this.Text2dCreate("win1", "WINNER", 11.2f, 5.9f, 3f);
            this.GetText2d("win1").SetFont("Arcade.ttf");
            this.GetText2d("win1").SetColor(Color.Green);
            this.GetText2d("win1").Visible = false;
            this.Text2dCreate("win2", "Druk op enter", 12f, 10.7f, 1f);
            this.GetText2d("win2").SetFont("Arcade.ttf");
            this.GetText2d("win2").SetColor(Color.Yellow);
            this.GetText2d("win2").Visible = false;

            //startscherm
            this.Text2dCreate("start1", "Pacman", 16f, 5.9f, 3f);
            this.GetText2d("start1").SetHorizontalAlignmentCenter();
            this.GetText2d("start1").SetFont("Arcade.ttf");
            this.GetText2d("start1").SetColor(Color.Yellow);
            this.GetText2d("start1").Visible = true;
            this.Text2dCreate("start2", "Druk op Spatie om te starten", 16f, 10.7f, 1f);
            this.GetText2d("start2").SetHorizontalAlignmentCenter();
            this.GetText2d("start2").SetFont("Arcade.ttf");
            this.GetText2d("start2").SetColor(Color.Yellow);
            this.GetText2d("start2").Visible = true;
        }

        protected override void Step()
        {
            if (Game.Input.GetKey(Urho.Key.Esc) && (Game.Input.GetKey(Urho.Key.LeftShift)))
            {
                Game.Exit();
            }

            //spel pas beginnen als s wordt ingedrukt
            if (Game.Input.GetKey(Urho.Key.Space) && room_main.ready == false)
            {
                room_main.ready = true;
                this.GetText2d("start1").Visible = false;
                this.GetText2d("start2").Visible = false;
                ghostSpeed = 0.2f;
                Instance[] ghosts = Game.CurrentRoom.GetInstancesByType(typeof(instance_ghost));
                foreach (instance_ghost ghost in ghosts)
                {
                    ghost.Speed = new Vector3(0, 0, ghostSpeed);
                }
            }

            //huidig aantal muntjes weergeven
            int nCoins = this.GetInstancesByType(typeof(instance_coin)).Length;
            this.GetText2d("coinsleft").SetText(nCoins.ToString());

            //speler heeft gewonnen
            if (nCoins <= 0)
            {
                this.GetText2d("win1").Visible = true;
                this.GetText2d("win2").Visible = true;
                Instance[] ghosts = Game.CurrentRoom.GetInstancesByType(typeof(instance_ghost));
                foreach (instance_ghost ghost in ghosts)
                {
                    ghost.Destroy();
                }
                if (Game.Input.GetKey(Key.Return))
                {
                    Game.RoomRestart(this.Name);
                    room_main.ready = false;
                }
            }

            //huidig aantal levens weergeven
            this.GetImage2d("live1").Visible = this.Lives >= 1;
            this.GetImage2d("live2").Visible = this.Lives >= 2;
            this.GetImage2d("live3").Visible = this.Lives >= 3;

            //speler heeft verloren
            if (this.Lives <= 0)
            {
                this.GetText2d("gameover1").Visible = true;
                this.GetText2d("gameover2").Visible = true;
                if (Game.Input.GetKey(Key.Return))
                {
                    Game.RoomRestart(this.Name);
                }
                room_main.ready = false;
            }
        }

        //maak een box met de gegeven coordinaten
        public void make_bigbox(float xleft, float xright, float ztop, float zbottom)
        {
            Instance bigbox = this.InstanceCreate(0.5f * (xright + xleft), 0.5f, 0.5f * (ztop + zbottom), typeof(instance_box));
            bigbox.Model.Size = new Vector3(xright - xleft + 1, 1f, zbottom - ztop + 1);
            bigbox.Collider.SetBox(new Vector3(xright - xleft + 1, 1f, zbottom - ztop + 1));
        }

        //plaats de muren en muntjes op de juiste positie
        public void build_level()
        {
            //buitenrand bovendeel
            make_bigbox(1, 55, 1, 1);
            make_bigbox(1, 1, 1, 19);
            make_bigbox(55, 55, 1, 19);
            make_bigbox(1, 11, 19, 19);
            make_bigbox(45, 55, 19, 19);
            make_bigbox(11, 11, 19, 27);
            make_bigbox(45, 45, 19, 27);
            make_bigbox(1, 11, 27, 27);
            make_bigbox(45, 55, 27, 27);

            //buitenrand onderdeel
            make_bigbox(1, 11, 31, 31);
            make_bigbox(45, 55, 31, 31);
            make_bigbox(11, 11, 31, 39);
            make_bigbox(45, 45, 31, 39);
            make_bigbox(1, 11, 39, 39);
            make_bigbox(45, 55, 39, 39);
            make_bigbox(1, 1, 39, 61);
            make_bigbox(55, 55, 39, 61);
            make_bigbox(1, 55, 61, 61);

            //uitgangen
            make_bigbox(1, 1, 27, 31);
            make_bigbox(55, 55, 27, 31);

            //binnenmuren
            make_bigbox(5, 11, 5, 9);
            make_bigbox(15, 23, 5, 9);
            make_bigbox(27, 29, 1, 9);
            make_bigbox(33, 41, 5, 9);
            make_bigbox(45, 51, 5, 9);

            make_bigbox(5, 11, 13, 15);
            make_bigbox(15, 17, 13, 27);
            make_bigbox(17, 23, 19, 21);
            make_bigbox(21, 35, 13, 15);
            make_bigbox(27, 29, 15, 21);
            make_bigbox(33, 39, 19, 21);
            make_bigbox(39, 41, 13, 27);
            make_bigbox(45, 51, 13, 15);

            make_bigbox(15, 17, 31, 39);
            make_bigbox(21, 35, 37, 39);
            make_bigbox(27, 29, 39, 45);
            make_bigbox(39, 41, 31, 39);

            make_bigbox(5, 11, 43, 45);
            make_bigbox(9, 11, 45, 51);
            make_bigbox(15, 23, 43, 45);
            make_bigbox(33, 41, 43, 45);
            make_bigbox(45, 51, 43, 45);
            make_bigbox(45, 47, 45, 51);

            make_bigbox(5, 23, 55, 57);
            make_bigbox(15, 17, 49, 55);
            make_bigbox(21, 35, 49, 51);
            make_bigbox(27, 29, 51, 57);
            make_bigbox(39, 41, 49, 55);
            make_bigbox(33, 51, 55, 57);

            make_bigbox(1, 5, 49, 51);
            make_bigbox(51, 55, 49, 51);

            //midden            
            Instance gate1 = this.InstanceCreate(28f, 0.5f, 25f, typeof(instance_gate));
            gate1.Model.Size = new Vector3(13f, 1f, 1f);
            gate1.Collider.SetBox(new Vector3(13f, 1f, 1f));
            Instance gate2 = this.InstanceCreate(28f, 0.5f, 33f, typeof(instance_gate));
            gate2.Model.Size = new Vector3(13f, 1f, 1f);
            gate2.Collider.SetBox(new Vector3(13f, 1f, 1f));

            make_bigbox(21, 21, 25, 33);
            make_bigbox(35, 35, 25, 33);


            float radius = 0.25f;

            //muntjes
            for (int i = 5; i <= 25; i += 2) { this.InstanceCreate(i, radius, 3, typeof(instance_coin)); }
            for (int i = 31; i <= 53; i += 2) { this.InstanceCreate(i, radius, 3, typeof(instance_coin)); }
            for (int i = 5; i <= 51; i += 2) { this.InstanceCreate(i, radius, 11, typeof(instance_coin)); }
            for (int i = 5; i <= 11; i += 2) { this.InstanceCreate(i, radius, 17, typeof(instance_coin)); }
            for (int i = 19; i <= 25; i += 2) { this.InstanceCreate(i, radius, 17, typeof(instance_coin)); }
            for (int i = 31; i <= 37; i += 2) { this.InstanceCreate(i, radius, 17, typeof(instance_coin)); }
            for (int i = 45; i <= 51; i += 2) { this.InstanceCreate(i, radius, 17, typeof(instance_coin)); }
            for (int i = 5; i <= 17; i += 2) { this.InstanceCreate(3, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 9; i += 2) { this.InstanceCreate(13, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 9; i += 2) { this.InstanceCreate(25, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 9; i += 2) { this.InstanceCreate(31, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 9; i += 2) { this.InstanceCreate(43, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 17; i += 2) { this.InstanceCreate(53, radius, i, typeof(instance_coin)); }
            for (int i = 13; i <= 15; i += 2) { this.InstanceCreate(19, radius, i, typeof(instance_coin)); }
            for (int i = 13; i <= 15; i += 2) { this.InstanceCreate(37, radius, i, typeof(instance_coin)); }
            for (int i = 19; i <= 21; i += 2) { this.InstanceCreate(25, radius, i, typeof(instance_coin)); }
            for (int i = 19; i <= 21; i += 2) { this.InstanceCreate(31, radius, i, typeof(instance_coin)); }

            for (int i = 13; i <= 39; i += 2) { this.InstanceCreate(13, radius, i, typeof(instance_coin)); }
            for (int i = 13; i <= 39; i += 2) { this.InstanceCreate(43, radius, i, typeof(instance_coin)); }
            for (int i = 15; i <= 17; i += 2) { this.InstanceCreate(i, radius, 29, typeof(instance_coin)); }
            for (int i = 39; i <= 41; i += 2) { this.InstanceCreate(i, radius, 29, typeof(instance_coin)); }
            for (int i = 19; i <= 37; i += 2) { this.InstanceCreate(i, radius, 23, typeof(instance_coin)); }
            for (int i = 21; i <= 35; i += 2) { this.InstanceCreate(i, radius, 35, typeof(instance_coin)); }
            for (int i = 25; i <= 39; i += 2) { this.InstanceCreate(19, radius, i, typeof(instance_coin)); }
            for (int i = 25; i <= 39; i += 2) { this.InstanceCreate(37, radius, i, typeof(instance_coin)); }

            for (int i = 3; i <= 25; i += 2) { this.InstanceCreate(i, radius, 41, typeof(instance_coin)); }
            for (int i = 31; i <= 53; i += 2) { this.InstanceCreate(i, radius, 41, typeof(instance_coin)); }
            for (int i = 43; i <= 47; i += 2) { this.InstanceCreate(3, radius, i, typeof(instance_coin)); }
            for (int i = 43; i <= 53; i += 2) { this.InstanceCreate(13, radius, i, typeof(instance_coin)); }
            for (int i = 5; i <= 7; i += 2) { this.InstanceCreate(i, radius, 47, typeof(instance_coin)); }
            for (int i = 49; i <= 51; i += 2) { this.InstanceCreate(7, radius, i, typeof(instance_coin)); }
            for (int i = 3; i <= 11; i += 2) { this.InstanceCreate(i, radius, 53, typeof(instance_coin)); }
            for (int i = 55; i <= 57; i += 2) { this.InstanceCreate(3, radius, i, typeof(instance_coin)); }
            for (int i = 15; i <= 41; i += 2) { this.InstanceCreate(i, radius, 47, typeof(instance_coin)); }
            for (int i = 43; i <= 45; i += 2) { this.InstanceCreate(25, radius, i, typeof(instance_coin)); }
            for (int i = 43; i <= 45; i += 2) { this.InstanceCreate(31, radius, i, typeof(instance_coin)); }
            for (int i = 49; i <= 53; i += 2) { this.InstanceCreate(19, radius, i, typeof(instance_coin)); }
            for (int i = 49; i <= 53; i += 2) { this.InstanceCreate(37, radius, i, typeof(instance_coin)); }
            for (int i = 43; i <= 53; i += 2) { this.InstanceCreate(43, radius, i, typeof(instance_coin)); }
            for (int i = 43; i <= 47; i += 2) { this.InstanceCreate(53, radius, i, typeof(instance_coin)); }
            for (int i = 49; i <= 51; i += 2) { this.InstanceCreate(49, radius, i, typeof(instance_coin)); }
            for (int i = 49; i <= 51; i += 2) { this.InstanceCreate(i, radius, 47, typeof(instance_coin)); }
            for (int i = 21; i <= 25; i += 2) { this.InstanceCreate(i, radius, 53, typeof(instance_coin)); }
            for (int i = 31; i <= 35; i += 2) { this.InstanceCreate(i, radius, 53, typeof(instance_coin)); }
            for (int i = 45; i <= 53; i += 2) { this.InstanceCreate(i, radius, 53, typeof(instance_coin)); }
            for (int i = 55; i <= 57; i += 2) { this.InstanceCreate(25, radius, i, typeof(instance_coin)); }
            for (int i = 55; i <= 57; i += 2) { this.InstanceCreate(31, radius, i, typeof(instance_coin)); }
            for (int i = 55; i <= 57; i += 2) { this.InstanceCreate(53, radius, i, typeof(instance_coin)); }
            for (int i = 3; i <= 53; i += 2) { this.InstanceCreate(i, radius, 59, typeof(instance_coin)); }
        }
    }
}
