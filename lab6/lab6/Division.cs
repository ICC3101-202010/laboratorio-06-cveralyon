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
    public abstract class Division
    {
        private string name;
        private Persona encargado;
        


        public string Name { get => name; set => name = value; }
        public Persona Encargado { get => encargado; set => encargado = value; }
        

        protected Division(string name, Persona encargado)
        {
            this.name = name;
            this.encargado = encargado;
        }
    }
}
