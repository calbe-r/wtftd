using wtftd.Engine.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace wtftd.Objects
{
    public class Player : BaseGameObject
    {
        public Player(Texture2D texture)
        {
            _texture = texture;
        }
    }
}