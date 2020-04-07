using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void turnudinhanoi()
    {
      
        char startCol = 'A';
        char endCol = 'C';
        char tempCol = 'B';
        int totalDiscuri = 3; 

        solveTowers(totalDiscuri, startCol, endCol, tempCol);

        void solveTowers(int n, char start, char end, char aux)
        {
            if (n > 0)
            {
                solveTowers(n - 1, start, aux, end);
                Console.WriteLine("Move disk from " + start + ' ' + end);
                solveTowers(n - 1, aux, end, start);

            }
        }
    }
    static void Main(string[] args)
    {
        turnudinhanoi();
        Console.ReadKey();
    }
}
