using MarsRoverKata.Navigation;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private readonly string input;
        private MarsRoverNavigator marsRoverNavigator;

        public MarsRover(string input)
        {
            this.input = input;
        }

        public NavigationParameters NavigationParameters { get; private set; }
        public string FinalPosition { get; private set; }

        public void Initialize()
        {
            NavigationParameters = InputValidator.GetNaviagtionParametersFromInput(input);
        }

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(NavigationParameters);
            FinalPosition = marsRoverNavigator.Navigate();
        }
    }
}