using System.Numerics;

namespace InvertirNumero;

public partial class Form2 : Form
{
  public Form2()
  {
    InitializeComponent();
    buttonInv.Click += Invertir_Click;
  }

  public void Invertir_Click(object? sender, EventArgs e)
  {
    // Se usa long para admitir que el número sea muy grande
    var isTrueNumber = BigInteger.TryParse(textbox1.Text, out BigInteger numero);
    if (isTrueNumber && numero > 0)
    {
      BigInteger t = 0;
      BigInteger r;
      while (numero > 0)
      {
        r = numero % 10;
        t = t * 10 + r;
        numero /= 10;
      }
      string numeroInv = t.ToString();
      label.Text = $"El número invertido es: {numeroInv}";
    }
    else
    {
      label.Text = "Debes ingresar un número natural";
    }


  }
}

