using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBattle
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public string Move { get; set; }
        public string SelectionText { get; set; }

        public Pokemon()
        {
        }
        public Pokemon(int id, string name, int health, int attack, string move, string selectionText)
        {
            Id = id;
            Name = name;
            Health = health;
            MaxHealth = health;
            Attack = attack;
            Move = move;
            SelectionText = selectionText;
        }
    }

}
