using wtftd.Engine.Input;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace wtftd.Input 
{
    public class GameplayInputMapper : BaseInputMapper 
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<GameplayInputCommand>();

            if (state.IsKeyDown(Keys.Left))
            {
                commands.Add(new GameplayInputCommand.MoveLeft());
            }

            if (state.IsKeyDown(Keys.Right))
            {
                commands.Add(new GameplayInputCommand.MoveRight());
            }

            if (state.IsKeyDown(Keys.Up))
            {
                commands.Add(new GameplayInputCommand.MoveUp());
            }

            if (state.IsKeyDown(Keys.Down))
            {
                commands.Add(new GameplayInputCommand.MoveDown());
            }
            
            return commands;
        }
    }
}