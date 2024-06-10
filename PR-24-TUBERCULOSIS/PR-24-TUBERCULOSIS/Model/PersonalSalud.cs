using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class PersonalSalud : Persona
    {
        public int idPersonalSalud { get; set; }
        public string codigoPersonalSalud { get; set; }

        public int IdHospital { get; set; }

        public PersonalSalud(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol, byte firstLogin, int idPersonal, string codigoPersonal) : base(primerNombre, segundoNombre, primerApellido, segundoApellido, ci, celular, usuario, contrasena, email, rol, firstLogin)
        {
            idPersonalSalud = idPersonal;
            codigoPersonalSalud = codigoPersonal;

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
        public PersonalSalud(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol, string codigoPersonal)
    : base(primerNombre, segundoNombre, primerApellido, segundoApellido, ci, celular, usuario, contrasena, email, rol)
        {
            codigoPersonalSalud = codigoPersonal;
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="idPersonal"></param>
        /// <param name="codigoPersonal"></param>
        /// <param name="destinoP"></param>
        public PersonalSalud(int idPersona, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string contrasena, string email, string rol, byte firstLogin, int idPersonal, string codigoPersonal) : base(idPersona, primerNombre, segundoNombre, primerApellido, segundoApellido, ci, celular, usuario, contrasena, email, rol, firstLogin)
        {
            idPersonalSalud = idPersonal;
            codigoPersonalSalud = codigoPersonal;
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


        public PersonalSalud() { }
        /// <summary>
        /// GET2
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
        public PersonalSalud(int idPersona, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string ci, int celular, string usuario, string codigoPersonal) : base(idPersona, primerNombre, segundoNombre, primerApellido, segundoApellido, ci, celular, usuario, codigoPersonal)
        {
            this.idPersona = idPersona;

            codigoPersonalSalud = codigoPersonal;
            this.idPersona = idPersona;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.celular = celular;
            this.usuario = usuario;
            this.codigoPersonalSalud = codigoPersonalSalud;

        }

        public PersonalSalud(
    string primerNombre,
    string segundoNombre,
    string primerApellido,
    string segundoApellido,
    string ci, string email,
    int celular,
    string usuario,
    string codigoPersonal) : base(primerNombre, segundoNombre, primerApellido, segundoApellido, ci, email, celular, usuario)
        {
            this.codigoPersonalSalud = codigoPersonal;
        }
    }
}
