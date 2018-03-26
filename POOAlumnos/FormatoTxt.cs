using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POOAlumnos.Utilities.FileUtilities;

namespace POOAlumnos
{
    public class FormatoTxt : Formato
    {
        public override void AddElement(String path, Alumno alumno)
        {
            FileStream fs = CrearFileAppend(path);
            EscribirFile(fs, alumno);
        }
    }
}
