using System;
using System.Diagnostics;
using System.Linq.Expressions;
/*Programa elaborado por JAVMARGAR09*/
/*Programa elaborado a base de:
 *clases
 *metodos
 *variables anonimas
 *arrays
 *bucles
 *casos (switch)
 *condicionales 
 *etc
*/
/*Programa que lleva el promedio de un alumno 
 * 1.El nombre será pedido por el usuario de entrada para darle la bienvenida.
 * 2.La cantidad de materias será pedida por el alumno.
 * 3.Las calificaciones de las materias igual serán pedidas por el alumno.
 * 4.El programa deberá mostrar un menú que me diga si quiero:
 * 4.1->Ingresar la cantidad de materias.
 * 4.2->Ingresar la calificación por cada materia.
 * 4.3->Obtener el promedio de las materias.
 * 4.4->Observar si Pase o no con un promedio de minimo general el periodo.
 * 4.5->Salir del programa
 * 5.Al salir del programa debe mostrar un mensaje de salida y el nombre del usuario.
 * !!!!!DALE TU PUEDES HACERLO¡¡¡¡¡
 */
namespace ConceptosPoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu mn = new Menu();
            mn.menu();
            /*Aceptacion aceptacion = new Aceptacion();*/
        }
    }

    public class Proceso  //Haremos una clase con los procesos para poder instanciarlos dentro del menu solicitado
    {
        public Proceso() { }
        public String solicitudDeNombre()   //Este metodo recoje el nombre del usuario.
        {
            Console.WriteLine("Bienvenido al servidor de promedios.");
            Console.WriteLine("Por favor inserte su nombre:");
            String nombre = Console.ReadLine();
            return nombre;
        }
        public int insertarNumeroDeMaterias()
        {
            Console.WriteLine("Por favor inserte el numero de materias que lleva usted en el periodo.");
            String num = Console.ReadLine();    //En este caso la respuesta ingresada debe de ser tipo entera; pero el readline solo acepta strings
            int num_materias = int.Parse(num);  //Por lo anterior debemos hacer un aconversión de String o cadena a tipo entero int.
            return num_materias;
        }
        public double[] ingresarMaterias(int num_materias, String nombre)  //En este metodo lo que haremos es ingresar las materias.
        {
            int cont = 1;
            double[] calificaciones = new double[num_materias]; //declaramos un array donde se almacenarán sus calificaciones.
            for (int i = 0; i < calificaciones.Length; i++)
            {
                Console.WriteLine($"Por favor {nombre} inserte su calificación de la materia: {cont}.");
                String respuesta = Console.ReadLine();
                int calificacion = int.Parse(respuesta);
                //int calificacion = Convert.ToInt32(respuesta);
                cont++;
                calificaciones[i] = calificacion;
            }
            return calificaciones;
        }
        public double promedio(int num_materias, double[] calificaciones)
        {
            double promedio = 0;

            for (int i = 0; i < calificaciones.Length; i++)
            {
                promedio = calificaciones[i]++;
            }
            promedio /= num_materias;
            return promedio;
        }

        public void acreditacionSiNo(double Promedio)
        {
            if (Promedio < 7)
            {
                Console.WriteLine("El promedio es insuficiente; No pasaste lo siento.");
            }
            else
            {
                Console.WriteLine("En hora-buena. El promedio es suficiente si acreditas el curso de c#. Excelente!!!!!");
            }
        }
    }

    public class Menu
    {
        int num_materias;
        String nombre;
        double[] calificaciones;
        double promedio;
        public Menu() { }
        public void menu()
        {
            Proceso desarrollo = new Proceso();
            nombre = desarrollo.solicitudDeNombre();
            Console.WriteLine($"Hola Bienvenido al menu alumno: {nombre} por favor digite la opcion que quiera usar.");
            Console.WriteLine("1->Ingresar la cantidad de materias.");
            Console.WriteLine("2->Ingresar la calificación por cada materia.");
            Console.WriteLine("3->Obtener el promedio de las materias.");
            Console.WriteLine("4->Observar si Pase o no con un promedio de minimo general el periodo.");
            Console.WriteLine("5->Salir del programa.");
            Console.WriteLine("Introduce un numero del 1-5. (según sea el caso de opciones):");
            int opcion = int.Parse(Console.ReadLine());
            // int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    num_materias = desarrollo.insertarNumeroDeMaterias();
                    menu();
                    break;
                case 2:
                    if (num_materias != 0)
                    {
                        desarrollo.ingresarMaterias(num_materias, nombre);
                        menu();
                    }
                    else
                    {
                        num_materias = desarrollo.insertarNumeroDeMaterias();
                        calificaciones = desarrollo.ingresarMaterias(num_materias, nombre);
                        menu();
                    }
                    break;
                case 3:
                    if (num_materias != 0)
                    {
                        promedio = desarrollo.promedio(num_materias, calificaciones);
                        menu();
                    }
                    else
                    {
                        num_materias = desarrollo.insertarNumeroDeMaterias();
                        promedio = desarrollo.promedio(num_materias, calificaciones);
                        menu();
                    }
                    break;
                case 4:
                    desarrollo.acreditacionSiNo(promedio);
                    menu();
                    break;
                case 5:
                    Console.WriteLine($"Muchas gracias por usar el programa{desarrollo.solicitudDeNombre()}");
                    break;
                default:
                    Console.WriteLine("Debes insertar como lo dice la instruccion( insertar del numero 1-5 ).");
                    break;
            }
        }
    }

    public class Aceptacion
    {
        String res;
        public void aceptacion()
        {
            Menu mn = new Menu();
            Console.WriteLine("Desea ingresar al menu de calificaciones.?");
            res = Console.ReadLine();
            try {
                do
                {
                    mn.menu();
                } while (res == "si");
            } catch(Exception e)
            {
                Console.WriteLine("No debes insertar si o no. Tu error es este" + e.Message);
                aceptacion();
            }        
        }
    }
}
