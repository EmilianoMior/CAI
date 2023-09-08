using System;
using System.Text.RegularExpressions;

namespace CAI_2023
{
	public class Administrador:Supervisor
	{
        public static void AltaDeUsuario(string nombre, string apellido, string nombreUsuario, string contraseña, bool esAdministrador)
        {
            if (nombreUsuario.Length < 8 || nombreUsuario.Length > 15)
            {
                Console.WriteLine("El nombre de usuario debe tener entre 8 y 15 caracteres.");
                return;
            }

            if (nombreUsuario.Contains(nombre) || nombreUsuario.Contains(apellido))
            {
                Console.WriteLine("El nombre de usuario no puede contener ni el nombre ni el apellido del usuario.");
                return;
            }

            if (!Regex.IsMatch(contraseña, @"^(?=.*[A-Z])(?=.*\d)(?!.*\s).{8,15}$"))
            {
                Console.WriteLine("La contraseña debe tener entre 8 y 15 caracteres, al menos una letra mayúscula y un número.");
                return;
            }

            if (esAdministrador && usuarios.Exists(u => u.EsAdministrador))
            {
                Console.WriteLine("Ya existe un perfil de Administrador.");
                return;
            }

            //hacer que esto lo consulte de lo que esta en persona 
            var usuario = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                Usuario = nombreUsuario,
                Contraseña = contraseña,
                EsAdministrador = esAdministrador,
                EsActivo = false,
                UltimaActualizacionContraseña = DateTime.MinValue
            };

            if (!esAdministrador)
            {
                // Generar una contraseña temporal para Supervisor y Vendedor
                string contraseñaTemporal = GenerarContraseñaTemporal();
                contraseñasTemporales[nombreUsuario] = contraseñaTemporal;
                Console.WriteLine($"Contraseña temporal generada: {contraseñaTemporal}");
            }

            usuarios.Add(usuario);
            Console.WriteLine("Usuario dado de alta correctamente.");
        }

        private static string GenerarContraseñaTemporal()
        {
            // Generar una contraseña temporal aleatoria con los requisitos necesarios
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string contraseñaTemporal = new string(Enumerable.Repeat(caracteres, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return contraseñaTemporal;
        }

        public static void BajaDeUsuario(string nombreUsuario)
        {
            var usuario = usuarios.Find(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("El usuario no existe.");
                return;
            }

            if (usuario.EsAdministrador)
            {
                Console.WriteLine("No se puede dar de baja a un administrador.");
                return;
            }

            usuarios.Remove(usuario);
            Console.WriteLine("Usuario dado de baja correctamente.");
        }

        public static void ModificarUsuario(string nombreUsuario, string nuevoNombre, string nuevoApellido, string nuevaContraseña)
        {
            var usuario = usuarios.Find(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("El usuario no existe.");
                return;
            }

            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                usuario.Nombre = nuevoNombre;
            }

            if (!string.IsNullOrEmpty(nuevoApellido))
            {
                usuario.Apellido = nuevoApellido;
            }

            if (!string.IsNullOrEmpty(nuevaContraseña))
            {
                if (!CumpleRequisitosContraseña(nuevaContraseña))
                {
                    Console.WriteLine("La nueva contraseña no cumple con los requisitos.");
                    return;
                }

                usuario.Contraseña = nuevaContraseña;
                usuario.UltimaActualizacionContraseña = DateTime.Now;
            }

            Console.WriteLine("Usuario modificado correctamente.");
        }

        public static bool CumpleRequisitosContraseña(string contraseña)
        {
            return Regex.IsMatch(contraseña, @"^(?=.*[A-Z])(?=.*\d)(?!.*\s).{8,15}$");
        }
    }
}