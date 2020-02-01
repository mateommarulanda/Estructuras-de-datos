using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    class Estudiante
    {
        public string nombreEstudiante;
        public string dniestudiante;
        public string clave;
        public Estudiante(string dniestudiante, string nombreEstudiante, string clave)
        {
            this.clave = clave;
            this.nombreEstudiante = nombreEstudiante;
            this.dniestudiante = dniestudiante;
        }

        public string GetEstudiante()
        {
            return this.dniestudiante;
        }

        public string GetClave()
        {
            return this.clave;
        }

        public string GetNombre()
        {
            return this.nombreEstudiante;
        }
    }
}
