using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Practices.Unity;
using RobotFactory.Producers;
using RobotFactory.Robot.Parts;

namespace RobotFactory
{
    class TaskFactory
    {
        public static readonly CancellationTokenSource TokenSource = new CancellationTokenSource();

        internal class ProducerContext
        {
            public IUnityContainer Container { get; set; }
            public BufferBlock<IRobotPart> Buffer { get; set; }
        }

        public static Task CreateTask<T>(IUnityContainer container, ITargetBlock<IRobotPart> nextStep)  where T : IRobotPart
        {
            var buffer = new BufferBlock<IRobotPart>();
            buffer.LinkTo(nextStep);
            return new Task(ProducerMethod<T>, new ProducerContext
            {
                Container = container,
                Buffer = buffer
            });
        }

        private static void ProducerMethod<T>(object obj) where T : IRobotPart
        {
            var ct = TokenSource.Token;
            var context = (ProducerContext)obj;
            var producer = context.Container.Resolve<IProducer<T>>();
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    context.Buffer.Complete();
                    Console.WriteLine("\rProduction canceled...");
                    return;
                }
                var part = producer.Produce();
                context.Buffer.Post(part);
            }
        }
    }
}