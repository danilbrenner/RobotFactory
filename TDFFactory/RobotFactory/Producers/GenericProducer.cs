using System;
using System.Threading;
using RobotFactory.Robot.Parts;

namespace RobotFactory.Producers
{
    public class GenericProducer<T> : IProducer<T> where T : IRobotPart
    {
        private readonly string _serial;
        private int _counter;
        private readonly int _productionCycle;

        public GenericProducer(string serial, int productionCycle)
        {
            _serial = serial;
            _productionCycle = productionCycle;
            _counter = 0;
        }

        public T Produce()
        {
            Thread.Sleep(_productionCycle);
            _counter++;
            var serialNumber = string.Concat(_serial, _counter);
            return (T)Activator.CreateInstance(typeof(T), serialNumber);
        }
    }
}