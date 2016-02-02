using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Archivo especial que almacena en su interior elementos del sistema
    /// de archivos de manera comprimida.
    /// </summary>
    public class ArchivoComprimido: Componente
    {
        // Tamaño del fichero tras la compresión, en %.
        private int tamañoCompresion = 30;
        // Lista de archivos comprimidos en este archivo comprimido
        private ISet<Componente> comprimidos = new HashSet<Componente>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        public ArchivoComprimido(String nombre)
        {
            Nombre = nombre;
            Tamaño = 0;
        }

        /// <summary>
        /// Retorna el ISet con todo el contenido del archivo
        /// comprimido
        /// </summary>
        /// <returns></returns>
        public ISet<Componente> getComprimidos()
        {
            return comprimidos;
        }

        /// <summary>
        /// Retorna el número de archivos comprimidos en este archivo
        /// comprimido
        /// </summary>
        /// <returns></returns>
        public override int numElem()
        {
            int numElem = 1;
            Func<int, int> lambda = num => numElem = num + numElem;

            comprimidos.ToList().ForEach(n => lambda(n.numElem())); 
            return numElem;
        }

        /// <summary>
        /// Añade un archivo al archivo comprimido
        /// </summary>
        /// <param name="c"></param>
        public void añadeArchivo(Componente c)
        {
            if (!comprimidos.Contains(c))
            {
                comprimidos.Add(c);
                aumentaTamaño(c.Tamaño);
            }
        }

        /// <summary>
        /// Elimina un archivo del archivo comprimido
        /// </summary>
        /// <param name="c"></param>
        public void eliminaArchivo(Componente c)
        {
            if (comprimidos.Contains(c))
            {
                comprimidos.Remove(c);
                disminuyeTamaño(c.Tamaño);
            }
        }

        /// <summary>
        /// Es llamado para aumentar el tamaño del archivo comprimido
        /// cuando añadimos otro componente
        /// </summary>
        /// <param name="tam"></param>
        private void aumentaTamaño(int tam)
        {
            double tamañoAux = Tamaño * 100 / tamañoCompresion;
            tamañoAux += tam;
            Tamaño = (int) tamañoAux * tamañoCompresion / 100;
        }

        /// <summary>
        /// Es llamado para disminuir el tamaño del archivo comprimido
        /// cuando eliminamos otro componente
        /// </summary>
        /// <param name="tam"></param>
        private void disminuyeTamaño(int tam)
        {
            double tamañoAux = Tamaño * 100 / tamañoCompresion;
            tamañoAux -= tam;
            // Si nos sale negativo puede ser debido a que se pierde algo de
            // precisión al usar enteros, por lo que lo ponemos a 0.
            if (tamañoAux < 0)
            {
                tamañoAux = 0;
            }
            Tamaño = (int) tamañoAux * tamañoCompresion / 100;
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

            if (!(o is ArchivoComprimido))
            {
                return false;
            }
            else if (((ArchivoComprimido)o).Nombre.Equals(Nombre))
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
            return f.formatoArchivoComprimido(this);
        }
    }
}
