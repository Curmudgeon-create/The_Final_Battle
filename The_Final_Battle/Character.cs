

public class Character
{
    public string Name { get; set; }
    public bool AI { get; set; }
    public bool NPC { get; set; }
    public string Attack_String { get; set; } 
    public int Attack_Dmg { get; set; }
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public bool Random_Hit { get; set; }

    public Character(string name, bool ai, bool npc)
    {
        Name = name;
        AI = ai;
        NPC = npc;
        if (!NPC)
        {
            MaxHP = 25;
            CurrentHP = 25;
            Attack_String = "PUNCH";
            Attack_Dmg = 1;
            Random_Hit = false;
        }
        else
        {
            MaxHP = 5;
            CurrentHP = 5;
            Attack_String = "BONE CRUNCH";
            Attack_Dmg = 2;
            Random_Hit=true;
        }
    }

    public Character(string name, bool ai, bool npc,string attack_string, int attack_dmg,int maxhp, int currenthp, bool random_hit)
    {
        Name = name;
        AI = ai;
        NPC = npc;
        Attack_String = attack_string;
        Attack_Dmg = attack_dmg;
        MaxHP = maxhp;
        CurrentHP = currenthp;
        Random_Hit = random_hit;
    }

    public static Character Skeleton() => new Character("SKELETON", true, true, "BONE CRUNCH", 2, 5, 5, true);

    public static Character UncodedOne() => new Character("UNCODED ONE", true, true, "UNRAVELING", 2, 15, 15, true);
    
}




