using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CAI_2023
{
    public class Persona
    {

        // Atributos de la persona     
        private int _usuario;
        private bool _estado;

        private string _password;
        private string otp;
        private DateTime ultimocambiopass;
        private DateTime ultimologin;

        private string _nombre;
        private string _apellido;
        private string _email;
        private string rol;


        //Propiedades

        public int Usuario { get => _usuario; set => _usuario = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        //Constructor

        public Persona(string _nombre, string _apellido, string _email,string _password)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Email = _email;
            Usuario = _usuario;
            Password = _password;
            Estado = true;
        }
    }
}

