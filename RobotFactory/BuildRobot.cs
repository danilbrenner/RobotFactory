using System;
using RobotFactory.Robot.Parts;

namespace RobotFactory
{
    public static class BuildRobot
    {
        private static int _robotIncrement;

        public static Robot.Robot Build(IRobotPart[] parts)
        {
            Arms arms = null;
            Head head = null;
            Boby boby = null;
            Legs legs = null;

            foreach (var robotPart in parts)
            {
                if (arms == null) arms = robotPart as Arms;
                if (head == null) head = robotPart as Head;
                if (boby == null) boby = robotPart as Boby;
                if (legs == null) legs = robotPart as Legs;
            }
            if (arms == null) throw new Exception("No arms received");
            if (head == null) throw new Exception("No head received");
            if (boby == null) throw new Exception("No boby received");
            if (legs == null) throw new Exception("No legs received");

            var robot = new Robot.Robot(string.Concat("robo", _robotIncrement), head, boby, arms, legs);
            _robotIncrement++;
            return robot;
        }
    }
}
