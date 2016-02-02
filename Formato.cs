using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Clase que implementa un formato de impresión
    /// </summary>
    public abstract class Formato
    {
        // Valor de la tabulación. Por defecto es 3, pero se 
        // puede configurar
        private int _tabulacion = 3;

        // Get y set de la tabulación
        public int Tabulacion
        {
            get
            {
                return _tabulacion;
            }

            set
            {
                _tabulacion = value;
            }
        }

        // Anidamiento del componente
        public int anidamiento = 0;

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo archivo.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public abstract String formatoArchivo(Archivo a);

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo archivo comprimido.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public abstract String formatoArchivoComprimido(ArchivoComprimido a);

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo directorio. 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public abstract String formatoDirectorio(Directorio d);

        /// <summary>
        /// Función que declara una operación de visita para los 
        /// objetos de tipo enlace directo. Retorna un String con
        /// su nombre
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        public abstract String formatoEnlaceDirecto(EnlaceDirecto ec);

        /// <summary>
        /// Función que retorna un String con el nombre de los elementos del
        /// ISet que se pasa como parámetro, uno por cada línea, y añadiendo
        /// la tabulación establecida.
        /// </summary>
        /// <param name="componentes"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public String formatoSet(ISet<Componente> componentes, Formato f)
        {
            String resultado = "";
            anidamiento++;
            foreach (Componente c in componentes)
            {
                resultado += "\n";
                resultado = creaTab(resultado);
                resultado += c.aceptar(f);
            }
            anidamiento--;
            return resultado;
        }

        /// <summary>
        /// Método auxiliar que añade las tabulaciones correspondientes
        /// en función del nivel de anidamiento y la tabulación elegida.
        /// </summary>
        /// <param name="resultado"></param>
        /// <returns></returns>
        private String creaTab(String resultado)
        {
            int j = 0;
            while (j < anidamiento)
            {
                int i = 0;
                while (i < Tabulacion)
                {
                    resultado += " ";
                    i++;
                }
                j++;
            }
            return resultado;
        }
    }
}
