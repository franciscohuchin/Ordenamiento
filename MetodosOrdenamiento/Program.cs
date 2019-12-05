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
                int Elemento = 0;
                while (Elemento == 0)
                {
                    Console.Write("Siguiente número ({0}): ", i + 1);
                    string Lectura = Console.ReadLine();
                    bool Numero = int.TryParse(Lectura, out Elemento);
                    if(!Numero)
                    {
                        Console.WriteLine("Por favor digite un número");
                        Console.WriteLine("...........");
                        Console.Write('\n');
                    }
                }
                aleatorios.Add(Elemento);
            }
            Console.Write("El vector capturado es: [");
            foreach (int N in aleatorios)
            {
                Console.Write(N);
                if (aleatorios.IndexOf(N) < aleatorios.Count - 1)
                    Console.Write(',');
            }
            Console.Write("]\n");
            Console.WriteLine("--------------------------------------------------------");
           
            int Metodo = 0;
            bool VolverMenu = true;
            while (VolverMenu)
            {

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
                List<int> Ordenados = null;
                Ordenamiento Metodos = new Ordenamiento();
                Console.WriteLine();
                if (Metodo == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------Tabla de eficiencia----------------------");
                    Metodos.CuadroComparitivo(aleatorios);
                }
                else if (Metodo == 2)
                {
                    int opcion = 0;
                    Console.WriteLine("---------------------Busquedas------------------------");

                    while (opcion == 0)
                    {
                        Console.WriteLine("Seleccione una opción.");
                        Console.WriteLine("1 -> Secuencial");
                        Console.WriteLine("2 -> Binaria");
                        Console.Write("Opcion: ");
                        string Lectura = Console.ReadLine();
                        bool EsNumero = int.TryParse(Lectura, out opcion);
                        if (!EsNumero || opcion <= 0 || opcion > 2)
                        {
                            Console.WriteLine("Por favor elija una opción.");
                            Console.WriteLine("...........");
                            Console.Write('\n');
                            opcion = 0;
                        }
                    }
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
                    if (opcion == 1)
                    {
                        Console.Write("Arreglo [");

                        foreach (int N in aleatorios)
                        {
                            Console.Write(N);
                            if (aleatorios.IndexOf(N) < aleatorios.Count - 1)
                                Console.Write(',');
                        }
                        Console.Write("]\n");

                        Posicion = BusquedaSecuencial(aleatorios, ValorDeseado);

                    }
                    if (opcion == 2)
                    {
                        Console.Write("Arreglo ordenado  [");

                        var NuevoOrdenamiento = Metodos.Shell(aleatorios.Select(ele => ele).ToList());
                        foreach (int N in NuevoOrdenamiento)
                        {
                            Console.Write(N);
                            if (NuevoOrdenamiento.IndexOf(N) < NuevoOrdenamiento.Count - 1)
                                Console.Write(',');
                        }
                        Console.Write("]\n");
                        Posicion = BusquedaBinaria(NuevoOrdenamiento, ValorDeseado);
                        if (Posicion > -1)
                        {
                            Posicion = NuevoOrdenamiento.IndexOf(ValorDeseado);
                        }
                    }
                    if (Posicion < 0)
                        Console.WriteLine("No se encontro el valor");
                    else
                        Console.WriteLine("Se encontro el valor en la posición: {0}", Posicion + 1);
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Fin del proceso");
                int Volver = 0;
                while (Volver==0) {
                    Console.WriteLine("-------------------Desea volver al menú-----------------");
                    Console.WriteLine("1 -> SI");
                    Console.WriteLine("2 -> NO");
                    Console.Write("Opcion: ");
                    string Accion = Console.ReadLine();

                    bool Numero = int.TryParse(Accion, out Volver);
                    if (!Numero || Volver < 0 || Volver > 2)
                    {
                        Console.WriteLine("Por favor elija una opción.");
                        Console.WriteLine("...........");
                        Console.Write('\n');
                        Volver = 0;
                    }
                }
                if(Volver == 2)
                {
                    VolverMenu = false;
                }
                else
                {
                    Metodo = 0;
                }

            }
            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

        }
        public static int BusquedaSecuencial(List<int> Lista, int Valor)
        {
            for(int i=0; i<Lista.Count; i++)
            {
                if (Valor == Lista[i])
                    return i;
            }
            return -1;
        }

        public static int BusquedaBinaria(List<int> Lista, int Valor)
        {
            if (Lista.Count == 0) return -1;
            int PuntoMedio = (Lista.Count + 1) / 2;

            int indice = PuntoMedio - 1;           
            List<int> Sublista = new List<int>();

            if (Lista[indice] == Valor) return indice;
            if (Valor < Lista[indice])
            {
               Sublista = Lista.GetRange(0, indice);
            }
            else
            {
                Sublista =Lista.GetRange(PuntoMedio, Lista.Count - PuntoMedio);
            }
            return BusquedaBinaria(Sublista, Valor);
        }
    }
}
