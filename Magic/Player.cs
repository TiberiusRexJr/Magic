using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magic
{
    public class Player
    {
        public short whoAmI = 0; //player id
        public float bodyRotation; //how fast the player can turnaorund. turnaround rate
        public Vector2 bodyVelocity; //how fast is player going
        public Vector2 position; //vector in space
        public short height = 32; //their pixels so we know how to draw the world around them
        public short width = 32;

        public Player()
        {

            position.X = -1;
            position.Y = -1;
            bodyVelocity = Vector2.Zero; //initially zero speed?
        }

        public void Update(GameTime gameTime)
        {
            position.X += (bodyVelocity.X * 0.5f); //x and y position can change in speed on a individual player basis due to "bodyVelocity" variable. Every player can have there own speed.
            position.Y += (bodyVelocity.Y * 0.5f);
            position.X = MathHelper.Clamp(position.X, width * 0.5f, (Game1.max_X) - (width * 0.5f)); //game barrier
            position.Y = MathHelper.Clamp(position.Y, height * 0.5f, (Game1.max_Y) - (height * 0.5f));
        }


    }
}
