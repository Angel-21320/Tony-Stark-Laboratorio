using System;
using System.IO;

class Program
{
    static string directorio = "LaboratorioAvengers";
    static string archivo = Path.Combine(directorio, "inventos.txt");
    static string backupDir = Path.Combine(directorio, "Backup");
    static string clasificadosDir = Path.Combine(directorio, "ArchivosClasificados");
    static string proyectosDir = Path.Combine(directorio, "ProyectosSecretos");

    static void Main()
    {
        Directory.CreateDirectory(directorio);
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("--- Laboratorio Avengers ---");
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer línea por línea");
            Console.WriteLine("4. Leer todo el archivo");
            Console.WriteLine("5. Copiar archivo");
            Console.WriteLine("6. Mover archivo");
            Console.WriteLine("7. Crear carpeta");
            Console.WriteLine("8. Listar archivos");
            Console.WriteLine("9. Eliminar archivo");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1": CrearArchivo(); break;
                case "2":
                    Console.Write("Ingrese el nombre del invento: ");
                    AgregarInvento(Console.ReadLine());
                    break;
                case "3": LeerLineaPorLinea(); break;
                case "4": LeerTodoElTexto(); break;
                case "5": CopiarArchivo(); break;
                case "6": MoverArchivo(); break;
                case "7": CrearCarpeta(); break;
                case "8": ListarArchivos(); break;
                case "9": EliminarArchivo(); break;
                case "10": salir = true; break;
                default: Console.WriteLine("Opción inválida. Intente de nuevo."); break;
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void CrearArchivo()
    {
        try
        {
            if (!File.Exists(archivo))
            {
                File.WriteAllText(archivo, "1. Traje Mark I\n2. Reactor Arc\n3. Inteligencia Artificial JARVIS\n");
                Console.WriteLine("Archivo creado exitosamente.");
            }
            else Console.WriteLine("El archivo ya existe.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void AgregarInvento(string invento)
    {
        try
        {
            File.AppendAllText(archivo, invento + "\n");
            Console.WriteLine("Invento agregado correctamente.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void LeerLineaPorLinea()
    {
        try
        {
            foreach (string linea in File.ReadLines(archivo))
                Console.WriteLine(linea);
        }
        catch (Exception) { Console.WriteLine("Error: El archivo no existe."); }
    }

    static void LeerTodoElTexto()
    {
        try { Console.WriteLine(File.ReadAllText(archivo)); }
        catch (Exception) { Console.WriteLine("Error: El archivo no existe."); }
    }

    static void CopiarArchivo()
    {
        try
        {
            Directory.CreateDirectory(backupDir);
            File.Copy(archivo, Path.Combine(backupDir, "inventos.txt"), true);
            Console.WriteLine("Archivo copiado a Backup.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void MoverArchivo()
    {
        try
        {
            Directory.CreateDirectory(clasificadosDir);
            File.Move(archivo, Path.Combine(clasificadosDir, "inventos.txt"));
            Console.WriteLine("Archivo movido a ArchivosClasificados.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void CrearCarpeta()
    {
        try
        {
            Directory.CreateDirectory(proyectosDir);
            Console.WriteLine("Carpeta ProyectosSecretos creada.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void ListarArchivos()
    {
        try
        {
            string[] archivos = Directory.GetFiles(directorio);
            Console.WriteLine("Archivos en " + directorio + ":");
            foreach (string archivo in archivos)
                Console.WriteLine(Path.GetFileName(archivo));
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivo))
            {
                CopiarArchivo();
                File.Delete(archivo);
                Console.WriteLine("Archivo eliminado tras respaldo.");
            }
            else Console.WriteLine("El archivo no existe.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
}
