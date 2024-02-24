namespace SumaNumeros;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Suma de Dos Números";


        textBoxNumero1 = new TextBox();
        textBoxNumero1.Location = new Point(100, 50);
        textBoxNumero1.PlaceholderText = "Ingrese el primer número";
        textBoxNumero1.Height = 30;
        textBoxNumero1.Width = 200;

        textBoxNumero2 = new TextBox();
        textBoxNumero2.PlaceholderText = "Ingrese el segundo número";
        textBoxNumero2.Height = 30;
        textBoxNumero2.Width = 200;
        textBoxNumero2.Location = new Point(100, 100);

        labelResultado = new Label();
        labelResultado.Width = 500;
        labelResultado.Location = new Point(100, 150);

        buttonLimpiar = new Button();
        buttonLimpiar.Text = "Limpiar";
        buttonLimpiar.Height = 35;
        buttonLimpiar.Location = new Point(100, 200);

        buttonSumar = new Button();
        buttonSumar.Text = "Sumar";
        buttonSumar.Height = 35;
        buttonSumar.Location = new Point(200, 200);

        buttonSalir = new Button();
        buttonSalir.Text = "Salir";
        buttonSalir.Height = 35;
        buttonSalir.Location = new Point(300, 200);

        buttonReset = new Button();
        buttonReset.Text = "Reset";
        buttonReset.Height = 35;
        buttonReset.Location = new Point(400, 200);


        // btn1 = new Button();
        // btn1.Name = "Boton1";
        // btn1.Text = "Hola que tal como estas soy goku";
        // btn1.Width = 300;
        // btn1.Location = new Point(20, 20);


        // textBox1 = new TextBox();

        // textBox1.Name = "TextBox1";
        // textBox1.Text = "vacio";
        // textBox1.Location = new Point(100, 100);
        // this.Controls.Add(btn1);
        // this.Controls.Add(textBox1);


        this.Controls.Add(textBoxNumero1);
        this.Controls.Add(textBoxNumero2);
        this.Controls.Add(labelResultado);
        this.Controls.Add(buttonLimpiar);
        this.Controls.Add(buttonSumar);
        this.Controls.Add(buttonSalir);
        this.Controls.Add(buttonReset);
    }


    private TextBox textBoxNumero1;
    private TextBox textBoxNumero2;
    private Label labelResultado;
    private Button buttonSumar;
    private Button buttonLimpiar;
    private Button buttonSalir;
    private Button buttonReset;
    // private Button btn1;
    // private TextBox textBox1;
    #endregion
}
