using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Clase que implementa el tipo de formato desplegado
    /// </summary>
    public class Desplegado : Formato
    {
        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo archivo. Retorna un String con su nombre
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public override String formatoArchivo(Archivo a)
        {
            return "f " + a.Nombre.ToString();
        }

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo archivo comprimido. Retorna un String
        /// con su nombre y contenido
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public override String formatoArchivoComprimido(ArchivoComprimido a)
        {
            String resultado;
            resultado = "c " + a.Nombre.ToString();

            return resultado + formatoSet(a.getComprimidos(), this);
        }

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo directorio. Retorna un String con su
        /// nombre y contenido
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public override String formatoDirectorio(Directorio d)
        {
            String resultado;
            resultado = "d " + d.Nombre.ToString();
            
            return resultado + formatoSet(d.getContenido(), this);
        }

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo enlace directo. Retorna un String con
        ///  su nombre
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        public override String formatoEnlaceDirecto(EnlaceDirecto ec)
        {
            return "e " + ec.Nombre.ToString();
        }
    }
}

