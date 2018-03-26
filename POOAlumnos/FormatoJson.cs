using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace POOAlumnos
{
    public class FormatoJson : Formato
    {
        public override void AddElement(string path, Alumno alumno)
        {
            // Creamos fichero para añadir los alumnos en formato JSON
            if (File.Exists(path))
            {
                List<Alumno> alumnos = new List<Alumno>();
                using (StreamReader r = new StreamReader(path))
                {
                    // Recuperamos los alumnos del fichero JSON
                    String json = r.ReadToEnd();
                    if (json != "")
                    {
                        var items = JsonConvert.DeserializeObject<List<Alumno>>(json);
                        foreach (var item in items)
                        {
                            alumnos.Add(item);
                        }
                    }

                    // Añadimos el Alumno insertado por consola
                    alumnos.Add(alumno);
                }

                using (FileStream fs1 = new FileStream(path, FileMode.Open))
                using (StreamWriter sw1 = new StreamWriter(fs1))
                {
                    var outputJSON = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                    sw1.WriteLine(outputJSON);
                }
            }
            else
            {
                List<Alumno> alumnos = new List<Alumno>();
                alumnos.Add(alumno);
                using (FileStream fs1 = new FileStream(path, FileMode.Create))
                using (StreamWriter sw1 = new StreamWriter(fs1))
                {
                    var outputJSON = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                    sw1.WriteLine(outputJSON);
                }
            }

        }

    }
}
