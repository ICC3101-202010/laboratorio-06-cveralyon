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
    public class Bloque : Division
    {
        public string name;
        public Persona encargado_bloque;
        public List<Persona> personal_general = new List<Persona>();

        public Bloque(string name, Persona encargado_bloque) : base(name, encargado_bloque)
        {
            this.name = name;
            this.encargado_bloque = encargado_bloque;
        }

        public void info_bloque()
        {
            Console.WriteLine("Nombre de Bloque: " + name + "// Encargado de Bloque: " + encargado_bloque.Name);
            Console.WriteLine("Personal de Bloque: ");
            foreach (Persona pp in personal_general)
            {
                Console.WriteLine(" - " + pp.Name);
            }
        }


    }
}
