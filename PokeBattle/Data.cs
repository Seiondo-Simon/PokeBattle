using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBattle
{
    public static class Data
    {
        public static List<Pokemon> Pokemons = new List<Pokemon>()
        {        
            new Pokemon {
                Id = 1,
                Name = "Mr.Mime",
                Health = 250,
                Attack = 500,
                Move = "Psychic"
            },
            new Pokemon {
                Id = 2,
                Name = "Dragonite",
                Health = 600,
                Attack = 600,
                Move = "Hyper Beam"
            },
            new Pokemon {
                Id = 3,
                Name= "Electrode",
                Health = 300,
                Attack = 300,
                Move = "Explode"
            },
            new Pokemon {
                Id = 4,
                Name = "Lapras",
                Health = 500,
                Attack = 350,
                Move = "Water Cannon"
            },
            new Pokemon {
                Id=5,
                Name = "Haunter",
                Health = 400,
                Attack = 350,
                Move = "Night Shade"
            },
            new Pokemon {
                Id = 6,
                Name = "Zapdos",
                Health = 500,
                Attack = 350,
                Move = "Thunder"
            },
            new Pokemon {
                Id = 7,
                Name = "Blastoise",
                Health = 400,
                Attack = 350,
                Move = "Hydro Pump"
            },
            new Pokemon {
                Id = 8,
                Name = "Charizard",
                Health = 500,
                Attack = 500,
                Move = "Fire Blast"
            },
            new Pokemon {
                Id = 9,
                Name = "Venasaur",
                Health= 600,
                Attack = 450,
                Move = "Razor Leaf"
            },
            new Pokemon {
                Id = 10,
                Name = "Arcanine",
                Health = 400,
                Attack = 400,
                Move = "Flamethrower"
            },
            new Pokemon {
                Id = 11,
                Name = "Mewtwo",
                Health = 1000,
                Attack = 1000,
                Move = "Psystrike"
            },
            new Pokemon {
                Id = 12,
                Name = "Articuno",
                Health = 500,
                Attack = 350,
                Move = "Ice Breath"
            }
        };

    }
}
