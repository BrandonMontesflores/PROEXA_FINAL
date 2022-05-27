using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ProyectoSnake.Colas.ColaCircular
{
    class ColaCircular
    {
        public int final;
        private static int MAX = 90000;
        protected int inicio;
        int tamano;

        protected Object[] listaCola;

        public ColaCircular()
        {
            inicio = 0;
            final = MAX - 1;
            listaCola = new Object[MAX];
        }

        private int Siguiente(int n)
        {
            return (n + 1) % MAX;
        }
     
        public bool ColaVaciaC()
        {
            return inicio == Siguiente(final);
        }
        
        public bool ColaLlenaC()
        {
            return final == Siguiente(Siguiente(final));
        }

        public void insertar(Object elemento)
        {
            if (!ColaLlenaC())
            {
                final = Siguiente(final);
                listaCola[final] = elemento;
                tamano++;
            }
            else
            {
                throw new Exception("ESTAS EN OVERFLOW");
            }
        }

        public Object Eliminar()
        {
            if (!ColaVaciaC())
            {
                Object tm = listaCola[inicio];
                inicio = Siguiente(inicio);
                tamano--;
                return tm;
            }
            else
            {
                throw new Exception("COLA VACIA");
            }
        }

        public void BorrarCola()
        {
            inicio = 0;
            final = MAX - 1;
            listaCola = new Object[MAX];
        }

        public Object frenteCola()
        {
            if (!ColaVaciaC())
            {
                return listaCola[inicio];
            }
            else
            {
                throw new Exception("COLA VACIA");
            }
        }

        public Object FinaColaCircular()
        {

            if (!ColaVaciaC())
            {
                return listaCola[final];
            }
            else
            {
                throw new Exception("COLA VACIA");
            }

        }

        public int Tam()
        {
            return tamano;
        }

        public bool Any(Point dato)
        {
            int i = 0, cont = 0;
            bool flag;
            while (i <= final)
            {
                Point a = (Point)listaCola[i];
                flag = ((a.X == dato.X) && (a.Y == dato.Y));
                int z = (flag == true) ? cont++ : cont + 0;
            }
            return (cont != 0) ? true : false;
        }
    }
}
