using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBattle
{
    public class Player
    {
        private List<Pokemon> Pokemons = new List<Pokemon>();
        public Pokemon ActivePokemon;

        public void InitializePokemon(int[] indexList)
        {
            for(int i = 0; i < indexList.Length - 1; i++)
            {
                Pokemon pokemon = Data.Pokemons[indexList[i]];
                this.Pokemons.Add(pokemon);
            }
        }

        public string PokemonList()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Pokemon p in Pokemons)
            {
                sb.AppendFormat("{0} | {1}", p.Id.ToString().PadLeft(3), p.Name);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public bool HasPokemon(int idToCheck)
        {
            var p = Pokemons.Where(p => p.Id == idToCheck).ToList();
            if(p.Any())
            {
                ActivePokemon = p.FirstOrDefault();
                return true;
            }

            return false; 
        }      

        public void ChooseRandomPokemon()
        {
            int select = new Random().Next(1, 5);
            ActivePokemon = Data.Pokemons[select];
        }
    }
}
