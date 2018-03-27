using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POOAlumnos.Utilities.FileUtilities;

namespace POOAlumnos
{
    public class FormatoJson : Formato
    {
        public override void Add(Alumno alumno)
        {
            FileStream fs = Append(getPath());
            Escribir(fs, alumno.ToJson());
        }

    }
}
