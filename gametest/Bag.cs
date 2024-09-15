using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gametest
{
    public class Bag
    {
        public List<food> BagList = new List<food>();

        //public void Draw(SpriteBatch _spriteBatch)
        //{
        //    for (int i = 0; i < BagList.Count; i++)
        //    {
        //        _spriteBatch.Draw(BagList[i].foodTex, new Vector2(0 + i * 50, 0), Color.White);
        //    }
        //}
    }
}
