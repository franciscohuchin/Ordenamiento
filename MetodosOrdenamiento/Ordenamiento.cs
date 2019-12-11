using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOrdenamiento
{
    public class Ordenamiento
    {

        private int IteracionesBurbuja = 0, CambiosBurbuja = 0;
        private int IteracionesQuicksort= 0, CambiosQuickSort=0;
        private int IteracionesShell=0, CambiosShell=0;
        public List<int> Burbuja(List<int> Lista)
        {            
            int Auxiliar;
            for (int i = 0; i < Lista.Count; i++)
            {
                for (int j = 0; j < Lista.Count - i -1; j++)
                {
                    IteracionesBurbuja++;
                    if (Lista[j] > Lista[j + 1])
                    {
                        CambiosBurbuja++;
                        Auxiliar = Lista[j];
                        Lista[j] = Lista[j + 1];
                        Lista[j + 1] = Auxiliar;
                    }
                }

            }
            return Lista;
        }

        public List<int> QuickSort(List<int> Lista)
        {
            if (Lista.Count < 1)
                return new List<int>();
            int Inicio = 0, Fin = 0, Posicion = 0, Auxiliar = 0, Derecha = 0, Izquierda = 0;
            bool Bandera = true;
            Derecha =
            Fin = Lista.Count - 1;
            while(Bandera)
            {
                Bandera = false;
                while (Lista[Posicion] <= Lista[Derecha] && Posicion != Derecha)
                {
                    IteracionesQuicksort++;
                    Derecha--;
                }
                if(Posicion != Derecha)
                {
                    IteracionesQuicksort++;
                    CambiosQuickSort++;
                    Izquierda = Posicion + 1;
                    Auxiliar = Lista[Posicion];
                    Lista[Posicion] = Lista[Derecha];
                    Lista[Derecha] = Auxiliar;
                    Posicion = Derecha;
                }
                while(Lista[Posicion]>=Lista[Izquierda] && Posicion != Izquierda)
                {
                    IteracionesQuicksort++;
                    Izquierda++;
                }
                if(Posicion != Izquierda)
                {
                    IteracionesQuicksort++;
                    CambiosQuickSort++;
                    Bandera = true;
                    Derecha = Posicion - 1;
                    Auxiliar = Lista[Posicion];
                    Lista[Posicion] = Lista[Izquierda];
                    Lista[Izquierda] = Auxiliar;
                    Posicion = Izquierda;
                    
                }
            }

            var izq = Lista.GetRange(0, Posicion);
            var der = Lista.GetRange(Posicion + 1, Fin - Posicion);

            return new List<int>().Concat(QuickSort( izq))
                                    .Concat(new List<int> { Lista[Posicion] })
                                    .Concat(QuickSort(der)).ToList();
        }

        public List<int> Shell(List<int> Lista)
        {
            IteracionesShell = 0;
            CambiosShell = 0;
            int Salto = Lista.Count;
            bool band = true;
            int Auxiliar = 0;
            while (band)
            {
                band = false;
                Salto = Salto / 2;
                if (Salto == 0)
                    Salto = 1;
                else band = true;
                for (int i = 0; i < Salto; i++)
                {
                    int j = Salto;
                    while (j < Lista.Count)
                    {
                        IteracionesShell++;
                        int inicio = j - Salto;
                        if (Lista[inicio] > Lista[j])
                        {
                            Auxiliar = Lista[inicio];
                            Lista[inicio] = Lista[inicio + Salto];
                            Lista[j] = Auxiliar;
                            band = true;
                            CambiosShell++;
                        }
                        j += Salto;
                    }
                }

            }
            return Lista;
        }

        public void CuadroComparitivo(List<int> Lista)
        {
            
            Console.WriteLine();
            Burbuja(Lista.Select(ele => ele).ToList());
            Shell(Lista.Select(ele => ele).ToList());
            QuickSort(Lista.Select(ele => ele).ToList());

            Console.WriteLine("Cuadro comparativo de los metodos de ordenamiento");

            Console.WriteLine("Nombre\t\tComparaciones\tCambios");
            Console.WriteLine("Burbuja\t\t{0}\t\t{1}", IteracionesBurbuja, CambiosBurbuja);
            Console.WriteLine("QuickSort\t{0}\t\t{1}", IteracionesQuicksort, CambiosQuickSort);
            Console.WriteLine("Shell\t\t{0}\t\t{1}", IteracionesShell, CambiosShell);

        }
    }
}
