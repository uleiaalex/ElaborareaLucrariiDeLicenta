using System;

class BacktrackingPC
{
    static string sir = "";
    static int statusSolve = 0;

    static void combinationUtil(int[] arr, int[] data, int start, int end, int index, int r)
    {
        string s = "";

        if (index == r) //Se afiseaza permutarile/combinarile
        {
            for (int j = 0; j < r; j++)
            {
                s += sir[data[j]];
            }
         
            Console.WriteLine(s);
            return;
        }

        if (statusSolve == 0) //Se genereaza Combinarile
        {
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1, end, index + 1, r);
            }

        }
        else if (statusSolve == 1)//Se genereaza Permutarile
        {
            for (int i = 0; i <= end; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1, end, index + 1, r);
            }
        }
    }

    static void Print(int[] arr, int n, int r)
    {
        int[] data = new int[r];
        combinationUtil(arr, data, 0, n - 1, 0, r);
    }


    static void Main(string[] args)
    {

        Console.WriteLine("Introdu sirul:");
        sir = Console.ReadLine(); //introducem sirul cu elemente care le vom permuta ex: {a,b,c,d,e}

        int[] arr = new int[sir.Length];

        for (int i = 0; i < sir.Length; i++)
        {
            arr[i] = i;
        }

        Console.WriteLine("Pentru combinari - introdu 1");
        Console.WriteLine("Pentru permutari - introdu 2");


        //alegem o optiune folosind variabila intermediara statusSolve
        int temp = int.Parse(Console.ReadLine());
        switch (temp)
        {
            case 1:
                statusSolve = 0;
                break;
            case 2:
                statusSolve = 1;
                break;
            default:
                break;
        }

        int n = arr.Length;

        //Luate cate r
        if (statusSolve == 0)
            Console.WriteLine("Combinari de {0} luate cate (trebuie sa fie mai mica ca {0})", n);
        else
            Console.WriteLine("Permutari de {0} luate cate (trebuie sa fie mai mica ca {0})", n);

        int r = int.Parse(Console.ReadLine());

        //Se verifica sa nu fi dar lui r o valoare mai mare a a lui n, lungimea maxima a sirului
        if (r >= 0 && r <= n)
            for (int j = 1; j <= r; j++)
            {
                Print(arr, n, j);
            }
        else
            Console.WriteLine("Nu poate fi r > n");
    }
}