

public class Group
{
    public List<Character> player_party { get; set; }
    public List<Character> AI_party { get; set; }

    public Group(Character character)
    {
        if (!character.NPC)
        {
            if (player_party == null)
                player_party = new List<Character>();
            player_party.Add(character);
            return;
        }
        else
        {
            if (AI_party == null)
                AI_party = new List<Character>();
            AI_party.Add(character);
            return; 
        }
    }
}


