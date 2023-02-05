using wtftd.Engine.Input;
using wtftd.Engine.States;
using wtftd.Input;
using wtftd.Objects;
using Microsoft.Xna.Framework;

namespace wtftd.States
{
    public class SplashState : BaseGameState
    {
        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture("Images/splash.png")));
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is SplashInputCommand.GameSelect)
                {
                    SwitchState(new GameplayState());
                }
            }
            );
        }

        public override void UpdateGameState(GameTime gameTime) 
        { 
            
        }


        protected override void SetInputManager()
        {
            InputManager = new InputManager(new SplashInputMapper());
        }
    }
    
}