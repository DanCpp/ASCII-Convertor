using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASCIIGraphic
{
    class Program
    {
        private const double WIDTH_OFFSET = 1.5;
        private const int MAX_WIDTH = 200;

        [STAThread]
        static void Main(string[] args)
        {
            
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
            };

            Console.WriteLine("Press enter to start...\n");

            while(true)
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayScale();

                var Converter = new BitmapToASCIIConverter(bitmap);
                var rows = Converter.Convert();

                foreach (var row in rows)
                    Console.WriteLine(row);

                Console.SetCursorPosition(0, 0);
            }
        }

        private static Bitmap ResizeBitmap(Bitmap map)
        {
            var newHeight = map.Height / WIDTH_OFFSET * MAX_WIDTH / map.Width;
            if(map.Width > MAX_WIDTH || map.Height > newHeight)
            {
                map = new Bitmap(map, new Size(MAX_WIDTH, (int)newHeight));
            }
            return map;
        }
    }
}
