using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Core.Factories;
using EasterRaces.Core.Factories.Contracts;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            var raceRepo = new RaceRepository();
            var driverRepo = new DriverRepository();
            var carRepo = new CarRepository();

            var raceFactory = new RaceFactory();
            var driverFactory = new DriverFactory();
            var carFactory = new CarFactory();

            IChampionshipController controller = new ChampionshipController(
                carRepo,
                driverRepo,
                raceRepo,
                carFactory,
                driverFactory,
                raceFactory
                );

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);

            enigne.Run();
        }
    }
}
