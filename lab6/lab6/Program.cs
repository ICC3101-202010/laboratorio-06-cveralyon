using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace lab6
{
    class MainClass
    {
        public static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n>Selecciona una opcion:");
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
                if (aux0 == false || n > o)
                {
                    Console.WriteLine("---ERROR: INGRESE SOLO NUMEROS del 1 al {0}---\n" +
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
            Stream stream = new FileStream("empresa.bin", FileMode.OpenOrCreate, FileAccess.Write);
            formatear.Serialize(stream, empresa);
            stream.Close();                
            
        }

        public static Empresa deserial() // deserializa una empresa 
        {
            
            try
            {
                IFormatter formatear = new BinaryFormatter();
                Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read);
                Empresa empresa = (Empresa)formatear.Deserialize(stream);
                stream.Close();

                return empresa;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Lo Sentimos pero el archivo que desea cargar no existe...");
                Thread.Sleep(2000);
                return crear_empresa();
            }
            
        }

        public static Empresa crear_empresa()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre de la Empresa:");
            string nombre = Palabra();
            Console.WriteLine("Ingrese el RUT de la Empresa:");
            int rut = Numero(999999999);
            Empresa empresa = new Empresa(nombre, rut);
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
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre de un Area:");
                        string ar = Palabra();
                        Console.WriteLine("Ingrese el Rut del encargado de Area:");
                        int id = Numero(999999999);
                        do
                        {
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Area area = new Area(ar, p);
                                    empresa.Lista_areas.Add(area);
                                    w = 1;
                                    break;
                                }
                            break;
                        } while (w != 1);
                        if (w != 1)
                        {
                            Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                                "Registre al Empleado:");
                            empresa.agregar_personal();
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Area area = new Area(ar, p);
                                    empresa.Lista_areas.Add(area);
                                    w = 1;
                                    break;
                                }
                        }

                        Console.WriteLine("Si agregar otra area ingrese 1 de lo contrario ingrese 2");
                        seg = Numero(2);
                    } while (seg != 2);
                    break;

                case 2:
                    w = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre de un Departamento:");
                        string ar = Palabra();
                        Console.WriteLine("Ingrese el Rut del encargado de Departamento:");
                        int id = Numero(999999999);
                        do
                        {
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Departamento d = new Departamento(ar, p);
                                    empresa.Lista_dptos.Add(d);
                                    w = 1;
                                    break;
                                }
                            break;
                        } while (w != 1);
                        if (w != 1)
                        {
                            Console.WriteLine(" \n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado ====\n" +
                                "Registre al Empleado:");
                            empresa.agregar_personal();
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Departamento d = new Departamento(ar, p);
                                    empresa.Lista_dptos.Add(d);
                                    w = 1;
                                    break;
                                }
                        }
                        Console.WriteLine("Si desea agregar otro Departamento ingrese 1 de lo contrario ingrese 2");
                        seg = Numero(2);
                    } while (seg != 2);

                    break;
                case 3:
                    w = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre de un Seccion:");
                        string ar = Palabra();
                        Console.WriteLine("Ingrese el Rut del encargado de Seccion:");
                        int id = Numero(999999999);
                        do
                        {
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Seccion s = new Seccion(ar, p);
                                    empresa.Lista_secciones.Add(s);
                                    w = 1;
                                    break;
                                }
                            break;
                        } while (w != 1);
                        if (w != 1)
                        {
                            Console.WriteLine(" \n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado ====\n" +
                                "Registre al Empleado:");
                            empresa.agregar_personal();
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Seccion s = new Seccion(ar, p);
                                    empresa.Lista_secciones.Add(s);
                                    w = 1;
                                    break;
                                }
                        }
                        Console.WriteLine("Si desea agregar otra Seccion ingrese 1 de lo contrario ingrese 2");
                        seg = Numero(2);
                    } while (seg != 2);

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
                                if (p.rut == id)
                                {
                                    Bloque area = new Bloque(ar, p);
                                    empresa.Lista_bloques.Add(area);
                                    Console.Clear();
                                    Console.WriteLine("Debe Ingresar el Personal que trabaja en el Bloque");
                                    empresa.agregar_per_bloque(area);
                                    w = 1;
                                    break;
                                }
                            break;
                        } while (w != 1);
                        if (w != 1)
                        {
                            Console.WriteLine("\n====Rut incorrecto, posiblemente el empleado ingresado aun no ha sido registrado====\n" +
                                "Registre al Empleado:");
                            empresa.agregar_personal();
                            foreach (Persona p in empresa.Personal_empresa)
                                if (p.rut == id)
                                {
                                    Bloque area = new Bloque(ar, p);
                                    empresa.Lista_bloques.Add(area);
                                    Console.Clear();
                                    Console.WriteLine("Debe Ingresar el Personal que trabaja en el Bloque");
                                    empresa.agregar_per_bloque(area);
                                    w = 1;
                                    break;
                                }
                        }
                        Console.WriteLine("Si desea agregar otro Bloque ingrese 1 de lo contrario ingrese 2");
                        seg = Numero(2);
                    } while (seg != 2);

                    break;
            }

            if (div == 1)
            {
                Console.Clear();
                Console.WriteLine("Debe agregar los Departamentos de cada area.");
                List<string> nom_area = new List<string>();
                int num = 1;
                foreach (Area aa in empresa.Lista_areas)
                {
                    nom_area.Add(aa.name);
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
                    Console.WriteLine("ENTRE--------------------------------");

                    foreach (Area area in empresa.Lista_areas)
                    {
                        if (area.name == criterio)
                        {
                            empresa.agregar_depto(area);
                            Console.Clear();
                            Console.WriteLine("Debe agregar las Secciones de cada Departamento.");
                            List<string> nom_depto = new List<string>();
                            num = 1;
                            foreach (Departamento dd in area.Lista_departamentos)
                            {
                                nom_depto.Add(dd.name);
                                num++;
                            }
                            num_select = 1;
                            while (num_select <= num)
                            {
                                Console.WriteLine("Seleccione un Departamento:");
                                criterio = "\0";
                                criterio = ShowOptions(nom_depto);
                                nom_depto.Remove(criterio);
                                foreach (Departamento dpto in area.Lista_departamentos)
                                {
                                    if (dpto.name == criterio)
                                    {
                                        empresa.agregar_seccion(dpto);
                                        Console.Clear();
                                        Console.WriteLine("Debe agregar los Bloques de cada Seccion.");
                                        List<string> nom_sec = new List<string>();
                                        num = 1;
                                        foreach (Seccion ss in dpto.Lista_secciones)
                                        {
                                            nom_sec.Add(ss.name);
                                            num++;
                                        }
                                        num_select = 1;
                                        while (num_select <= num)
                                        {

                                            Console.WriteLine("Seleccione una Seccion:");
                                            criterio = "\0";
                                            criterio = ShowOptions(nom_sec);
                                            nom_sec.Remove(criterio);
                                            foreach (Seccion se in dpto.Lista_secciones)
                                            {
                                                if (se.name == criterio)
                                                {
                                                    empresa.agregar_bloque(se);

                                                }
                                            }
                                            if (nom_sec.Count() == 0)
                                            {
                                                break;
                                            }
                                            num_select++;
                                        }
                                    }
                                }
                                if (nom_depto.Count() == 0)
                                {
                                    break;
                                }
                                num_select++;
                            }
                        }
                    }
                    if (nom_area.Count() == 0)
                    {
                        break;
                    }
                    num_select++;
                }
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
                            foreach (Seccion seccion in dpto.Lista_secciones)
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
                                foreach (Seccion se in dpto.Lista_secciones)
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
            

            return empresa;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Desea Cargar la Informacion de la Empresa?");
            Console.WriteLine("1 -> Si, deseo cargar un archivo\n" +
                "2 -> No, Ingresare los datos manualmente\n");
            int op = Numero(2);

            if (op == 2)
            {
                serial(crear_empresa());
            }
            else if (op == 1)
            {
                Console.Clear();
                Empresa empresa = deserial();


                Console.WriteLine("NOMBRE EMPRESA: "+empresa.Name);
                
                if (empresa.Lista_areas.Count() != 0)
                {
                    foreach(Area area in empresa.Lista_areas)
                    {
                        area.Info_area();
                        foreach(Departamento depto in area.Lista_departamentos)
                        {
                            depto.Info_depto();
                            foreach(Seccion seccion in depto.Lista_secciones)
                            {
                                seccion.Info_seccion();
                                foreach(Bloque bloque in seccion.Lista_bloquess)
                                {
                                    bloque.Info_bloque();
                                }
                            }
                        }
                    }
                }
                else if (empresa.Lista_dptos.Count() != 0)
                {
                    foreach (Departamento depto in empresa.Lista_dptos)
                    {
                        depto.Info_depto();
                        foreach (Seccion seccion in depto.Lista_secciones)
                        {
                            seccion.Info_seccion();
                            foreach (Bloque bloque in seccion.Lista_bloquess)
                            {
                                bloque.Info_bloque();
                            }
                        }
                    }
                }
                else if (empresa.Lista_secciones.Count() != 0)
                {
                    foreach (Seccion seccion in empresa.Lista_secciones)
                    {
                        seccion.Info_seccion();
                        foreach (Bloque bloque in seccion.Lista_bloquess)
                        {
                            bloque.Info_bloque();
                        }
                    }
                }
                else
                {
                    foreach (Bloque bloque in empresa.Lista_bloques)
                    {
                        bloque.Info_bloque();
                    }

                }
                serial(empresa);
                Console.ReadKey();
            }

            


             
        }
    }
}
