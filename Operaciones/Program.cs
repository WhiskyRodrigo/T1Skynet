using Admin.DAL;
using Admin.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class Program
    {
        static IEliminadorDAL eliminadorDAL = new IEliminadorDAL();

        static void IngresarEliminador()
        {
            string numeroDeSerie;
            string tipoEliminador;
            int prioridadEjecucion;
            string objetivo;
            uint fechaDestino;

            Eliminador eliminador = new Eliminador();

            //Validamos que el numero de serie sea correcto
            do
            {
                Console.WriteLine("\nIngrese Número de Serie");

                numeroDeSerie = Console.ReadLine().Trim();
                eliminador.NumeroDeSerie = numeroDeSerie;

                Console.WriteLine(eliminador.NumeroDeSerie.Equals(string.Empty) ? "ERROR: \nEl número se serie debe tener 7 caracteres" : "Número de serie aceptado. \nGuardando");
            } while (eliminador.NumeroDeSerie.Equals(string.Empty));
            do
            {
                Console.WriteLine("\nSeleccione el Tipo de Eliminador");
                Console.WriteLine("(a) T-1 \n(b) T-800\n(c) T-1000\n(d) T-3000");

                tipoEliminador = Console.ReadLine().Trim();
                eliminador.TipoEliminador = tipoEliminador;

                Console.WriteLine(eliminador.TipoEliminador.Equals("*") ? "ERROR: \nSeleccione un tipo válido" : "Tipo de Eliminador aceptado. \nGuardando");
            } while (eliminador.TipoEliminador.Equals("*"));
            do
            {
                Console.WriteLine("\nSeleccione prioridad de Ejecución...");
                Console.WriteLine("1-5 \n999 -> Otro");

                try { prioridadEjecucion = int.Parse(Console.ReadLine().Trim()); }
                catch { prioridadEjecucion = 0; }

                eliminador.PrioridadEliminacion = prioridadEjecucion;
                Console.WriteLine(eliminador.PrioridadEliminacion > 0 && eliminador.PrioridadEliminacion < 6 || eliminador.PrioridadEliminacion == 999 ? "Prioridad aceptada.\nGuardando" : "ERROR: \nIngrese un valor válido");
            }
            while (eliminador.PrioridadEliminacion == 0);
            //Validar que el numero ingresado de prioridad sea correcto
            do
            {
                Console.WriteLine("\nIngrese el Objetivo");

                objetivo = Console.ReadLine().Trim();
                eliminador.Objetivo = objetivo;

                Console.WriteLine(eliminador.Objetivo.Equals(string.Empty) ? "ERROR: \nIngerse un Objetivo válido." : "Objetivo aceptado. \nGuardando");
            } while (eliminador.Objetivo.Equals(string.Empty));

            do
            {
                Console.WriteLine("\nIngrese Año de destino\n(1997-3000)");

                try { fechaDestino = uint.Parse(Console.ReadLine().Trim()); }
                catch { fechaDestino = 0000; }

                eliminador.FechaDestino = fechaDestino;

                Console.WriteLine(eliminador.FechaDestino > 1997 && eliminador.FechaDestino < 3000 ? "Año aceptado\nGuardando" : "ERROR:\nAño no válido.");
            } while (eliminador.FechaDestino < 1997 || eliminador.FechaDestino > 3000);

            eliminadorDAL.AgregarEliminador(eliminador);
            Console.WriteLine("Registrando nuevo Eliminador\nEliminador registrado y operativo\n");
        }

        static void ListarEliminadores()
        {
            Console.WriteLine("\nEliminadores Disponibles");
            List<Eliminador> eliminadores = eliminadorDAL.ObtenerEliminadores();
            eliminadores.ForEach(e => Console.WriteLine(e.ToString()));
        }

        static void BuscarEliminador()
        {
            string tipoEliminador;
            uint fechaDestino;
            List<Eliminador> eliminadores = new List<Eliminador>();

            Eliminador eliminador = new Eliminador();

            Console.WriteLine("Buscando Eliminador");

            //Modelos Disponibles.
            do
            {
                Console.WriteLine("\nSeleccione el Tipo de Eliminador");
                Console.WriteLine("(a) T-1 \n(b) T-800\n(c) T-1000\n(d) T-3000");

                tipoEliminador = Console.ReadLine().Trim();
                eliminador.TipoEliminador = tipoEliminador;

                Console.WriteLine(eliminador.TipoEliminador.Equals("*") ? "ERROR: \nSeleccione un tipo válido" : "Tipo de Eliminador aceptado \nGuardando...");
            } while (eliminador.TipoEliminador.Equals("*"));

            //Validamos el ingreso de año  
            do
            {
                Console.WriteLine("\nIngrese Año de destino\n(1997-3000)");

                try { fechaDestino = uint.Parse(Console.ReadLine().Trim()); }
                catch { fechaDestino = 0000; }

                eliminador.FechaDestino = fechaDestino;

                Console.WriteLine(eliminador.FechaDestino > 1997 && eliminador.FechaDestino < 3000 ? "Año aceptado\nGuardando" : "ERROR:\nAño no válido.");
            } while (eliminador.FechaDestino < 1997 || eliminador.FechaDestino > 3000);

            eliminadores = eliminadorDAL.FiltrarEliminadores(eliminador.TipoEliminador, fechaDestino);

            Console.WriteLine("\nEliminadores Encontrados");
            eliminadores.ForEach(e => Console.WriteLine(e.ToString()));
        }

        static void EliminarDB()
        {
            Console.WriteLine("Base de datos Eliminada");
            eliminadorDAL.EliminarDB();
        }
    }


}
