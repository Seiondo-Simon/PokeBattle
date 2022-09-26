using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PokeBattle
{
    public enum BattlePhaseEnum
    {
        CHALLENGE, 
        SELECTION,  
        TAUNT,
        BATTLE,
        FINISHED
    }

    public class Battle
    {
        private Player opponent;
        private Player player;        
        private bool inBattle;
        private BattlePhaseEnum phase;

        public Battle(Player one, Player two)
        {
            opponent = one;
            player = two;
        }

        public void LayOn()
        {
            phase = BattlePhaseEnum.CHALLENGE;
            inBattle = true;
            bool inputValid = false;
            string inputText = "";

            while (inBattle){
                PromptPlayer();
                do
                {
                    (bool valid, string input) = GetPlayerResponse();
                    inputValid = valid;
                    inputText = input;
                } while (!inputValid);
                
                ProcessResponse(inputText);
            }
        }

        private void PromptPlayer()
        {
            switch (phase)
            {
                case BattlePhaseEnum.CHALLENGE:
                    Console.WriteLine("Your rival challenges you to battle!");
                    Console.WriteLine("Do you accept? (yes or no)");
                    break;

                case BattlePhaseEnum.SELECTION:
                    Console.WriteLine("Who will you take into battle?");
                    Console.WriteLine(player.PokemonList());
                    break;

                case BattlePhaseEnum.TAUNT:
                    opponent.ChooseRandomPokemon();
                    Console.WriteLine("Opponent: Hehe... This is gonna be too easy! I choose you, {0}.\n", opponent.ActivePokemon.Name);                    
                    Console.WriteLine("That's what you think! Let's go, {0}!\n", player.ActivePokemon.Name);
                    Console.WriteLine("Type GO to attack...");
                    break;

                case BattlePhaseEnum.BATTLE:
                    Console.WriteLine("{0} used {1}!", opponent.ActivePokemon.Name, opponent.ActivePokemon.Move);
                    Console.WriteLine("{0} used {1}!", player.ActivePokemon.Name, player.ActivePokemon.Move);
                    Console.WriteLine("The ground trembles as these two titans engage in a fierce battle. However, there can be only one winner!");
                    Console.WriteLine("(Press ENTER for results...)");
                    break;

                case BattlePhaseEnum.FINISHED:
                    Console.WriteLine("Do you wish to engage in another battle?");
                    Console.WriteLine("(yes or no)");
                    break;

            }
        }

        private (bool valid, string response) GetPlayerResponse()
        {
            string input = Console.ReadLine();
            input = input.ToUpper();

            switch (phase)
            {
                case BattlePhaseEnum.CHALLENGE:
                case BattlePhaseEnum.FINISHED:
                    if (input == "Y" || input == "YES" || input == "YEAH" ||
                        input == "N" || input == "NO"  || input == "NOPE")
                    {
                        return (true, input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid response! Please enter Yes or No.");
                        return (false, input);
                    }                     

                case BattlePhaseEnum.SELECTION:
                    int selection = -1;
                    Int32.TryParse(input, out selection);

                    if (player.HasPokemon(selection))
                    {
                        return (true, selection.ToString());
                    }
                    else
                    {
                        Console.WriteLine("That selection is not in your collection!");
                        return (false, input);
                    }
                    break;

                case BattlePhaseEnum.TAUNT:
                    return (input.ToUpper() == "GO", input);

                case BattlePhaseEnum.BATTLE:
                    return (true, "");                     
            }
            return (false, "INVALID BATTLE PHASE");
        }

        private void ProcessResponse(string input)
        {
            StringBuilder sb = new StringBuilder();

            switch (phase)
            {
                case BattlePhaseEnum.CHALLENGE:
                    string message = input.StartsWith("Y") ?
                                     "Yeah!! Let's show him who's boss!" :
                                     "This is no time to chicken out! We're doing this!";
                    sb.AppendLine(message);
                    phase = BattlePhaseEnum.SELECTION;
                    break;

                case BattlePhaseEnum.SELECTION:
                    sb.AppendLine(player.ActivePokemon.SelectionText);
                    phase = BattlePhaseEnum.TAUNT;
                    break;

                case BattlePhaseEnum.TAUNT:
                    sb.AppendLine("Here we go!");
                    phase = BattlePhaseEnum.BATTLE;
                    break;

                case BattlePhaseEnum.BATTLE:
                    if(opponent.ActivePokemon.Attack > player.ActivePokemon.Health)
                    {
                        sb.AppendLine("Oh no! He got us this time! We'll be back though, stronger than ever!");
                    }
                    else if(player.ActivePokemon.Attack > opponent.ActivePokemon.Health)
                    {
                        sb.AppendLine("We won! That was too easy. Looks like you need to do some training!");
                    }
                    else
                    {
                        sb.AppendLine("Opponent: It's a draw! Lucky we went easy on ya!");
                    }
                    phase = BattlePhaseEnum.FINISHED;
                    break;

                case BattlePhaseEnum.FINISHED:
                    if(input.ToUpper().StartsWith("Y"))
                    {
                        opponent.ActivePokemon = null;
                        player.ActivePokemon = null;
                        phase = BattlePhaseEnum.CHALLENGE;                        
                        sb.AppendLine("----------------------------------------------------------------");
                    }
                    else
                    {
                        sb.AppendLine("Until the next battle...");                        
                        Environment.Exit(0);                            
                    }

                    break;

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
