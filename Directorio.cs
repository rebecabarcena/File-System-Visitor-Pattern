using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Contenedor de archivos u otros elementos que pueda alojar el sistema de archivos, 
    /// sirviendo para organizar y estructurar el sistema de manera que sea más fácil la
    /// localización de la información, de acuerdo al criterio de cada usuario.
    /// </summary>
    public class Directorio: Componente
    {
        // Tamaño que ocupa un directorio sólo por su definición
        private int definicion = 1;
        // Archivos almacenados en el directorio
        private ISet<Componente> contenidos = new HashSet<Componente>();

        public Directorio(String nombre)
        {
            Nombre = nombre;
            Tamaño = definicion;
        }

        /// <summary>
        /// Retorna el ISet con todo el contenido del directorio
        /// </summary>
        /// <returns></returns>
        public ISet<Componente> getContenido()
        {
            return contenidos;
        }

        /// <summary>
        /// Añade un componente al directorio
        /// </summary>
        /// <param name="c"></param>
        public void añadeElemento(Componente c)
        {
            if (!contenidos.Contains(c))
            {
                contenidos.Add(c);
                Tamaño += c.Tamaño;
            }
        }

        /// <summary>
        /// Elimina un componente del directorio
        /// </summary>
        /// <param name="c"></param>
        public void eliminaElemento(Componente c)
        {
            if (contenidos.Contains(c))
            {
                contenidos.Remove(c);
                Tamaño -= c.Tamaño;
            }
        }

        /// <summary>
        /// Retorna el número de archivos contenidos en este directorio
        /// </summary>
        /// <returns></returns>
        public override int numElem()
        {
            int numElem = 1;
            Func<int, int> lambda = num => numElem = num + numElem;

            contenidos.ToList().ForEach(n => lambda(n.numElem()));
            return numElem;
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

            if (!(o is Directorio))
            {
                return false;
            }
            else if (((Directorio)o).Nombre.Equals(Nombre))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método abstracto que implementa la operación de visita
        /// para cada elemento concreto en la estructura de objetos
        /// dependiendo del formato que pasemos como parámetro.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public override String aceptar(Formato f)
        {
            return f.formatoDirectorio(this);
        }
    }
}
