using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;
using InvertirNumero;

namespace Practico_Matrices_Programación_1
{
  class Matriz
  {
    public int[,] v;
    public int f, c;

    public Matriz()
    {
      v = new int[50, 50];
      f = 0;
      c = 0;
    }

    public void Cargar(int nf, int nc, int a, int b)
    {
      f = nf;
      c = nc;

      int f1, c1;
      Random r;

      r = new Random();

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          v[f1, c1] = r.Next(a, b + 1);
        }
      }
    }

    public string Descargar()
    {
      int f1, c1;
      string s;

      s = "";

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          s = s + v[f1, c1] + "\t";
        }

        s = s + "\r\n";
      }


      return s;
    }

    // Ejercicio 1
    public string AcumularPrimos()
    {
      int f1, c1;
      string s;
      bool bandera;
      NEnt num;


      num = new NEnt();
      bandera = true;
      s = " F = ";

      for (f1 = f; f1 >= 1; f1--)
      {
        for (c1 = c; c1 >= 1; c1--)
        {
          num.Cargar(v[f1, c1]);
          if (num.VerificarPrimo())
          {
            if (bandera)
            {
              s = $"{s} - √{v[f1, c1]} ";
            }
            else
            {
              s = $"{s} + √{v[f1, c1]} ";
            }
            bandera = !bandera;
          }
        }
      }

      return s;
    }

    // Ejercicio 2 contar Elementos no repetidos
    public int ContarElementosNoRepetidos()
    {
      int contador = 0;
      for (int f1 = 1; f1 <= f; f1++)
      {
        for (int c1 = 1; c1 <= c; c1++)
        {
          if (Frecuencia(v[f1, c1]) == 1)
          {
            contador++;
          }
        }
      }
      return contador;
    }

    public int Frecuencia(int elemento)
    {
      int frec;

      frec = 0;

      for (int f1 = 1; f1 <= f; f1++)
      {
        for (int c1 = 1; c1 <= c; c1++)
        {
          if (elemento == v[f1, c1])
          {
            frec++;
          }
        }
      }
      return frec;
    }

    // Ejercicio 3
    public bool VerificarPertenencia(int ele)
    {
      int f1, c1;

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          if (v[f1, c1] == ele)
            return true;
        }
      }

      return false;
    }

    public bool VerificarSiM1EstaEnM2(ref Matriz M2)
    {
      int f1, c1;

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          if (!M2.VerificarPertenencia(v[f1, c1]))
            return false;
        }
      }

      return true;
    }
    // Ejercicio 4 (Realizado pero no funciona si no le agrego una fila extra a la matriz)
    public void Intercambiar(int f1, int c1, int f2, int c2)
    {
      int temp = v[f1, c1];
      v[f1, c1] = v[f2, c2];
      v[f2, c2] = temp;
    }
    public void IntercambiarColumnas(int c1, int c2)
    {
      int f1;

      for (f1 = 1; f1 <= f; f1++)
      {
        Intercambiar(f1, c1, f1, c2);
      }
    }
    public int ContarPrimosDeLaColumna(int nc)
    {
      int f1, count;
      NEnt n1;

      n1 = new NEnt();
      count = 0;


      for (f1 = 1; f1 <= f; f1++)
      {
        n1.Cargar(v[f1, nc]);
        if (n1.VerificarPrimo())
          count++;
      }

      return count;
    }

    public void AñadirPrimosColumna()
    {
      int c1;
      for (c1 = 1; c1 <= c; c1++)
      {
        v[f + 1, c1] = ContarPrimosDeLaColumna(c1);
      }
      f++;
    }

    public void OrdenarColumnaPrimos()
    {
      int p, d;
      for (p = 1; p <= c - 1; p++)
      {
        for (d = p + 1; d <= c; d++)
        {
          if (v[f, d] < v[f, p])
            IntercambiarColumnas(d, p);
        }
      }
    }

    // Ejercicio 5
    public void OrdenarPorFrecuencia()
    {
      int c1, f1, c2, f2;

      for (c1 = c; c1 >= 1; c1--)
      {
        for (f1 = 1; f1 <= f; f1++)
        {
          for (c2 = c; c2 >= 1; c2--)
          {
            for (f2 = 1; f2 <= f; f2++)
            {
              if (Frecuencia(v[f1, c1]) > Frecuencia(v[f2, c2]) ||
                  Frecuencia(v[f1, c1]) == Frecuencia(v[f2, c2]) &&
                  v[f1, c1] > v[f2, c2])

                Intercambiar(f1, c1, f2, c2);
            }
          }
        }
      }
    }

    // Ejercicio 6
    public void IntercalarFibonacciYNoFibonacci()
    {
      int f1, c1, f2, c2, inc;
      NEnt n1, n2;

      bool b = true;

      n1 = new NEnt(); n2 = new NEnt();

      for (f1 = f; f1 >= 1; f1--)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          if (b)
          {
            for (f2 = f1; f2 >= 1; f2--)
            {
              for (c2 = c1; c2 <= c; c2++)
              {
                if (f2 == f1)
                {
                  inc = c1;
                }
                else
                {
                  inc = 1;
                }
                for (c2 = inc; c2 <= c; c2++)
                {
                  n1.Cargar(v[f1, c1]);
                  n2.Cargar(v[f2, c2]);

                  if (n2.VerificarFibonacci() && !n1.VerificarFibonacci() ||
                      n2.VerificarFibonacci() && n1.VerificarFibonacci() && v[f2, c2] < v[f1, c1] ||
                     !n2.VerificarFibonacci() && !n1.VerificarFibonacci() && v[f2, c2] < v[f1, c1])
                  {
                    Intercambiar(f2, c2, f1, c1);
                  }
                }
              }
            }
          }
          else
          {
            for (f2 = f1; f2 >= 1; f2--)
            {
              for (c2 = c1; c2 <= c; c2++)
              {
                if (f2 == f1)
                {
                  inc = c1;
                }
                else
                {
                  inc = 1;
                }
                for (c2 = inc; c2 <= c; c2++)
                {
                  n1.Cargar(v[f1, c1]);
                  n2.Cargar(v[f2, c2]);

                  if (!n2.VerificarFibonacci() && n1.VerificarFibonacci() ||
                      !n2.VerificarFibonacci() && !n1.VerificarFibonacci() && v[f2, c2] < v[f1, c1] ||
                       n2.VerificarFibonacci() && n1.VerificarFibonacci() && v[f2, c2] < v[f1, c1])
                  {
                    Intercambiar(f2, c2, f1, c1);
                  }
                }
              }
            }
          }
          b = !b;
        }
      }
    }

    // Ejercicio 7
    public void OrdenarTriangularSuperiorDerecha()
    {
      int f1, f2, c1, c2;
      int a;
      int b;

      a = 2;

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = a; c1 <= c; c1++)
        {
          b = 2;
          for (f2 = 1; f2 <= f; f2++)
          {
            for (c2 = b; c2 <= c; c2++)
            {
              if (v[f1, c1] < v[f2, c2])
                Intercambiar(f2, c2, f1, c1);
            }
            b++;
          }
        }
        a++;
      }
    }
    // Ejercicio 8
    public void OrdenarTriangularInferiorIzquierda()
    {
      int f1, c1, f2, c2, inc;

      for (f1 = 2; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= f1 - 1; c1++)
        {
          for (f2 = f1; f2 <= f; f2++)
          {
            if (f1 == f2)
            {
              inc = c1;
            }
            else
            {
              inc = 1;
            }
            for (c2 = inc; c2 <= f2 - 1; c2++)
            {
              if (v[f1, c1] > v[f2, c2])
                Intercambiar(f2, c2, f1, c1);
            }
          }
        }
      }
    }
    public void SegmentarParYNoParTriangularInferiorIzquierda()
    {
      int f1, c1, f2, c2;
      NEnt n1, n2;

      n1 = new NEnt(); n2 = new NEnt();

      for (f1 = 2; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= f1 - 1; c1++)
        {
          for (f2 = f1; f2 <= f; f2++)
          {
            for (c2 = c1; c2 <= f2 - 1; c2++)
            {
              n1.Cargar(v[f1, c1]);
              n2.Cargar(v[f2, c2]);

              if (n2.VerificarPar() && !n1.VerificarPar() ||
                  n2.VerificarPar() && n1.VerificarPar() && v[f2, c2] < v[f1, c1] ||
                 !n2.VerificarPar() && !n1.VerificarPar() && v[f2, c2] < v[f1, c1])
              {
                Intercambiar(f2, c2, f1, c1);
              }
            }
          }
        }
      }
    }
    public void SegmentarParYNoParDeLaTriangularInferiorDerecha()
    {
      int f1, c1, f2, c2;
      NEnt n1, n2;

      n1 = new NEnt(); n2 = new NEnt();

      for (c1 = 2; c1 <= c; c1++)
      {
        for (f1 = f; f1 > f - c1 + 1; f1--)
        {
          for (c2 = 2; c2 <= c; c2++)
          {
            for (f2 = f; f2 > f - c2 + 1; f2--)
            {
              n1.Cargar(v[f1, c1]);
              n2.Cargar(v[f2, c2]);

              if (n2.VerificarPar() && !n1.VerificarPar() ||
                 n2.VerificarPar() && n1.VerificarPar() && v[f2, c2] < v[f1, c1] ||
                !n2.VerificarPar() && !n1.VerificarPar() && v[f2, c2] < v[f1, c1])
              {
                Intercambiar(f2, c2, f1, c1);
              }
            }
          }
        }
      }
    }
    // Ejercicio 9
    public void OrdenarDiagonalPrincipal()
    {
      int f1, c1, f2, c2;

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = 1; c1 <= c; c1++)
        {
          for (f2 = f1; f2 <= f; f2++)
          {
            for (c2 = c1; c2 <= c; c2++)
            {
              if (c1 == f1 && c2 == f2 && v[f1, c1] > v[f2, c2])
              {
                Intercambiar(f1, c1, f2, c2);
              }
            }
          }
        }
      }
    }
    public void OrdenarDiagonalSecundaria()
    {
      int f1, c1, f2, c2;

      for (f1 = 1; f1 <= f; f1++)
      {
        for (c1 = c; c1 >= 1; c1--)
        {
          for (f2 = f1; f2 <= f; f2++)
          {
            for (c2 = c1; c2 >= 1; c2--)
            {
              if (c1 == c - f1 + 1 && c2 == c - f2 + 1 && v[f1, c1] > v[f2, c2])
              {
                Intercambiar(f1, c1, f2, c2);
              }
            }
          }
        }
      }
    }

    // Ejercicio 10
    public int EncontrarElementoMayorFila(int nf, int init)
    {
      int c1, mayor;

      mayor = v[nf, init];

      for (c1 = init; c1 <= c; c1++)
      {
        if (mayor < v[nf, c1])
          mayor = v[nf, c1];
      }

      return mayor;
    }
    public void AñadirFilaConElMayor()
    {
      int f1, init;

      init = 1;

      for (f1 = f; f1 >= 1; f1--)
      {
        v[f1, c + 1] = EncontrarElementoMayorFila(f1, init);
        init++;
      }

      c++;
    }


    // Fin del practico :)

    // METODOS CREADOS SIN UTIZAR: 
    // OrdenarTriangularInferiorIzquierda
    // SegmentarParYNoParDeLaTriangularInferiorIzquierda
    // Ordenar Diagonal Principal
  }
}
