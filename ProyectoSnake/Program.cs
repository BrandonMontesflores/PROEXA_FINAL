using ProyectoSnake.Colas.ColaArrayList;
using ProyectoSnake.Colas.ColaCircular;
using ProyectoSnake.Colas.ColaLinealArreglo;
using ProyectoSnake.Colas.ColaListaEnlazada;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace ProyectoSnake
{
    class Program
    {
        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }

        private static void DibujaPantalla(Size size)
        {
            Console.Title = "BIENVENIDO AL JUEGO SNAKE";
            Console.WindowHeight = size.Height + 3;
            Console.WindowWidth = size.Width + 3;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }

        private static void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 0);
            Console.Write($"TUS PUNTOS {punteo.ToString("0000")}");
        }

        private static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }

        private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }

       


        static void opc11()
        {
            var punteo = 0;
            var velocidad = 100; 
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(65, 25);
            ColaListaE culebrita = new ColaListaE();
            var longitudCulebra = 4; 
            var posiciónActual = new Point(5, 8); 
            culebrita.Insertar(posiciónActual);
            var dirección = Direction.Arriba; 
            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverCulebritaLisE(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra += 3; 
                    punteo += 5; 
                    MuestraPunteo(punteo);
                    velocidad -= 10;
                }
                if (posiciónComida == Point.Empty) 
                {
                    posiciónComida = ComidaLisE(tamañoPantalla, culebrita);
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Beep(659, 125);
            Console.Write("GAME OVER");
            Thread.Sleep(2000);
            Console.ReadKey();
        }
        
        private static bool MoverCulebritaLisE(ColaListaE culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.FinalColaLisE();

            if (lastPoint.Equals(posiciónObjetivo)) return true;
       
            if (culebra.Any(posiciónObjetivo)) return false;//

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");
            culebra.Insertar(posiciónObjetivo);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            if (culebra.ElementosColaLisE() > longitudCulebra)//
            {
                var removePoint = (Point)culebra.Eliminar();//
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }
        
        private static Point ComidaLisE(Size screenSize, ColaListaE culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.FinalColaLisE();
            var coor = cabezaCulebra.X;
            var rnd = new Random();
            do
            {
                var xi = rnd.Next(0, screenSize.Width - 1);
                var yi = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(x => coor != xi || coor != yi)
                    && Math.Abs(xi - cabezaCulebra.X) + Math.Abs(yi - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(xi, yi);
                    Console.Beep(659, 125);
                }
            } while (lugarComida == Point.Empty);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");
            return lugarComida;
        }


        static void opc22()
        {
            var punteo = 0;
            var velocidad = 100; 
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(65, 25);
            var culebrita = new ColaLineal();
            var longitudCulebra = 4; 
            var posiciónActual = new Point(5, 8); 
            culebrita.InsertarLin(posiciónActual);
            var dirección = Direction.Arriba; 
            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverCulebritaLineal(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra++;
                    punteo += 5; 
                    MuestraPunteo(punteo);
                    velocidad -= 5;
                }

                if (posiciónComida == Point.Empty) 
                {
                    posiciónComida = ComidaLineal(tamañoPantalla, culebrita);
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Beep(659, 125);
            Console.Write("GAME OVER");
            Thread.Sleep(2000);
            Console.ReadKey();

        }
        private static bool MoverCulebritaLineal(ColaLineal culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.FinalColaLin();
            int pausa = 0;
            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.ToString().Any(x => x.Equals(posiciónObjetivo))) return false;
            
            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");
            culebra.InsertarLin(posiciónObjetivo);
            int pausa1 = 0;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            if (culebra.TAM() > longitudCulebra)
            {
                var removePoint = (Point)culebra.EliminarLin();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }
        private static Point ComidaLineal(Size screenSize, ColaLineal culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.FinalColaLin();
            var rnd = new Random();
            var Px = cabezaCulebra.X;
            var Py = cabezaCulebra.Y;
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(p => Px != x || Py != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                    Console.Beep(659, 125);
                }

            } while (lugarComida == Point.Empty);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");
            return lugarComida;
        }
     

        static void opc33()
        {
            var punteo = 0;
            var velocidad = 100; 
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(65, 25);
            var culebrita = new ColaLista();
            var longitudCulebra = 4;
            var posiciónActual = new Point(5, 8); 
            culebrita.Insertar(posiciónActual);
            var dirección = Direction.Arriba; 
            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverCulebritaLista(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra++; 
                    punteo += 5; 
                    MuestraPunteo(punteo);
                    velocidad -= 10;
                }

                if (posiciónComida == Point.Empty) 
                {
                    posiciónComida = ComidaLista(tamañoPantalla, culebrita);
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Beep(659, 125);
            Console.Write("GAME OVER");
            Thread.Sleep(2000);
            Console.ReadKey();
        }

        private static Point ComidaLista(Size screenSize, ColaLista culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.FinalCola();
            var rnd = new Random();

            var Px = cabezaCulebra.X;
            var Py = cabezaCulebra.Y;
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().Any(p => Px != x || Py != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                    Console.Beep(659, 125);
                }

            } while (lugarComida == Point.Empty) ;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");
            return lugarComida;
        }

        private static bool MoverCulebritaLista(ColaLista culebra, Point posiciónObjetivo,
           int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.FinalColaLista();

            int pausa = 0;
            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.ToString().Any(x => x.Equals(posiciónObjetivo))) return false;

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");
            culebra.Insertar(posiciónObjetivo);
            int pausa1 = 0;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");
          
            if (culebra.ElementosLista() > longitudCulebra)
            {
                var removePoint = (Point)culebra.Eliminar();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }


        
        static void opc44()
        {
            var punteo = 0;
            var velocidad = 100; 
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(65, 25);
            var culebrita = new ColaCircular();
            var longitudCulebra = 4; 
            var posiciónActual = new Point(5, 8); 
            culebrita.insertar(posiciónActual);
            var dirección = Direction.Arriba; 
            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverCulebritaCircular(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra += 3; 
                    punteo += 5; 
                    MuestraPunteo(punteo);
                    velocidad -= 5;
                }
                if (posiciónComida == Point.Empty) 
                {
                    posiciónComida = ComidaCircular(tamañoPantalla, culebrita);
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Beep(659, 125);
            Console.Write("GAME OVER");
            Console.Beep(650, 2);
            Thread.Sleep(2000);
            Console.ReadKey();
        }

        private static bool MoverCulebritaCircular(ColaCircular culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.FinaColaCircular();//

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.ToString().Any(x => x.Equals(posiciónObjetivo))) return false;//

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");
            culebra.insertar(posiciónObjetivo);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            if (culebra.Tam() > longitudCulebra)//
            {
                var removePoint = (Point)culebra.Eliminar();//
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point ComidaCircular(Size screenSize, ColaCircular culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.FinaColaCircular();
            var coor = cabezaCulebra.X;//
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(p => coor != x || coor != y)//
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                    Console.Beep(659, 125);
                }

            } while (lugarComida == Point.Empty);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");
            return lugarComida;
        }


        static void Menu()
        {
            int Opc;
            Console.WriteLine("JUEGO SNAKE O CULEBRITA\n\n");
            Console.WriteLine("PRESIONA 0 LISTA ENLAZADA");
            Console.WriteLine("PRESIONA 1 LINEAL");
            Console.WriteLine("PRESIONA 2 LISTA");
            Console.WriteLine("PRESIONA 3 CIRCULAR");
            Opc = int.Parse(Console.ReadLine());

            switch (Opc)
            {
                case 0: opc1(); break;
                case 1: opc2(); break;
                case 2: opc3(); break;
                case 3: opc4(); break;
                case 4: return;
            }
        }

        static void opc1()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            opc11();
        }

        static void opc2()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            opc22();
        }

        static void opc3()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            opc33();
        }

        static void opc4()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            opc44();
        }

        static void Main()
        {
            Menu();
        }

    }
}

