using Microsoft.VisualStudio.TestTools.UnitTesting;
using POOAlumnos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POOAlumnos.Utilities.FileUtilities;
using Newtonsoft.Json;

namespace POOAlumnos.Tests
{

    [TestClass()]
    public class FormatoTxtTests
    {
        Formato formatoTxt;
        Formato formatoJson;

        [TestInitialize]
        public void testInit()
        {
            formatoTxt = new FormatoTxt();
            formatoJson = new FormatoJson();
            using (FileStream fs1 = new FileStream("AlumnosTest.json", FileMode.Create)) ;
        }

        [DataRow("AlumnosTest.txt", 1, "pere", "zamora", "3333")]
        [DataTestMethod]
        public void AddElementTest(string path, int id, string name, string apellidos, string dni)
        {
            // Creamos usuario de pruebas
            Alumno alumno = new Alumno(id, name, apellidos, dni);

            // Realizamos la llamada metodo para añadir elemento
            formatoTxt.AddElement(path, alumno);

            // Leemos fichero pruebas txt
            Alumno alumnoAux = LeerAlumnoTxt(path);

            // Comaparamos el alumno insertado con el que hemos recuperado
            Assert.IsTrue(alumno.Equals(alumnoAux));
        }

        [DataRow("AlumnosTest.json", 1, "pere", "zamora", "3333")]
        [DataTestMethod]
        public void AddElementTestJson(string path, int id, string name, string apellidos, string dni)
        {
            // Creamos usuario de pruebas
            Alumno alumno = new Alumno(id, name, apellidos, dni);

            // Realizamos la llamada metodo para añadir elemento
            formatoJson.AddElement(path, alumno);

            // Leemos fichero pruebas txt
            Alumno alumnoAux = LeerAlumnoJson(path);

            // Comaparamos el alumno insertado con el que hemos recuperado
            Assert.IsTrue(alumno.Equals(alumnoAux));
        }

        public Alumno LeerAlumnoTxt(string path)
        {
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
                return alumnoAux;
            }
        }

        public Alumno LeerAlumnoJson(string path)
        {
            List<Alumno> alumnos = new List<Alumno>();
            using (StreamReader r = new StreamReader(path))
            {
                // Recuperamos los alumnos del fichero JSON
                String json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Alumno>>(json);
                foreach (var item in items)
                {
                    alumnos.Add(item);
                }
            }
            return alumnos[0];
        }

        [TestCleanup]
        public void testClean()
        {
            File.Delete("AlumnosTest.txt");
            File.Delete("AlumnosTest.json");
        }
    }
}