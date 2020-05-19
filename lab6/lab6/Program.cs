using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;

namespace lab6
{
    class MainClass
    {
        public static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine(">Selecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];
        }

        public static int Numero(int o) // verifica que el input  sea un numero dentro del rango requerido
        {
            int n;
            bool aux0;
            do
            {
                string p;
                p = Console.ReadLine();
                aux0 = int.TryParse(p, out n);
                if (aux0 == false || n > o) { Console.WriteLine("---ERROR: INGRESE SOLO NUMEROS del 1 al {0}---\n" +
                    "Intente Nuevamente: ", o); }
            } while (!aux0 || n > o);

            return n;
        }
        public static string Palabra() // verifica que el input sea palabra o signo .,/- 
        {
            string palabra;
            int count = 0;
            List<char> abcdario = new List<char> { 'A', 'B', 'C', 'D',' ','.',',','/','-', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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

        public static void serial(object empresa) // serializa una empresa 
        {           
            IFormatter formatear = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Append, FileAccess.Write);
            formatear.Serialize(stream, empresa);
            stream.Close();                
            
        }

        public static void deserial(Empresa empresa)
        {
            try
            {
                IFormatter formatear = new BinaryFormatter();
                Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read);
                empresa = (Empresa)formatear.Deserialize(stream);
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Lo Sentimos pero el archivo que desea cargar no existe...");
                Thread.Sleep(2000);
                Console.WriteLine("Ingrese el nombre de la Empresa:");
                string nombre = Palabra();
                Console.WriteLine("Ingrese el RUT de la Empresa:");
                int rut = Numero(999999999);
                empresa = new Empresa(nombre, rut);

                IFormatter formatear = new BinaryFormatter();
                Stream stream = new FileStream("empresa.bin", FileMode.Append, FileAccess.Write);

                formatear.Serialize(stream, empresa);
                stream.Close();
            }
            
            
        }



        public static void Main(string[] args)
        {

            Console.WriteLine("Desea Cargar la Informacion de la Empresa?");
            Console.WriteLine("1 -> Si, deseo cargar un archivo\n" +
                "2 -> No, Ingresare los datos manualmente\n");
            int op = Numero(2);

            if (op == 2)
            {
                Console.WriteLine("Ingrese el nombre de la Empresa:");
                string nombre = Palabra();
                Console.WriteLine("Ingrese el RUT de la Empresa:");
                int rut = Numero(999999999);
                Empresa empresa = new Empresa(nombre, rut);
                serial(empresa);
                Console.WriteLine("Cual es la mayor Division que posee su empresa:\n" +
                "1 -> Area\n" +
                "2 -> Departamento\n" +
                "3 -> Seccion\n" +
                "4 -> Bloque\n");
                int div = Numero(4);
                int seg, w;
                switch (div)
                {
                    case 1:
                        w = 0;
                        do
                        {

                            Console.WriteLine("Ingrese el nombre de un Area:");
                            string ar = Palabra();
                            Console.WriteLine("Ingrese el Rut del encargado de Area:");
                            int id = Numero(999999999);
                            do
                            {
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Area area = new Area(ar, p);
                                        empresa.Lista_areas.Add(area);
                                        serial(area);
                                        w = 1;
                                        break;
                                    }
                                break;
                            } while (w != 1);
                            if (w!=1)
                            {
                                Console.WriteLine("Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado\n" +
                                    "Registre al Empleado:");
                                empresa.agregar_personal();
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Area area = new Area(ar, p);
                                        empresa.Lista_areas.Add(area);
                                        serial(area);
                                        serial(empresa);

                                        w = 1;
                                        break;
                                    }
                            }

                            Console.WriteLine("Si agregar otra area ingrese 1 de lo contrario ingrese 2");
                            seg = Numero(2);
                        } while (seg != 2);
                        serial(empresa);

                        break;

                    case 2:
                        w = 0;
                        do
                        {

                            Console.WriteLine("Ingrese el nombre de un Departamento:");
                            string ar = Palabra();
                            Console.WriteLine("Ingrese el Rut del encargado de Departamento:");
                            int id = Numero(999999999);
                            do
                            {
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Departamento area = new Departamento(ar, p);
                                        empresa.Lista_dptos.Add(area);
                                        serial(area);
                                        serial(empresa);

                                        w = 1;
                                        break;
                                    }
                                break;
                            } while (w != 1);
                            if (w != 1)
                            {
                                Console.WriteLine("Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado\n" +
                                    "Registre al Empleado:");
                                empresa.agregar_personal();
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Departamento area = new Departamento(ar, p);
                                        empresa.Lista_dptos.Add(area);
                                        serial(area);
                                        serial(empresa);


                                        w = 1;
                                        break;
                                    }
                            }
                            Console.WriteLine("Si desea agregar otro Departamento ingrese 1 de lo contrario ingrese 2");
                            seg = Numero(2);
                        } while (seg != 2);
                        serial(empresa);

