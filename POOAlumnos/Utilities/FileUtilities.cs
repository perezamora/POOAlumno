using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static POOAlumnos.EnumApp.EnumApp;

namespace POOAlumnos.Utilities
{
    public static class FileUtilities
    {

        public static FileStream CrearFile(string pathFile)
        {
            FileStream fs;
            if (!File.Exists(pathFile))
            {
                fs = new FileStream(pathFile, FileMode.Create, FileAccess.Write);
                return fs;
            }
            else
            {
                fs = new FileStream(pathFile, FileMode.Open, FileAccess.Write);
                return fs;
            }
        }

        public static FileStream CrearFileAppend(string pathFile)
        {
            try
            {
                FileStream fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write);
                return fs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static FileStream AbriFile(string pathFile)
        {
            using (FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Write))
                return fs;
        }

        public static void EscribirFile(FileStream fs, Alumno alumno)
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                var contenido = string.Format("{0};{1};{2};{3};{4}", alumno.Id, alumno.Name, alumno.Apellidos, alumno.Dni, alumno.Guid);
                sw.WriteLine(contenido);
            }
        }

    }
}
