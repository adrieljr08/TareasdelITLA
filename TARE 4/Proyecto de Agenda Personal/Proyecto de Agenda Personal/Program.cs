using System;
using System.Collections.Generic;

public class Contacto
{
    public int Id;
    public string Nombre;
    public string Telefono;
    public string Email;
    public string Direccion;

    public void Mostrar()
    {
        Console.WriteLine($"{Id} {Nombre} {Telefono} {Email} {Direccion}");
    }
}

public class Agenda
{
    List<Contacto> contactos = new List<Contacto>();
    int idActual = 1;

    public void Agregar()
    {
        Contacto c = new Contacto();
        c.Id = idActual++;
        Console.Write("Nombre: ");
        c.Nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        c.Telefono = Console.ReadLine();
        Console.Write("Email: ");
        c.Email = Console.ReadLine();
        Console.Write("Dirección: ");
        c.Direccion = Console.ReadLine();
        contactos.Add(c);
    }

    public void Ver()
    {
        foreach (var c in contactos)
            c.Mostrar();
    }

    public void Buscar()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        foreach (var c in contactos)
            if (c.Id == id) c.Mostrar();
    }

    public void Editar()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        foreach (var c in contactos)
        {
            if (c.Id == id)
            {
                Console.Write("Nombre: ");
                c.Nombre = Console.ReadLine();
                Console.Write("Teléfono: ");
                c.Telefono = Console.ReadLine();
                Console.Write("Email: ");
                c.Email = Console.ReadLine();
                Console.Write("Dirección: ");
                c.Direccion = Console.ReadLine();
            }
        }
    }

    public void Eliminar()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        contactos.RemoveAll(c => c.Id == id);
    }
}

public class Programa
{
    public static void Main()
    {
        Agenda agenda = new Agenda();
        bool seguir = true;

        while (seguir)
        {
            Console.WriteLine("1. Agregar 2. Ver 3. Buscar 4. Editar 5. Eliminar 6. Salir");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1) agenda.Agregar();
            else if (op == 2) agenda.Ver();
            else if (op == 3) agenda.Buscar();
            else if (op == 4) agenda.Editar();
            else if (op == 5) agenda.Eliminar();
            else if (op == 6) seguir = false;
            else Console.WriteLine("Opción no válida");
        }
    }
}

