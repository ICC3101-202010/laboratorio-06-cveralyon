using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class MainClass
    {
        public static int Numero(int o) // verifica que el input  sea un numero dentro del rango requerido
        {
            int n;
            bool aux0;
            do
            {
                string p;
                p = Console.ReadLine();
                aux0 = int.TryParse(p, out n);
                if (aux0 == false || n > o) { Console.WriteLine("---ERROR: INGRESE SOLO NUMEROS del 1 al {0}---", o); }
            } while (!aux0 || n > o);

            return n;
        }
        public static string Palabra()
        {
            string palabra;
            int count = 0;
            List<char> abcdario = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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
                    Console.WriteLine("---ERROR: NO PUEDE INGRESAR CARACTERES QUE NO SEAN LETRAS---");
                }
            } while (palabra.Length != count);


            return palabra.ToLower();
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

            }
            else if (op == 1)
            {

            }



        }
    }
}
