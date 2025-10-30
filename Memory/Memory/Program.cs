
namespace Memory
{

    public struct Interval
    {
        private static Random _random = new Random(); 
        public float Min { get; }
        public float Max { get; }
        public float Get()
        {
            return Convert.ToSingle(_random.NextDouble()) * (Max - Min) + Min;
        }

        public Interval(int minValue, int maxValue, string context = "")
        {

            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
                Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Вы перепутали минимальный и максимальный урон для {0}. Значения поменяны местами.");
            }

            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Указанные значения максимального и минимального урона для {0} одинаковы, мы автоматически увеличили максимальный урон на 10", context);
            }

            if (minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Указанное значение минимального урона для {0} отрицательное, мы автоматически установили его в 0.", context);
            }

            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("[ПРЕДУПРЕЖДЕНИЕ] Указанное значение максимального урона для {0} отрицательное, мы автоматически установили его в 0.", context);
            }

            Min = minValue;
            Max = maxValue;
        }
    }

    public struct Room
    {
        public Unit Unit { get; }
        public Weapon Weapon { get; }

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    public class Dungeon
    {
        public Room[] _rooms = new Room[4];

        public Dungeon()
        {

            _rooms[0] = new Room(
                new Unit("Воин",4 ,4),
                new Weapon("Меч", 0, 0)
            );

            _rooms[1] = new Room(
             new Unit(),                            // Проверить как инициализируется юнит через констурктор без параметров
            new Weapon("Лук", -1, 12)
            );

            _rooms[2] = new Room(
                new Unit("Разбойник", 5, 10),
                new Weapon("Кинжал", 12, 18)
            );

            _rooms[3] = new Room(
                new Unit("Маг", 10, 18),
                new Weapon("Огненный посох", 8, 22)   
            );
           
        }


        public void ShowRooms()
        {
            for (int i = 0; i < _rooms.Length; i++)
            {
                var room = _rooms[i];
                Console.WriteLine();
                Console.WriteLine("Команата {0}", i + 1);
                Console.WriteLine("Юнит: {0}", room.Unit.Name);
                Console.WriteLine("Оружие: {0}", room.Weapon.Name);
                Console.WriteLine("Интервал урона юнита: {0} - {1}", room.Unit.UnitDamageInterval.Min, room.Unit.UnitDamageInterval.Max);
                Console.WriteLine("Интервал урона оружия: {0} - {1}", room.Weapon.WeaponDamageInterval.Min, room.Weapon.WeaponDamageInterval.Max);
                Console.WriteLine();

            }
        }

    }

    internal class Program
    {

        static void Main(string[] args)
        {
           Dungeon dungeon = new Dungeon();
           dungeon.ShowRooms();

        }
    }
}
