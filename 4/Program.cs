using _4;

class Program
{
    static void Main()
    {
        Random random = new Random();
        BinarySearchTree tree = new BinarySearchTree();

        // случайные значения 
        for (int i = 0; i < 10; i++)
        {
            int value = random.Next(10, 1001);
            tree.Add(value);

        }

        // Вычисление суммы значений в дереве
        int sum = tree.SumValues();
        //1 задание
        Console.WriteLine("1 Задание");
        Console.WriteLine("Сумма значений в дереве: " + sum);
        //2 задание
        Console.WriteLine("2 Задание");
        int count = tree.CountInternalNodes();
        Console.WriteLine("Количество внутренних узлов: " + count);
    }
}