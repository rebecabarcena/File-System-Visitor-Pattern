using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    /// <summary>
    /// <author>Rebeca Bárcena Orero</author>
    /// Programa principal que sirve para probar los formatos.
    /// Crea una estructura de archivos y los muestra por pantalla
    /// usando ambos formatos.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos el directorio raíz
            Directorio raiz = creaComponentes();
            // Mostramos por pantalla el formato desplegado
            Formato f1 = new Desplegado();
            Console.Out.WriteLine("Formato Desplegado \n" + f1.formatoDirectorio(raiz));

            Console.Out.WriteLine("\n \n");

            // Mostramos por pantalla el formato compacto
            Formato f2 = new Compacto();
            Console.Out.WriteLine("Formato Compacto \n" + f2.formatoDirectorio(raiz));
            Console.In.ReadLine();
        }

        /// <summary>
        /// Método auxiliar que crea los componentes de la estructura de 
        /// archivos y almacena unos en otros, creando una estructura
        /// anidada.
        /// </summary>
        /// <returns></returns>
        private static Directorio creaComponentes()
        {
            // Creamos los elementos de la estructura
            Directorio raiz = new Directorio("Raiz");
            Directorio vacio = new Directorio("Directorio Vacio");
            Directorio unico = new Directorio("Directorio Con Archivo Unico");
            Directorio comprimidoSimple = new Directorio("Directorio Con Archivo Comprimido Simple");
            Directorio anidado = new Directorio("Directorio con Directorio Anidado");
            Directorio complejo = new Directorio("Directorio con Archivo Comprimido Complejo");
            Directorio vacio2 = new Directorio("Directorio Vacio En Archivo Comprimido");

            Archivo a1 = new Archivo("foto001.jpg", 10);
            Archivo a2 = new Archivo("foto002.jpg", 10);
            Archivo a3 = new Archivo("foto003.jpg", 10);
            Archivo a4 = new Archivo("foto004.jpg", 10);
            Archivo a5 = new Archivo("foto005.jpg", 10);
            Archivo a6 = new Archivo("foto006.jpg", 10);
            Archivo a7 = new Archivo("foto007.jpg", 10);
            Archivo a8 = new Archivo("foto008.jpg", 10);

            ArchivoComprimido ac1 = new ArchivoComprimido("ccSimple.zip");
            ArchivoComprimido ac2 = new ArchivoComprimido("ccComplejo.zip");
            ArchivoComprimido ac3 = new ArchivoComprimido("ccAnidada.zip");

            EnlaceDirecto e1 = new EnlaceDirecto(a1);
            EnlaceDirecto e2 = new EnlaceDirecto(ac1);
            EnlaceDirecto e3 = new EnlaceDirecto(vacio);

            // Creamos la estructura
            ac3.añadeArchivo(a7);
            ac2.añadeArchivo(ac3);
            ac2.añadeArchivo(a8);

            complejo.añadeElemento(a5);
            complejo.añadeElemento(a6);
            complejo.añadeElemento(ac2);

            anidado.añadeElemento(a4);
            anidado.añadeElemento(e2);
            anidado.añadeElemento(e3);
            anidado.añadeElemento(complejo);

            ac1.añadeArchivo(vacio2);
            ac1.añadeArchivo(a3);
            ac1.añadeArchivo(e1);

            comprimidoSimple.añadeElemento(a2);
            comprimidoSimple.añadeElemento(e1);
            comprimidoSimple.añadeElemento(ac1);

            unico.añadeElemento(a1);

            raiz.añadeElemento(vacio);
            raiz.añadeElemento(unico);
            raiz.añadeElemento(comprimidoSimple);
            raiz.añadeElemento(anidado);

            // Retornamos el directorio raíz
            return raiz;
        }
    }
}
