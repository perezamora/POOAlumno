using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POOAlumnos
{
    public abstract class Formato
    {
        public abstract FileStream Crear(String path);
        public abstract int AddElement(String path, Alumno alumno);
    }
}
