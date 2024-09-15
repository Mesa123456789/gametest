using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gametest
{
    public class food
    {
        public Vector2 foodPos;
        public Texture2D foodTex;
        public static List<food> foodList = new List<food>();
        public Rectangle foodBox;
        Bag bag;
        public int getFood;
        Array getfood;
        public food(Vector2 foodPos , Texture2D foodTex)
        {
            this.foodPos = foodPos;
            this.foodTex = foodTex;
            foodBox = new Rectangle((int)foodPos.X, (int)foodPos.Y, 32 , 32);

        }
        
        public void Update()
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(Game1.player.playerBox))
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();
                }
            }
            if (ms.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < Game1.BagList.Count; i++)
                {
                    Game1.BagList[i].foodPos = new Vector2(ms.X, ms.Y);
                }
            }



            foodBox = new Rectangle((int)foodPos.X, (int)foodPos.Y, 32 , 32);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(foodTex , foodPos, Color.White);
    
        }


        public void OnCollision()
        {
            Game1.IsPopUp = true;
            Game1.BagList.Add(this);

            foreach (food food in foodList)
            {
                foodList.Remove(this);
                break;
            }
            
        }
    }
}
