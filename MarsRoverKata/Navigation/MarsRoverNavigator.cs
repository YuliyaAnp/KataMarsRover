using System;

namespace MarsRoverKata
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters navigationParameters;
        private SpinningControl spinningControl;
        private MovingControl movingControl;

        public MarsRoverNavigator(NavigationParameters navigationParameters)
        {
            this.navigationParameters = navigationParameters;
            spinningControl = new SpinningControl();
            movingControl = new MovingControl();
        }

        public string Navigate()
        {
            var command = navigationParameters.Command;

            foreach (var step in command)
            {
                DoAStep(step);
            }

            var result = $"{navigationParameters.CurrentCoordinates.X} {navigationParameters.CurrentCoordinates.Y} {navigationParameters.CurrentDirection}";

            return result;
        }

        private void DoAStep(char stepCommand)
        {
            var newDirection = spinningControl.SpinningFunctions[stepCommand](navigationParameters.CurrentDirection);
            navigationParameters.UpdateCurrentDirection(newDirection);

            var newCoordinates = movingControl.Move(stepCommand, navigationParameters.CurrentDirection, navigationParameters.CurrentCoordinates);

            if (newCoordinates.X > navigationParameters.PlateauDimenstions.X || newCoordinates.Y > navigationParameters.PlateauDimenstions.Y)
            {
                throw new Exception("Command is invalid: Rover is sent outside the Plateau");
            }

            navigationParameters.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}
