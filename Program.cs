using System;
using Admin.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
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
            Console.WriteLine("3. Mostrar Eliminador");
            Console.WriteLine("4. Destruir Skynet\n");

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
                    Console.WriteLine("ERROR#404 OPCION NO VALIDA HUMANO!\n");
                    break;
            }

            return continuar;
        }
    }
}
