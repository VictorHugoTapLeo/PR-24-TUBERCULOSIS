using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class Persona : BaseModel
    {
        public int idPersona { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string ci { get; set; }
        public int celular { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string email { get; set; }
        public string rol { get; set; }
        public byte FirstLogin { get; set; }

        public Persona(int idPersona, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol, byte firstLogin)
        {
            this.idPersona = idPersona;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.celular = celular;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.email = email;
            this.rol = rol;
            FirstLogin = firstLogin;
        }
        public Persona(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol, byte firstLogin)
        {

            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.celular = celular;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.email = email;
            this.rol = rol;
            FirstLogin = firstLogin;
        }
        public Persona(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol)
        {
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.celular = celular;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.email = email;
            this.rol = rol;
        }


        public Persona() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="primerNombre"></param>
        /// <param name="segundoNombre"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="ci"></param>
        /// <param name="celular"></param>
        /// <param name="usuario"></param>
        /// <param name="codigoPersonal"></param>
        public Persona(int idPersona, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string codigoPersonal)
        {
            this.idPersona = idPersona;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.celular = celular;
            this.usuario = usuario;

        }

        public Persona(
    string primerNombre,
    string segundoNombre,
    string primerApellido,
    string segundoApellido,
    string ci, string correo,
    int celular,
    string usuario)
        {
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.email = correo;
            this.celular = celular;
            this.usuario = usuario;
        }


    }
}
