using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography; //Este enlace me proporciona clases para implementar algoritmo de encriptación.
using System.Text; //Contiene clases para trabajar con texto como, Encoding o StringBuilder que se utiliza para crear
//cadenas de textos eficientes.
using System.Web.UI.WebControls;
using ProyectoEmpresa.Models;

namespace ProyectoEmpresa.Utils //Agrupa el codigo en una carpeta (Utils) en ProyectoEmpresa
{
    //Definición de la clase.
    public static class Encriptador //Public, para acceder en cualquier parte del proyecto.
                                    //static, Me indica que no es necesario crear una instancia para usar sus metodos.
                                    //ya que se accede directamente como Encriptador.EncriptarContraseña.
    {
        //Definición del Metodo.
        public static string EncriptarContraseña(string contraseña) //public, accesible en cualquier parte del proyecto.
                                                                    //stactic, sucede lo mismo que con la clase no necesitamos una instancia para llamarlo.
        {                                                           //string EncriptarContraseña(string contraseña), Me dice que el metodo recibe una contraseña como parametro de tipo (string) y devuelve la contraseña encriptada tambien como (string)
            using (SHA256 sha256 = SHA256.Create())// Crea una instancia del algoritmo de la clase SHA256.
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña)); //(Encoding.UTF8.GetBytes(contraseña). Convierte la contraseña (string) en un array de bytes, es necesario ya que los algoritmos de hashing trabajan sobre datos binarios.
                                                                                       //sha256.ComputeHash, Aplica el algoritmo y lo convierte en otra array pero encriptada.

                StringBuilder builder = new StringBuilder(); //Crea un objeto de tipo StringBuilder para construir la cadena encriptada de forma mas eficiente.
                foreach (byte b in bytes)//Itera sobre cada byte, en la array bytes que creo sha256.ComputeHash.
                {
                    builder.Append(b.ToString("x2")); //x2 conviertes los bytes a formato hexadecimal
                                                      //builder.Append. Agrega el valor hexadecimal a cada byte al StringBuilder 
                }

                return builder.ToString();//Devulve la cadena StringBuilder en un string final(Es la representación hexadecimal del Hash encriptado).
            }
        }
    }
}


//Falta crear el controlador, para el inicio session, crear la vista y realizar pruebas.