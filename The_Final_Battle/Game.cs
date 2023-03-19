

public class Game
{
    public void GameSetup()
    {
        bool victory = true;

        Console.Write("Enter your characters name: ");
        string name = Console.ReadLine();

        //Add objects directly to Group objects
        Group playerGroup = new Group(new Character(name, true, false, Attacks.Punch()));
        Group aiGroup = new Group(Character.Skeleton());

        playerGroup.player_party.Add(new Character("VIN FLETCHER", true, true, Attacks.QuickShot()));

        //first encounter
        GameRun(playerGroup, aiGroup);
        if (playerGroup.player_party.Count > 0)
            Console.WriteLine("You won the first battle!");
        else
        {
            Console.WriteLine("You have lost and the Uncoded One's forces have prevailed!");
            victory = false;
        }
        if (victory)
        {
            //second encounter
            aiGroup.AI_party.Add(Character.Skeleton());
            aiGroup.AI_party.Add(Character.Skeleton());
            GameRun(playerGroup, aiGroup);
        }
        if (playerGroup.player_party.Count > 0)
            Console.WriteLine("You won the second battle!");
        else
        {
            Console.WriteLine("You have lost and the Uncoded One's forces have prevailed!");
            Console.WriteLine("GAME OVER!");
        }
        aiGroup.AI_party.Add(Character.UncodedOne());
        GameRun(playerGroup, aiGroup);
        if (playerGroup.player_party.Count > 0)
            Console.WriteLine("You won the final battle!");
        else
        {
            Console.WriteLine("You have lost and the Uncoded One's forces have prevailed!");
            Console.WriteLine("GAME OVER!");
        }

    }
    public void GameRun(Group player, Group ai)
    {
        new Combat(player, ai);
              
        return;
    }

}