using System;

public abstract class Command
{
    public string Name { get; }

    protected Command(string name)
    {
        Name = name;
    }

    public abstract void Execute(string argument);
}

public class HelpCommand : Command
{
    public HelpCommand() : base("help") { }

    public override void Execute(string argument)
    {
        Console.WriteLine("Tillgängliga kommandon:");
        Console.WriteLine("- help: visar tillgängliga kommandon");
        Console.WriteLine("- solve 'mystery': löser ett mysterium");
        Console.WriteLine("- examine 'object': undersöker ett objekt");
        Console.WriteLine("- talk 'message': säger något till en NPC");
        Console.WriteLine("- inventory: visar dina plockade föremål");
    }
}

public class SolveMysteryCommand : Command
{
    private Player player;

    public SolveMysteryCommand(Player player) : base("solve")
    {
        this.player = player;
    }

    public override void Execute(string argument)
    {
        if (string.IsNullOrEmpty(argument))
        {
            Console.WriteLine("Skriv namnet på mysteriet du vill lösa.");
            return;
        }

        Console.WriteLine($"Du försöker lösa mysteriet: '{argument}'...");
        // Logik för att lösa mysterier
    }
}

public class ExamineCommand : Command
{
    public ExamineCommand() : base("examine") { }

    public override void Execute(string argument)
    {
        if (string.IsNullOrEmpty(argument))
        {
            Console.WriteLine("Skriv namnet på objektet du vill undersöka.");
            return;
        }

        Console.WriteLine($"Du undersöker: '{argument}'. Det finns ledtrådar här.");
    }
}

public class TalkCommand : Command
{
    public TalkCommand() : base("talk") { }

    public override void Execute(string argument)
    {
        if (string.IsNullOrEmpty(argument))
        {
            Console.WriteLine("Skriv meddelandet du vill säga.");
            return;
        }

        Console.WriteLine($"Du säger: '{argument}'. En NPC ger dig information.");
    }
}

public class InventoryCommand : Command
{
    private Player player;

    public InventoryCommand(Player player) : base("inventory")
    {
        this.player = player;
    }

    public override void Execute(string argument)
    {
        player.ShowInventory();
    }
}
