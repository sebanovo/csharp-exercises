namespace PruebaCsharp;
public class Prueba
{

    public static int MarcoPregunta(int numero1, int numero2)
    { // llamada
        int resultado = 0;

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
                copia2 /= 10;
            }
            numero1 /= 10;
        }
        return resultado;
    }
    public static void Init() // llamada
    {
        Console.WriteLine("Pregunta1");
        Console.WriteLine(MarcoPregunta(15032, 40375));
    }
}