using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public class Departamento : Division
    {
        public Persona encargado_depto;

        public List<Seccion> lista_secciones = new List<Seccion>();

        public Departamento(Persona encargado_depto) : base(encargado_depto)
        {
            this.encargado_depto = encargado_depto;
        }
    }
}
