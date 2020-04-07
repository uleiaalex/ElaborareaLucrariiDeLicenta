using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sortari
{
    static Random rnd = new Random();
    static void Afisare(int[] v)
    {
        for (int i = 0; i < v.Length; i++)
        {
            Console.Write(v[i] + " ");
        }
        Console.WriteLine();
    }
    //BubbleSort
    static void Bubble_Sort(ref int[] v)
    {
        bool sortat = true;
        for (int i = 1; i < v.Length; i++)
        {
            sortat = true;
            for (int j = 1; j < v.Length-i+1; j++)
            {
                if (v[j] > v[j + 1])
                {
                    sortat = false;
                    int aux = v[j];
                    v[j] = v[j + 1];
                    v[j + 1] = aux;
                }
            }
        }
    }
    //InsertionSort
    static void Insertion_Sort(ref int[] v)
    {
        for (int i = 1; i < v.Length; ++i)
        {
            int V = v[i];
            int j = i - 1;
            while (j > 0 && v[j] > V)
            {
                v[j + 1] = v[j];
                --j;
            }
            v[j + 1] = V;
        }
    }
    //QuickSort // st = 0, dr = v.Length -1
    static int Partitie(int[] v, int st, int dr)
    {
        int poz = st + rnd.Next(0, dr - st + 1);
        int tmp = v[poz];
        v[poz] = v[st];
        v[st] = tmp;
        int V = v[st];
        --st; ++dr;
        while (st < dr)
        {
            do
                --dr;
            while (st < dr && v[dr] > V);
            do
                ++st;
            while (st < dr && v[st] < V);
            if (st < dr)
            {
                int aux = v[st];
                v[st] = v[dr];
                v[dr] = aux;
            }
        }
        return dr;
    }
    static void Quicksort(ref int[] v, int st, int dr) 
    {
        while (st < dr)
        {
            int P = Partitie(v, st, dr);
            if (P - st < dr - P - 1)
            {
                Quicksort(ref v, st, P);
                st = P + 1;
            }
            else
            {
                Quicksort(ref v, P + 1, dr);
                dr = P;
            }
        }
    }
    //MergeSort // st = 0, dr = v.Length -1
    static void Merge_sort(ref int[] v, int st, int dr)
    {
        if (st < dr)
        {
            int m = (st + dr) / 2;
            Merge_sort(ref v, st, m);
            Merge_sort(ref v, m + 1, dr);
            Interclasare(v, st, m, dr);
        }
    }
    static void Interclasare(int[] v, int st, int m, int dr)
    {
        int[] B = new int[dr - st + 2];
        int i = st, j = m + 1, k = 0;
        while (i <= m && j <= dr)
            if (v[i] <= v[j])
                B[++k] = v[i++];
            else
                B[++k] = v[j++];
        while (i <= m)
            B[++k] = v[i++];
        while (j <= dr)
            B[++k] = v[j++];
        for (i = 1; i <= k; ++i)
            v[st + i - 1] = B[i];
        //delete B;
    }
    //Selection Sort
    static void Selection_SortMin(ref int[] v)
    {
        for (int i = 0; i < v.Length-1; i++)
        {
            int min = i;
            for (int j = i + 1; j < v.Length; j++)
            {
                if (v[j] < v[min])
                {
                    min = j;
                }
            }
            int aux = v[min];
            v[min] = v[i];
            v[i] = aux;
        }
    }
    static void Selection_SortMax(ref int[] v)
    {
        for (int i = 0; i < v.Length - 1; i++)
        {
            int max = i;
            for (int j = i + 1; j < v.Length; j++)
            {
                if (v[j] > v[max])
                {
                    max = j;
                }
            }
            int aux = v[max];
            v[max] = v[i];
            v[i] = aux;
        }
    }

    static void Main(string[] args)
    {
        int[] v = { };

        Console.Write("Lungimea sirului de numere: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Introdu elementele in vector: ");

        for (int i = 0; i < n; i++)
        {
            Console.Write("v[" + i + "]= ");
            Array.Resize(ref v, v.Length + 1);
            v[v.Length - 1] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sirul initial: ");
        Afisare(v);

        Console.WriteLine("Sorteaza crescator cu urmatorii algoritmi: ");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Insertion Sort");
        Console.WriteLine("3. Quicksort Sort");
        Console.WriteLine("4. Merge Sort");
        Console.WriteLine("5. Selection Sort");
        Console.WriteLine("6. Close");

        int nr = int.Parse(Console.ReadLine());

        switch (nr)
        {
            case 1:
                Bubble_Sort(ref v);
                break;
            case 2:
                Insertion_Sort(ref v);
                break;
            case 3:
                Quicksort(ref v, 0, v.Length - 1);
                break;
            case 4:
                Merge_sort(ref v, 0, v.Length - 1);
                break;
            case 5:
                Selection_SortMin(ref v);
                break;
            default:
                Environment.Exit(0);
                break;
        }
        Afisare(v);
        Console.ReadKey();
    }
}

