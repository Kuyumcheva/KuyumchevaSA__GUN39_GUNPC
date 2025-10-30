using Memory;

public class Unit
{
    private float _health;
    
    public string Name { get; }
    
    public float Health => _health;
    
    public Interval UnitDamageInterval { get; private set; }
    
    public float Armor { get; }
    public Unit(string name)
    {
        Name = name;
        UnitDamageInterval = new Interval(0, 5);
        Armor = 0.6f;
        _health = 100.0f;
    }

    public Unit() : this("Unknown Unit") { }
    
    public Unit(string name, int minDamage, int maxDamage) : this(name)
    {
        UnitDamageInterval = new Interval(minDamage, maxDamage, $"{Name}");
    }

    public float GetRealHealth()
    {
        return _health * (1f + Armor);
    }

    public bool SetDamage(float value)
    {
        _health -= value * Armor;
        return _health <= 0f;
    }
    
}
