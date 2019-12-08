using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOrdenamiento
{
    public class Busqueda
    {
        public int Secuencial(List<int> Lista, int Valor)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Valor == Lista[i])
                    return i;
            }
            return -1;
        }

        public int Binaria(List<int> Lista, int Valor)
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
                Sublista = Lista.GetRange(PuntoMedio, Lista.Count - PuntoMedio);
            }
            return Binaria(Sublista, Valor);
        }
    }
}
