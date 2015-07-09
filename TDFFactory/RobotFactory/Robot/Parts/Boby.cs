namespace RobotFactory.Robot.Parts
{
    public class Boby : IRobotPart
    {
        public Boby(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; private set; }
    }
}