using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gametest
{
    public class Player
    {
        Texture2D playerTex;
        public Vector2 playerPos = new Vector2(100, 100);
        public Rectangle playerBox = new Rectangle(0, 0, 64, 64);
        

        public Player(Vector2 playerPos, Texture2D playerTex)
        {
            this.playerPos = playerPos;
            this.playerTex = playerTex;
            playerBox = new Rectangle((int)playerPos.X, (int)playerPos.Y, 64 , 64);
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerPos.X += 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerPos.X -= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerPos.Y -= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerPos.Y += 2;
            }
            playerBox = new Rectangle((int)playerPos.X, (int)playerPos.Y, 64, 64);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(playerTex, playerPos , new Rectangle(0,0, 64, 64), Color.White);

        }
    }
}
