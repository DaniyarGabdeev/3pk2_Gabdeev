using System.Collections;
using System.Diagnostics;
internal class Program
{
    internal class Timing
    {
        TimeSpan ad;
        TimeSpan[] da;
        public Timing()
        {
            ad = new TimeSpan(0);
            da = new TimeSpan[Process.GetCurrentProcess().Threads.Count];
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < da.Length; i++)
                da[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime()
        {
            TimeSpan tmp;
            for (int i = 0; i < da.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(da[i]);
                if (tmp > TimeSpan.Zero)
                    ad = tmp;
            }
        }
        public TimeSpan Result()
        {
            return ad;
        }
    }
    //Метод прямого поиска
    static int SimpleSerch(int[] a, int x)
    {
        int i = 0;
        while (i < a.Length && a[i] != x)
            i++;
        if (i < a.Length)
        {
            return i;
        }
        else
        {
            return -1;
        }
    }
    //Бинарный поиск
    static int SearchBinary(int[] a, int x)
    {
        int middle, left = 0, right = a.Length - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Length)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((a[middle] != x) && (left <= right));
        if (a[middle] == x)
            return middle;

        else
            return -1;
    }
    //Поиск прямым способом для списка
    static int SimpleSearch_list(List<int> a, int x)
    {
        int i = 0;
        while (i < a.Count && a[i] != x) i++;
        if (i < a.Count)
        {
            return i;
        }
        else
        {
            return -1;
        }
    }
    //Бинарный поиск для списка
    static int SearchBinary_list(List<int> a, int x)
    {
        int middle, left = 0, right = a.Count - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Count)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((a[middle] != x) && (left <= right));
        if (a[middle] == x)
            return middle;

        else
            return -1;
    }
    //Поиск для хэш таблиц
    static int SimpleSearch_hash(Hashtable a, int x)
    {
        int i = 0;
        while (i < a.Count && Convert.ToInt32(a[i]) != x) i++;
        if (i < a.Count)
        {
            return i;
        }
        else
        {
            return -1;
        }
    }
    //Бинарный поиск для хэш таблиц
    static int SearchBinary_hash(Hashtable a, int x)
    {
        int middle, left = 0, right = a.Count - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Count)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((Convert.ToInt32(a[middle]) != x) && (left <= right));
        if (Convert.ToInt32(a[middle]) == x)
            return middle;

        else
            return -1;
    }

    private static void Main(string[] args)
    {
        int a = -1;
        int b = -1;
        Random rand = new Random();
        int[] array = new int[7560];
        for (int num = 0; num < array.Length; num++)
        {
            array[num] = rand.Next(1, 4315);

        }
        List<int> list = new List<int>(7560);
        for (int j = 0; j < 5000; j++)
        {
            list.Add(rand.Next(1, 4315));
        }

        Hashtable hash = new Hashtable();

        for (int i = 0; i < 7560; i++)
        {
            hash.Add(i, rand.Next(1, 4315));
        }

        Stopwatch stpWatch = new Stopwatch();
        Timing timing = new Timing();
        stpWatch.Start();

        Console.WriteLine("Поиск хэш таблиц");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSearch_hash(hash, 56);

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SimpleSearch_hash(hash, 56); ;
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");

        Console.WriteLine("Поиск массивов");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSerch(array, 56);

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SearchBinary(array, 56);
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");

        Console.WriteLine("Поиск списков");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSearch_list(list, 56);

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SearchBinary_list(list, 56);
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");
    }
}


