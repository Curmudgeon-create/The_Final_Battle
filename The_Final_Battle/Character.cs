

public class Character
{
    public string Name { get; set; }
    public bool AI { get; set; }
    public bool NPC { get; set; }
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public Attacks Attack { get; set; }

    public Character(string name, bool ai, bool npc, Attacks attack)
    {
        Name = name;
        AI = ai;
        NPC = npc;
        if (!NPC)
        {
            MaxHP = 25;
            CurrentHP = 25;
        }
        else
        {
            MaxHP = 5;
            CurrentHP = 5;
        }
        Attack = attack;
    }

    public Character(string name, bool ai, bool npc, int maxhp, int currenthp, Attacks attack)
    {
        Name = name;
        AI = ai;
        NPC = npc;
        MaxHP = maxhp;
        CurrentHP = currenthp;
        Attack = attack;    
    }

    public static Character Skeleton() => new Character("SKELETON", true, true, 5, 5, Attacks.BoneCrunch());

    public static Character UncodedOne() => new Character("UNCODED ONE", true, true, 15, 15, Attacks.UnRavel());
    
}




