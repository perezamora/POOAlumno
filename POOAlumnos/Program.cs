using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace POOAlumnos
{
    class Program
    {

        public enum OpcMenType
        {
            Exit = 0,
            Create = 1,
            Cont = 2
        };

        public enum OpcTypeFile
        {
            Txt = 0,
            Json = 1,
            Xml = 2
        }

        static void Main(string[] args)
        {
            bool flagEnd = true;

            do
            {
                var key = MostrarMenu();
                switch (key)
                {
                    case OpcMenType.Create:
                        CrearAlumnoTxt();
                        break;
                    case OpcMenType.Exit:
                        flagEnd = false;
                        break;
                    case OpcMenType.Cont:
                    default:
                        Console.WriteLine("Opcion no valida .... escoja otra por favor \n");
                        break;
                }

                // Control para continuar proceso
                if (flagEnd) PasoContinuarProceso();


            } while (flagEnd);

        }

        public static void PasoContinuarProceso()
        {
            Console.WriteLine("\n Aprete tecla para continuar ...");
            var salir = Console.ReadKey();
            Console.Clear();
        }

        // Mostrar opciones menu principal
        public static OpcMenType MostrarMenu()
        {
            Console.WriteLine("Elige Opcion:");
            Console.WriteLine(" 1- Crear alumno ");
            Console.WriteLine(" 0- Salir aplicacion");
            var keyPressed = Console.ReadLine();
            return keyPressed != "" ? (OpcMenType)int.Parse(keyPressed) : OpcMenType.Cont;
        }

        // Creamos objeto alumno para añadir al fichero
        // escogemos el formato a guardar
        //  1.- txt
        //  2.- JSON
        //  3.- XML
        public static Alumno CrearAlumno()
        {
            // Creamos las preguntas para los atributos del alumno
            Console.Clear();
            Console.WriteLine("Entra datos del Alumno: ");
            Console.WriteLine("Entra id:");
            var id = Console.ReadLine();
            Console.WriteLine("Entra name:");
            var name = Console.ReadLine();
            Console.WriteLine("Entra apellidos:");
            var apellidos = Console.ReadLine();
            Console.WriteLine("Entra dni:");
            var dni = Console.ReadLine();
            Console.WriteLine("Escoja opcion formato salida (Texto = 1, JSON = 2, XML = 3) ");
            Console.WriteLine(" ");
            var opcType = Console.ReadKey();

            return new Alumno(int.Parse(id), name, apellidos, dni); ;
        }
            
        public static void CrearAlumnoTxt()
        {

            Alumno alumno = CrearAlumno();

            // Creamos fichero para añadir los alumnos en formato TXT
            // Si ya existe los agrega al final.
            using (FileStream fs = new FileStream("Alumnos.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                var contenido = string.Format("{0};{1};{2};{3};", alumno.Id, alumno.Name, alumno.Apellidos, alumno.Dni);
                sw.WriteLine(contenido);
            }

            // Creamos fichero para añadir los alumnos en formato JSON
            using (FileStream fs1 = new FileStream("Alumnos.json", FileMode.Create))
            using (StreamWriter sw1 = new StreamWriter(fs1))
            {
                var outputJSON = JsonConvert.SerializeObject(alumno);
                sw1.WriteLine(outputJSON);
            }

        }            

        public static void CrearAlumnoJson()
        {
            Alumno alumno = CrearAlumno();
            var outputJSON = JsonConvert.SerializeObject(alumno);
            File.WriteAllText("MiPrimerJSON.json", outputJSON);

        }
    }
}
