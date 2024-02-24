namespace Calculadora01;
public class Calculadora
{
  /*
  Ejercicio: Calculadora Simple

  Crea un programa en C# que permita al usuario realizar operaciones de suma, resta, multiplicación y división con dos números. El programa debe mostrar un menú con opciones y luego realizar la operación seleccionada por el usuario.
  */
  public static void Init()
  {
    Console.WriteLine("Calculadora");
    Console.WriteLine("***********");
    Console.WriteLine("OPCIONES");
    Console.WriteLine("--------");
    Console.WriteLine("1.Suma");
    Console.WriteLine("2.Resta");
    Console.WriteLine("3.Multiplicacion");
    Console.WriteLine("4.Division");
    Console.WriteLine("------------");
    Console.Write("Escoja una opcion a realizar: ");
    var opcion = Console.ReadLine();
    Console.Write("Ingrese el primer numero: ");
    double numero1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Ingrese el segundo numero: ");
    double numero2 = Convert.ToDouble(Console.ReadLine());
    if (opcion == "1")
    {
      Console.WriteLine("La suma es: " + (numero1 + numero2));
    }
    else if (opcion == "2")
    {
      Console.WriteLine("La resta es: " + (numero1 - numero2));
    }
    else if (opcion == "3")
    {
      Console.WriteLine("La multiplicacion es: " + numero1 * numero2);
    }
    else if (opcion == "4")
    {

      if (numero2 == 0)
      {
        Console.Error.WriteLine("Division por cero es invalida ❌");
      }
      else
      {
        double real = numero1 / numero2;
        Console.WriteLine("La division es: " + real);
      }
    }
    else
    {
      Console.Error.WriteLine("La opcion elegida no esta dentro de las opciones mostradas");
    }
  }
}
