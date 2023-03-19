

public class Combat
{
    public Combat(Group player, Group npc)
    {
        int action = 0;
        bool turn = true;
        Random rnd = new Random();
        int selection;
        int player_spot = 0;
        int npc_spot = 0;

        while ((player.player_party.Count > 0) && (npc.AI_party.Count > 0))

        {
            player_spot = 0;
            foreach (Character character in player.player_party)
            {
                if (turn)
                {
                    if (character.AI)
                    {

                        Attack(player, player_spot, npc, 0, false);
                        turn = false;
                    }
                    else
                    {
                        selection = ChooseTarget(npc);
                        action = SelectAction();
                        switch (action)
                        {
                            case 0:
                                DoNothing(character);
                                break;
                            case 1:
                                Attack(player, player_spot, npc, selection, false);
                                break;
                            default:
                                break;

                        }
                    }
                }
                player_spot++;
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            foreach (Character character in npc.AI_party)
            {
                if (character.AI)
                {
                    if (player.player_party.Count > 0)
                    {
                        Attack(npc, npc_spot, player, 0, true);
                        turn = true;
                    }
                }
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
        return;
    }

    public int ChooseTarget(Group npc)
    {
        int selection = 0;
        int count = 0;
        if (npc.AI_party.Count > 1)
        {
            Console.WriteLine("You are facing the following:");
            foreach (Character character in npc.AI_party)
            {
                Console.WriteLine($"{count}. {character.Name}");
                count++;
            }
            Console.WriteLine("Choose the target for your action: ");
            selection = Convert.ToInt32(Console.ReadLine());
        }
        return selection;
    }

    public int SelectAction()
    {
        int selection = 0;
        Console.WriteLine("Choose your preferred action:");
        Console.WriteLine("0. Do nothing");
        Console.WriteLine("1. Attack");
        selection = Convert.ToInt32(Console.ReadLine());
        return selection;
    }

    public void DoNothing(Character character)
    {
        Console.WriteLine($"It is {character.Name}'s turn...");
        Console.WriteLine($"{character.Name} did NOTHING.");
        Console.WriteLine();
    }

    public void Attack(Group attacker, int attacker_spot, Group defender, int defender_spot, bool AI)
    {
        int damage = 0;
        bool dead = false;
        Character attack;
        Character defend
;
        if (!AI)
        {
            attack = attacker.player_party[attacker_spot];
            defend = defender.AI_party[defender_spot];
        }
        else
        {
            attack = attacker.AI_party[attacker_spot];
            defend = defender.player_party[defender_spot];

        }
        Console.WriteLine($"It is {attack.Name}'s turn...");
        Console.WriteLine($"{attack.Name} used {attack.Attack_String} on {defend.Name}");
        damage = DetermineDamage(attack);
        defend.CurrentHP -= damage;
        if (defend.CurrentHP <= 0)
        {
            defend.CurrentHP = 0;
            dead = true;
        }
        Console.WriteLine($"{attack.Attack_String} dealt {damage} damage to {defend.Name}.");
        Console.WriteLine($"{defend.Name} is now at {defend.CurrentHP}/{defend.MaxHP} hp.");
        if (!AI)
            defender.AI_party[defender_spot] = defend;
        else
            defender.player_party[defender_spot] = defend;

        if (dead)
        {
            Console.WriteLine($"{defend.Name} has been defeated!");
            if (!AI)
                defender.AI_party.RemoveAt(defender_spot);
            else
                defender.player_party.RemoveAt(defender_spot);
        }
    }

    public int DetermineDamage(Character character)
    {
        Random rnd = new Random();
        int num = 0;
        if (character.Random_Hit)
        {
            num = rnd.Next(2);
            if (num == 0)
                return 0;
            else
                return character.Attack_Dmg;
        }
        return character.Attack_Dmg;
    }
}
