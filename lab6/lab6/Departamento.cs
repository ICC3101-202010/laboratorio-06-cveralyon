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
    public class Departamento : Division
    {
        public string name;
        public Persona encargado_depto;

        public List<Seccion> lista_secciones = new List<Seccion>();

        public Departamento(string name, Persona encargado_depto)
        {
            this.name = name;
            this.encargado_depto = encargado_depto;
        }

        public void Info_depto()
        {
            Console.WriteLine("Nombre de Bloque: " + name + "// Encargado de Bloque: " + encargado_depto.Name);

        }
    }
}
