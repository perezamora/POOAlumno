using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace POOAlumnos
{

    public class Alumno
    {

        private int id;
        private String name;
        private String apellidos;
        private String dni;
        private String guid;

        public Alumno()
        {
        }

        public Alumno(int id, String name, String apellidos, String dni)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.dni = dni;
            this.guid = System.Guid.NewGuid().ToString();
        }

        public Alumno(int id, String name, String apellidos, String dni, String guid)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.dni = dni;
            this.guid = guid;
        }

        public int Id //Propiedad
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public String Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public override String ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};", this.id, this.name, this.apellidos, this.dni, this.guid);
        }

        public String ToJson()
        {
            Alumno alumn = new Alumno
            {
                Id = this.id,
                Name = this.name,
                Apellidos = this.apellidos,
                Dni = this.dni,
                Guid = this.guid
            };
            return JsonConvert.SerializeObject(alumn, Formatting.Indented);
        }

        public override bool Equals(object obj)
        {

            var alumno = obj as Alumno;
            return alumno != null &&
                   id == alumno.id &&
                   name == alumno.name &&
                   apellidos == alumno.apellidos &&
                   dni == alumno.dni &&
                   guid == alumno.guid;
        }

        public override int GetHashCode()
        {
            var hashCode = -192160356;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(guid);
            return hashCode;
        }
    }
}
