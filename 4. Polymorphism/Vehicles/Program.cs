

using Vehicles.Core;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

ConsoleReader consoleReader = new ConsoleReader();
ConsoleWriter consoleWriter = new ConsoleWriter();
IVehicle vehicle = null;

Engine engine = new Engine(consoleReader, consoleWriter, vehicle);
engine.Run(consoleReader, consoleWriter, vehicle);

engine.PrintOutupData(consoleWriter, vehicle);