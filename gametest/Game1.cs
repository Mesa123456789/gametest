using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace gametest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D food1;
        Texture2D food2;
        Texture2D playerTex;
        Texture2D popup;
        Texture2D uni;
        Texture2D food3;
        public Vector2 foodPos;
        public Texture2D foodTex;
        Vector2 playerPos = new Vector2(100,100);
        Rectangle playerBox = new Rectangle(0,0,64,64);
        food food;
        Bag bag;
        public static Player player;
        public static List<food> BagList = new List<food>();
        public static List<food> CraftList = new List<food>();
        public static bool IsPopUp = false;
        //ทำlistรับอาหารที่ปรุงเส้ดแล้ว และทำboolรับค่าว่าได้อะไร เมื่อได้สิ่งนั้นค่อยวาด
        public static List<Texture2D> Menu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            food = new food(foodPos, foodTex);
            playerTex = Content.Load<Texture2D>("Char01_1");
            player = new Player(playerPos , playerTex);
            food1 = Content.Load<Texture2D>("Chicken");
            food2 = Content.Load<Texture2D>("enemy");
            popup = Content.Load<Texture2D>("rectangle");
            uni = Content.Load<Texture2D>("Uni");
            food3 = Content.Load<Texture2D>("flower");
            //Menu.Add(uni);
            food.foodList.Add(new food((new Vector2(200 , 300)), food3));
            food.foodList.Add(new food((new Vector2(300, 300)), food2));
            food.MenuList.Add(new food((new Vector2(200, 300)), food3));
            food.MenuList.Add(new food((new Vector2(300, 300)), food2));
            //food.foodList.Add(new food((new Vector2(300, 400)), food1));

            // TODO: use this.Content to load your game content here
        }

        public int countPopUp;
        public bool Ontable = false;
        public Rectangle tableBox = new Rectangle(100 , 150,64,64);
        public Rectangle equalBox = new Rectangle(350, 75, 64,64);
        bool Crafting = false;
        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle(ms.X,ms.Y,50,50);
            if (player.playerBox.Intersects(tableBox))
            {
                if (ms.LeftButton == ButtonState.Pressed && mouseBox.Intersects(tableBox))
                {
                    Ontable = true;
                }
            }
            else
            {
                Ontable = false;
            }

            for (int i = 0; i < BagList.Count; i++)
            {
                BagList[i].Update();
                if (mouseBox.Intersects(BagList[i].foodBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
                {
                    for(int j = food.MenuList.Count; j <= 2; j++)
                    { 
                        food.getFood++;
                    }
                    for (int j = food.MenuList.Count; j > 2 && j <= 5; j++)
                    {
                        food.IsUni++;
                    }
                    CraftList.Add(BagList[i]);
                    BagList.RemoveAt(i);
                    break;
                }  
            }
            if (mouseBox.Intersects(equalBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
            {
                Crafting = true;
            }
            for (int i = food.foodList.Count - 1; i >= 0; i--)
            {
                food.foodList[i].Update();
            }
            player.Update();
            



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (food food in BagList)
            {
                if (IsPopUp == true)
                {

                    for (int i = 0; i < BagList.Count; i++)
                    {
                        _spriteBatch.Draw(popup, new Rectangle(700, 100, 100, 70), Color.Black);
                        _spriteBatch.Draw(BagList[i].foodTex, new Vector2(720, 120), Color.White);
                    }
                    CountTime();
                }
            }
            foreach (food food in food.foodList)
            {
                for (int i = 0; i < food.foodList.Count; i++)
                {
                    food.foodList[i].Draw(_spriteBatch);
                }

            }

            _spriteBatch.Draw(popup, new Vector2(100,150),tableBox, Color.White);

            player.Draw(_spriteBatch);
            //ui craft
            if(Ontable == true)
            {
                //craft
                _spriteBatch.Draw(popup, new Rectangle(200, 50, 500, 150), Color.Red);
                _spriteBatch.Draw(popup, new Rectangle(200, 230, 500, 200), Color.White);
                _spriteBatch.Draw(popup,new Vector2(350, 75), equalBox , Color.White);
                for (int i = 0; i < CraftList.Count; i++)
                {
                    _spriteBatch.Draw(CraftList[i].foodTex, new Vector2(230 + i * 60, 70), Color.White);
                }
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTex, new Vector2(230 + i * 60, 250), Color.White);
                }
                if (food.getFood == 2 && Crafting == true)
                {
                    _spriteBatch.Draw(uni, new Rectangle(450, 70, 64, 64), Color.White);
                }

            }
          

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void CountTime()
        {
            countPopUp += 1;
            {
                if (countPopUp > 100)
                {
                    countPopUp = 0;
                    IsPopUp = false;
                    Ontable = false;
                }
            }
        }
     
    }
}
