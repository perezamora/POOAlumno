using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOAlumnos
{
    public class FormatoTxt : Formato
    {
        public override int AddElement(String path, Alumno alumno)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                var contenido = string.Format("{0};{1};{2};{3};", alumno.Id, alumno.Name, alumno.Apellidos, alumno.Dni);
                sw.WriteLine(contenido);
            }
            return 1;
        }

        public override FileStream Crear(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                return fs;
            }
        }
    }
}
