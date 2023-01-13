using wtftd.Engine;
using wtftd.States;
using System;

namespace wtftd
{
    public static class Program
    {
        private const int WIDTH = 1280;
        private const int HEIGHT = 720;

        [STAThread]
        static void Main()
        {
            using (var game = new Game1(WIDTH, HEIGHT, new SplashState()))
            {
                game.IsFixedTimeStep = true;
                game.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 60);
                game.Run();
            }
        }
    }
}
