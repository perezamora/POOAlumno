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
                                formato.Add(alumno);
                                break;
                            case OpcTypeFile.Json:
                                formato = factory.CrearFormatoJson();
                                formato.Add(alumno);
                                break;
                            case OpcTypeFile.Xml:
                                formato = factory.CrearFormatoXml();
                                formato.Add( alumno);
                                break;
                            default:
                                Console.WriteLine(Properties.Resources.NingunFormato);
                                break;
                        }

                        break;
                    case OpcMenType.Config:
                        MenuConfig();
                        break;
                    case OpcMenType.Exit:
                        flagEnd = false;
                        break;
                    case OpcMenType.Cont:
                    default:
                        Console.WriteLine(Properties.Resources.OpcionNoValida);
                        break;
                }

                // Control para continuar proceso
                if (flagEnd) PasoContinuarProceso();


            } while (flagEnd);

        }

        // Solo mostrar sino salimos del proceso 
        public void PasoContinuarProceso()
        {
            Console.WriteLine("\n "+ Properties.Resources.ContProceso);
            var salir = Console.ReadKey();
            Console.Clear();
        }

        // Mostrar opciones menu principal
        public OpcMenType MostrarMenu()
        {
            Console.WriteLine(Properties.Resources.Litmenu);
            Console.WriteLine(Properties.Resources.menuAlum);
            Console.WriteLine(Properties.Resources.menuConfig);
            Console.WriteLine(Properties.Resources.menuSalir);
            Console.Write(Properties.Resources.elegiropcion);
            var keyPressed = Console.ReadLine();
            return keyPressed != "" ? (OpcMenType)int.Parse(keyPressed) : OpcMenType.Cont;
        }

        // Menu configuracion tipo formato 
        public void MenuConfig()
        {
            Console.WriteLine(Properties.Resources.formdatosdefecto + getValorConfigKey("serializable"));
            Console.WriteLine(Properties.Resources.formdatosparse);

            // Objecto console key
            var cki = Console.ReadLine();
            if (cki != "")
            {
                setValorConfigKey("serializable", Enum.GetName(typeof(OpcTypeFile), int.Parse(cki)));
            }
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
            Console.WriteLine(Properties.Resources.formdatos);
            Console.Write(Properties.Resources.formId);
            var id = Console.ReadLine();
            Console.Write(Properties.Resources.formName);
            var name = Console.ReadLine();
            Console.Write(Properties.Resources.formApellidos);
            var apellidos = Console.ReadLine();
            Console.Write(Properties.Resources.formDni);
            var dni = Console.ReadLine();
           
            return new Alumno(int.Parse(id), name, apellidos, dni); ;
        }

    }
}
