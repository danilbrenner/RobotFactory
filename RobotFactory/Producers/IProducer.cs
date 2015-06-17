using RobotFactory.Robot.Parts;

namespace RobotFactory.Producers
{
    public interface IProducer<out T> where T : IRobotPart
    {
        T Produce();
    }
}
