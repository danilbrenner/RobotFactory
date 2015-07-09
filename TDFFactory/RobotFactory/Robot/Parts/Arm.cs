namespace RobotFactory.Robot.Parts
{
    public class Arms : IRobotPart
    {
        public Arms(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; private set; }
    }
}