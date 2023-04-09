
using Raiding.Engine;
using Raiding.IO;
using Raiding.Models;
using Raiding.Models.Interfaces;

IBaseHero baseHero = null;
ConsoleReader consoleReader = new ConsoleReader();
ConsoleWriter consoleWriter = new ConsoleWriter();

Engine engine = new Engine(consoleReader, consoleWriter, baseHero);
engine.RunTheProgram(consoleReader, consoleWriter, baseHero);

