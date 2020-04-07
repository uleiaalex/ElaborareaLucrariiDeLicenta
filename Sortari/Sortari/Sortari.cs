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
    //Verifica cate 2 elemente si se executa pana cand nu se va mai executa nici-o interschimbare pentru ordonare.
    static void Bubble_Sort(ref int[] v)
    {
        bool sortat = true; //Presupunem ca e sortat
        for (int i = 1; i < v.Length; i++)
        {
            sortat = true;
            for (int j = 1; j < v.Length-i+1; j++) //Se merge tot sirul, daca v[j]>v[j+1] atunci se interchimba iar atunci sortat devine fals,
                                                    //si mergem din nou sa verificam daca sirul este sortat
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
    //avem vector-ul v, daca toate elementele dinaintea lui x[i] este ordonata atunci inseram ca ultim element x[i]
    //iar secventa finala ordonata va fi 0, 1, ..., i-1,i, iar la final vectorul va fi ordonat
    static void Insertion_Sort(ref int[] v)
    {
        for (int i = 1; i < v.Length; ++i)
        {
            int elem = v[i];
            int j = i - 1;
            while (j > 0 && v[j] > elem) // se verifica daca elementele dinaintea pozitiei "i" sunt ordonate crescator si le ordoneaza in acelasi timp.
            {
                v[j + 1] = v[j];
                --j;
            }
            v[j + 1] = elem;
        }
    }
    //QuickSort // st = 0, dr = v.Length -1
    //Exista un pivot, elem. de la stanga la el sa fie mai mic decat el si la dr mai mare decat el.
    static int Partitie(int[] v, int st, int dr)
    {
        int poz = st + rnd.Next(0, dr - st + 1); // Se ia pozitia pivot la intamplare
        int tmp = v[poz];
        v[poz] = v[st];
        v[st] = tmp;
        int V = v[st];
        --st; ++dr;
        //Se reorganizeaza lista in functie de pivot a.i cele mai mici fata de pivot sunt inainte pivotului, iar cele
        //mai mari decat pivotul sa fie in partea dreapta.
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
            //Impartim vectorul in 2 subvectori aproximativ egali
            int m = (st + dr) / 2; // pivotul de mijloc
            //Se sorteaza cei doi subvectori recursiv tot cu algoritmul merge sort
            Merge_sort(ref v, st, m);
            Merge_sort(ref v, m + 1, dr);
            // iar la final cei doi vectori se interclaseaza si se optine vectorul final
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
    }
    //Selection Sort
    //Se verifica minimul, se compara cu restul elementelor, daca se gaseste alt minim atunci acesta devine minim
    //iar la final de sir se interschimba elementul i cu elementul de pe pozitia min.
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

