using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    class Examen
    {
        public string dniunico;
        public List<string> preguntas;
        public List<string> respuestas;
        public List<int> puntajes;
        public List<string> puntajeEstudiantes;
        public List<int> tiposPreguntas;
        public List<string> opcion1;
        public List<string> opcion2;
        public List<string> opcion3;
        public List<string> opcion4;
        public Examen(string dniunico, List<string> preguntas, List<string> respuestas, List<int> puntajes, List<int> tiposPreguntas, List<string> opcion1, List<string> opcion2, List<string> opcion3, List<string> opcion4, List<string> puntajeEstudiantes)
        {
            this.dniunico = dniunico;
            this.preguntas = preguntas;
            this.respuestas = respuestas;
            this.puntajes = puntajes;
            this.tiposPreguntas = tiposPreguntas;
            this.opcion1 = opcion1;
            this.opcion2 = opcion2;
            this.opcion3 = opcion3;
            this.opcion4 = opcion4;
            this.puntajeEstudiantes = puntajeEstudiantes;
        }

        public List<string> GetPuntajeEstudiantes()
        {
            return this.puntajeEstudiantes;
        }
        public List<string> GetOpcion1()
        {
            return this.opcion1;
        }
        public List<string> GetOpcion2()
        {
            return this.opcion2;
        }
        public List<string> GetOpcion3()
        {
            return this.opcion3;
        }
        public List<string> GetOpcion4()
        {
            return this.opcion4;
        }
        public List<int> GetTipoPreguntas()
        {
            return this.tiposPreguntas;
        }
        public List<string> GetPreguntas()
        {
            return this.preguntas;
        }
        public List<string> GetRespuestas()
        {
            return this.respuestas;
        }
        public List<int> GetPuntajes()
        {
            return this.puntajes;
        }
        public string getDniunico()
        {
            return this.dniunico;
        }
        public int PuntajeTotal(List<int> puntajes)
        {
            int acum = 0;
            for (int i = 0; i < puntajes.Count; i++)
            {
                acum += puntajes[i];
            }
            return acum;
        }
    }
}
