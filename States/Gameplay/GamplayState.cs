using wtftd.Engine.Input;
using wtftd.Engine.States;
using wtftd.Engine.Objects;
using wtftd.Input;
using wtftd.Objects;
using Microsoft.Xna.Framework;
using System;


namespace wtftd.States
{
    public class GameplayState : BaseGameState
    {
        public int pXVel = 0;
        public int pYVel = 0;
        private int moveVal = 10;
        private Vector2 pos;
        public Player player;

        public override void LoadContent()
        {
            AddGameObject(player = new Player(LoadTexture("Images/player.png")));
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is GameplayInputCommand.MoveLeft)
                {
                    Console.WriteLine("LEFT");
                    pXVel = -1 * moveVal;
                }
                else if (cmd is GameplayInputCommand.MoveRight)
                {
                    Console.WriteLine("RIGHT");
                    pXVel = 1 * moveVal;
                }
                else 
                {
                    pXVel = 0;
                }

                if (cmd is GameplayInputCommand.MoveDown)
                {
                    Console.WriteLine("DOWN");
                    pYVel = 1 * moveVal;
                }
                else if (cmd is GameplayInputCommand.MoveUp)
                {
                    Console.WriteLine("UP");
                    pYVel = -1 * moveVal;
                }
                else 
                {
                    pYVel = 0;
                }
            }
            );
        }

        public override void UpdateGameState(GameTime gameTime) 
        {
            pos = new Vector2(pXVel, pYVel);
            Console.WriteLine(pos);
            player.Position += pos;
        }


        protected override void SetInputManager()
        {
            InputManager = new InputManager(new GameplayInputMapper());
        }
    }
}