public class Attacks
{ 
    public string Name { get; set; }
    public int Damage { get; set; }
    public double Ratio { get; set; }

    public Attacks (string name, int damage, double ratio)
    {
        Name = name;
        Damage = damage;
        Ratio = ratio;
    }

    public static Attacks Punch() => new Attacks("PUNCH", 1, 1);
    public static Attacks BoneCrunch() => new Attacks("BONE CRUNCH", 2,0.5);
    public static Attacks UnRavel() => new Attacks("UNRAVEL", 2, 0.5);
    public static Attacks QuickShot() => new Attacks("QUICK SHOT", 3, 0.5);

}