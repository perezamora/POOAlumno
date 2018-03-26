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
        public abstract void AddElement(String path, Alumno alumno);
    }
}
