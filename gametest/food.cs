using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static List<food> MenuList = new List<food>();
        public Rectangle foodBox;
        Bag bag;
        public int getFood;
        public int IsUni;


        public bool OntableAble;
        public food(Vector2 foodPos , Texture2D foodTex)
        {
            this.foodPos = foodPos;
            this.foodTex = foodTex;
            foodBox = new Rectangle((int)foodPos.X, (int)foodPos.Y, 64 ,64);
            OntableAble = false;

        }
        
        public void Update()
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(Game1.player.playerBox) && !OntableAble)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();
                    
                }
            }
            OnCraft();



            foodBox = new Rectangle((int)foodPos.X, (int)foodPos.Y, 64 , 64);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(foodTex , foodPos, Color.White);
    
        }


        public void OnCollision()
        {
            OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;
            foreach (food food in foodList)
            {
                foodList.Remove(this);
                //เพราะfoodถูกรีมูฟค่า
                break;
            }
        }
        public void OnCraft()
        {


        }


    }
}
