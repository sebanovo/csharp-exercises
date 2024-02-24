namespace StringMayus02;
public class StringMayus
{
  public static void Init()
  {
    Console.Write("Introduce una cadena: ");
    string cadena = new(Console.ReadLine());
    Console.WriteLine(ConvertirMayuscula(cadena));
  }

  static string ConvertirMayuscula(string input)
  {
    return input.ToUpper();
  }
}