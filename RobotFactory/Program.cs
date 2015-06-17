using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;
using RobotFactory.Producers;
using RobotFactory.Robot.Parts;

namespace RobotFactory
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Configuring factory...");

            var container = ProducersBootstraper.Bootstrap();
            var nextStep = new BatchBlock<IRobotPart>(4, new GroupingDataflowBlockOptions{ Greedy = false });
            
            var buildRobotBlock = new TransformBlock<IRobotPart[], Robot.Robot> (rps => BuildRobot.Build(rps));
            
            var saveRobotBlock = new ActionBlock<Robot.Robot>(async robot => SaveRobot.Save(robot));

            nextStep.LinkTo(buildRobotBlock);
            buildRobotBlock.LinkTo(saveRobotBlock);

            var armsProdTask = TaskFactory.CreateTask<Arms>(container, nextStep);
            var headsProdTask = TaskFactory.CreateTask<Head>(container, nextStep);
            var bodysProdTask = TaskFactory.CreateTask<Boby>(container, nextStep);
            var legsProdTask = TaskFactory.CreateTask<Legs>(container, nextStep);

            armsProdTask.Start();
            headsProdTask.Start();
            bodysProdTask.Start();
            legsProdTask.Start();

            Console.WriteLine("Starting factory...");
            Console.ReadLine();

            TaskFactory.TokenSource.Cancel();
            Thread.Sleep(1000);
            for (var i = 3; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\rBye {0}s   ", i);
                Thread.Sleep(1000);
            }
        }
    }
}
