using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Clase abstracta que implementa un componente.
    /// </summary>
    public abstract class Componente: Visitante
    {
        // Nombre del componente
        private String nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        // Tamaño del componente
        private int tamaño;

        public int Tamaño
        {
            get
            {
                return tamaño;
            }

            set
            {
                tamaño = value;
            }
        }

        /// <summary>
        /// Función que retorna el número de componentes o elementos
        /// dentro de un componente
        /// </summary>
        /// <returns></returns>
        public abstract int numElem();

        /// <summary>
        /// Método abstracto que implementa la operación operación 
        /// “Accept” que toma un visitante como argumento
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public override abstract String aceptar(Formato f);
    }
}
