namespace RobotFactory.Robot.Parts
{
    public class Head : IRobotPart
    {
        public Head(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; private set; }
    }
}