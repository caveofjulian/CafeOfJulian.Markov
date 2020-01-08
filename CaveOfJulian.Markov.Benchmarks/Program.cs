using System;
using System.Collections.Generic;
using System.Threading;
using BenchmarkDotNet.Running;
using CaveOfJulian.Markov;

namespace CafeOfJulian.Benchmarks
{
    public class Player
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }

        public Player()
        {
            Name = "Julian";
            HitPoints = 100;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DynamicInvokeVSInvoke>();
            Console.ReadKey();
        }

        static void RunSampleChain()
        {
            double[,] probabilities =
            {
                {0, 0.5, 0.5},
                {0.5, 0, 0.5},
                {0.5, 0.5, 0}
            };

            Func<Player, Player>[,] funcs =
            {
                {null, Punch, Kick},
                {Punch, null, Heal},
                {Heal, Kick, null},
            };

            var chain = new MarkovActionChain<Player>(probabilities, funcs);
            chain.Run();
        }


        public static Player Punch(Player player)
        {
            if(player is null) player = new Player();

            const int PUNCH_DMG = 20;
            Console.WriteLine($"Punches {player.Name} for {PUNCH_DMG} damage!");
            player.HitPoints -= PUNCH_DMG;
            Thread.Sleep(2000);
            return player;
        }

        public static Player Kick(Player player)
        {
            if (player is null) player = new Player();

            const int KICK_DMG = 25;
            Console.WriteLine($"Kicks {player.Name} for {KICK_DMG} damage!");
            player.HitPoints -= KICK_DMG;
            Thread.Sleep(2000);
            return player;
        }

        public static Player Heal(Player player)
        {
            if (player is null) player = new Player();

            const int HEAL_HP = 30;
            Console.WriteLine($"Heals {player.Name} for {HEAL_HP} hitpoints!");
            player.HitPoints += HEAL_HP;
            Thread.Sleep(2000);
            return player;
        }
    }
}