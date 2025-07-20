﻿Console.WriteLine("Bienvenido a mi lista de Contactes");

// Declaración de listas y diccionarios
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (runing)
{
    Console.WriteLine(@"
1. Agregar Contacto     
2. Ver Contactos    
3. Buscar Contactos     
4. Modificar Contacto   
5. Eliminar Contacto    
6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;
        case 2:
            Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
            Console.WriteLine($"____________________________________________________________________________________________________________________________");
            foreach (var id in ids)
            {
                var isBestFriend = bestFriends[id];
                string isBestFriendStr = isBestFriend ? "Si" : "No";
                Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
            }
            break;
        case 3:
            SearchContact(ids, names, lastnames);
            break;
        case 4:
            ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;
        case 5:
            DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}

static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona:");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona:");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección:");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona:");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona:");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona:");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("¿Es mejor amigo? 1. Sí / 2. No:");
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames)
{
    Console.WriteLine("Digite el nombre o apellido a buscar:");
    string search = Console.ReadLine().ToLower();

    bool found = false;
    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(search) || lastnames[id].ToLower().Contains(search))
        {
            Console.WriteLine($"ID: {id} - {names[id]} {lastnames[id]}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No se encontraron contactos con ese nombre o apellido.");
    }
}

static void ModifyContact(List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails,
    Dictionary<int, int> ages,
    Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el ID del contacto a modificar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("Contacto no encontrado.");
        return;
    }

    Console.WriteLine("Digite el nuevo nombre:");
    names[id] = Console.ReadLine();

    Console.WriteLine("Digite el nuevo apellido:");
    lastnames[id] = Console.ReadLine();

    Console.WriteLine("Digite la nueva dirección:");
    addresses[id] = Console.ReadLine();

    Console.WriteLine("Digite el nuevo teléfono:");
    telephones[id] = Console.ReadLine();

    Console.WriteLine("Digite el nuevo email:");
    emails[id] = Console.ReadLine();

    Console.WriteLine("Digite la nueva edad:");
    ages[id] = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("¿Es mejor amigo? 1. Sí / 2. No:");
    bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;

    Console.WriteLine("Contacto modificado exitosamente.");
}

static void DeleteContact(List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails,
    Dictionary<int, int> ages,
    Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el ID del contacto a eliminar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("Contacto no encontrado.");
        return;
    }

    ids.Remove(id);
    names.Remove(id);
    lastnames.Remove(id);
    addresses.Remove(id);
    telephones.Remove(id);
    emails.Remove(id);
    ages.Remove(id);
    bestFriends.Remove(id);

    Console.WriteLine("Contacto eliminado exitosamente.");
}
