using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmerGrainGame { 

    enum Direction { North, South };

    class Farmer
{
    private Direction farmer;
    private List<string> northBank = new List<string>();
    private List<string> southBank = new List<string>();

    public Direction TheFarmer { get { return farmer; } set { farmer = value; } }
    public List<string> NorthBank { get { return northBank; } set { northBank = value; } }
    public List<string> SouthBank { get { return southBank; } set { southBank = value; } }


    public Farmer()
    {
        northBank.Add("FOX");
        northBank.Add("CHICKEN");
        northBank.Add("GRAIN");
        farmer = Direction.North;
    }

    public int AnimalAteFood()
    {
        int pick = 0;

        if (farmer == Direction.North && southBank.Count > 1)
        {
            for (int i = 0; i < southBank.Count; i++)
            {
                if (southBank[i] == "FOX") { pick = pick + 1; }
                if (southBank[i] == "CHICKEN") { pick = pick + 3; }
                if (southBank[i] == "GRAIN") { pick = pick + 5; }
            }
        }
        else if (farmer == Direction.South && northBank.Count > 1)
        {
            for (int i = 0; i < northBank.Count; i++)
            {
                if (northBank[i] == "FOX") { pick = pick + 1; }
                if (northBank[i] == "CHICKEN") { pick = pick + 3; }
                if (northBank[i] == "GRAIN") { pick = pick + 5; }
            }
        }

        if (DetermineWin()) { return 1; }
        else if (pick == 4 || pick == 8) { return pick; }
        else if (farmer == Direction.South && northBank.Count == 3 && pick == 9) { return 4; }
        else { return 0; }
    }

    public bool DetermineWin()
    {
        int pick = 0;

        for (int i = 0; i < southBank.Count; i++)
        {
            if (southBank[i] == "FOX") { pick = pick + 1; }
            if (southBank[i] == "CHICKEN") { pick = pick + 3; }
            if (southBank[i] == "GRAIN") { pick = pick + 5; }
        }

        if (pick == 9) { return true; }
        else { return false; }
    }

    public int Move(string carry)
    {
        int pick = 0;

        if (carry == "")
        {
            if (farmer == Direction.North) { farmer = Direction.South; }
            else if (farmer == Direction.South) { farmer = Direction.North; }
        }
        else if (farmer == Direction.North)
        {
            northBank.Remove(carry.ToUpper());
            southBank.Add(carry.ToUpper());
            farmer = Direction.South;
        }
        else if (farmer == Direction.South)
        {
            southBank.Remove(carry.ToUpper());
            northBank.Add(carry.ToUpper());
            farmer = Direction.North;
        }

        pick = AnimalAteFood();
        if (pick > 0)
        {
            northBank.Clear();
            southBank.Clear();
            farmer = Direction.North;
            northBank.Add("FOX");
            northBank.Add("CHICKEN");
            northBank.Add("GRAIN");
        }
        return pick;
    }
}
}

