using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Vector
{
  class NEnt
  {
    private int valor;

    public NEnt()
    {
      valor = 0;
    }
    public void Cargar(int numero)
    {
      valor = numero;
    }
    public string Descargar()
    {
      return valor.ToString();
    }
    public void Invertir()
    {
      int digito;
      int resultado = 0;
      int numero = valor;
      while (numero > 0)
      {
        digito = numero % 10;
        resultado = resultado * 10 + digito;
        numero /= 10;
      }
      valor = resultado;
    }
    public void Ndigs()
    {
      int numeroDigs = valor.ToString().Length;
      valor = numeroDigs;
    }
    public bool VerificarPar()
    {
      return valor % 2 == 0;
    }
    // IMPORTANTE CONSIDERO AL 1 COMO PRIMO
    public bool VerificarPrimo()
    {
      int i, c, r;
      c = 0;
      for (i = 1; i <= valor; i++)
      {
        r = valor % i;
        if (r == 0)
          c++;
      }
      return c == 2 || valor == 1;
    }
    public bool VerificarCapicua()
    {
      int capicua = this.valor;
      this.Invertir();
      return capicua == this.valor;
    }
    public bool VerificarCuadradoPerfecto(int num)
    {
      int raizCua = (int)Math.Sqrt(num);
      return raizCua * raizCua == num;
    }
    public bool VerificarFibonacci()
    {
      return VerificarCuadradoPerfecto(5 * valor * valor + 4) || VerificarCuadradoPerfecto(5 * valor * valor - 4);
    }
  }
}
