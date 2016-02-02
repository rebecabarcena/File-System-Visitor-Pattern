using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{    
     /// <summary>
     /// <author>Rebeca Bárcena Orero</author>
     /// Elemento básico del sistema de archivos. Se corresponde con
     /// documentos, fotografías u otros elementos que se deseen almacenar
     /// en el sistema de ficheros.
     /// </summary>
    public class Archivo : Componente
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tamaño"></param>
        public Archivo(String nombre, int tamaño)
        {
            Nombre = nombre;
            Tamaño = tamaño;
        }

        /// <summary>
        /// Retorna el número de elementos
        /// </summary>
        /// <returns></returns>
        public override int numElem()
        {
            return 1;
        }

        /// <summary>
        /// Método equals que indica si un objeto es igual a la instancia de 
        /// esta clase
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public Boolean equals(Object o)
        {
            if (o == null)
            {
                return false;
            }

            if(!(o is Archivo))
            {
                return false;
            } else if (((Archivo)o).Nombre.Equals(Nombre))
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
            return f.formatoArchivo(this);
        }
    }
}
