using Microsoft.VisualStudio.TestTools.UnitTesting;
using POOAlumnos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOAlumnos.Tests
{

    [TestClass()]
    public class FormatoTxtTests
    {

        // Creamos la factoria de formatos.
        Formato formato = new FormatoTxt();
        Alumno alumno = new Alumno();

        [TestMethod()]
        public void AddElementTest()
        {
            // Creamos usuario de pruebas
            var path = "AlumnosTest.txt";
            alumno.Id = 1;
            alumno.Name = "Pere";
            alumno.Apellidos = "Zamora";
            alumno.Dni = "11111A";

            // Realizamos la llamada metodo para añadir elemento
            formato.AddElement(path, alumno);

            // Validar si el insert se ha realizado correctamente
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (StreamReader sw = new StreamReader(fs))
            {
                // Recuperamos los alumnos del fichero JSON
                String text = sw.ReadToEnd();
                string[] fields = text.Split(';');
                Alumno alumnoAux = new Alumno();
                alumnoAux.Id = int.Parse(fields[0]);
                alumnoAux.Name = fields[1];
                alumnoAux.Apellidos = fields[2];
                alumnoAux.Dni = fields[3];

                // Comaparamos el alumno insertado con el que hemos recuperado
                Assert.IsTrue(alumno.Equals(alumnoAux));
            }
        }
    }
}