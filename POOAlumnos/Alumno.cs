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
    }
}
