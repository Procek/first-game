using System.Drawing;

namespace GraProckowa
{
    public class Sprite
    {
        public Vector position = null;
        public Vector scale = null;
        public string directory = "";
        public Vector shift = null;
        public Bitmap spriteFinish = null;        

        public Sprite(Vector position, Vector scale, string directory, Vector shift)
        {
            this.position = position;
            this.scale = scale;
            this.directory = directory;
            this.shift = shift;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");

            Bitmap sprite = new Bitmap(tmp);
            spriteFinish = sprite;
        }
    }
}
