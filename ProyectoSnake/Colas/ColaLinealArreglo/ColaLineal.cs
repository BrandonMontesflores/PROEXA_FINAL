using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ProyectoSnake.Colas.ColaLinealArreglo
{
    class ColaLineal
    {
        public int final;
        private static int MAX = 90000;
        protected int inicio;
        int tamano;
        protected Object[] listaCola;

        public ColaLineal()
        {
            inicio = 0;
            final = -1;
            listaCola = new Object[MAX];
        }

        public void InsertarLin(Object elemento)
        {
            if (!ColaLlenaLin())
            {
                listaCola[++final] = elemento;
                tamano++;

            }
            else
            {
                throw new Exception("ESTAS EN OVERFLOW");
            }
        }

        public bool ColaVaciaLin()
        {
            return inicio > final;
        }
  
        public bool ColaLlenaLin()
        {
            if (final == MAX - 1)
            {
                return true;
            }
            return false;
        }

        public Object EliminarLin()
        {
            if (!ColaVaciaLin())
            {
                tamano--;
                return listaCola[inicio++];
                //      
            }
            else
            {
                throw new Exception("COLA VACIA");
            }
        }

        public void LimpiarCola()
        {
            inicio = 0;
            final = -1;
        }

        public Object InicioColaLin()
        {
            if (!ColaVaciaLin())
            {
                return listaCola[inicio++];
            }
            else
            {
                throw new Exception("COLA VACIA");
            }
        }

        public Object FinalColaLin()
        {

            if (!ColaVaciaLin())
            {
                return listaCola[final];
            }
            else
            {
                throw new Exception("COLA VACIA");
            }

        }

        public int TAM()
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
                i++;
            }
            return (cont != 0) ? true : false;
        }
    }
}
