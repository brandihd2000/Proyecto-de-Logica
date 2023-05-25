using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoPensamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Calculo básico y pensamiento lógico ===");
                Console.WriteLine("");
                Console.WriteLine("1. Valores Aleatorios");
                Console.WriteLine("2. números primos");
                Console.WriteLine("3. Emulador de Cajero automático");
                Console.WriteLine("4. Coincidencias");
                Console.WriteLine("");
                Console.Write("Selecciona una opción: ");
                string opcionPrincipal = Console.ReadLine();

                switch (opcionPrincipal)
                {
                    case "1":
                        Opcion1();
                        break;
                    case "2":
                        Opcion2();
                        break;
                    case "3":
                        Opcion3();
                        break;
                    case "4":
                        Opcion4();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presiona cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }


        //Valores Aleatorios
        static List<int> GenerarNumerosAleatorios(int cantidad = 5)
        {
            if (cantidad > 20)
                return null;

            Random random = new Random();
            List<int> numeros = new List<int>();

            while (numeros.Count < cantidad)
            {
                int numero = random.Next(1, 101); 

                if (!numeros.Contains(numero))
                {
                    numeros.Add(numero);
                }
            }

            return numeros;
        }

        //Valores Primos
        static List<int> GenerarNumerosPrimos(int cantidad = 9)
        {
            List<int> primos = new List<int>();
            int numero = 2;

            while (primos.Count < cantidad)
            {
                if (EsPrimo(numero))
                {
                    primos.Add(numero);
                }

                numero++;
            }

            return primos;
        }

        //Valores CajeroAutomatico
        static void CajeroAutomatico(decimal monto)
        {
            Dictionary<string, decimal> denominaciones = new Dictionary<string, decimal>
            {
              { "2000", 2000m },
              { "1000", 1000m },
              { "500", 500m },
              { "200", 200m },
              { "100", 100m },
              { "50", 50m },
              { "25", 25m },
              { "10", 10m },
              { "5", 5m },
              { "1", 1m }
            };
            Console.WriteLine("\nDesglose de billetes y monedas:");
            foreach (var denominacion in denominaciones)
            {
                decimal cantidad = Math.Floor(monto / denominacion.Value);
                if (cantidad > 0)
                {
                    Console.WriteLine("Cantidad: {0} | Denominacion:{1}", cantidad, denominacion.Key);
                    monto -= cantidad * denominacion.Value;
                }
            }

        }

        // Coincidencias
        static List<int> GenerarNumerosFibonacci()
        {
            List<int> aleatorios = GenerarNumerosAleatorios(20); 
            List<int> primos = new List<int>();
            List<int> fibonacci = new List<int>();

            foreach (int numero in aleatorios)
            {
                if (EsPrimo(numero))
                {
                    primos.Add(numero);
                }
            }
            int numeroMayor = primos.Max();
            fibonacci = Fibonacci(numeroMayor);
            Console.WriteLine("Numero Seleccionado: " + numeroMayor);
            Console.WriteLine("");
            return fibonacci;
        }


        static void Opcion1()
        {
            Console.WriteLine("=== Valores Aleatorios ===");
            Console.WriteLine("");
            Console.WriteLine("Ingresar la cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            List<int> aleatorios = GenerarNumerosAleatorios(cantidad);
            Console.WriteLine("");
            foreach (var aleatorio in aleatorios)
            {
                Console.WriteLine("numero: " + aleatorio);
            }
            Console.WriteLine("<== Presione una tecla para volver al menu ==>");
            Console.ReadKey();
        }

        static void Opcion2()
        {
            Console.WriteLine("=== Números Primos ===");
            Console.WriteLine("");
            Console.WriteLine("Ingresar la cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            List<int> primos = GenerarNumerosPrimos(cantidad);
            Console.WriteLine("");
            foreach (var primo in primos)
            {
                Console.WriteLine("numero: " + primo);
            }
            Console.WriteLine("<== Presione una tecla para volver al menu ==>");
            Console.ReadKey();
        }

        static void Opcion3()
        {
            Console.WriteLine("=== Emulador de Cajero automático ===");
            Console.WriteLine("");
            Console.WriteLine("Ingresar el monto: ");
            decimal monto = Convert.ToDecimal(Console.ReadLine());
            CajeroAutomatico(monto);
            Console.WriteLine("");
            Console.WriteLine("<== Presione una tecla para volver al menu ==>");
            Console.ReadKey();
        }

        static void Opcion4()
        {
            Console.WriteLine("=== Coincidencias ===");
            Console.WriteLine("");
            List<int> fibonacci = GenerarNumerosFibonacci();
            Console.WriteLine("");
            foreach (var num in fibonacci)
            {
                Console.WriteLine("numero: " + num);
            }
            Console.WriteLine("<== Presione una tecla para volver al menu ==>");
            Console.ReadKey();
        }
        static List<int> Fibonacci(int numero)
        {
            List<int> numeros = new List<int>();

            int a = 0;
            int b = 1;

            for (int i = 0; i < numero; i++)
            {
                numeros.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }

            return numeros;
        }
        static bool EsPrimo(int numero)
        {
            if (numero < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
