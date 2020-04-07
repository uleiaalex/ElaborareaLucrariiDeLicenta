using System;

class Program
{

    //Turnurile din Hanoi pentru un numar limita de 3 tije asezate in ordine descrescatoare de jos in sus
    static void turnudinhanoi()
    {
      
        char startCol = 'A';//  Prima tija
        char endCol = 'C';//    tija finala/destinatia
        char tempCol = 'B';//   tija de ajutor/auxiliara
        int totalDiscuri = 3;// numarul finit de discuri

        rezolva(totalDiscuri, startCol, endCol, tempCol);

        void rezolva(int n, char start, char end, char aux)//Afisam reucursiv mutarile care se fac de pe o tija pe alta...
        {
            if (n > 0)
            {
                rezolva(n - 1, start, aux, end);
                Console.WriteLine("Move disk from " + start + ' ' + end);
                rezolva(n - 1, aux, end, start);
            }
        }
    }
    static void Main(string[] args)
    {
        //Chemam functia turnurile din hanoi
        turnudinhanoi();
        Console.ReadKey();
    }
}
