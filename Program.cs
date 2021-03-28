using System;

namespace ChickenFarmerGrainGame
{
    class Program
    {
        static void Main(string[] args)
        {
            FarmerUI fui = new FarmerUI();
            Info i = new Info();
            
            i.DisplayInfo("#6 - The Chicken, Farmer & Grain Game");
            fui.PlayGame();

        }
    }
}
