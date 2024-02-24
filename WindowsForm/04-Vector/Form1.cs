using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Clase_Vector
{
  public partial class Form1 : Form
  {
    Vector V1;
    Vector V2;
    Vector V3;
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      V1 = new Vector();
      V2 = new Vector();
      V3 = new Vector();
    }
    private void CargarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1.CargarRandom(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
    }

    private void DescargarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox1.Text = V1.Descargar();
    }

    private void menuToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }


    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void selecPrimosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2 = new Vector();
      V1.SeleccionarPrimos(ref V2);
    }

    private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      textBox2.Text = V2.Descargar();
    }

    private void cargarEleXEleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1 = new Vector();
      int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
      for (int i = 1; i <= n1; i++)
        V1.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
    }

    private void cargarSerieToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1 = new Vector();
      int numeroDePosiciones = int.Parse(Interaction.InputBox("Cuantos Elementos quiere para la serie Aritmetica?"));
      int valorInicial = int.Parse(Interaction.InputBox("Valor Inicial: "));
      int razon = int.Parse(Interaction.InputBox("Valor de la razon: "));
      V1.CargarSerieAritmetica(numeroDePosiciones, valorInicial, razon);
    }

    private void cargarRandomToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.CargarRandom(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
    }

    private void selecPosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2 = new Vector();
      int intervalo = int.Parse(Interaction.InputBox("Ingresa el Intervalo: "));
      V1.SeleccionarPorPosicion(intervalo, ref V2);
    }

    private void selecNoPrimosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2 = new Vector();
      V1.SeleccionarNoPrimos(ref V2);
    }


    private void maximoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox2.Text = string.Concat($"El maximo es: {V1.Maximo()}");
    }
    private void frecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox2.Text = string.Concat($"La frecuencia del maximo es: {V1.Frecuencia(int.Parse(textBox5.Text))}");
    }

    private void maximoYFrecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int maximo = 0;
      int frecuencia = 0;
      V1.MaximoYFrecuencia(ref maximo, ref frecuencia);
      textBox2.Text = string.Concat($"Maximo: {maximo}  frecuencia: {frecuencia}");
    }

    private void cargarSerieFobonacciToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1 = new Vector();
      int numeroDePosiciones = int.Parse(Interaction.InputBox("Numero de Terminos de la serie de Fibonacci: "));
      V1.CargarSerieFibonacci(numeroDePosiciones);
    }

    private void promedioToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox2.Text = string.Concat($"El promedio es: {V1.Promedio()}");
    }

    private void desviaciónMediaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox2.Text = string.Concat($"La desviacion media es: {V1.DesviacionMedia()}");
    }

    private void desviaciónEstandarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox2.Text = string.Concat($"La desviación estandar es: {V1.DesviacionEstandar()}");
    }

    private void seleccionarBuenosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2 = new Vector();
      V1.SeleccionarBuenos(ref V2);
    }

    private void busquedaBinariaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int valorBuscado = int.Parse(Interaction.InputBox($"Introduzca el valor a buscar: "));
      bool encontrado = V1.BusquedaBinaria(valorBuscado);

      if (encontrado)
      {
        MessageBox.Show($"El valor {valorBuscado} se encuentra en el vector.");
      }
      else
      {
        MessageBox.Show($"El valor {valorBuscado} no se encuentra en el vector.");
      }
    }

    private void busquedaSecuencialToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int valorBuscado = int.Parse(Interaction.InputBox($"Introduzca el valor a buscar: "));
      bool encontrado = V1.BusquedaSecuencial(valorBuscado);

      if (encontrado)
      {
        MessageBox.Show($"El valor {valorBuscado} se encuentra en el vector.");
      }
      else
      {
        MessageBox.Show($"El valor {valorBuscado} no se encuentra en el vector.");
      }
    }

    private void graficarToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void ordenamientoPorIntercambioToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1.OrdenamientoPorIntercambioAscendente();
      textBox2.Text = V1.Descargar();
    }

    private void ordenamientoPorIntercambioToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      V1.OrdenamientoPorIntercambioDescendente();
      textBox2.Text = V1.Descargar();
    }
    private void unionDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      V3.UnionDeConjuntos(V1, V2);
      textBox6.Text = V3.Descargar();
    }

    private void interseccionDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      V3.InterseccionDeConjuntos(V1, V2);
      textBox6.Text = V3.Descargar();
    }


    private void diferenciaDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      V3.DiferenciaDeConjuntosAB(V1, V2);
      textBox6.Text = V3.Descargar();
    }

    private void diferenciaDeConjuntosBAToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      V3.DiferenciaDeConjuntosBA(V1, V2);
      textBox6.Text = V3.Descargar();
    }

    private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      V1.CargarRandom(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
    }

    private void descargarToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      textBox6.Text = V3.Descargar();
    }

    private void ordenamientoBurbujaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.OrdenamientoBurbujaAscendente();
      textBox1.Text = V2.Descargar();
    }

    private void ordenamientoPorInserciónToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.OrdenamientoPorInsercion();
      textBox1.Text = V2.Descargar();
    }

    private void ordenamientoQuickSortToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.OrdenamientoPorQuickSort();
      textBox1.Text = V2.Descargar();
    }

    private void ordenamientoPorIntercambioToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      V2.OrdenamientoBurbujaAscendente();
    }

    private void segmentarParYNoParToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.SegmentarParImpar();
      textBox6.Text = V2.Descargar();
    }

    private void segmentarPrimoYNoPrimoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.SegmentarPrimoYNoPrimo();
      textBox6.Text = V2.Descargar();
    }

    private void intercalarParYNoParToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.IntercalarParImpar();
      textBox6.Text = V2.Descargar();
    }

    private void intercalarPrimoYNoPrimoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.IntercalarPrimoYNoPrimo();
      textBox6.Text = V2.Descargar();
    }

    private void invertirVectorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1.Invertir();
      textBox2.Text = V1.Descargar();
    }

    private void contarElementosDeLasPosicionesSubmultiplosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show(string.Concat($"El número de submultiplos es: {V1.ContarSubmultiplos()}"));
    }

    private void buscarElementoMayorDeLasPosicionesMultiplosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int indice = int.Parse(Interaction.InputBox($"BUSCAR ELEMENTO MAYOR\nDeme un multiplo para las posiciones:"));
      MessageBox.Show(string.Concat($"El elemento mayor del vector de las posiciones multiplos de {indice} es: {V1.BuscarElementoMayor(indice)}"));
    }

    private void buscarLaMediaDeLasPosicionesMultiplosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int indice = int.Parse(Interaction.InputBox("BUSCAR LA MEDIA\nDeme un multiplo para las posiciones"));
      MessageBox.Show(string.Concat($"La media del vector de las posiciones multiplos de {indice} es: {V1.BuscarMedia(indice)}"));
    }

    private void verificarTodosLosElementosIgualesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool booleano = V1.VerificarElementosIguales();
      if (booleano)
        MessageBox.Show(string.Concat(booleano, " - Elementos De V1 iguales"));
      else
        MessageBox.Show(string.Concat(booleano, " - Elementos De V1 No iguales"));
    }

    private void verificarSiElSegmentoEstaOrdenadoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int a = int.Parse(Interaction.InputBox("Introduzca el primer limite: "));
      int b = int.Parse(Interaction.InputBox("Introduzca el segundo limite: "));

      if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
        MessageBox.Show("Indice fuera de los limites");
      else
        MessageBox.Show(string.Concat(V1.VerificarSegmentoOrdenado(a, b)));
    }

    private void insertarVector2En1RespectoAUnaPosiciónToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      int posicion = int.Parse(Interaction.InputBox("Introduzca la posición a insertar: "));
      if (V1.RetornarDimension() == 0 || V2.RetornarDimension() == 0)
        MessageBox.Show("Tienes que cargar el Vector V1 y el V2");
      else if (posicion < 1 || posicion > V1.RetornarDimension())
        MessageBox.Show("Posición fuera de los limites del Vector 1");
      else
      {
        V3.InsertarVectorPorPosicion(V1, V2, posicion);
        textBox6.Text = V3.Descargar();

      }
    }

    private void eliminarElementosDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int dimensionMaxima = V1.RetornarDimension();
      int a = int.Parse(Interaction.InputBox("Introduzca la primera posición"));
      int b = int.Parse(Interaction.InputBox("Introduzca la segunda posición"));

      if (a < 1 || b < 1 || a > dimensionMaxima || b > dimensionMaxima)
        MessageBox.Show("Posicion fuera de los límites");
      else
      {
        V1.EliminarElementosDelVectorIndicandoLasPosiciones(a, b);
        textBox2.Text = V1.Descargar();
      }
    }

    private void duplicarElementosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V1.DuplicarElementos();
      textBox2.Text = V1.Descargar();
    }

    private void ordenarElementosDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
      int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));

      if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
        MessageBox.Show("Posición fuera de los limites del vector");
      else
      {
        V1.OrdenarElementosDeUnSegmento(a, b);
        textBox2.Text = V1.Descargar();
      }
    }

    private void encontrarElementoMenosRepetidoDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
      int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
      if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
        MessageBox.Show("Posición fuera de los limites del vector");
      else
      {
        int ElementoMenosRepetido = V1.EncontrarElementoMenosRepetidoEntreUnSegmento(a, b);
        MessageBox.Show($"El elemento menos repetido es: {ElementoMenosRepetido}");
      }
    }

    private void encontrarLaFrecuenciaDeDistribuciónDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
      int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
      if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
        MessageBox.Show("Posición fuera de los limites del vector");
      else
      {
        V2 = new Vector();
        V3 = new Vector();

        V1.EncontrarLaFrecuenciaDeDistribucionEntreUnSegmento(a, b, ref V2, ref V3);
        textBox2.Text = V2.Descargar();
        textBox6.Text = V3.Descargar();
      }
    }

    private void segmentarCapicuasYNoCapicuasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2.SegmentarCapicuaYNoCapicua();
      textBox6.Text = V2.Descargar();
    }

    private void intercalarPrimosYNoPrimosDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
      int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
      if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
        MessageBox.Show("Posición fuera de los limites del vector");
      else
      {
        V1.IntercalarPrimoYNoPrimoDeUnSegmento(a, b);
        textBox2.Text = V1.Descargar();
      }
    }


    private void ResetearTextBoxs()
    {
      textBox1.Text = "";
      textBox2.Text = "";
      textBox6.Text = "";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      V1 = new Vector();
      V2 = new Vector();
      V3 = new Vector();

      ResetearTextBoxs();
    }

    private void cargarElementoXElementoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      V2 = new Vector();
      int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
      for (int i = 1; i <= n1; i++)
        V2.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
    }

    private void cargarElementoXElementoToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      V3 = new Vector();
      int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
      for (int i = 1; i <= n1; i++)
        V3.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
    }

    private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialog1.ShowDialog();
      V1.Grabar(saveFileDialog1.FileName);
    }

    private void leerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
      V1.Leer(openFileDialog1.FileName);
    }
  }
}
