using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Vector
{
  class Vector
  {
    public int[] v;
    public int n;

    ArchSec A1;
    // Constructor de la clase vector
    public Vector()
    {
      v = new int[100];
      n = 0;

      A1 = new ArchSec();
    }

    // metodos que tienen la capacidad de acceder a variables que estan por fuera de ellos
    public void CargarRandom(int n1, int a, int b)
    {
      Random r = new Random();
      n = n1;
      for (int i = 1; i <= n; i++)
        v[i] = r.Next(a, b + 1);
    }

    // Metodo para cargar por elemento
    public void CargarElementoXElemento(int dato)
    {
      n++;
      v[n] = dato;
    }

    // Metodo que carga en el vector una serie aritmetica
    public void CargarSerieAritmetica(int numeroDePosiciones, int valorInicial, int razon)
    {
      n = numeroDePosiciones;
      for (int i = 1; i <= n; i++)
        v[i] = valorInicial + (i - 1) * razon;
    }

    // Metodo que muestra por textbox el vector
    public string Descargar()
    {
      string s = "";
      for (int i = 1; i <= n; i++)
        s = s + v[i] + " | ";
      return s;
    }
    // Selecciona los elementos de un vector de acuerdo a un intervalo y los carga en otro vector
    public void SeleccionarPorPosicion(int intervalo, ref Vector v2)
    {
      int numeroDePosiciones = n / intervalo;
      for (int i = 1; i <= numeroDePosiciones; i++)
        v2.CargarElementoXElemento(v[i * intervalo]);
    }

    // Reune en un vector cuales de los numeros del vector son primos
    public void SeleccionarPrimos(ref Vector v2)
    {
      NEnt n1 = new NEnt();
      for (int i = 1; i <= n; i++)
      {
        n1.Cargar(v[i]);
        if (n1.VerificarPrimo())
          v2.CargarElementoXElemento(v[i]);
      }
    }

    // Reune en un vector cuales numeros del vector no son primos
    public void SeleccionarNoPrimos(ref Vector s)
    {
      NEnt n1 = new NEnt();
      for (int i = 1; i <= n; i++)
      {
        n1.Cargar(v[i]);
        if (!(n1.VerificarPrimo()))
          s.CargarElementoXElemento(v[i]);
      }
    }

    // Carga los buenos el vector de referencia
    public void SeleccionarBuenos(ref Vector v2)
    {
      double media, estandar, rango;

      media = this.Promedio();
      estandar = this.DesviacionEstandar();
      rango = media + estandar;
      for (int i = 1; i <= n; i++)
        if (v[i] > rango)
          v2.CargarElementoXElemento(v[i]);

    }


    // Devuelve cual es el maximo número del vector
    public int Maximo()
    {
      int dr = v[1];
      for (int i = 2; i <= n; i++)
        if (v[i] > dr)
          dr = v[i];
      return dr;

    }

    // Devuelve la frecuencia en la que aparece un número
    public int Frecuencia(int elemento)
    {
      int c = 0;
      for (int i = n; i >= 1; i--)
        if (v[i] == elemento)
          c++;
      return c;
    }

    // Devueve el Maximo número del vector con su Frecuencia
    public void MaximoYFrecuencia(ref int maximo, ref int frecuencia)
    {
      maximo = Maximo();
      frecuencia = Frecuencia(maximo);
    }

    // Carga la serie de Fibonacci en vector
    public void CargarSerieFibonacci(int n1)
    {

      n = n1;
      v[1] = 0; // Primer término de la serie
      v[2] = 1; // Segundo término de la serie

      if (n < 1)
        return; // No se generan términos si n es menor que 1

      if (n == 1)
        return; // Solo se generó el primer término

      if (n == 2)
        return; // Solo se generaron los dos primeros términos

      for (int i = 3; i <= n; i++)
        v[i] = v[i - 1] + v[i - 2];
    }

    // Devuelve el promedio de los números del vector
    public double Promedio()
    {
      int suma = 0;
      for (int i = 1; i <= n; i++)
      {
        suma = suma + v[i];
      }

      return (double)suma / n;
    }

    // Devuelve la desviacion media del vector
    public double DesviacionMedia()
    {
      double media = this.Promedio();
      double suma = 0;
      for (int i = 1; i <= n; i++)
        suma = suma + Math.Abs(v[i] - media);
      return suma / n;
    }

    // Devuelve la desviación estandar publacional no de muestra
    public double DesviacionEstandar()
    {
      double media = this.Promedio();
      double suma = 0;
      for (int i = 1; i <= n; i++)
        suma = suma + Math.Pow(v[i] - media, 2);
      return Math.Sqrt(suma / n);
    }

    // Busca en el vector un número y devuelve un boolean
    public bool BusquedaBinaria(int valorBuscado)
    {
      this.OrdenamientoBurbujaAscendente();
      int izquierda = 0;
      int derecha = n - 1;

      while (izquierda <= derecha)
      {
        int medio = izquierda + (derecha - izquierda) / 2;

        // Si el valor en el medio es igual al valor buscado, lo hemos encontrado.
        if (v[medio] == valorBuscado)
          return true;

        // Si el valor en el medio es mayor que el valor buscado, buscamos en la mitad izquierda.
        if (v[medio] > valorBuscado)
          derecha = medio - 1;

        // Si el valor en el medio es menor que el valor buscado, buscamos en la mitad derecha.
        else
          izquierda = medio + 1;
      }

      // El valor no se encontró en el vector.
      return false;
    }

    // Busca en el vector un número y devuelve un boolean
    public bool BusquedaSecuencial(int valorBuscado)
    {
      for (int i = 1; i <= n; i++)
        if (valorBuscado == v[i])
          return true;

      return false;
    }

    public int RetornarDimension()
    {
      return n;
    }
    public int RetornarElemento(int elemento)
    {
      return v[elemento];
    }
    private int[] RetornarVector()
    {
      return v;
    }

    // Elimina los duplicados y modifica la longitud del vector
    public void EliminarDuplicados()
    {
      v = v.Distinct().ToArray();
      n = v.Length - 1;
    }

    // Intercambia Dos elementos
    public void IntercambiarElementos(int a, int b)
    {
      int variableAuxiliar = v[a];
      v[a] = v[b];
      v[b] = variableAuxiliar;
    }

    // Ordena el vector Intercambiando los elementos -->
    public void OrdenamientoPorIntercambioAscendente()
    {
      for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
          if (j != n)
            if (v[j] > v[j + 1])
              this.IntercambiarElementos(j, j + 1);
    }

    // Ordena el vector Intercambiando los elementos <-- 
    public void OrdenamientoPorIntercambioDescendente()
    {
      for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
          if (j != n)
            if (v[j] < v[j + 1])
              this.IntercambiarElementos(j, j + 1);
    }

    // Ordena el vector por Selección -->
    public void OrdenamientoPorSeleccionAscendente()
    {
      for (int i = 1; i < n; i++)
      {
        int indiceMinimo = i;
        for (int j = i + 1; j <= n; j++)
          if (v[j] < v[indiceMinimo])
            indiceMinimo = j;

        // Intercambiar el elemento mínimo con el elemento en la posición i
        int temp = v[i];
        v[i] = v[indiceMinimo];
        v[indiceMinimo] = temp;
      }
    }

    //Ordena el vector por Selección <--
    public void OrdenamientoPorSeleccionDescendente()
    {
      for (int i = 1; i < n; i++)
      {
        int indiceMaximo = i;
        for (int j = i + 1; j <= n; j++)
          if (v[j] > v[indiceMaximo])
            indiceMaximo = j;

        // Intercambiar el elemento máximo con el elemento en la posición i
        int temp = v[i];
        v[i] = v[indiceMaximo];
        v[indiceMaximo] = temp;
      }
    }

    // Ordena el vector por Ordenamiento burbuja -->
    public void OrdenamientoBurbujaAscendente()
    {
      bool intercambio;
      do
      {
        intercambio = false;

        for (int i = 1; i < n; i++)
          if (v[i] > v[i + 1])
          {
            // Intercambiar los elementos
            int temp = v[i];
            v[i] = v[i + 1];
            v[i + 1] = temp;

            intercambio = true;
          }
      } while (intercambio);
    }

    // Ordena el vector por Ordenamiento burbuja <-- 
    public void OrdenamientoBurbujaDescendente()
    {
      bool intercambio;
      do
      {
        intercambio = false;

        for (int i = 1; i < n; i++)
          if (v[i] < v[i + 1]) // Cambiar el signo de comparación
          {
            // Intercambiar los elementos
            int temp = v[i];
            v[i] = v[i + 1];
            v[i + 1] = temp;

            intercambio = true;
          }
      } while (intercambio);
    }

    // Busca Si el elemento esta en el conjunto
    private bool Pertenencia(int numero)
    {
      bool pertenece = false;
      for (int i = 1; i <= n; i++)
        if (v[i] == numero)
        {
          pertenece = true;
          break;
        }
      return pertenece;
    }

    // Carga el vector con la Interseccion de dos vectores
    public void InterseccionDeConjuntos(Vector v1, Vector v2)
    {
      int longitudV1 = v1.RetornarDimension();
      int longitudV2 = v2.RetornarDimension();
      int[] vector1 = v1.RetornarVector();
      int[] vector2 = v2.RetornarVector();

      for (int i = 1; i <= longitudV1; i++)
        for (int j = 1; j <= longitudV2; j++)
          if (vector1[i] == vector2[j])
          {
            this.CargarElementoXElemento(vector1[i]);
            break;
          }
      this.EliminarDuplicados();
    }

    // Carga el vector con la Union de dos vectores
    public void UnionDeConjuntos(Vector v1, Vector v2)
    {
      int longitudV1 = v1.RetornarDimension();
      int longitudV2 = v2.RetornarDimension();
      int[] vector1 = v1.RetornarVector();
      int[] vector2 = v2.RetornarVector();

      for (int i = 1; i <= longitudV1; i++)
        this.CargarElementoXElemento(vector1[i]);

      for (int j = 1; j <= longitudV2; j++)
        this.CargarElementoXElemento(vector2[j]);

      this.EliminarDuplicados();
    }

    // Carga el vector con la Diferencia de vectores A - B
    public void DiferenciaDeConjuntosAB(Vector v1, Vector v2)
    {
      int longitudV1 = v1.RetornarDimension();
      int[] vector1 = v1.RetornarVector();

      for (int i = 1; i <= longitudV1; i++)
        if (!v2.Pertenencia(vector1[i]))
          this.CargarElementoXElemento(vector1[i]);

      this.EliminarDuplicados();
    }

    // Carga el vector con la Diferencia de vectores B - A
    public void DiferenciaDeConjuntosBA(Vector v1, Vector v2)
    {
      int longitudV2 = v2.RetornarDimension();
      int[] vector2 = v2.RetornarVector();

      for (int i = 1; i <= longitudV2; i++)
        if (!v1.Pertenencia(vector2[i]))
          this.CargarElementoXElemento(vector2[i]);

      this.EliminarDuplicados();
    }
    // Inserta un elemento en el vector directamente en la posición donde debería de estar ordenado
    private void InsertarElementoEnLaPosicionCorrectamenteOrdenada(int ele)
    {
      // Este metodo inserta un elemento en su posisión correcta
      int d;
      d = n;
      while (d >= 1 && v[d] > ele)
      {
        v[d + 1] = v[d];
        d--;
      }
      v[d + 1] = ele;
      n++;
    }
    public void OrdenamientoPorInsercion()
    {
      int p, d, ele;
      for (p = 2; p <= n; p++)
      {
        ele = v[p];
        d = p - 1;
        while (d >= 1 && v[d] > ele)
        {
          v[d + 1] = v[d];
          d--;
        }
        v[d + 1] = ele;
      }
    }

    // Ordenamiento por QUICK SORT
    private void Push(int dato)
    {
      n++;
      v[n] = dato;
    }
    private int Pop()
    {
      int ele;
      ele = v[n];
      n--;
      return ele;
    }
    private bool Under()
    {
      return n == 0;
    }
    public void OrdenamientoPorQuickSort()
    {
      int i, d, id, dd, pivo;
      Vector p1, p2;
      p1 = new Vector();
      p2 = new Vector();
      p1.Push(1);
      p2.Push(n);
      while (!(p1.Under()))
      {
        i = p1.Pop();
        d = p2.Pop();
        while (i < d)
        {
          pivo = v[(i + d) / 2];
          id = i;
          dd = d;
          while (id <= dd)
          {
            while (id <= dd && v[id] < pivo)
              id++;
            while (id <= dd && v[dd] > pivo)
              dd--;
            if (id <= dd)
            {
              IntercambiarElementos(id, dd);
              id++;
              dd--;
            }
          }
          p1.Push(id);
          p2.Push(d);
          d = dd;
        }
      }
    }

    // Separa en el mismo vector los números pares y luego los impares (ordenadamente)
    public void SegmentarParImpar()
    {
      int p, d;
      NEnt n1, n2;
      n1 = new NEnt();
      n2 = new NEnt();
      for (p = 1; p <= n - 1; p++)
        for (d = p + 1; d <= n; d++)
        {
          n1.Cargar(v[d]);
          n2.Cargar(v[p]);
          if (n1.VerificarPar() && !n2.VerificarPar() ||
             n1.VerificarPar() && n2.VerificarPar() && v[d] < v[p] ||
             !n1.VerificarPar() && !n2.VerificarPar() && v[d] < v[p])

            this.IntercambiarElementos(d, p);
        }
    }

    // Separa en el mismo vector los números primos y luego los no primos (ordenadamente)
    public void SegmentarPrimoYNoPrimo()
    {
      int p, d;
      NEnt n1, n2;
      n1 = new NEnt();
      n2 = new NEnt();
      for (p = 1; p <= n - 1; p++)
        for (d = p + 1; d <= n; d++)
        {
          n1.Cargar(v[d]);
          n2.Cargar(v[p]);
          if (n1.VerificarPrimo() && !n2.VerificarPrimo() ||
             n1.VerificarPrimo() && n2.VerificarPrimo() && v[d] < v[p] ||
             !n1.VerificarPrimo() && !n2.VerificarPrimo() && v[d] < v[p])

            this.IntercambiarElementos(d, p);
        }
    }

    // Intercala en el mismo vector los números pares y los impares (ordenadamente)
    public void IntercalarParImpar()
    {
      int p, d;
      NEnt n1, n2;
      bool b = true;
      n1 = new NEnt();
      n2 = new NEnt();
      for (p = 1; p <= n - 1; p++)
      {
        if (b)
          for (d = p + 1; d <= n; d++)
          {
            n1.Cargar(v[d]);
            n2.Cargar(v[p]);
            if (n1.VerificarPar() && !n2.VerificarPar() ||
                n1.VerificarPar() && n2.VerificarPar() && v[d] < v[p] ||
               !n1.VerificarPar() && !n2.VerificarPar() && v[d] < v[p])

              this.IntercambiarElementos(d, p);

          }
        else
          for (d = p + 1; d <= n; d++)
          {
            n1.Cargar(v[d]);
            n2.Cargar(v[p]);
            if (!n1.VerificarPar() && n2.VerificarPar() ||
                !n1.VerificarPar() && !n2.VerificarPar() && v[d] < v[p] ||
                 n1.VerificarPar() && n2.VerificarPar() && v[d] < v[p])

              this.IntercambiarElementos(d, p);
          }
        b = !b;
      }
    }

    // Intercala en el mismo vector los números primos y no primos (ordenadamente)
    public void IntercalarPrimoYNoPrimo()
    {
      int p, d;
      NEnt n1, n2;
      bool b = true;
      n1 = new NEnt();
      n2 = new NEnt();
      for (p = 1; p <= n - 1; p++)
      {
        if (b)
          for (d = p + 1; d <= n; d++)
          {
            n1.Cargar(v[d]);
            n2.Cargar(v[p]);
            if (n1.VerificarPrimo() && !n2.VerificarPrimo() ||
                n1.VerificarPrimo() && n2.VerificarPrimo() && v[d] < v[p] ||
               !n1.VerificarPrimo() && !n2.VerificarPrimo() && v[d] < v[p])

              this.IntercambiarElementos(d, p);

          }
        else
          for (d = p + 1; d <= n; d++)
          {
            n1.Cargar(v[d]);
            n2.Cargar(v[p]);
            if (!n1.VerificarPrimo() && n2.VerificarPrimo() ||
                !n1.VerificarPrimo() && !n2.VerificarPrimo() && v[d] < v[p] ||
                 n1.VerificarPrimo() && n2.VerificarPrimo() && v[d] < v[p])

              this.IntercambiarElementos(d, p);
          }
        b = !b;
      }
    }

    // Invierte el vector
    public void Invertir()
    {
      int inicio = 1;
      int fin = n;
      while (inicio < fin)
      {
        this.IntercambiarElementos(inicio, fin);
        inicio++;
        fin--;
      }
    }

    // Cuenta los submultiplos
    public int ContarSubmultiplos()
    {
      int contador = 0;

      for (int i = 1; i <= n; i++)
        if (v[i] % i == 0)
          contador++;
      return contador;
    }

    // Busca el elemento mayor de un vector buscando por el indice "No lo entiendo mucho"
    public int BuscarElementoMayor(int indice)
    {
      int mayor;
      mayor = 0;
      for (int i = 1; i <= n; i++)
        if (i % indice == 0 && mayor < v[i])
          mayor = v[i];
      return mayor;
    }

    // Busca la media del vector
    public double BuscarMedia(int indice)
    {
      int suma = 0;
      int contador = 0;
      for (int i = 1; i <= n; i++)
        if (i % indice == 0)
        {
          suma = suma + v[i];
          contador++;
        }
      return (double)suma / contador;
    }

    // Verifica si dos elementos son iguales
    public bool VerificarElementosIguales()
    {
      bool booleano = true;
      int inicial = v[1];
      for (int i = 1; i <= n; i++)
        if (inicial != v[i])
          return false;
      return booleano;
    }

    //
    public bool VerificarSegmentoOrdenado(int a, int b)
    {
      // Verificar si el segmento desde a hasta b está ordenado de manera ascendente
      for (int i = a; i < b; i++)
      {
        if (v[i] > v[i + 1])
        {
          return false;
        }
      }
      return true;
    }

    // Inserta Un Vector En otro
    public void InsertarVectorPorPosicion(Vector v1, Vector v2, int posicion)
    {
      int n1 = v1.RetornarDimension();
      int n2 = v2.RetornarDimension();

      int[] vector1 = v1.RetornarVector();
      int[] vector2 = v2.RetornarVector();

      for (int i = 1; i < posicion; i++)
        this.CargarElementoXElemento(vector1[i]);

      for (int i = 1; i <= n2; i++)
        this.CargarElementoXElemento(vector2[i]);

      for (int i = posicion; i <= n1; i++)
        this.CargarElementoXElemento(vector1[i]);
    }

    // Elimina los elementos del vector indicando dos posiciones (rango)
    public void EliminarElementosDelVectorIndicandoLasPosiciones(int a, int b)
    {
      Vector Copia = new Vector();

      for (int i = 1; i <= n; i++)
      {
        if (i >= a && i <= b)
          continue;
        Copia.CargarElementoXElemento(v[i]);
      }

      this.v = Copia.v;
      this.n = Copia.n;
    }

    // Duplicar elementos del vector
    public void DuplicarElementos()
    {
      Vector Copia = new Vector();

      for (int i = 1; i <= n; i++)
        for (int j = 1; j <= 2; j++)
          Copia.CargarElementoXElemento(v[i]);

      this.v = Copia.v;
      this.n = Copia.n;
    }

    // Concatena dos vectores 
    public void Concat(Vector v1)
    {
      int n1 = v1.n;
      for (int i = 1; i <= n1; i++)
        this.CargarElementoXElemento(v1.v[i]);
    }

    // Ordena los elementos de un segmento
    public void OrdenarElementosDeUnSegmento(int a, int b)
    {
      Vector Vector1 = new Vector();
      Vector Vector2 = new Vector();
      Vector Vector3 = new Vector();

      for (int i = 1; i <= a - 1; i++)
        Vector1.CargarElementoXElemento(v[i]);

      for (int i = a; i <= b; i++)
        Vector2.CargarElementoXElemento(v[i]);

      for (int i = b + 1; i <= n; i++)
        Vector3.CargarElementoXElemento(v[i]);


      Vector2.OrdenamientoBurbujaAscendente();

      Vector1.Concat(Vector2);
      Vector1.Concat(Vector3);

      this.v = Vector1.v;
      this.n = Vector1.n;
    }

    // Busca El elemento Menos Repetido de un vector
    public int BuscarElementoMenosRepetido()
    {

      int leastFrequentNumber = 0;
      int minCount = int.MaxValue;

      int longitud = this.n;
      int[] vector = this.v;


      for (int i = 1; i <= longitud; i++)
      {
        int count = 0;
        int currentNumber = v[i];

        if (currentNumber == int.MinValue)
          continue;

        for (int j = i; j <= longitud; j++)
        {
          if (vector[j] == currentNumber)
          {
            count++;
            vector[j] = int.MinValue;
          }
        }

        if (count < minCount)
        {
          minCount = count;
          leastFrequentNumber = currentNumber;
        }
      }

      return leastFrequentNumber;
    }

    // Encuentra el elemento Menos repetido entre un Segmento
    public int EncontrarElementoMenosRepetidoEntreUnSegmento(int a, int b)
    {
      Vector Vector1 = new Vector();

      for (int i = a; i <= b; i++)
        Vector1.CargarElementoXElemento(v[i]);

      int menosRepetido = Vector1.BuscarElementoMenosRepetido();

      return menosRepetido;
    }

    // Carga en un vector la frecuencia de con la que aparece un número otra frecuencia
    public void CargarFrecuencia(ref Vector v3, Vector v2)
    {
      for (int i = 1; i <= v2.n; i++)
        v3.CargarElementoXElemento(this.Frecuencia(v2.v[i]));
    }

    // Encuentra la frecuencia de distribución de un segmento
    public void EncontrarLaFrecuenciaDeDistribucionEntreUnSegmento(int a, int b, ref Vector v2, ref Vector v3)
    {
      Vector v1 = new Vector();

      for (int i = a; i <= b; i++)
        v1.CargarElementoXElemento(v[i]);

      v1.OrdenamientoBurbujaAscendente();
      Vector Copia = new Vector();


      for (int i = 1; i <= v1.n; i++)
        v2.CargarElementoXElemento(v1.v[i]);

      v2.EliminarDuplicados();

      v1.CargarFrecuencia(ref v3, v2);
    }

    // Cuenta los números que son capicuas de un vector
    public int ContarCapicuas()
    {
      int contarCapicuas = 0;
      NEnt n1;
      n1 = new NEnt();

      for (int i = 1; i <= n; i++)
      {
        n1.Cargar(v[i]);
        if (!n1.VerificarCapicua())
          break;

        contarCapicuas++;
      }
      return contarCapicuas;
    }

    // Cuenta los números que no son capicuas de un vector
    public int ContarNoCapicuas()
    {
      int contarNoCapicuas = 0;
      NEnt n1;
      n1 = new NEnt();

      for (int i = 1; i <= n; i++)
      {
        n1.Cargar(v[i]);
        if (n1.VerificarCapicua())
          break;

        contarNoCapicuas++;
      }
      return contarNoCapicuas;
    }

    // Segmenta un Vector Los capicuas y luego los No capicuas
    // Capicuas Ascendentemente
    // No Capicuas Descendentemente
    public void SegmentarCapicuaYNoCapicua()
    {
      int p, d;
      NEnt n1, n2;
      n1 = new NEnt();
      n2 = new NEnt();
      for (p = 1; p <= n - 1; p++)
        for (d = p + 1; d <= n; d++)
        {
          n1.Cargar(v[d]);
          n2.Cargar(v[p]);
          if (n1.VerificarCapicua() && !n2.VerificarCapicua() ||
              n1.VerificarCapicua() && n2.VerificarCapicua() && v[d] < v[p] ||
             !n1.VerificarCapicua() && !n2.VerificarCapicua() && v[d] < v[p])

            this.IntercambiarElementos(d, p);
        }

      int capicuas = this.ContarCapicuas();
      int NoCapicuas = this.ContarNoCapicuas();
      int longitud = this.n;
      int[] vector = this.v;

      Vector v1 = new Vector();
      Vector v2 = new Vector();
      for (int i = 1; i <= capicuas; i++)
        v1.CargarElementoXElemento(v[i]);

      for (int i = capicuas + 1; i <= this.n; i++)
        v2.CargarElementoXElemento(v[i]);

      v1.OrdenamientoBurbujaAscendente();
      v2.OrdenamientoBurbujaDescendente();

      v1.Concat(v2);

      this.v = v1.v;
      this.n = v1.n;
    }

    // Intercala los primos y no primos de un Segmento
    public void IntercalarPrimoYNoPrimoDeUnSegmento(int a, int b)
    {
      Vector Vector1 = new Vector();
      Vector Vector2 = new Vector();
      Vector Vector3 = new Vector();

      for (int i = 1; i <= a - 1; i++)
        Vector1.CargarElementoXElemento(v[i]);

      for (int i = a; i <= b; i++)
        Vector2.CargarElementoXElemento(v[i]);

      for (int i = b + 1; i <= n; i++)
        Vector3.CargarElementoXElemento(v[i]);

      Vector2.OrdenamientoBurbujaAscendente();
      Vector2.IntercalarPrimoYNoPrimo();

      Vector1.Concat(Vector2);
      Vector1.Concat(Vector3);

      this.v = Vector1.v;
      this.n = Vector1.n;
    }

    // Tengo el codigo bien solo me falta aprender
    public void Grabar(string Narch1)
    {
      A1.Abrir_Grabar(Narch1);
      for (int i = 1; i <= n; i++)
      {
        A1.Grabar(v[i]);
      }
      A1.Cerrar_Grabar();

    }
    public void Leer(string Narch1)
    {
      int i = 0;
      ArchSec A1 = new ArchSec();
      A1.Abrir_Leer(Narch1);
      while (!A1.Verif_Fin())
      {
        i++;
        v[i] = A1.Leer();
      }
      n = i;
      A1.Cerrar_Leer();
    }
  }
}
