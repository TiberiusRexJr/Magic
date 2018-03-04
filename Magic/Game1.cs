using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magic
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Texture2D player_texture;
        public static short= myPlayer=0; /// always 0, first player
        public static Player player = new Player();
        public static Player[] player_list = new Player[255]; //max 255 players
        public static int max_X = (32 * 100);
        public static int max_Y = (32 * 100);



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            for (int i = 0; i < 255; i++)
            {
                player_list[i] = new Player();
                player_list[i].whoAmI = (short)i;  // to reference any player from the current player aka myplayer

            }
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player_texture = base.Content.Load<Texture2D>(@"player1"); //@ to create a string

            // TODO: use this.Content to load your game content here
        }

       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

   
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Player p in player_list)
            {
                p.Update(gameTime);  //update every player
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Map_Handling.Transform);

            for (int i = 0; i < 255; i++)
            {
                spriteBatch.Draw(player_texture, player_list[i].position, null, Color.White, player_list[i].bodyRotation, new Vector2(16, 16), 1.0f, SpriteEffects.None, 0.0f); 
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
