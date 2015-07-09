namespace RobotFactory.Robot.Parts
{
    public class Legs : IRobotPart
    {
        public Legs(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; private set; }
    }
}