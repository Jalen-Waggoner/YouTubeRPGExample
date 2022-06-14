using System.Data;

using System;
namespace EpicAdventure
{
    public class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic
        
        //Encounters
        public static void FirstEncounter() {
            Console.WriteLine("As you approach you quickly realize you were right to come here.\n" +
            "The thing you saw is Android 13! The muscle bound menace with a baseball cap made by the evil Dr.Gero!");
            Console.ReadKey();
            Combat(false, "Android 13", 1, 4);
        }
        
        //Encounter Tools
        public static void Combat(bool random, string name, int power, int health) {
            string n = "";
            int p = 0;
            int h = 0;
            
            if (random){

            } else {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0 ) {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("===================");
                Console.WriteLine("|(A)ttack (D)efend|");
                Console.WriteLine("|     (H)eal      |");
                Console.WriteLine("===================");
                Console.WriteLine($" Potions: {ProgramUI.currentPlayer.potion}  Health: {ProgramUI.currentPlayer.health}");
                
                string input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack"){
                    
                    //Attack
                    int damage = p - ProgramUI.currentPlayer.armorValue;
                    if (damage < 0) {
                    damage = 0;} 
                    int attack = rand.Next(0, ProgramUI.currentPlayer.weaponValue) + rand.Next(1,4);
                    
                    Console.WriteLine($"You swipe horizontally with your Power Pull! Delivering a staggering blow that deals {damage}");
                    Console.WriteLine($"{n} follows up with their own attack!    You lose {damage} health");
                    ProgramUI.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if(input.ToLower() == "d" || input.ToLower() == "defend"){
                    //Defend
                    int damage = (p/4) - ProgramUI.currentPlayer.armorValue;
                    if (damage < 0) {
                    damage = 0;}
                    int attack = rand.Next(0, ProgramUI.currentPlayer.weaponValue) + rand.Next(1,4);
                    
                    Console.WriteLine($"You puff up your chest while taunting with an outstretched hand. Ready and willing to accept the blow from {n}");
                    Console.WriteLine($"{n} lashes out in frustration! Dealing a glancing blow while taking {attack} damage due to their sloppiness.    You lose {damage} health");
                    ProgramUI.currentPlayer.health -= damage;
                    h -= attack;
                }
                
                else if(input.ToLower() == "h" || input.ToLower() == "heal"){
                    //Heal
                    int damage = p - ProgramUI.currentPlayer.armorValue;
                    if (ProgramUI.currentPlayer.potion == 0) {
                        Console.WriteLine("You desperately grab at your knapsack rummaging for a healing potion but you're all out!");
                        Console.WriteLine($"Seizing the opportunity, {n} strikes hard and fast dealing {damage}!");
                    } else {
                        Console.WriteLine("You reach into your knapsack and pop the cork off a healing potion. You chug it like a white claw and smash the glass on the ground.");
                        int potionV = 5;
                        Console.WriteLine($"You gain {potionV} health");
                    }
                    ProgramUI.currentPlayer.health += damage;
                }
                Console.ReadKey();
            }
        }
    }
}