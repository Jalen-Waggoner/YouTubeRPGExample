using System.Runtime.ExceptionServices;
using System.Net.WebSockets;
using System;

public class ProgramUI {
    public static TJ currentPlayer = new TJ();
    public void Run(){
        
        RunMenu();
        Encounters.FirstEncounter();
    }

    public void RunMenu() {
    
    Console.Clear();
    Console.WriteLine("---------------Welcome to DragonBall TJ---------------\n" +
    "  Press any key to embark on this tale for the ages!");
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine("You wake up from an amazing nap atop a grassy knoll.");
    Console.ReadKey();
    Console.WriteLine("\"Wow\" you think to yourself, \"That was great! I really need to do that more often!\"");
    Console.ReadKey();
    Console.WriteLine("Wiping the sleep from your eyes you peer out across the valley below and something catches your eye.");
    Console.ReadKey();
    Console.WriteLine("\"Odd. Could that be? No surely it couldn't. Unless?\"");
    Console.ReadKey();
    
    Console.WriteLine("Do you go to inspect the anomaly or lay back down for another nap?\n" +
    "1. Charge!\n" +
    "2. Zzzzzz");
    string selection = Console.ReadLine();
    if (selection == "1"){
    
    Console.WriteLine("Uncertain yet determined, you tighten your gi, strap a Power Pole to your side," + 
    "and set your dreads in place before speeding down the hill towards your quarry.");
    } 
    else if (selection == "2") {
        Console.WriteLine("You fall flat on your back, stretch out your arms and then weave your fingers behind your head. Slowly drifting back to sleep wearing a grin from ear to ear.");
        Console.ReadKey();
        Console.WriteLine("Whatever it was at the bottom of the hill couldn't have been THAT important...");
        Console.ReadKey();
        System.Console.WriteLine("All of a sudden, you hear a CRASH coming from the direction of the anomaly!");
        Console.ReadKey();
        System.Console.WriteLine("Frustrated, you exclaim \"I can't sleep with all that ruckus!\" and you reluctantly get up with a yawn to investigate further.");
    } 
    else {
        Console.WriteLine("Please input a valid option.");
    }
    Console.ReadKey();
    Console.Clear();
}

    public class TJ {
        public string name = "Saiyan TJ";
        public int coins = 0;
        public int health = 9000;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;
    }

// private void WaitForKey() {
//     public bool Prompt;
//     Prompt prompt = new Prompt;
//     Console.ReadKey();
//     if (prompt = true){
//     Console.WriteLine("Press any key to continue...");
//     }
// }
    public class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic
        
        //Encounters
        public static void FirstEncounter() {
            Console.WriteLine("As you approach you quickly realize you were right to come here.\n" +
            "The thing you saw is Android 13! The muscle bound menace with a baseball cap made by the evil Dr.Gero!");
            Console.ReadKey();
            Console.WriteLine($"You square your jaw and set your gaze directly at Android 13. Daring him to take you on!");
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
                Console.WriteLine("ATK: " + p + "/" + " HP: " + h);
                Console.WriteLine("===================");
                Console.WriteLine("|(A)ttack (D)efend|");
                Console.WriteLine("| (H)eal   (R)un  |");
                Console.WriteLine("===================");
                Console.WriteLine($" Potions: {ProgramUI.currentPlayer.potion}  Health: {ProgramUI.currentPlayer.health}");
                System.Console.WriteLine("(E)xit");

                
                string input = Console.ReadLine();

                if(input.ToLower() == "a" || input.ToLower() == "attack"){
                    
                    //Attack
                    int damage = p - ProgramUI.currentPlayer.armorValue;
                    if (damage < 0) {
                    damage = 0;} 
                    int attack = rand.Next(0, ProgramUI.currentPlayer.weaponValue) + rand.Next(1,4);
                    
                    Console.WriteLine($"You swipe horizontally with your Power Pole! Delivering a staggering blow that deals {damage}");
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
                    
                    Console.WriteLine($"You puff up your chest while taunting with an outstretched hand. Ready and willing to accept the blow from {n}.");
                    Console.WriteLine($"{n} lashes out in frustration! Dealing a glancing blow while taking {attack} damage due to their sloppiness.    You lose {damage} health");
                    ProgramUI.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if(input.ToLower() == "E" || input.ToLower() == "Exit"){
                    //Exit
                    h = 0;
                }
                
                else if(input.ToLower() == "h" || input.ToLower() == "heal"){
                    //Heal
                    if (ProgramUI.currentPlayer.potion == 0) {
                        int damage = p - ProgramUI.currentPlayer.armorValue;
                        Console.WriteLine("You desperately grab at your knapsack rummaging for a healing potion but you're all out!");
                        Console.WriteLine($"Seizing the opportunity, {n} strikes hard and fast dealing {damage}!");
                        if (damage < 0 ) {
                            damage = 0;}
                    } else {
                        Console.WriteLine("You reach into your knapsack and pop the cork off a healing potion. You chug it like a white claw and smash the glass on the ground.");
                        int potionV = 5;
                        Console.WriteLine($"You gain {potionV} health");
                        ProgramUI.currentPlayer.health += potionV;
                        Console.WriteLine($"Mid chug {n} jabs forward!");
                        int damage = (p / 2) - ProgramUI.currentPlayer.armorValue;
                        if (damage < 0 ) {
                            damage = 0;}
                        ProgramUI.currentPlayer.potion -= 1;
                        Console.WriteLine($"You loose {damage} health");
                        }
                    }
                else if(input.ToLower() == "r" || input.ToLower() == "run"){

                    //Run
                    int damage = (p*10) - ProgramUI.currentPlayer.armorValue;
                    if (damage < 0){
                        damage = 0;}

                        System.Console.WriteLine("You try to run from combat, but are thwarted in your attempt!");
                        System.Console.WriteLine("\"You can't run from me!\"");
                        System.Console.WriteLine($"You've taken {damage} damage!");
                        ProgramUI.currentPlayer.health -= damage;
                }
                Console.ReadKey();
                }
            }
        }
    }
    
