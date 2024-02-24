namespace ClasePersona03;
public class Persona
{
  public string? Nombre { get; set; }
  public int Edad { get; set; }

  public Persona(string Nombre, int Edad)
  {
    this.Nombre = Nombre;
    this.Edad = Edad;
  }
  public string Saludar()
  {
    return $"Hola soy {Nombre}\nY tengo {Edad}";
  }
}

public class ClasePersona
{
  public static void Init()
  {
    // Se crean los objetos de forma muy similar en javascript
    Persona persona = new("Sebastian Cespedes Rodas", 19);
    Console.WriteLine(persona.Saludar());
  }
}