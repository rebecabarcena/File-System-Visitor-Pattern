using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{    
     /// <summary>
     /// <author>Rebeca Bárcena Orero</author>
     /// Elemento que permite ir directamente desde el lugar donde 
     /// se encuentra hasta otro elemento del sistema de archivos.
     /// </summary>
    public class EnlaceDirecto: Componente
    {
        // Tamaño que ocupa en el sistema de ficheros
        private int tamaño = 1;
        // Referencia al elemento al que permite ir.
        private Componente elementoDestino;
        public Componente ElementoDestino
        {
            get
            {
                return elementoDestino;
            }

            set
            {
                // No se permite que el elemento destino sea un enlace directo.
                if (!(value is EnlaceDirecto))
                {
                    elementoDestino = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elemento"></param>
        public EnlaceDirecto(Componente elemento)
        {
            if(!(elemento is EnlaceDirecto))
            {
                elementoDestino = elemento;
            }
            Nombre = elemento.Nombre;
            Tamaño = tamaño;
        }

        /// <summary>
        /// Número de elementos contenidos en el enlace directo
        /// </summary>
        /// <returns></returns>
        public override int numElem()
        {
            return 1;
        }        

        /// <summary>
        /// Método equals
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public Boolean equals(Object o)
        {
            if (o == null)
            {
                return false;
            }

            if (!(o is EnlaceDirecto))
            {
                return false;
            }
            else if (((EnlaceDirecto)o).Nombre.Equals(Nombre))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método abstracto que implementa la operación operación 
        /// “Accept” que toma un visitante como argumento
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public override String aceptar(Formato f)
        {
            return f.formatoEnlaceDirecto(this);
        }
    }
}
