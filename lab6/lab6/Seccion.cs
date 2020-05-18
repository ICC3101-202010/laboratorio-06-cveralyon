using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public class Seccion : Division
    {
        public Persona encargado_seccion;

        public List<Bloque> lista_bloquess = new List<Bloque>();

        public Seccion(Persona encargado_seccion) : base(encargado_seccion)
        {
            this.encargado_seccion = encargado_seccion;
        }
    }
}
