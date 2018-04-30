using OpenTK.Input;
using System;
using Zenseless.ExampleFramework;

namespace Example
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            var window = new ExampleWindow();
            var model = new Model();
            var view = new View();

            window.Update += (dt) =>
            {
                // handle input
                var movementXAxis = Keyboard.GetState()[Key.Left] ? -1f : (Keyboard.GetState()[Key.Right] ? 1f : 0f);
                var movementYAxis = Keyboard.GetState()[Key.Down] ? -1f : (Keyboard.GetState()[Key.Up] ? 1f : 0f);
                var isShooting = Keyboard.GetState()[Key.Space];
                model.Update(movementXAxis, movementYAxis, isShooting, dt);
            };

            window.Render += () =>
            {
                view.ClearScreen();
                view.DrawPlayer(model.player);
                foreach (var asteroid in model.asteroidsList) view.DrawAsteroids(asteroid.shape);
                foreach (var bullet in model.bullets) view.DrawBullet(bullet);
            };

            window.Resize += view.Resize;

            window.Run();
        }
    }
}