using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practico_Matrices_Programación_1
{
  public partial class Form1 : Form
  {
    Matriz M1;
    Matriz M2;
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      M1 = new Matriz();
      M2 = new Matriz();
    }
    private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      M1.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
    }

    private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBox5.Text = M1.Descargar();
    }

    private void acumularPrimosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show($"F = {M1.AcumularPrimos()}");
    }

    private void contarElementosNoRepetidosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show($"No repetidos = {M1.ContarElementosNoRepetidos()}");
    }

    private void verificarSiLosElementosDe1EstánEn2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show($"Estan todos los elementos? : {M1.VerificarSiM1EstaEnM2(ref M2)}!!!");
    }

    private void ordenarFilasPorNumeroDePrimosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      M1.AñadirPrimosColumna();
      M1.OrdenarColumnaPrimos();

      M1.f--;

      textBox6.Text = M1.Descargar();

      M1 = new Matriz();
    }

    private void ordenarPorFrecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      M1.OrdenarPorFrecuencia();
      textBox6.Text = M1.Descargar();
    }

    private void intercalarFibonacciYNoFibonacciToolStripMenuItem_Click(object sender, EventArgs e)
    {
      M1.IntercalarFibonacciYNoFibonacci();
      textBox6.Text = M1.Descargar();
    }

    private void ordenarTriangularSuperiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (M1.f != M1.c)
      {
        MessageBox.Show("La Matriz tiene que ser cuadrada");
        return;
      }
      M1.OrdenarTriangularSuperiorDerecha();
      textBox6.Text = M1.Descargar();
    }

    private void segmentarParYNoParTriangularInferiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (M1.f != M1.c)
      {
        MessageBox.Show("La Matriz tiene que ser cuadrada");
        return;
      }
      M1.SegmentarParYNoParDeLaTriangularInferiorDerecha();
      textBox6.Text = M1.Descargar();
    }

    private void ordenarDiagonalSecundariaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (M1.f != M1.c)
      {
        MessageBox.Show("La Matriz tiene que ser cuadrada");
        return;
      }
      M1.OrdenarDiagonalSecundaria();
      textBox6.Text = M1.Descargar();
    }

    private void encontarElementoMayorFilaDeLaTriangularInferiorDerechaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (M1.f != M1.c)
      {
        MessageBox.Show("La Matriz tiene que ser cuadrada");
        return;
      }
      M1.AñadirFilaConElMayor();
      textBox6.Text = M1.Descargar();
    }

    private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      M2.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
    }

    private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      textBox6.Text = M2.Descargar();
    }

    private void button1_Click(object sender, EventArgs e)
    {

      M1 = new Matriz();
      M2 = new Matriz();
      textBox1.Text = "";
      textBox2.Text = "";
      textBox3.Text = "";
      textBox4.Text = "";
      textBox5.Text = "";
      textBox6.Text = "";
    }
  }
}
