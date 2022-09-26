// See https://aka.ms/new-console-template for more information
using PokeBattle;

Console.WriteLine("Pokemon Battle!");

Player opponent = new Player();
opponent.InitializePokemon( new int[] { 1,2,3,4,5,6 });

Player me = new Player();
me.InitializePokemon(new int[] { 7,8,9,10,11,12});

Battle theBattle = new Battle(opponent, me);
theBattle.LayOn();

