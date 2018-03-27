using Microsoft.VisualStudio.TestTools.UnitTesting;
using POOAlumnos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POOAlumnos.Utilities.FileUtilities;
using static POOAlumnos.Utilities.ConfigUtilities;
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

        [DataRow(1, "pere", "zamora", "3333")]
        [DataTestMethod]
        public void AddElementTest(int id, string name, string apellidos, string dni)
        {
            string guid = System.Guid.NewGuid().ToString();

            // Creamos usuario de pruebas
            Alumno alumno = new Alumno(id, name, apellidos, dni, guid);

            // Realizamos la llamada metodo para añadir elemento
            formatoTxt.Add(alumno);

            // Leemos fichero pruebas txt
            Alumno alumnoTest = LeerAlumnoTxt();

            // Comaparamos el alumno insertado con el que hemos recuperado
            Console.WriteLine(alumno);
            Console.WriteLine(alumnoTest);
            Assert.IsTrue(alumno.Equals(alumnoTest));
        }

        [DataRow(1, "pere", "zamora", "3333")]
        [DataTestMethod]
        public void AddElementTestJson(string path, int id, string name, string apellidos, string dni)
        {

            string guid = System.Guid.NewGuid().ToString();

            // Creamos usuario de pruebas
            Alumno alumno = new Alumno(id, name, apellidos, dni, guid);

            // Realizamos la llamada metodo para añadir elemento
            formatoJson.Add(alumno);

            // Leemos fichero pruebas txt
            Alumno alumnoAux = LeerAlumnoJson(path);

            // Comaparamos el alumno insertado con el que hemos recuperado
            Assert.IsTrue(alumno.Equals(alumnoAux));
        }

        public Alumno LeerAlumnoTxt()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fullPath = path + "\\" + "alumnos.txt";
            Console.WriteLine("file path -->" + fullPath);

            // Validar si el insert se ha realizado correctamente
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (StreamReader sw = new StreamReader(fs))
            {
                // Recuperamos los alumnos del fichero JSON
                String text = sw.ReadToEnd();
                string[] fields = text.Split(';');
                return new Alumno(int.Parse(fields[0]), fields[1], fields[2], fields[3], fields[4]); ;
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