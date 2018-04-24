using System;

using TestWcf.ServiceReference1;

namespace TestWcf
{
    class Program
    {
        static void Main(string[] args)
        {
            BiblioWcfClient client = new BiblioWcfClient("BasicHttpBinding_IBiblioWcf");
          
            var val =client.CumparaCarte(new AchizitieCarte
            {
                Titlu = "aaaaaa",
                Descriere = "aaaaaa",
                NumarCarti = 2,
                NumeAutor = "aaaaaa",
                PrenumeAutor = ""
            });
            Console.WriteLine(val);
            Console.Read();
        }
    }
}
