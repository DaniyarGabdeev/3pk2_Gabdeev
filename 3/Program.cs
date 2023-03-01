using _3;

internal class Program
{
    static void Main(string[] args)
    {
        int sizeRoot = 3;
        Node root = new Node();
        BynaryTree tree = new BynaryTree(sizeRoot);
        root = tree.Root;
        Console.WriteLine("Все значения древа: ");
        BynaryTree.GetTreeData(tree.Root);
        //Задание 1
        Console.WriteLine("Среднее арифмитичиское значений древа: " + Math.Round(root.GetAverage(sizeRoot), 0));
        //Задание 2
        Console.WriteLine("Количесивр положительных корней: " + root.CountTRoot);
        Console.WriteLine("Количиство отрицательных корней: " + root.CountFRoot);
        //Задание 3
        Console.Write("Подсчитать повторяющиеся узлы в древе:");
        int FindRoot = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Количиство узлов с заданным значением " + FindRoot + " : " + root.FindNumberRoot(root, FindRoot));
    }
}