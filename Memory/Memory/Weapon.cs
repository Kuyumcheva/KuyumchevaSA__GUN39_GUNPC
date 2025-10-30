using Memory;
public class Weapon
{
    public string Name { get; }

    public float Durability { get; }

    public Interval WeaponDamageInterval { get; private set; }

    public Weapon(string name)
    {
        Name = name;
        Durability = 1.0f;
        WeaponDamageInterval = new Interval(1, 10);
    }
    public Weapon(string name, int minDamage, int maxDamage) : this(name)
    {
        //SetDamageParams(minDamage, maxDamage);
        WeaponDamageInterval = new Interval(minDamage, maxDamage, $"{Name}");
    }

    public void SetDamageParams(int minDamage, int maxDamage)
    {
        int temp;

        if (minDamage > maxDamage)
        {
            Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Вы перепутали минимальный и максимальный урон для {0}. Значения поменяны местами.", Name);
            temp = minDamage;
            minDamage = maxDamage;
            maxDamage = temp;
        }

        if (minDamage < 1)
        {
            Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Указанное значение минимального урона для {0} слишком маленькое, мы автоматически установили его в 1", Name);
            minDamage = 1;
        }

        if (maxDamage <= 1)
        {
            Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Указанное значение максимального урона для {0} слишком маленькое, мы автоматически установили его в 10", Name);
            maxDamage = 10;
        }

        WeaponDamageInterval = new Interval(minDamage, maxDamage);
    }

    public int GetDamage()
    {
        return (int)((WeaponDamageInterval.Min + WeaponDamageInterval.Max) / 2);
    }
}
