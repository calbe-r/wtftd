using wtftd.Engine.Input;

namespace wtftd.Input
{
    public class GameplayInputCommand :BaseInputCommand
    {
        public class MoveLeft : GameplayInputCommand { }

        public class MoveRight : GameplayInputCommand { }

        public class MoveUp : GameplayInputCommand { }

        public class MoveDown : GameplayInputCommand { }
        
    }
}