using Admin.DAL;
using Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Skynet.Operaciones
{
    public partial class Program
    {
        static EliminadorDAL eliminadoresDAL = new EliminadorDAL();
        static void IngresarTerminator()
        {
            string num_serie;
            string tipo;
            Int32 destino;
            string objetivo;
            int prioridad;

            do
            {
                Console.WriteLine("Ingresar N° de Serie :");
                num_serie = Console.ReadLine().Trim();
                if (num_serie.Length == 7)
                {
                    esValido = true;
                }
                else
                {
                    Console.WriteLine("Debe tener 7 caracteres");
                    esValido = false;
                }
            } while (!esValido || num_serie.Equals(string.Empty));

            //Tipo
            do
            {
                textoTitulo("Ingrese Modelo :");
                Console.WriteLine(@"a) T-1
                                    b) T-800
                                    c) T-1000
                                    d) T-3000");
                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "a":
                        tipo = "T-1"; esValido = true;
                        break;
                    case "b":
                        tipo = "T-800"; esValido = true;
                        break;
                    case "c":
                        tipo = "T-1000"; esValido = true;
                        break;
                    case "d":
                        tipo = "T-3000"; esValido = true;
                        break;
                    default:
                        tipo = string.Empty;
                        Console.WriteLine("Ingresa bien una opción");
                        esValido = false;
                        break;
                }
            } while (!esValido);

            //Objetivo y prioridad
            do
            {
                Console.WriteLine("Ingrese objetivo:");
                objetivo = Console.ReadLine().Trim().ToLower();
                switch (objetivo)
                {
                    case "Objetivo 1":
                        prioridad = 1;
                        break;
                    case "Objetivo 2":
                        prioridad = 2;
                        break;
                    case "Objetivo 3":
                        prioridad = 3;
                        break;
                    case "Objetivo 4":
                        prioridad = 4;
                        break;
                    case "Objetivo 5":
                        prioridad = 5;
                        break;
                    default:
                        prioridad = 999;
                        break;
                }
            } while (objetivo.Equals(string.Empty));

            //Destino
            do
            {
                Console.WriteLine("Ingrese año de destino");
                esValido = Int32.TryParse(Console.ReadLine().Trim(), out destino);
                if (destino >= 1997 && destino <= 3000)
                {
                    esValido = true;
                }
                else
                {
                    esValido = false;
                    rojo("Debe estar entre 1997 y 3000");
                    Console.WriteLine();
                }
            } while (!esValido);

            Eliminador terminator = new Eliminador()
            {
                Num_serie = num_serie,
                Tipo = tipo,
                Destino = destino,
                Objetivo = objetivo,
                Prioridad = prioridad
            };
            eliminadoresDAL.AgregarEliminador(terminator);
        }
        static void MostrarTerminator()
        {
            //Limpiamos y cargamos ascii a la consola
            Console.Clear();
            imprimirAscii();
            rojo("--------------MOSTRAR TERMINATOR--------------");
            Console.WriteLine();

            //Lista para obtener los terminators y luego mostrar
            List<Eliminador> eliminadores = eliminadoresDAL.ObtenerEliminadores();
            for (int i = 0; i < eliminadores.Count(); i++)
            {
                Eliminador actual = eliminadores[i];
                (" Numero de serie:"); Console.Write(actual.Num_serie);
                (" Tipo[Modelo]:"); Console.Write(actual.Tipo);
                (" Objetivo:"); Console.Write(actual.Objetivo);
                (" Destino:"); Console.Write(actual.Destino);
                Console.WriteLine();
            }
            if (eliminadores.Count == 0)
            {
                Console.WriteLine("No se han creado Terminators");
            }
            Console.ReadLine();
        }
        static void BuscarTerminator()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            bool esValido = false;
            string buscar_tipo;
            Int32 buscar_destino;
            List<Eliminador> elim = eliminadoresDAL.ObtenerEliminadores();
            if (elim.Count == 0)
            {
               Console.WriteLine ("Aún no hay Terminators creados"); 
                Console.ReadLine();
            }
            else
            {
                bool reiniciar = false;
                do
                {
                    do
                    {
                        Console.Write("Ingresa tipo: ");
                        buscar_tipo = Console.ReadLine().Trim();
                    } while (buscar_tipo.Equals(string.Empty));
                    do
                    {
                        Console.Write("Ingresa año destino: ");
                        esValido = Int32.TryParse(Console.ReadLine().Trim(), out buscar_destino);
                    } while (!esValido);
                    List<Eliminador> eliminadores = new EliminadorDAL().FiltrarEliminadores(buscar_tipo, buscar_destino);
                    if (eliminadores.Count == 0)
                    {
                        Console.WriteLine("No hay coincidencias");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Spacebar)
                        {
                            reiniciar = true;
                        }
                        else
                        {
                            reiniciar = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        foreach (Eliminador e in eliminadores)
                        {
                            ("Numero de serie:"); Console.Write(e.Num_serie);
                            ("Tipo[Modelo]:"); Console.Write(e.Tipo);
                            ("Objetivo:"); Console.Write(e.Objetivo);
                            Console.WriteLine();
                            //Console.WriteLine("Numero de serie:{0}, Tipo(Modelo):{1}, Objetivo:{2}", e.Num_serie, e.Tipo, e.Objetivo);
                        }
                        reiniciar = false;
                        Console.ReadLine();

                    }
                } while (reiniciar);

            }


        
