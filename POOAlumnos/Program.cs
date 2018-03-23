using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace POOAlumnos
{
    class Program
    {

        static void Main(string[] args)
        {
            Alumno alumno = new Alumno();
            bool flagEnd = true;

            do
            {
                var key = MostrarMenu();
                switch (key)
                {
                    case 1:
                        CrearAlumno();
                        break;
                    case 0:
                        flagEnd = false;
                        break;
                }

                Console.WriteLine("para continuar");
                var salir = Console.ReadKey();
                Console.Clear();

            } while (flagEnd);

        }

        public static int MostrarMenu()
        {
            Console.WriteLine("Elige Opcion: \n");
            Console.WriteLine("1- Crear alumno \n");
            Console.WriteLine("0- Salir aplicacion   \n");
            var keyPressed = Console.ReadLine();
            return int.Parse(keyPressed);
        }

        public static void CrearAlumno()
        {
            Console.WriteLine("Entra id Alumno: \n");
            var id = Console.ReadLine();
            Console.WriteLine("Entra name Alumno: \n");
            var name = Console.ReadLine();
            Console.WriteLine("Entra apellidos Alumno: \n");
            var apellidos = Console.ReadLine();
            Console.WriteLine("Entra dni Alumno: \n");
            var dni = Console.ReadLine();
            Alumno alumno = new Alumno(int.Parse(id), name, apellidos, dni);

            using (StreamWriter writer = new StreamWriter("Alumnos.txt"))
            {
                writer.WriteLine(string.Format("{0};{1};{2};{3};", alumno.Dni, alumno.Name, alumno.Apellidos,alumno.Dni));
            }
        }
    }
}
