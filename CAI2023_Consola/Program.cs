using System;
using System.Collections.Generic;
using CAI2023_Entidades;
using CAI2023_Negocio;


namespace CAI2023_Consola
{
    class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Bienvenido a su Sistema!\n");

            MenuPrincipal();

        }
        public static void MenuPrincipal()
        {

            Console.WriteLine("Menu principal");
            Console.WriteLine("1 - Menu Administrador");
            Console.WriteLine("2 - Menu Supervisor");
            Console.WriteLine("3 - Menu Vendedor");
            Console.WriteLine("0 - Salir del sistema");

            int valor;
            valor = Validaciones.PedirInt("\nSeleccione una opcion:", 0, 5);
            Console.Clear();
            do
            {
                switch (valor)
                {
                    case 0:
                        Console.WriteLine("Muchas gracias por usar el sistema!!\nPresiona una tecla para salir");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case 1:
                        MenuAdministrador();
                        break;
                    case 2:
                        MenuSupervisor();
                        break;
                    case 3:
                        MenuVendedor();
                        break;
                }
            } while (valor != 0);
        }

        public static void MenuAdministrador()
        {
            Console.Clear();

            Console.WriteLine("1 - Alta de Usuario");
            Console.WriteLine("2 - Baja de Usuario");
            Console.WriteLine("3 - Modificacion de Usuario");
            Console.WriteLine("0 - Volver al menu principal");

            int valor;
            valor = Validaciones.PedirInt("\nSeleccione una opcion:", 0, 3);
            Console.Clear();
            switch (valor)
            {
                case 0:
                    MenuPrincipal();
                    break;
                case 1:
                    AltaDeUsuario();
                    break;
                case 2:
                    BajaDeUsuario();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    ModificarUsuario();
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public static void MenuSupervisor()
        {
            Console.WriteLine("Desarrollar");
        }

        public static void MenuVendedor()
        {
            Console.WriteLine("Desarrollar");
        }
    }
}