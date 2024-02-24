namespace SumaNumeros;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        buttonLimpiar.Click += ButtonLimpiar_Click;
        buttonSumar.Click += ButtonSumar_Click;
        buttonSalir.Click += ButtonSalir_Click;
        buttonReset.Click += ButtonReset_Click;
        // textBox1.MouseDown += TextBox1_MouseDown;
        // textBox1.MouseMove += TextBox1_MouseMove;
    }
    private void ButtonSumar_Click(object? sender, EventArgs e)
    {
        var isTrueNumber1 = double.TryParse(textBoxNumero1.Text, out double numero1);
        var isTrueNumber2 = double.TryParse(textBoxNumero2.Text, out double numero2);

        if (isTrueNumber1 && isTrueNumber2)
        {
            double resultado = numero1 + numero2;
            labelResultado.Text = $"El resultado de la suma: {resultado}";
        }
        else
        {
            labelResultado.Text = "Ingresa números válidos en ambos campos.";
        }
    }

    private void ButtonLimpiar_Click(object? sender, EventArgs e)
    {
        textBoxNumero1.Text = "";
        textBoxNumero2.Text = "";
        labelResultado.Text = "";
    }

    private void ButtonSalir_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void ButtonReset_Click(object? sender, EventArgs e)
    {
        Application.Restart();
    }

    // private Point _startPoint;

    // private void TextBox1_MouseDown(object? sender, MouseEventArgs e)
    // {
    //     _startPoint = e.Location;
    // }

    // private void TextBox1_MouseMove(object? sender, MouseEventArgs e)
    // {
    //     if (e.Button == MouseButtons.Left)
    //     {
    //         int deltaX = e.X - _startPoint.X;
    //         int deltaY = e.Y - _startPoint.Y;
    //         textBox1.Left += deltaX;
    //         textBox1.Top += deltaY;
    //     }
    // }
}
