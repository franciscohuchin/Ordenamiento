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
                IteracionesBurbuja++;
                for (int j = 0; j < Lista.Count - 1; j++)
                {
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
            List<int> Izquierda = new List<int>();//Los valores que son menores
            List<int> Derecha = new List<int>();//Los valores que son mayores
            if (Lista.Count < 1)
                return new List<int>();
            IteracionesQuicksort++;
            int Pivote = Lista[0];//El pivote sera siempre el primer elemento
            for (int i = 1; i < Lista.Count; i++)
            {
                if (Pivote > Lista[i])
                {
                    CambiosQuickSort++;
                    Izquierda.Add(Lista[i]);
                }
                else
                {
                    CambiosQuickSort++;
                    Derecha.Add(Lista[i]);
                }
            }
            return new List<int>().Concat(QuickSort(Izquierda))//agregamos los menores
                                    .Concat(new List<int> { Pivote })//agregamos el numero actual
                                    .Concat(QuickSort(Derecha)).ToList();//agregamos los mayores
        }

        public List<int> Shell(List<int> Lista)
        {
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
                    IteracionesShell++;
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

            Console.WriteLine("Nombre\t\tIteraciones\tCambios");
            Console.WriteLine("Burbuja\t\t{0}\t\t{1}", IteracionesBurbuja, CambiosBurbuja);
            Console.WriteLine("QuickSort\t{0}\t\t{1}", IteracionesQuicksort, CambiosQuickSort);
            Console.WriteLine("Shell\t\t{0}\t\t{1}", IteracionesShell, CambiosShell);

        }
    }
}