                        break;
                    case 3:
                        w = 0;
                        do
                        {
                            Console.WriteLine("Ingrese el nombre de un Seccion:");
                            string ar = Palabra();
                            Console.WriteLine("Ingrese el Rut del encargado de Seccion:");
                            int id = Numero(999999999);
                            do
                            {
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Seccion area = new Seccion(ar, p);
                                        empresa.Lista_secciones.Add(area);
                                        serial(area);
                                        serial(empresa);

                                        w = 1;
                                        break;
                                    }
                                break;
                            } while (w != 1);
                            if (w != 1)
                            {
                                Console.WriteLine("Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado\n" +
                                    "Registre al Empleado:");
                                empresa.agregar_personal();
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Seccion area = new Seccion(ar, p);
                                        empresa.Lista_secciones.Add(area);
                                        serial(area);
                                        serial(empresa);

                                        w = 1;
                                        break;
                                    }
                            }
                            Console.WriteLine("Si desea agregar otra Seccion ingrese 1 de lo contrario ingrese 2");
                            seg = Numero(2);
                        } while (seg != 2);
                        serial(empresa);

                        break;
                    case 4:
                        w = 0;
                        do
                        {
                            Console.WriteLine("Ingrese el nombre de un Bloque:");
                            string ar = Palabra();
                            Console.WriteLine("Ingrese el Rut del encargado de Bloque:");
                            int id = Numero(999999999);
                            do
                            {
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Bloque area = new Bloque(ar, p);
                                        empresa.Lista_bloques.Add(area);
                                        serial(area);
                                        serial(empresa);

                                        w = 1;
                                        break;
                                    }
                                break;
                            } while (w != 1);
                            if (w != 1)
                            {
                                Console.WriteLine("Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado\n" +
                                    "Registre al Empleado:");
                                empresa.agregar_personal();
                                foreach (Persona p in empresa.Personal_empresa)
                                    if (p.Rut == id)
                                    {
                                        Bloque area = new Bloque(ar, p);
                                        empresa.Lista_bloques.Add(area);
                                        w = 1;
                                        break;
                                    }
                            }
                            Console.WriteLine("Si desea agregar otro Bloque ingrese 1 de lo contrario ingrese 2");
                            seg = Numero(2);
                        } while (seg != 2);
                        serial(empresa);

                        break;
                }
                serial(empresa);

                if (div == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Debe agregar los Departamentos de cada area.");
                    List<string> nom_area = new List<string>();
                    int num = 1;
                    foreach (Area area in empresa.Lista_areas)
                    {
                        nom_area.Add(area.name);
                        num++;
                    }
                    int num_select = 1;
                    string criterio;
                    while (num_select <= num)
                    {
                        Console.WriteLine("Seleccione un area:");
                        criterio = "\0";
                        criterio = ShowOptions(nom_area);
                        nom_area.Remove(criterio);
                        foreach (Area area in empresa.Lista_areas)
                        {
                            if (area.name == criterio)
                            {
                                empresa.agregar_depto(area);
                                serial(empresa);
                                serial(area);


                                Console.Clear();
                                Console.WriteLine("Debe agregar las Secciones de cada Departamento.");
                                List<string> nom_depto = new List<string>();
                                num = 1;
                                foreach (Departamento depto in area.lista_departamentos)
                                {
                                    nom_depto.Add(depto.name);
                                    num++;
                                }
                                num_select = 1;
                                while (num_select <= num)
                                {
                                    Console.WriteLine("Seleccione un Departamento:");
                                    criterio = "\0";
                                    criterio = ShowOptions(nom_depto);
                                    nom_depto.Remove(criterio);
                                    foreach (Departamento dpto in area.lista_departamentos)
                                    {
                                        if (dpto.name == criterio)
                                        {
                                            empresa.agregar_seccion(dpto);
                                            serial(dpto);
                                            serial(empresa);

                                            Console.Clear();
                                            Console.WriteLine("Debe agregar los Bloques de cada Seccion.");
                                            List<string> nom_sec = new List<string>();
                                            num = 1;
                                            foreach (Seccion seccion in dpto.lista_secciones)
                                            {
                                                nom_sec.Add(seccion.name);
                                                num++;
                                            }
                                            num_select = 1;
                                            while (num_select <= num)
                                            {
                                                Console.WriteLine("Seleccione una Seccion:");
                                                criterio = "\0";
                                                criterio = ShowOptions(nom_sec);
                                                nom_sec.Remove(criterio);
                                                foreach (Seccion se in dpto.lista_secciones)
                                                {
                                                    if (se.name == criterio)
                                                    {
                                                        empresa.agregar_bloque(se);
                                                        serial(se);
                                                        serial(empresa);

                                                    }
                                                }
                                                num_select++;
                                            }
                                        }
                                    }
                                    serial(empresa);

                                    num_select++;
                                }
                            }
                        }
                        num_select++;
                    }
                    serial(empresa);

                    Console.Clear();
                }
                else if (div == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Debe agregar las Secciones de cada Departamento.");
                    List<string> nom_depto = new List<string>();
                    int num = 1;
                    foreach (Departamento depto in empresa.Lista_dptos)
                    {
                        nom_depto.Add(depto.name);
                        num++;
                    }
                    int num_select = 1;
                    while (num_select <= num)
                    {
                        Console.WriteLine("Seleccione un Departamento:");
                        string criterio = "\0";
                        criterio = ShowOptions(nom_depto);
                        nom_depto.Remove(criterio);
                        foreach (Departamento dpto in empresa.Lista_dptos)
                        {
                            if (dpto.name == criterio)
                            {
                                empresa.agregar_seccion(dpto);
                                serial(empresa);
                                serial(dpto);

                                Console.Clear();
                                Console.WriteLine("Debe agregar los Bloques de cada Seccion.");
                                List<string> nom_sec = new List<string>();
                                num = 1;
                                foreach (Seccion seccion in dpto.lista_secciones)
                                {
                                    nom_sec.Add(seccion.name);
                                    num++;
                                }
                                num_select = 1;
                                while (num_select <= num)
                                {
                                    Console.WriteLine("Seleccione una Seccion:");
                                    criterio = "\0";
                                    criterio = ShowOptions(nom_sec);
                                    nom_sec.Remove(criterio);
                                    foreach (Seccion se in dpto.lista_secciones)
                                    {
                                        if (se.name == criterio)
                                        {
                                            empresa.agregar_bloque(se);
                                            serial(empresa);
                                            serial(se);

                                        }
                                        serial(empresa);

                                    }
                                    num_select++;
                                }
                            }
                            serial(empresa);

                        }
                        num_select++;
                    }
                    serial(empresa);

                }
                else if (div == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Debe agregar los Bloques de cada Seccion.");
                    List<string> nom_sec = new List<string>();
                    int num = 1;
                    foreach (Seccion seccion in empresa.Lista_secciones)
                    {
                        nom_sec.Add(seccion.name);
                        serial(empresa);

                        num++;
                    }
                    int num_select = 1;
                    while (num_select <= num)
                    {
                        Console.WriteLine("Seleccione una Seccion:");
                        string criterio = "\0";
                        criterio = ShowOptions(nom_sec);
                        nom_sec.Remove(criterio);
                        foreach (Seccion se in empresa.Lista_secciones)
                        {
                            if (se.name == criterio)
                            {
                                empresa.agregar_bloque(se);
                                serial(empresa);
                                serial(se);


                            }
                            serial(empresa);

                        }
                        num_select++;
                    }

                }
                serial(empresa);

            }
            else if (op == 1)
            {
                Empresa empresa;
                try
                {
                    IFormatter formatear = new BinaryFormatter();
                    Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read);
                     empresa = (Empresa)formatear.Deserialize(stream);
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine("Lo Sentimos pero el archivo que desea cargar no existe...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Ingrese el nombre de la Empresa:");
                    string nombre = Palabra();
                    Console.WriteLine("Ingrese el RUT de la Empresa:");
                    int rut = Numero(999999999);
                     empresa = new Empresa(nombre, rut);

                    IFormatter formatear = new BinaryFormatter();
                    Stream stream = new FileStream("empresa.bin", FileMode.Append, FileAccess.Write);

                    formatear.Serialize(stream, empresa);
                    stream.Close();
                }

                Console.WriteLine(empresa.Name);
                if (empresa.Lista_areas != null)
                {
                    foreach(Area area in empresa.Lista_areas)
                    {
                        area.info_area();
                        foreach(Departamento depto in area.lista_departamentos)
                        {
                            depto.info_depto();
                            foreach(Seccion seccion in depto.lista_secciones)
                            {
                                seccion.info_seccion();
                                foreach(Bloque bloque in seccion.lista_bloquess)
                                {
                                    bloque.info_bloque();
                                }
                            }
                        }
                    }
                }
                else if (empresa.Lista_dptos != null)
                {
                    foreach (Departamento depto in empresa.Lista_dptos)
                    {
                        depto.info_depto();
                        foreach (Seccion seccion in depto.lista_secciones)
                        {
                            seccion.info_seccion();
                            foreach (Bloque bloque in seccion.lista_bloquess)
                            {
                                bloque.info_bloque();
                            }
                        }
                    }
                }
                else if (empresa.Lista_secciones!= null)
                {
                    foreach (Seccion seccion in empresa.Lista_secciones)
                    {
                        seccion.info_seccion();
                        foreach (Bloque bloque in seccion.lista_bloquess)
                        {
                            bloque.info_bloque();
                        }
                    }
                }
                else
                {
                    foreach (Bloque bloque in empresa.Lista_bloques)
                    {
                        bloque.info_bloque();
                    }

                }
            }

            


             
        }
    }
}
