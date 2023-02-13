bool[,] M = new bool[4, 4]
{
    {false, true, false, true}, // матрица смежности графа G4
    {true, false, false, false},
    {true, true, false, true},
    {false, true, false, false}
};

    Graph graph = new Graph(4, M);
    graph.Depth(1);

public class Graph
{
    private int size; // количество вершин в графе
    private bool[,] adjacency; // матрица смежности графа
    private bool[] vector; // вектор посещенных вершин
    public int Size { get; set; }
    public bool[,] Adjacency { get; set; }
    public bool[] Vector { get; set; }

    public Graph(int size, bool[,] G) // конструктор класса «Графы»
    {
        Adjacency = new bool[size, size]; // инициализация матрицы смежности
        Adjacency = G;
        Vector = new bool[size];
        for (int i = 0; i < size; i++)
            Vector[i] = false; // иниц-я вектора посещенных вершин
        Size = size;
    }
    public void Depth(int i) //i – вершина, с которой начинается обход
    {
        Vector[i] = true; // отметить вершину i как обработанную
        Console.Write("{0}" + ' ', i); // распечатать номер посещенной вершины
        for (int k = 0; k < Size; k++) // найти первую встретившуюся ранее 
                                       //непосещенную вершину k, смежную с вершиной i
        if (Adjacency[i, k] && !(Vector[k]))
        Depth(k); // перейти к обработке вершины k
    }
}


