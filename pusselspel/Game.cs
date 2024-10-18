using System;
using System.Collections.Generic;

public class Game
{
    private Player player;
    private List<Command> commands;

    public Game()
    {
        player = new Player();
        commands = new List<Command>
        {
            new HelpCommand(),
            new SolveMysteryCommand(player),
            new ExamineCommand(),
            new TalkCommand(),
            new InventoryCommand(player)
        };
    }

    public void Start()
    {
        Console.WriteLine("Välkommen till det försvunna arvet! Lös mysterier för att upptäcka sanningen.");
        Console.WriteLine("Skriv 'help' för att se tillgängliga kommandon.");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            ExecuteCommand(input);
        }
    }

    private void ExecuteCommand(string input)
    {
        string[] parts = input.Split(' ', 2);
        string commandName = parts[0].ToLower();

        foreach (var command in commands)
        {
            if (command.Name == commandName)
            {
                command.Execute(parts.Length > 1 ? parts[1] : "");
                return;
            }
        }

        Console.WriteLine("Okänt kommando. Skriv 'help' för hjälp.");
    }
}
