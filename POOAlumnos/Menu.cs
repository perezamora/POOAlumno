using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace POOAlumnos
{
    class Menu
    {
        public enum OpcMenType
        {
            Exit = 0,
            Create = 1,
            Cont = 2
        };

        public enum OpcTypeFile
        {
            Txt = 1,
            Json = 2,
            Xml = 3
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

                        // Por defecto creamos factoria de ficheros texto
                        var result = 0;
                        TypeFactory factory = new FileFactory();
                        Formato formato = factory.CrearFormatoTxt();

                        // Creamos el alumno
                        Alumno alumno = CrearAlumno();

                        // Tratar formato segun escogido por usuario
                        switch (getValorConfigKey("serializable"))
                        {
                            case OpcTypeFile.Txt:                       
                                result = formato.AddElement("Alumnos.txt",alumno);
                                break;
                            case OpcTypeFile.Json:
                                formato = factory.CrearFormatoJson();
                                result = formato.AddElement("Alumnos.json", alumno);
                                break;
                            case OpcTypeFile.Xml:
                                formato = factory.CrearFormatoXml();
                                result = formato.AddElement("Alumnos.xml", alumno);
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
            Console.WriteLine("Formato por defecto Alumno : "+ ConfigurationManager.AppSettings["serializable"]);
            Console.WriteLine("Escoja opcion formato salida (Texto = 1, JSON = 2, XML = 3) o continue con la de defecto");

            // Objecto console key
            var cki = Console.ReadLine();
            if (cki != "")
            {
                setValorConfigKey("serializable",Enum.GetName(typeof(OpcTypeFile), int.Parse(cki)));
            }
           
            return new Alumno(int.Parse(id), name, apellidos, dni); ;
        }

        // Obtenemos valor de la key configuracion
        public static OpcTypeFile getValorConfigKey(String keyConfig)
        {
            var opcSerial = ConfigurationManager.AppSettings[keyConfig];
            return (OpcTypeFile)Enum.Parse(typeof(OpcTypeFile), opcSerial, true);
        }

        // Guardamos valor de la key en archivo configuracion "nombre.exe.config"
        public static void setValorConfigKey(String key, String value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
    }
}
