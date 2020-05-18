using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public class Area: Division
    {
        public Persona encargado_area;
        public List<Departamento> lista_departamentos = new List<Departamento>();

        public Area(Persona encargado_area) : base(encargado_area)
        {
            this.encargado_area = encargado_area;
        }
    }
}
