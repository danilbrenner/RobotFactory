using System.IO;
using Newtonsoft.Json;

namespace RobotFactory
{
    class SaveRobot
    {
        private static readonly StreamWriter File = new StreamWriter("test.txt");

        public static async void Save(Robot.Robot robot)
        {
            var json = JsonConvert.SerializeObject(robot);
            await File.WriteLineAsync(json);
            await File.FlushAsync();
        }
    }
}
