using System;
using System.Collections.Generic;

public class Player
{
    public List<string> Inventory { get; private set; }

    public Player()
    {
        Inventory = new List<string>();
    }

    public void Pickup(string item)
    {
        Inventory.Add(item);
        Console.WriteLine($"Du plockade upp: {item}");
    }

    public void ShowInventory()
    {
        if (Inventory.Count == 0)
        {
            Console.WriteLine("Din inventarie är tom.");
            return;
        }

        Console.WriteLine("Du har följande föremål:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
}
