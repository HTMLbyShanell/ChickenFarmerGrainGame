using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarmerGrainGame
{
    class FarmerUI
    {
        Farmer f = new Farmer();

        public FarmerUI() { }

        public void DisplayGameState()
        {
            DisplayNorthBank();
            DisplayRiver();
            DisplaySouthBank();
            Console.WriteLine("\nThe farmer is on the {0} Bank of the river.", f.TheFarmer);
        }

        public void DisplayNorthBank()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("******************************* NORTH BANK *************************************");
            Console.WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < f.NorthBank.Count; i++)
            {
                Console.Write(f.NorthBank[i]);
                Console.Write("  ");
            }
        }

        public void DisplayRiver()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~THE RIVER~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void DisplaySouthBank()
        {
            for (int i = 0; i < f.SouthBank.Count; i++)
            {
                Console.Write(f.SouthBank[i]);
                Console.Write("  ");
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            Console.WriteLine("******************************* SOUTH BANK *************************************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n\tThis is the Farmer, Chicken & Grain Game.  The object of the game");
            Console.WriteLine("\tis to get the farmer, fox, chicken, and grain to the other");
            Console.WriteLine("\tside of the river.  But hold on! Not so fast...  If the farmer");
            Console.WriteLine("\tleaves the chicken and grain on either side of the river alone,");
            Console.WriteLine("\tthe chicken will eat the grain and that is not good.  If the");
            Console.WriteLine("\tfarmer leaves the fox and chicken on any side of the river alone,");
            Console.WriteLine("\tthe fox will eat the chicken.  That is not good.  In either case");
            Console.WriteLine("\tyou will lose the game.  If you get the farmer, chicken,");
            Console.WriteLine("\tfox, and the grain safely across the river, you win!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nPress any key to play.");
            Console.ReadKey();
            Console.Clear();
        }

        public bool Play(int intro)
        {
            if (intro < 1) { DisplayWelcome(); }
            DisplayGameState();
            return PromptForMove();
        }

        public void PlayGame()
        {
            bool Start = true;
            int count = 0;

            while (Start)
            {
                Start = Play(count);
                count++;
            }
        }

        public bool PromptForMove()
        {
            string playAgain = "";
            string Choice = "";
            bool badChoice = true;
            int outcome = 0;

            Console.Write("\nChoose the next item for the farmer.  Press enter to choose nothing ");
            Choice = Console.ReadLine();
            if (Choice == "")
            {
                outcome = f.Move(Choice);
                badChoice = false;
            }
            else if (f.TheFarmer == Direction.North)
            {
                for (int i = 0; i < f.NorthBank.Count; i++)
                {
                    if (Choice.ToUpper() == f.NorthBank[i])
                    {
                        outcome = f.Move(Choice.ToUpper());
                        badChoice = false;
                        Choice = "";
                    }
                }
            }
            else if (f.TheFarmer == Direction.South)
            {
                for (int i = 0; i < f.SouthBank.Count; i++)
                {
                    if (Choice.ToUpper() == f.SouthBank[i])
                    {
                        outcome = f.Move(Choice.ToUpper());
                        badChoice = false;
                        Choice = "";
                    }
                }
            }

            Console.Clear();
            if (badChoice)
            {
                Console.WriteLine("\nThat item is not on this side of the river.");
                Console.WriteLine("Try again");
                return true;
            }
            else if (outcome == 1)
            {
                Console.WriteLine("\n\n\nYou Won!");
                Console.WriteLine("CONGRATULATIONS");
                Console.Write("\n\n\nWould you like to play again? ");
                playAgain = Console.ReadLine();
                if (playAgain != "" && playAgain.ToUpper()[0] == 'Y')
                {
                    Console.Clear();
                    return true;
                }
                else { return false; }
            }
            else if (outcome == 4)
            {
                Console.WriteLine("\n\n\n\n\n\nOh No! The Fox Ate the Chicken!");
                Console.WriteLine("You Lose");
                Console.Write("\n\n\nWould you like to play again? ");
                playAgain = Console.ReadLine();
                if (playAgain != "" && playAgain.ToUpper()[0] == 'Y')
                {
                    Console.Clear();
                    return true;
                }
                else { return false; }
            }
            else if (outcome == 8)
            {
                Console.WriteLine("\n\n\n\n\n\nOh No! The Chicken Ate the Grain!!");
                Console.WriteLine("You Lose");
                Console.Write("\n\n\nWould you like to play again? ");
                playAgain = Console.ReadLine();
                if (playAgain != "" && playAgain.ToUpper()[0] == 'Y')
                {
                    Console.Clear();
                    return true;
                }
                else { return false; }
            }
            else { return true; }
        }
    }
}

