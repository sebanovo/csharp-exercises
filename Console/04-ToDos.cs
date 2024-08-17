namespace ToDos04;
/*
Ejercicio: Lista de Tareas
_Crea una aplicación de consola en C# para gestionar una lista de tareas. La aplicación debe permitir al usuario realizar las siguientes operaciones:
*Agregar Tarea: El usuario puede agregar nuevas tareas a la lista. Cada tarea tiene un nombre y una descripción.
*Ver Lista de Tareas: El usuario puede ver todas las tareas en la lista, mostrando sus nombres pero no sus descripciones completas.
*Marcar Tarea como Completada: El usuario puede marcar una tarea como completada. Las tareas completadas deben destacarse de alguna manera en la lista.
*Eliminar Tarea: El usuario puede eliminar una tarea de la lista.
*Salir de la Aplicación: El usuario puede elegir salir de la aplicación en cualquier momento.
Puedes estructurar el ejercicio en diferentes etapas:
*********************************************************************************************************************
1.Definición de Clases: Crea una clase Tarea con propiedades para el nombre, la descripción y el estado (completado o no).
2.Menú de Opciones: Crea un menú que permita al usuario seleccionar las diferentes operaciones (agregar tarea, ver lista, etc.).
3.Agregar y Mostrar Tareas: Implementa la lógica para agregar tareas a una lista y mostrarlas en el formato deseado.
4.Marcar Tarea como Completada: Permite al usuario marcar una tarea como completada y actualiza su estado.
5.Eliminar Tarea: Implementa la lógica para eliminar una tarea de la lista.
*/

#pragma warning disable 
// "pragma waringin disable" es para que me quites los warning que son innecesarios
public class ToDos
{

  class Tarea
  {
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool? Completada { get; set; }
  }

  static List<Tarea> listaTareas = new List<Tarea>();

  public static void Init()
  {
    while (true)
    {
      Console.WriteLine("\n--- Lista de Tareas ---");
      Console.WriteLine("1. Agregar Tarea");
      Console.WriteLine("2. Ver Lista de Tareas");
      Console.WriteLine("3. Marcar Tarea como Completada");
      Console.WriteLine("4. Eliminar Tarea");
      Console.WriteLine("5. Salir");
      Console.Write("Selecciona una opción: ");

      if (int.TryParse(Console.ReadLine(), out int opcion))
      {
        switch (opcion)
        {
          case 1:
            AgregarTarea();
            break;
          case 2:
            MostrarTareas();
            break;
          case 3:
            MarcarTareaComoCompletada();
            break;
          case 4:
            EliminarTarea();
            break;
          case 5:
            Console.WriteLine("¡Adiós!");
            return;
          default:
            Console.WriteLine("Opción no válida.");
            break;
        }
      }
      else
      {
        Console.WriteLine("Entrada no válida.");
      }
    }

  }


  static void AgregarTarea()
  {
    Console.Write("Nombre de la Tarea: ");
    string nombre = Console.ReadLine();
    Console.Write("Descripción de la Tarea: ");
    string descripcion = Console.ReadLine();
    listaTareas.Add(new Tarea { Nombre = nombre, Descripcion = descripcion, Completada = false });
    Console.WriteLine("Tarea agregada con éxito.");
  }

  static void MostrarTareas()
  {
    Console.WriteLine("\nLista de Tareas:");
    for (int i = 0; i < listaTareas.Count; i++)
    {
      string estado = (bool)listaTareas[i].Completada ? "[Completada]" : "[Pendiente]";
      Console.WriteLine($"{i + 1}. {listaTareas[i].Nombre} {estado}");
    }
  }

  static void MarcarTareaComoCompletada()
  {
    MostrarTareas();
    Console.Write("Selecciona el número de tarea para marcar como completada: ");
    if (int.TryParse(Console.ReadLine(), out int indice))
    {
      if (indice >= 1 && indice <= listaTareas.Count)
      {
        listaTareas[indice - 1].Completada = true;
        Console.WriteLine("Tarea marcada como completada.");
      }
      else
      {
        Console.WriteLine("Índice no válido.");
      }
    }
    else
    {
      Console.WriteLine("Entrada no válida.");
    }
  }

  static void EliminarTarea()
  {
    MostrarTareas();
    Console.Write("Selecciona el número de tarea para eliminar: ");
    if (int.TryParse(Console.ReadLine(), out int indice))
    {
      if (indice >= 1 && indice <= listaTareas.Count)
      {
        listaTareas.RemoveAt(indice - 1);
        Console.WriteLine("Tarea eliminada con éxito.");
      }
      else
      {
        Console.WriteLine("Índice no válido.");
      }
    }
    else
    {
      string emoji = ":smile:";
      Console.WriteLine("Entrada no válida.");
    }
  }

  public int Pregunta1(int numero1, int numero2)
  {
    int resultado = 1;

    while (numero1 > 0)
    {
      int d1 = numero1 % 10;
      int copia2 = numero2;
      while (copia2 > 0)
      {
        int d2 = copia2 % 10;
        if (d1 == d2)
        {
          resultado = resultado * 10 + d1;
        }
      }
      numero1 /= 10;
    }
    return 0;
  }
}