using System;
using System.Diagnostics.Contracts;
using RobotFactory.Robot.Parts;

namespace RobotFactory.Robot
{
    public class Robot
    {
        public Robot(string serialNumber, Head head, Boby boby, Arms arms, Legs legs)
        {
            Head = head;
            Boby = boby;
            Arms = arms;
            Legs = legs;
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; private set; }
        public Head Head { get; private set; }
        public Boby Boby { get; private set; }
        public Arms Arms { get; private set; }
        public Legs Legs { get; private set; }
    }
}
