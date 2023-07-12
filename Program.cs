using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Skynet
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            while (Menu()) ;
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar Eliminador");
            Console.WriteLine("2. Buscar Eliminador");
            Console.WriteLine("3. Mostrar Eliminadores");
            Console.WriteLine("4. Destruir SkyNet\n");

            switch (Console.ReadLine().Trim())
            {
                case "1":
                    IngresarEliminador();
                    break;
                case "2":
                    BuscarEliminador();
                    break;
                case "3":
                    ListarEliminadores();
                    break;
                case "4":
                    EliminarDB();
                    break;
                default:
                    Console.WriteLine("Ingrese una opción válida\n");
                    break;
            }

            return continuar;
        }
    }
}
