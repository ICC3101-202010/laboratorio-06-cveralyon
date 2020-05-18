using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace lab6
{
    [Serializable]
    public abstract class Division
    {
        private Persona encargado;

        protected Division(Persona encargado)
        {
            this.encargado = encargado;
        }

        public Persona Encargado { get => encargado; set => encargado = value; }
    }
}
