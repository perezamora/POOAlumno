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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void Add(Alumno alumno)
        {
            log.Info("Añadir alumno en formato texto.");
            FileStream fs = Append(getPath());
            Escribir(fs, alumno.ToString());
        }
    }
}
