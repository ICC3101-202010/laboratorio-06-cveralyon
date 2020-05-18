using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public class Bloque : Division
    {
        public Persona encargado_bloque;
        public List<Persona> personal_general = new List<Persona>();

        public Bloque(Persona encargado_bloque) : base(encargado_bloque)
        {
            this.encargado_bloque = encargado_bloque;
        }
    }
}
