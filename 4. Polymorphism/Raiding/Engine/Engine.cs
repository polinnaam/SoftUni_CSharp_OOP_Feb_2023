using Raiding.Engine.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Engine
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IBaseHero baseHero;
        private ICollection<IBaseHero> baseHeroes;

        public Engine(IReader consoleReader,IWriter consoleWriter, IBaseHero baseHero)
        {
            baseHeroes = new List<IBaseHero>();

            reader = consoleReader;
            writer = consoleWriter;
            this.baseHero = baseHero;
        }
        public void RunTheProgram(IReader consoleReader, IWriter consoleWriter, IBaseHero baseHero)
        {
            int nLines = int.Parse(consoleReader.ReadLine());

            for (int i = 0; i < nLines; i++)
            {
                string heroName = consoleReader.ReadLine();
                string heroType = consoleReader.ReadLine();
                try
                {
                    baseHeroes.Add(CreateHero(heroName, heroType, consoleWriter));
                }
                catch (ArgumentException ex)
                {
                    i--;
                    consoleWriter.WriteLine(ex.Message);
                }
            }

            long bossPower = long.Parse(consoleReader.ReadLine());
            long heroesPower = 0;

            foreach (IBaseHero hero in baseHeroes)
            {
                heroesPower += hero.Power;
                consoleWriter.WriteLine(hero.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                consoleWriter.WriteLine("Victory!");
            }
            else
            {
                consoleWriter.WriteLine("Defeat...");
            }

        }

        public IBaseHero CreateHero(string heroName, string heroType, IWriter consoleWriter)
        {
            switch(heroType)
            {
                case "Druid":
                    BaseHero driod = new Druid(heroName);
                    return driod;
                    break;

                case "Paladin":
                    BaseHero paladin = new Paladin(heroName);
                    return paladin;
                    break;

                case "Rogue":
                    BaseHero rogue = new Rogue(heroName);
                    return rogue;
                    break;

                case "Warrior":
                    BaseHero warrior = new Warrior(heroName);
                    return warrior;
                    break;

                default:
                    throw new ArgumentException("Invalid hero!");
            }

        }

    }
}
