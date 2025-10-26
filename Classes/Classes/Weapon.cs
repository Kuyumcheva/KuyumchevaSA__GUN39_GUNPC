
namespace Classes
{
    internal class Weapon
    {

        public string Name { get; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public float Durability { get; }

        public Weapon(string name)
        {
            Name = name;
            Console.WriteLine(Name);
            Durability = 1.0f;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            int temp;

            if(minDamage > maxDamage)
            {
                Console.WriteLine("Вы перепутали минимальный и максимальный урон");
                temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
            }

            if(minDamage < 1)
            {
                Console.WriteLine("Указанное значение минимального урона слишком маленькое, мы автоматически установили его в 1");
                minDamage = 1;
            }

            if(maxDamage <= 1)
            {
                Console.WriteLine("Указанное значение максимального урона слишком маленькое, мы автоматически установили его в 10");
                maxDamage = 10;
            }

            MinDamage = minDamage;
            MaxDamage = maxDamage;

        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage)/2;
        }

    }
}
