using System;
using WarCroft.Core;
using WarCroft.Core.Factories;
using WarCroft.Core.Factories.Contracts;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var warriorFactory = new WarriorFactory();
            var priestFactory = new PriestFactory();
            var firePotionFactory = new FirePotionFactory();
            var healthPotionFactory = new HealthPotionFactory();


            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //var engine = new Engine(reader, writer);
            //engine.Run();

            /* Use the below configuration instead of the usual one if you wish to print all output messages together after the inputs for easier comparison with the example output. */

            IReader reader = new ConsoleReader();
            var sbWriter = new StringBuilderWriter();
            var controller = new WarController(warriorFactory, priestFactory, firePotionFactory, healthPotionFactory);


            var engine = new Engine(reader, sbWriter,controller);
            engine.Run();

            Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
    }
}