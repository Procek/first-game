using System.Drawing;
using System.Reflection;

namespace GraProckowa
{
    public class Sprite
    {
        public Vector Scale { get; }
        public Vector Shift { get; }
        public Bitmap SpriteFinish { get; }     

        // TODO: Seems that position is not used
        public Sprite(Vector position, Vector scale, string directory, Vector shift)
        {
            Scale = scale;
            Shift = shift;

            var assembly = Assembly.GetExecutingAssembly();

            directory = directory.Replace("/", ".");
            var resourceName = $"GraProckowa.Assets.{directory}.png";
            using (var imageStream = assembly.GetManifestResourceStream(resourceName))
            {
                var tmp = Image.FromStream(imageStream);

                Bitmap sprite = new Bitmap(tmp);
                SpriteFinish = sprite;
            }
        }
    }
}
