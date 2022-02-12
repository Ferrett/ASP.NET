using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Team
    {
        public string Name { get; set; }
        public Game Discipline { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public Team(string name, Game discipline, DateTime creationDate, List<Player> players)
        {
            Name = name;
            Discipline = discipline;
            CreationDate = creationDate;
            Players = players;
        }
    }
}
