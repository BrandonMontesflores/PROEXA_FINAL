using ProyectoSnake.Colas.Objeto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ProyectoSnake.Colas.ColaListaEnlazada
{
    class ColaListaE : ColaArrayList.ColaLista
    {
        public void FinalCola(Object elemento)
        {
            Insertar(elemento);
        }

        public void InicioCola(Object elemento)
        {
            Nodo nuevo;
            nuevo = new Nodo(elemento);
            if (ColaVacia())
            {
                ultimo = nuevo;
            }
            nuevo.siguiente = primero;
            primero = nuevo;
        }
       
        public Object EliminarInicio()
        {
            return Eliminar();
        }
        
        public Object EliminarFinal()
        {
            Object aux;
            if (!ColaVacia())
            {
                if (primero == ultimo)
                {
                    aux = Eliminar();
                }
                else
                {
                    Nodo nuevo = primero;
                    while (nuevo.siguiente != ultimo)
                    {
                        nuevo = nuevo.siguiente;
                    }
                    nuevo.siguiente = nuevo;
                    aux = ultimo.elemento;
                    ultimo = nuevo;
                }
            }
            else
            {
                throw new Exception("COLA VACIA");
            }
            return aux;
        }

        public Object InicioColaLisE()
        {
            return InCola();
        }

        public Object FinalColaLisE()
        {
            if (ColaVacia())
            {
                throw new Exception("LA COLA ESTA VACIA");
            }
            return (ultimo.elemento);
        }

        public bool ColaLisEVacia()
        {
            return ColaVacia();
        }

        public void EliminarColaLisE()
        {
            ElimCola();
        }

        public int ElementosColaLisE()
        {
            int n;
            Nodo a = primero;

            if (ColaLisEVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while (a != ultimo)
                {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;
        }

        public bool Any(Point dato)
        {
            int i = 0, cont = 0;

            Nodo aux = primero;
            bool flag;
            while (aux != null)
            {
                Point a = (Point)aux.elemento;
                flag = ((a.X == dato.X) && (a.Y == dato.Y));
                int z = (flag == true) ? cont++ : cont + 0;
                i++;
                aux = aux.siguiente;
            }
            return (cont != 0) ? true : false;
        }
    }
}
