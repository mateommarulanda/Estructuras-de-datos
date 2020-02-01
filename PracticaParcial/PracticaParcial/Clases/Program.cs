using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial
{
    class Program
    {
        static string contraseña = "admin2019";
        static string dniexamen = "";

        static void Main(string[] args)
        {
            List<Examen> ex = new List<Examen>();
            List<Estudiante> estudiantes = new List<Estudiante>();
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese una opción: ");
                Console.WriteLine("1 - Modo administrador (Profesor)");
                Console.WriteLine("2 - Modo usuario (Estudiante)");
                Console.WriteLine("0 - Salir");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    string password;
                    int intentos = 4;
                    do
                    {
                        Console.Clear();
                        Console.Write("Ingrese la contraseña: ");
                        password = Console.ReadLine();
                        if (verificarContraseña(password))
                        {
                            opcionesAdministrador(dniexamen, ex);
                        }
                        else if (!verificarContraseña(password))
                        {
                            intentos--;
                            Console.WriteLine("Contraseña errada");
                            Console.WriteLine("Le quedan " + intentos + " intentos");
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            if (intentos == 0)
                            {
                                Console.WriteLine("Se han acabado los intentos");
                                Console.WriteLine("Presione alguna tecla para continuar");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (!verificarContraseña(password));

                }
                else if (opcion == 2)
                {
                    Console.Clear();
                    opcionesUsuario(estudiantes, ex);
                }

            } while (opcion != 0);
        } //Método principal

        static Boolean verificarContraseña(string password)
        {
            if (password == contraseña)
            {
                return true;
            }
            else
            {
                return false;
            }
        } //Verifica si la contraseña ingresada es la correcta cuando se intenta entrar al menú de administrador
        static void opcionesAdministrador(string dniexamen, List<Examen> ex)
        {
            int opcionAdmin;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido Profesor");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("1 - Crear un examen");
                Console.WriteLine("2 - Revisar un examen");
                Console.WriteLine("0 - Salir del modo administrador");
                opcionAdmin = int.Parse(Console.ReadLine());
                if (opcionAdmin == 1)
                {
                    Console.Clear();
                    opcionesCrearExamen(ex, dniexamen);
                }
                else if (opcionAdmin == 2)
                {
                    RevisarExamen(ex);
                }
            } while (opcionAdmin != 0);
        } //Menú del administrador

        static void opcionesCrearExamen(List<Examen> ex, string dniexamen)
        {
            int opcionExamen;
            do
            {
                Console.Clear();
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("1 - Crear examen");
                Console.WriteLine("2 - Editar una pregunta de un examen");
                Console.WriteLine("3 - Eliminar una pregunta de un examen");
                Console.WriteLine("0 - Salir al menú de administrador");
                opcionExamen = int.Parse(Console.ReadLine());
                if (opcionExamen == 1)
                {
                    List<string> preguntas = new List<string>();
                    List<string> respuestas = new List<string>();
                    List<int> puntajes = new List<int>();
                    List<int> tiposPreguntas = new List<int>();
                    List<string> opcion1 = new List<string>();
                    List<string> opcion2 = new List<string>();
                    List<string> opcion3 = new List<string>();
                    List<string> opcion4 = new List<string>();
                    List<string> puntajeEstudiantes = new List<string>();
                    CrearExamen(ex, dniexamen, preguntas, respuestas, puntajes, tiposPreguntas, opcion1, opcion2, opcion3, opcion4, puntajeEstudiantes);
                }
                else if (opcionExamen == 2)
                {
                    EditarExamen(ex);
                }
                else if (opcionExamen == 3)
                {
                    EliminarPregunta(ex);
                }
            } while (opcionExamen != 0);
        } //Menú del administrador para crear un examen, editar preguntas y eliminar preguntas 

        static void opcionesUsuario(List<Estudiante> est, List<Examen> ex)
        {
            int opcionUsuario = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido Estudiante");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("1 - Realizar registro");
                Console.WriteLine("2 - Realizar examen");
                Console.WriteLine("0 - Salir al menú principal");
                opcionUsuario = int.Parse(Console.ReadLine());
                if (opcionUsuario == 1)
                {
                    RegistroEstudiante(est);
                }
                else if (opcionUsuario == 2)
                {
                    RealizarExamen(est, ex);
                }
            } while (opcionUsuario != 0);

        } //Menú del usuario (estudiante)

        static Boolean EncontroExamen(string DniIngresado, List<Examen> ex)
        {
            foreach (Examen examen in ex)
            {
                if (examen.getDniunico().Equals(DniIngresado))
                {
                    return true;
                }
            }
            return false;

        } //Retorna un valor booleano dependiendo de si encuentra el dni del examen en la lista de objetos "ex" de tipo Examen

        static void CrearExamen(List<Examen> ex, string dniexamen, List<string> preguntas, List<string> respuestas, List<int> puntajes, List<int> tiposPreguntas, List<string> opcion1, List<string> opcion2, List<string> opcion3, List<string> opcion4, List<string> puntajeEstudiantes)
        {
            Console.Clear();
            Console.Write("Ingrese el número de identificación del examen: ");
            dniexamen = Console.ReadLine();
            if (EncontroExamen(dniexamen, ex))
            {
                Console.WriteLine("El número de identificación del examen no está disponible");
                Console.WriteLine();
                Console.WriteLine("Por favor ingrese otro número de identificación");
                dniexamen = Console.ReadLine();
                while (EncontroExamen(dniexamen, ex))
                {
                    Console.WriteLine("El número de identificación del examen no está disponible");
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese otro número de identificación");
                    dniexamen = Console.ReadLine();
                }
                ex.Add(new Examen(dniexamen, preguntas, respuestas, puntajes, tiposPreguntas, opcion1, opcion2, opcion3, opcion4, puntajeEstudiantes));
                Console.Clear();
                Console.WriteLine("El número de identificación del examen se ha guardado correctamente");
                Console.WriteLine();
                Console.WriteLine("Pulse enter para continuar");
                Console.ReadLine();
            }
            else
            {
                ex.Add(new Examen(dniexamen, preguntas, respuestas, puntajes, tiposPreguntas, opcion1, opcion2, opcion3, opcion4, puntajeEstudiantes));
                Console.Clear();
                Console.WriteLine("El número de identificación del examen se ha guardado correctamente");
                Console.WriteLine();
                Console.WriteLine("Pulse enter para continuar");
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("¿Cuantas preguntas quiere hacer?");
            string pregunta;
            string respuesta;
            int puntaje;
            int tipoPregunta;
            int repeticiones = int.Parse(Console.ReadLine());
            for (int i = 0; i < repeticiones; i++)
            {
                opcion1.Add(null);
                opcion2.Add(null);
                opcion3.Add(null);
                opcion4.Add(null);
            }

            for (int i = 0; i < repeticiones; i++)
            {
                Console.Clear();
                Console.Write("Ingrese puntaje de la pregunta (1 a 10 puntos): ");
                puntaje = int.Parse(Console.ReadLine());
                while (puntaje < 1 || puntaje > 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("El puntaje ingresado NO ES VÁLIDO");
                    Console.WriteLine();
                    Console.Write("Ingresa otro puntaje: ");
                    puntaje = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("Ingrese el tipo de pregunta: \n1 - Completar \n2 - Falso o Verdadero \n3 - Opción Múltiple (4 Opciones)");
                tipoPregunta = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Ingrese la pregunta " + (i + 1) + ": ");
                pregunta = Console.ReadLine();
                Console.WriteLine();
                if (tipoPregunta == 1)
                {
                    Console.WriteLine("Por favor ingrese la respuesta sin mayúscula y sin punto final");
                    Console.WriteLine();
                    Console.Write("Respuesta: ");
                    respuesta = Console.ReadLine();
                    respuestas.Add(respuesta);
                }
                if (tipoPregunta == 2)
                {
                    Console.Write("Ingrese la respuesta correcta (F ó V): ");
                    respuesta = Console.ReadLine();
                    respuestas.Add(respuesta);
                }
                if (tipoPregunta == 3)
                {
                    Console.WriteLine("Recuerda que una opción será la correcta");
                    Console.WriteLine();
                    Console.Write("Ingrese la opción A: ");
                    string opcionA = Console.ReadLine();
                    opcion1.Insert(i, opcionA);
                    Console.WriteLine();
                    Console.Write("Ingrese la opción B: ");
                    string opcionB = Console.ReadLine();
                    opcion2.Insert(i, opcionB);
                    Console.WriteLine();
                    Console.Write("Ingrese la opción C: ");
                    string opcionC = Console.ReadLine();
                    opcion3.Insert(i, opcionC);
                    Console.WriteLine();
                    Console.Write("Ingrese la opción D: ");
                    string opcionD = Console.ReadLine();
                    opcion4.Insert(i, opcionD);
                    Console.WriteLine();
                    Console.Write("Ingrese la opción correcta (a, b, c ó d (EN MINÚSCULA)): ");
                    respuesta = Console.ReadLine();
                    respuestas.Add(respuesta);
                }
                puntajes.Add(puntaje);
                preguntas.Add(pregunta);
                tiposPreguntas.Add(tipoPregunta);
            }
            new Examen(dniexamen, preguntas, respuestas, puntajes, tiposPreguntas, opcion1, opcion2, opcion3, opcion4, puntajeEstudiantes);
            Console.Clear();
            Console.WriteLine("El examen se ha creado correctamente");
            Console.WriteLine("Presione enter para continuar");
            Console.ReadLine();
        } //Crea el dni de un examen, preguntas de diferente tipo y sus respectivas respuestas

        static void EditarExamen(List<Examen> ex)
        {
            Console.Clear();
            Console.Write("El número de identificación de examen existentes: ");
            for (int i = 0; i < ex.Count; i++)
            {
                Console.Write(ex[i].getDniunico() + " ");
            }
            Console.WriteLine();
            Console.Write("Ingrese el número de identificación del examen: ");
            string dniexamen = Console.ReadLine();
            if (EncontroExamen(dniexamen, ex))
            {
                Console.Clear();
                Console.WriteLine("Las preguntas con las respectiva respuestas del examen con identificación " + dniexamen + " son: ");
                Console.WriteLine();
                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        for (int j = 0; j < ex[i].GetPreguntas().Count; j++)
                        {
                            Console.WriteLine("PUNTAJE de la pregunta " + (j + 1) + ": " + ex[i].GetPuntajes()[j]);
                            Console.WriteLine("Pregunta " + (j + 1) + ": " + ex[i].GetPreguntas()[j]);
                            if (ex[i].GetTipoPreguntas()[j] == 3)
                            {
                                Console.WriteLine("A) " + ex[i].GetOpcion1()[j]);
                                Console.WriteLine("B) " + ex[i].GetOpcion2()[j]);
                                Console.WriteLine("C) " + ex[i].GetOpcion3()[j]);
                                Console.WriteLine("D) " + ex[i].GetOpcion4()[j]);
                                Console.WriteLine("OPCIÓN CORRECTA: " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 2)
                            {
                                Console.WriteLine("Respuesta " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 1)
                            {
                                Console.WriteLine("Respuesta " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("¿Qué pregunta desea editar?");
                int editarPregunta = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Ingrese el tipo de pregunta: \n1 - Completar \n2 - Falso o Verdadero \n3 - Opción Múltiple (4 Opciones)");
                int tipoDePregunta = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Ingrese la pregunta: ");
                string pregunta;
                pregunta = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese el PUNTAJE de la pregunta (1 - 10): ");
                int puntaje;
                puntaje = int.Parse(Console.ReadLine());
                while (puntaje < 1 || puntaje > 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("El puntaje ingresado NO ES VÁLIDO");
                    Console.WriteLine();
                    Console.Write("Ingresa otro puntaje: ");
                    puntaje = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                string respuesta;
                if (editarPregunta != 0)
                {
                    editarPregunta -= 1;
                }
                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        if (tipoDePregunta == 1)
                        {
                            Console.WriteLine("NOTA: Recuerde ingresar la respuesta sin la letra inicial en mayúscula y sin punto final");
                            Console.WriteLine();
                            Console.Write("Ingrese la respuesta: ");
                            respuesta = Console.ReadLine();

                            ex[i].GetPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetPreguntas().Insert(editarPregunta, pregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);
                            ex[i].GetRespuestas().Insert(editarPregunta, respuesta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetTipoPreguntas().Insert(editarPregunta, tipoDePregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                            ex[i].GetPuntajes().Insert(editarPregunta, puntaje);
                        }
                        if (tipoDePregunta == 2)
                        {
                            Console.Write("Ingrese la respuesta (F ó V): ");
                            respuesta = Console.ReadLine();

                            ex[i].GetPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetPreguntas().Insert(editarPregunta, pregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);
                            ex[i].GetRespuestas().Insert(editarPregunta, respuesta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetTipoPreguntas().Insert(editarPregunta, tipoDePregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                            ex[i].GetPuntajes().Insert(editarPregunta, puntaje);
                        }
                        if (tipoDePregunta == 3)
                        {
                            Console.Write("Ingrese la opción A: ");
                            string opcion1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Ingrese la opción B: ");
                            string opcion2 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Ingrese la opción C: ");
                            string opcion3 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Ingrese la opción D: ");
                            string opcion4 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Ingrese la opción correcta(a, b, c ó d): ");
                            respuesta = Console.ReadLine();

                            ex[i].GetOpcion1().RemoveAt(editarPregunta);
                            ex[i].GetOpcion1().Insert(editarPregunta, opcion1);

                            ex[i].GetOpcion2().RemoveAt(editarPregunta);
                            ex[i].GetOpcion2().Insert(editarPregunta, opcion2);

                            ex[i].GetOpcion3().RemoveAt(editarPregunta);
                            ex[i].GetOpcion3().Insert(editarPregunta, opcion3);

                            ex[i].GetOpcion4().RemoveAt(editarPregunta);
                            ex[i].GetOpcion4().Insert(editarPregunta, opcion4);

                            ex[i].GetPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetPreguntas().Insert(editarPregunta, pregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);
                            ex[i].GetRespuestas().Insert(editarPregunta, respuesta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);
                            ex[i].GetTipoPreguntas().Insert(editarPregunta, tipoDePregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                            ex[i].GetPuntajes().Insert(editarPregunta, puntaje);
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Presione enter para ver las preguntas y respuestas editadas");
                Console.ReadLine();
                Console.Clear();

                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        for (int j = 0; j < ex[i].GetPreguntas().Count; j++)
                        {
                            Console.WriteLine("PUNTAJE de la pregunta " + (j + 1) + ": " + ex[i].GetPuntajes()[j]);
                            Console.WriteLine("Pregunta " + (j + 1) + ": " + ex[i].GetPreguntas()[j]);
                            if (ex[i].GetTipoPreguntas()[j] == 3)
                            {
                                Console.WriteLine("A) " + ex[i].GetOpcion1()[j]);
                                Console.WriteLine("B) " + ex[i].GetOpcion2()[j]);
                                Console.WriteLine("C) " + ex[i].GetOpcion3()[j]);
                                Console.WriteLine("D) " + ex[i].GetOpcion4()[j]);
                                Console.WriteLine("OPCIÓN CORRECTA: " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 2)
                            {
                                Console.WriteLine("Respuesta(F(FALSO) ó V(VERDADERO)): " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 1)
                            {
                                Console.WriteLine("Respuesta " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró el examen");
                Console.WriteLine();
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
        } //Edita preguntas de un examen según el dni del examen ingresado

        static void EliminarPregunta(List<Examen> ex)
        {
            Console.Clear();
            Console.Write("El número de identificación de examen existentes son: ");
            for (int i = 0; i < ex.Count; i++)
            {
                Console.Write(ex[i].getDniunico() + " ");
            }
            Console.WriteLine();
            Console.Write("Ingrese el número de identificación del examen: ");
            string dniexamen = Console.ReadLine();
            if (EncontroExamen(dniexamen, ex))
            {
                Console.Clear();
                Console.WriteLine("Las preguntas con las respectiva respuestas del examen con identificación " + dniexamen + " son: ");
                Console.WriteLine();
                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        for (int j = 0; j < ex[i].GetPreguntas().Count; j++)
                        {
                            Console.WriteLine("PUNTAJE de la pregunta " + (j + 1) + ": " + ex[i].GetPuntajes()[j]);
                            Console.WriteLine("Pregunta " + (j + 1) + ": " + ex[i].GetPreguntas()[j]);
                            if (ex[i].GetTipoPreguntas()[j] == 3)
                            {
                                Console.WriteLine("A) " + ex[i].GetOpcion1()[j]);
                                Console.WriteLine("B) " + ex[i].GetOpcion2()[j]);
                                Console.WriteLine("C) " + ex[i].GetOpcion3()[j]);
                                Console.WriteLine("D) " + ex[i].GetOpcion4()[j]);
                                Console.WriteLine("OPCIÓN CORRECTA: " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 2)
                            {
                                Console.WriteLine("Respuesta(F(FALSO) ó V(VERDADERO)): " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 1)
                            {
                                Console.WriteLine("Respuesta " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("¿Qué pregunta desea eliminar?");
                int editarPregunta = int.Parse(Console.ReadLine());
                if (editarPregunta != 0)
                {
                    editarPregunta -= 1;
                }
                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        if (ex[i].GetTipoPreguntas()[editarPregunta] == 1)
                        {
                            ex[i].GetPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                        }
                        if (ex[i].GetTipoPreguntas()[editarPregunta] == 2)
                        {
                            ex[i].GetPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                        }
                        if (ex[i].GetTipoPreguntas()[editarPregunta] == 3)
                        {
                            ex[i].GetOpcion1().RemoveAt(editarPregunta);

                            ex[i].GetOpcion2().RemoveAt(editarPregunta);

                            ex[i].GetOpcion3().RemoveAt(editarPregunta);

                            ex[i].GetOpcion4().RemoveAt(editarPregunta);

                            ex[i].GetPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetRespuestas().RemoveAt(editarPregunta);

                            ex[i].GetTipoPreguntas().RemoveAt(editarPregunta);

                            ex[i].GetPuntajes().RemoveAt(editarPregunta);
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Presione enter para ver las preguntas y respuestas actuales");
                Console.ReadLine();

                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniexamen))
                    {
                        for (int j = 0; j < ex[i].GetPreguntas().Count; j++)
                        {
                            Console.WriteLine("PUNTAJE de la pregunta " + (j + 1) + ": " + ex[i].GetPuntajes()[j]);
                            Console.WriteLine("Pregunta " + (j + 1) + ": " + ex[i].GetPreguntas()[j]);
                            if (ex[i].GetTipoPreguntas()[j] == 3)
                            {
                                Console.WriteLine("A) " + ex[i].GetOpcion1()[j]);
                                Console.WriteLine("B) " + ex[i].GetOpcion2()[j]);
                                Console.WriteLine("C) " + ex[i].GetOpcion3()[j]);
                                Console.WriteLine("D) " + ex[i].GetOpcion4()[j]);
                                Console.WriteLine("OPCIÓN CORRECTA: " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 2)
                            {
                                Console.WriteLine("Respuesta(F(FALSO) ó V(VERDADERO)): " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            if (ex[i].GetTipoPreguntas()[j] == 1)
                            {
                                Console.WriteLine("Respuesta " + (j + 1) + ": " + ex[i].GetRespuestas()[j]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró el examen");
                Console.WriteLine();
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
        } //Elimina preguntas de un examen según el dni del examen ingresado

        static void RevisarExamen(List<Examen> ex)
        {
            Console.Clear();
            Console.Write("El número de identificación de examen existentes: ");
            for (int i = 0; i < ex.Count; i++)
            {
                Console.Write(ex[i].getDniunico() + " ");
            }
            Console.WriteLine();
            Console.Write("Ingrese una identificación de examen: ");
            string dniDigitado = Console.ReadLine();
            Console.Clear();
            if (EncontroExamen(dniDigitado, ex))
            {
                for (int i = 0; i < ex.Count; i++)
                {
                    if (ex[i].getDniunico().Equals(dniDigitado))
                    {
                        Console.WriteLine("Calificación de los estudiantes en el examen " + dniDigitado);
                        Console.WriteLine();
                        for (int j = 0; j < ex[i].GetPuntajeEstudiantes().Count; j++)
                        {
                            Console.WriteLine(ex[i].GetPuntajeEstudiantes()[j]);
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("El examen con el número de identificación ingresado no existe");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
        } //Imprime las calificaciones de un examen según el dni del examen ingresado

        static void RegistroEstudiante(List<Estudiante> est)
        {
            Console.Clear();
            Console.Write("Ingrese su nombre: ");
            string nombreEstudiante = Console.ReadLine();
            Console.Write("Ingrese su cédula: ");
            string dniestudiante = Console.ReadLine();
            Console.Write("Ingrese una clave segura: ");
            string clave = Console.ReadLine();
            est.Add(new Estudiante(dniestudiante, nombreEstudiante, clave));
            Console.Clear();
            Console.WriteLine("Registro exitoso");
            Console.WriteLine("Presione enter para continuar");
            Console.ReadLine();
        }  //Registro para el estudiante para que pueda presentar el examen

        static void RealizarExamen(List<Estudiante> est, List<Examen> ex)
        {
            Console.Clear();
            Console.Write("Ingrese su cédula: ");
            string cedula = Console.ReadLine();
            if (EncontroEstudiante(cedula, est))
            {
                Console.Write("Ingrese su clave: ");
                string clave = Console.ReadLine();
                if (EncontroClave(clave, est, cedula))
                {
                    Console.Clear();
                    Console.WriteLine(IdentificarEstudiante(est, cedula));
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    OpcionesPresentarExamen(ex, cedula);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("CLAVE INCORRECTA");
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Su cédula no se ha encontrado en el sistema, debe registrarse antes de realizar un examen");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
        } //Inicio de sesión antes de presentar un examen

        static Boolean EncontroEstudiante(string dni, List<Estudiante> est)
        {
            foreach (Estudiante estudiante in est)
            {
                if (estudiante.GetEstudiante().Equals(dni))
                {
                    return true;
                }
            }
            return false;
        } //Retorna un valor booleano dependiendo de si encuentra el dni del estudiante en el sis

        static Boolean EncontroClave(string clave, List<Estudiante> est, string dni)
        {
            if (clave == est[posicionEstudiante(dni, est)].GetClave())
            {
                return true;
            }
            return false;
        } //Retorna un valor booleano dependiendo de si encuentra la clave en el sistema o no

        static int posicionEstudiante(string dni, List<Estudiante> est)
        {
            for (int i = 0; i < est.Count; i++)
            {
                if (est[i].GetEstudiante().Equals(dni))
                {
                    return i;
                }
            }
            return 0;
        } //Comparar la posición del dni del estudiante con la clave que le corresponde a ese dni (Retorna la posición del dni ingresado)

        static string IdentificarEstudiante(List<Estudiante> est, string dni)
        {
            return "¡HOLA " + est[posicionEstudiante(dni, est)].GetNombre() + "!";
        } //Bienvenida al estudiante (Encontrarlo en el sistema según su dni)

        static void OpcionesPresentarExamen(List<Examen> ex, string cedula)
        {
            int opcionPresentarExamen = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido Estudiante");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("1 - Presentar examen");
                Console.WriteLine("0 - Cerrar sesión");
                opcionPresentarExamen = int.Parse(Console.ReadLine());
                if (opcionPresentarExamen == 1)
                {
                    PresentarExamen(ex, cedula);
                }
            } while (opcionPresentarExamen != 0);
        } //Menú de opciones para presentar un examen

        static void PresentarExamen(List<Examen> ex, string cedula)
        {
            Console.Clear();
            Console.Write("El número de identificación de examen existentes: ");
            for (int i = 0; i < ex.Count; i++)
            {
                Console.Write(ex[i].getDniunico() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("¿Cuál examen desea presentar?");
            string examenAPresentar = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Presione enter para continuar con las preguntas");
            Console.ReadLine();
            Console.Clear();
            double puntaje = 0;
            string respuesta;
            double calificacion;
            for (int i = 0; i < ex.Count; i++)
            {
                if (ex[i].getDniunico().Equals(examenAPresentar))
                {
                    for (int j = 0; j < ex[i].GetPreguntas().Count; j++)
                    {
                        Console.Clear();
                        Console.WriteLine("Pregunta " + (j + 1) + ": " + ex[i].GetPreguntas()[j]);
                        Console.WriteLine();
                        if (ex[i].GetTipoPreguntas()[j] == 1)
                        {
                            Console.WriteLine("Por favor escribe la respuesta sin la letra inicial en mayúscula y sin punto final");
                            Console.WriteLine();
                            Console.Write("Completa la respuesta: ");
                            respuesta = Console.ReadLine();
                            if (respuesta == ex[i].GetRespuestas()[j])
                            {
                                puntaje += ex[i].GetPuntajes()[j];
                            }
                        }
                        if (ex[i].GetTipoPreguntas()[j] == 2)
                        {
                            Console.WriteLine("Falso ó Verdadero");
                            Console.Write("Ingrese su respuesta (V ó F): ");
                            respuesta = Console.ReadLine();
                            if (respuesta == ex[i].GetRespuestas()[j])
                            {
                                puntaje += ex[i].GetPuntajes()[j];
                            }
                        }
                        if (ex[i].GetTipoPreguntas()[j] == 3)
                        {
                            Console.WriteLine("Las opciones de respuesta son: ");
                            Console.WriteLine();
                            Console.WriteLine("Opción A: " + ex[i].GetOpcion1()[j]);
                            Console.WriteLine("Opción B: " + ex[i].GetOpcion2()[j]);
                            Console.WriteLine("Opción C: " + ex[i].GetOpcion3()[j]);
                            Console.WriteLine("Opción D: " + ex[i].GetOpcion4()[j]);
                            Console.WriteLine();
                            Console.Write("Ingrese su respuesta (a, b, c ó d): ");
                            respuesta = Console.ReadLine();
                            if (respuesta == ex[i].GetRespuestas()[j])
                            {
                                puntaje += ex[i].GetPuntajes()[j];
                            }
                        }
                    }
                    if (ex[i].getDniunico().Equals(examenAPresentar))
                    {
                        calificacion = (puntaje * 100 / (ex[i].PuntajeTotal(ex[i].GetPuntajes())));
                        string porcentaje = calificacion + "%";
                        string porcentajeDeEstudiante = "Cédula: " + cedula + "  ........................... " + "Calificación: " + porcentaje;
                        ex[i].GetPuntajeEstudiantes().Add(porcentajeDeEstudiante);
                        Console.Clear();
                        Console.WriteLine("Presione enter para saber su calificación en porcentaje");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Su calificación es: " + porcentaje);
                    }
                }
            }
            Console.WriteLine("Presione enter para salir del examen");
            Console.ReadLine();
        } //El estudiante presenta el examen
    }
}