using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOrdenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> aleatorios = new List<int>();
            int NumeroElementos = 0;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("------------------------Bienvenido------------------------");
            Console.WriteLine("----------------Proyecto de estrura de datos--------------");
            Console.WriteLine("Para empezar es necesario establecer el tamaño del arreglo");
            Console.WriteLine("Ingrese un numero(Minimo: 3, Maximo: 20)");
            while (NumeroElementos <= 2 && NumeroElementos <=20)
            {
                Console.Write("Número: ");
                string Lectura = Console.ReadLine();
                bool Numero = int.TryParse(Lectura, out NumeroElementos);
                if (!Numero || NumeroElementos <= 2 || NumeroElementos > 20)
                {
                    Console.WriteLine("Por favor digite un número que sea mayor que 2 pero menor o igual que 20");
                    Console.WriteLine("...........");
                    Console.Write('\n');
                    NumeroElementos = 0;
                }
            }
            Console.WriteLine("Establecio el tamaño del arreglo en : {0}", NumeroElementos);
            Console.WriteLine("Vamos a capturar los números...");
            
            for(int i=0; i<NumeroElementos; i++)
            {                
                aleatorios.Add(NuevoElemento(aleatorios, i));
            }
            Console.Clear();
            int Metodo = 0;
            bool VolverMenu = true;
            while (VolverMenu)
            {
                Console.WriteLine("------------------------Arreglo-------------------------");
                Console.Write("Arreglo ");
                ImprimirArreglo(aleatorios);
                Console.WriteLine("--------------------------Menú--------------------------");
                while (Metodo == 0)
                {
                    Console.WriteLine("Opciones disponibles.");
                    Console.WriteLine("1 -> Tabla de eficiencia");
                    Console.WriteLine("2 -> Busquedas");
                    Console.Write("Opcion: ");
                    string Lectura = Console.ReadLine();
                    bool Numero = int.TryParse(Lectura, out Metodo);
                    if (!Numero || Metodo < 0 || Metodo > 2)
                    {
                        Console.WriteLine("Por favor elija una opción del menú...");
                        Console.WriteLine("...........");
                        Console.Write('\n');
                        Metodo = 0;
                    }
                }
                Ordenamiento Metodos = new Ordenamiento();
                Console.WriteLine();
                if (Metodo == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------Tabla de eficiencia----------------------");
                    Console.Write("Arreglo ");
                    ImprimirArreglo(aleatorios);                  
                    Metodos.CuadroComparitivo(aleatorios);                    
                }
                else if (Metodo == 2)
                {
                    //int opcion = 0;
                    Console.WriteLine("-----------------------Busquedas-------------------------");                    
                    int ValorDeseado = 0;
                    bool band = true;
                    while (band)
                    {
                        band = false;
                        Console.WriteLine("Valor a buscar.");
                        Console.Write("Valor: ");
                        string Lectura = Console.ReadLine();
                        bool EsNumero = int.TryParse(Lectura, out ValorDeseado);
                        if (!EsNumero)
                        {
                            Console.WriteLine("No es un número");
                            Console.WriteLine("...........");
                            Console.Write('\n');
                            band = true;
                        }
                    }
                    int Posicion = 0;
                    Busqueda Busquedas = new Busqueda();

                    Posicion = Busquedas.Secuencial(aleatorios, ValorDeseado);

                   
                    Console.WriteLine("\n");

                    Console.WriteLine("-----------------Busqueda secuencial--------------------");
                    Console.WriteLine("Arreglo de entrada: ");
                    Console.Write("Arreglo ");
                    ImprimirArreglo(aleatorios);                    
                    if (Posicion < 0)//esto se movio
                        Console.WriteLine("No se encontro el valor");
                    else
                        Console.WriteLine("Se encontro el valor en la posición: {0}", Posicion + 1);
                    Console.WriteLine("\n");
                    Console.WriteLine("------------------Busqueda binaria----------------------");
                    Console.Write("Arreglo ordenado de forma ascendente: ");

                    var NuevoOrdenamiento = Metodos.Shell(aleatorios.Select(ele => ele).ToList());
                    ImprimirArreglo(NuevoOrdenamiento);
                    Console.WriteLine();                   
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Fin del proceso");
                int Volver = 0;
                while (Volver==0) {
                    Console.WriteLine("-------------------Desea volver al menú-----------------");
                    Console.WriteLine("1 -> SI");
                    Console.WriteLine("2 -> NO");
                    Console.WriteLine("3 -> SI Y LIMPIAR PANTALLA");
                    Console.Write("Opcion: ");
                    string Accion = Console.ReadLine();
                    bool Numero = int.TryParse(Accion, out Volver);
                    switch (Volver)
                    {
                        case 1:
                            Metodo = 0;
                            break;
                        case 2:
                            VolverMenu = false;
                            break;
                        case 3:
                            Metodo = 0;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Por favor elija una opción.");
                            Console.WriteLine("...........");
                            Console.Write('\n');
                            Volver = 0;
                            break;
                    }
                }
            }
            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

        }

        public static void ImprimirArreglo(List<int> arreglo)
        {
            Console.Write("[");

            foreach (int N in arreglo)
            {
                Console.Write(N);
                if (arreglo.IndexOf(N) < arreglo.Count - 1)
                    Console.Write(',');
            }
            Console.Write("]\n");
        }

        public static int NuevoElemento(List<int> Lista, int i)
        {
            int Elemento = -1;
            while (Elemento == -1)
            {
                Console.Write("Siguiente número ({0}): ", i + 1);
                string Lectura = Console.ReadLine();
                bool Numero = int.TryParse(Lectura, out Elemento);
                if (!Numero)
                {
                    Console.WriteLine("Por favor digite un número");
                    Console.WriteLine("...........");
                    Console.Write('\n');
                }
                if (Lista.Contains(Elemento))
                {
                    Console.WriteLine("Este elemento ya se encuentra en el arreglo.");
                    Console.WriteLine("...........");
                    Console.Write('\n');
                    Elemento = -1;
                }
            }
            return Elemento;
        }
    }
}
