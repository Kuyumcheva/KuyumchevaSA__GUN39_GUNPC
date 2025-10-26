namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon knife = new Weapon("Нож");
            knife.SetDamageParams(0, 0);
            
            var knifeDamage = knife.GetDamage();
            Console.WriteLine("Урон: {0}", knifeDamage);

            Weapon dagger = new Weapon("Кинжал", 3, 9);
            var daggerDamage = dagger.GetDamage();
            Console.WriteLine("Урон: {0}", daggerDamage);

            Weapon sword = new Weapon("Меч", 10, 5);
            var swordDamage = sword.GetDamage();
            Console.WriteLine("Урон: {0}", swordDamage);

        }
    }
}
