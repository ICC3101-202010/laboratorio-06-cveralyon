using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab6
{
    [Serializable]
    public class Empresa
    {
        public string name;
        public int rut;
        public List<Persona> personal_empresa = new List<Persona>();
        public List<Area> lista_areas = new List<Area>();
        public List<Departamento> lista_dptos = new List<Departamento>();
        public List<Seccion> lista_secciones = new List<Seccion>();
        public List<Bloque> lista_bloques = new List<Bloque>();

        public string Name { get => name; set => name = value; }
        public int Rut { get => rut; set => rut = value; }
        public List<Persona> Personal_empresa { get => personal_empresa; set => personal_empresa = value; }
        public List<Area> Lista_areas { get => lista_areas; set => lista_areas = value; }
        public List<Departamento> Lista_dptos { get => lista_dptos; set => lista_dptos = value; }
        public List<Seccion> Lista_secciones { get => lista_secciones; set => lista_secciones = value; }
        public List<Bloque> Lista_bloques { get => lista_bloques; set => lista_bloques = value; }

        public static int Numero(int o) // verifica que el input  sea un numero dentro del rango requerido
        {
            int n;
            bool aux0;
            do
            {
                string p;
                p = Console.ReadLine();
                aux0 = int.TryParse(p, out n);
                if (aux0 == false || n > o)
                {
                    Console.WriteLine("---ERROR: INGRESE SOLO NUMEROS del 1 al {0}---\n" +
                        "Intente Nuevamente: ", o);
                }
            } while (!aux0 || n > o);

            return n;
        }
        public static string Palabra() // verifica que el input sea palabra o signo .,/- 
        {
            string palabra;
            int count = 0;
            List<char> abcdario = new List<char> { 'A', 'B', 'C', 'D', ' ', '.', ',', '/', '-', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            do
            {

                string palabra1 = Console.ReadLine();
                palabra = palabra1.ToUpper();

                for (int i = 0; i < palabra.Length; i++)
                {
                    foreach (char letra in abcdario)
                    {
                        if (palabra[i] == letra)
                        {
                            count++;
                        }
                    }
                }
                if (palabra.Length != count)
                {
                    Console.WriteLine("---ERROR: NO PUEDE INGRESAR CARACTERES QUE NO SEAN LETRAS---\n" +
                        "Intente nuevamente:");
                }
            } while (palabra.Length != count);


            return palabra.ToLower();
        }

        public Empresa(string name, int rut)
        {
            this.name = name;
            this.rut = rut;
        }



        public void agregar_personal()
        {
            Console.WriteLine("Ingrese el NOMBRE del Empleado:");
            string nombre = Palabra();
            Console.WriteLine("Ingrese el APELLIDO del Empleado:");
            string apellido = Palabra();
            Console.WriteLine("Ingrese el RUT del Empleado:");
            int rut = Numero(999999999);
            Console.WriteLine("Ingrese el CARGO del Empleado:");
            string cargo = Palabra();
            Persona persona = new Persona(nombre, apellido, rut, cargo);
            Personal_empresa.Add(persona);
            
        }

        public void agregar_seccion(Departamento dpto)
        {
            int w = 0, seg;
            do
            {
                Console.WriteLine("Ingrese el nombre de un Seccion:");
                string ar = Palabra();
                Console.WriteLine("Ingrese el Rut del encargado de Seccion:");
                int id = Numero(999999999);
                do
                {
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Seccion area = new Seccion(ar, p);
                            dpto.lista_secciones.Add(area);
                            w = 1;
                            break;
                        }
                    break;
                } while (w != 1);
                if (w != 1)
                {
                    Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                        "Registre al Empleado:");
                    agregar_personal();
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Seccion area = new Seccion(ar, p);
                            dpto.lista_secciones.Add(area);
                            
                            w = 1;
                            break;
                        }
                }
                Console.WriteLine("Si desea agregar otra Seccion ingrese 1 de lo contrario ingrese 2");
                seg = Numero(2);
            } while (seg != 2);
        }
        public void agregar_per_bloque(Bloque bloque)
        {
            int w = 0, seg;
            do
            {
                Console.WriteLine("Ingrese el Rut del Empleado:");
                int id = Numero(999999999);
                do
                {
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            bloque.personal_general.Add(p);
                            w = 1;
                            break;
                        }
                    
                } while (w != 1);
                if (w != 1)
                {
                    Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                        "Registre al Empleado:");
                    agregar_personal();
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            bloque.personal_general.Add(p);
                            w = 1;
                            break;
                        }
                }
                Console.WriteLine("Si desea agregar otro EMPLEADO al  Bloque ingrese 1 de lo contrario ingrese 2");
                seg = Numero(2);
            } while (seg != 2);
        }

        public void agregar_bloque(Seccion seccion)
        {
            int w = 0,seg;
            do
            {
                Console.WriteLine("Ingrese el nombre de un Bloque:");
                string ar = Palabra();
                Console.WriteLine("Ingrese el Rut del encargado de Bloque:");
                int id = Numero(999999999);
                do
                {
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Bloque area = new Bloque(ar, p);
                            seccion.lista_bloquess.Add(area);
                            Console.Clear();
                            Console.WriteLine("Debe Ingresar el Personal que trabaja en el Bloque");
                            agregar_per_bloque(area);
                            w = 1;
                            break;
                        }
                    break;
                } while (w != 1);
                if (w != 1)
                {
                    Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                        "Registre al Empleado:");
                    agregar_personal();
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Bloque area = new Bloque(ar, p);
                            seccion.lista_bloquess.Add(area);
                            Console.Clear();
                            Console.WriteLine("Debe Ingresar el Personal que trabaja en el Bloque");
                            agregar_per_bloque(area);
                            w = 1;
                            break;
                        }
                }
                Console.WriteLine("Si desea agregar otro Bloque ingrese 1 de lo contrario ingrese 2");
                seg = Numero(2);
            } while (seg != 2);
        }


        public void agregar_depto(Area a)
        {
            int w = 0, seg;
            do
            {

                Console.WriteLine("Ingrese el nombre de un Departamento:");
                string ar = Palabra();
                Console.WriteLine("Ingrese el Rut del encargado de Departamento:");
                int id = Numero(999999999);
                do
                {
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Departamento area = new Departamento(ar, p);
                            a.lista_departamentos.Add(area);
                            w = 1;
                            break;
                        }
                    break;
                } while (w != 1);
                if (w != 1)
                {
                    Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                        "Registre al Empleado:");
                    agregar_personal();
                    foreach (Persona p in Personal_empresa)
                        if (p.Rut == id)
                        {
                            Departamento area = new Departamento(ar, p);
                            a.lista_departamentos.Add(area);
                            w = 1;
                            break;
                        }
                }
                Console.WriteLine("Si desea agregar otro Departamento ingrese 1 de lo contrario ingrese 2");
                seg = Numero(2);
            } while (seg != 2);
        }

    }

}