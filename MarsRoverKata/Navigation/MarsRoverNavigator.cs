using MarsRoverKata.Exceptions;

namespace MarsRoverKata.Navigation
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters navigationParameters;
        private readonly SpinningControl spinningControl;
        private readonly MovingControl movingControl;
        private string currentDirection;
        private Coordinates currentCoordinates;

        public MarsRoverNavigator(NavigationParameters navigationParameters)
        {
            this.navigationParameters = navigationParameters;
            currentDirection = navigationParameters.CurrentDirection;
            currentCoordinates = navigationParameters.CurrentCoordinates;
            spinningControl = new SpinningControl();
            movingControl = new MovingControl();
        }

        public NavigationParameters Navigate(string command)
        {
            foreach (var step in command)
            {
                DoAStep(step);
            }

            return new NavigationParameters(currentDirection, navigationParameters.PlateauDimensions, currentCoordinates);
        }

        private void DoAStep(char stepCommand)
        {
            currentDirection = spinningControl.GetNextDirection(currentDirection, stepCommand);
            currentCoordinates = movingControl.Move(stepCommand, currentDirection, currentCoordinates);



            if (currentCoordinates.X > navigationParameters.PlateauDimensions.X || currentCoordinates.Y > navigationParameters.PlateauDimensions.Y)
            {
                throw new InvalidCommandException();
            }
        }
    }
}