using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASCIIGraphic
{
    public class BitmapToASCIIConverter
    {
        private readonly char[] ASCIItable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };
        private readonly Bitmap _bitmap;
        public BitmapToASCIIConverter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public char[][] Convert()
        {
            var result = new char[_bitmap.Height][];

            for(int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for(int x = 0; x < _bitmap.Width; x++)
                {
                    int MapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, ASCIItable.Length - 1);
                    result[y][x] = ASCIItable[MapIndex];
                }
            }    

            return result;
        }

        private float Map(float valueToMap, float start1, float end1, float start2, float end2)
        {
            return ((valueToMap - start1) / (end1 - start1) * (end2 - start2)) + start2;
        }
    }
}
