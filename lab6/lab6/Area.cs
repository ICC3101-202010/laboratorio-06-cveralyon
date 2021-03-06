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
    public class Area: Division
    {
        public string name;
        public Persona encargado_area;
        public List<Departamento> lista_departamentos = new List<Departamento>();

        public Area(String name, Persona encargado_area) 
        {
            this.name = name;
            this.encargado_area = encargado_area;
        }

        public List<Departamento> Lista_departamentos { get => lista_departamentos; set => lista_departamentos = value; }

        public void Info_area()
        {
            Console.WriteLine("Nombre de Bloque: " + name + "// Encargado de Bloque: " + encargado_area.Name);

        }
    }
}
