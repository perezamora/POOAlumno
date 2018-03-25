using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOAlumnos
{
    public class Alumno
    {

        private int id;
        private String name;
        private String apellidos;
        private String dni;

        public Alumno()
        {

        }

        public Alumno(int id, String name, String apellidos, String dni)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.dni = dni;
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

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   id == alumno.id &&
                   name == alumno.name &&
                   apellidos == alumno.apellidos &&
                   dni == alumno.dni;
        }

        public override int GetHashCode()
        {
            var hashCode = -818402288;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(dni);
            return hashCode;
        }
    }
}
