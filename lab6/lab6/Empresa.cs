using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public class Empresa
    {
        private string name;
        private int rut;
        public List<Division> lista_divisiones = new List<Division>();

        public string Name { get => name; set => name = value; }
        public int Rut { get => rut; set => rut = value; }

        public Empresa(string name, int rut)
        {
            this.name = name;
            this.rut = rut;
        }
    }
       
}