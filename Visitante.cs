using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>     
    /// <author>Rebeca Bárcena Orero</author>
    /// Clase abstracta que implementa a un visitante
    /// </summary>
    public abstract class Visitante
    {
        /// <summary>
        /// Método abstracto que implementa la operación operación 
        /// “Accept” que toma un visitante como argumento
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public abstract String aceptar(Formato f);
    }
}
