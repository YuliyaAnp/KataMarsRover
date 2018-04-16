using MarsRoverKata.Exceptions;

namespace MarsRoverKata.Navigation
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters navigationParameters;
        private readonly SpinningControl spinningControl;
        private readonly MovingControl movingControl;

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
            var newDirection = spinningControl.GetNextDirection(navigationParameters.CurrentDirection, stepCommand);

            navigationParameters.UpdateCurrentDirection(newDirection);

            var newCoordinates = movingControl.Move(stepCommand, navigationParameters.CurrentDirection, navigationParameters.CurrentCoordinates);

            if (newCoordinates.X > navigationParameters.PlateauDimenstions.X || newCoordinates.Y > navigationParameters.PlateauDimenstions.Y)
            {
                throw new InvalidCommandException();
            }

            navigationParameters.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}