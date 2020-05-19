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
    public class Persona
    {
        private string name;
        private string last;
        private int rut;
        private string cargo;

        public string Name { get => name; set => name = value; }
        public string Last { get => last; set => last = value; }
        public int Rut { get => rut; set => rut = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Persona(string name, string last, int rut, string cargo)
        {
            this.name = name;
            this.last = last;
            this.rut = rut;
            this.cargo = cargo;
        }


    }
}
