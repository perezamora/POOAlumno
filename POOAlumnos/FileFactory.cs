using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOAlumnos
{
    public class FileFactory : TypeFactory
    {
        public override Formato CrearFormatoTxt()
        {
            return new FormatoTxt();
        }
    }
}
