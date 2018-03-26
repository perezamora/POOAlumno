using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static POOAlumnos.Utilities.ConfigUtilities;
using System.Configuration;
using static POOAlumnos.EnumApp.EnumApp;

namespace POOAlumnos
{
    class Menu
    {

        public Menu() { }

        public void IniApp()
        {
            bool flagEnd = true;

            do
            {
                var key = MostrarMenu();
                switch (key)
                {
                    case OpcMenType.Create:

                        // Por defecto creamos factoria de ficheros texto
                        TypeFactory factory = new FileFactory();
                        Formato formato = factory.CrearFormatoTxt();

                        // Creamos el alumno
                        Alumno alumno = CrearAlumno();

                        // Tratar formato segun escogido por usuario
                        switch (getValorConfigKey("serializable"))
                        {
                            case OpcTypeFile.Txt:                       
                                formato.AddElement("Alumnos.txt",alumno);
                                break;
                            case OpcTypeFile.Json:
                                formato = factory.CrearFormatoJson();
                                formato.AddElement("Alumnos.json", alumno);
                                break;
                            case OpcTypeFile.Xml:
                                formato = factory.CrearFormatoXml();
                                formato.AddElement("Alumnos.xml", alumno);
                                break;
                            default:
                                Console.WriteLine(" Ningun formato correcto ");
                                break;
                        }

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

        // Solo mostrar sino salimos del proceso 
        public void PasoContinuarProceso()
        {
            Console.WriteLine("\n Aprete tecla para continuar ...");
            var salir = Console.ReadKey();
            Console.Clear();
        }

        // Mostrar opciones menu principal
        public OpcMenType MostrarMenu()
        {
            Console.WriteLine("Menu aplicacion: ");
            Console.WriteLine(" 1- Crear alumno ");
            Console.WriteLine(" 0- Salir aplicacion");
            Console.Write("Elige Opcion:");
            var keyPressed = Console.ReadLine();
            return keyPressed != "" ? (OpcMenType)int.Parse(keyPressed) : OpcMenType.Cont;
        }

        // Creamos objeto alumno para añadir al fichero
        // escogemos el formato a guardar
        //  1.- txt
        //  2.- JSON
        //  3.- XML
        public Alumno CrearAlumno()
        {
            // Creamos las preguntas para los atributos del alumno
            Console.Clear();
            Console.WriteLine("Entra datos del Alumno: ");
            Console.Write("Entra id: ");
            var id = Console.ReadLine();
            Console.Write("Entra name: ");
            var name = Console.ReadLine();
            Console.Write("Entra apellidos: ");
            var apellidos = Console.ReadLine();
            Console.Write("Entra dni: ");
            var dni = Console.ReadLine();
            Console.WriteLine("Formato por defecto Alumno : "+ getValorConfigKey("serializable"));
            Console.WriteLine("Escoja opcion formato salida (Texto = 1, JSON = 2, XML = 3) o continue con la de defecto");

            // Objecto console key
            var cki = Console.ReadLine();
            if (cki != "")
            {
                setValorConfigKey("serializable",Enum.GetName(typeof(OpcTypeFile), int.Parse(cki)));
            }
           
            return new Alumno(int.Parse(id), name, apellidos, dni); ;
        }

    }
}
