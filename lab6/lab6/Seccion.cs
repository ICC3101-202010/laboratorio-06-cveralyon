﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab6
{
    [Serializable]
    public class Seccion : Division
    {
        public string name;
        public Persona encargado_seccion;

        public List<Bloque> lista_bloquess = new List<Bloque>();

        public Seccion(string name, Persona encargado_seccion)
        {
            this.name = name;
            this.encargado_seccion = encargado_seccion;
        }

        public List<Bloque> Lista_bloquess { get => lista_bloquess; set => lista_bloquess = value; }

        public void Info_seccion()
        {
            Console.WriteLine("Nombre de Bloque: " + name + "// Encargado de Bloque: " + encargado_seccion.Name);
            
        }
    }
}
