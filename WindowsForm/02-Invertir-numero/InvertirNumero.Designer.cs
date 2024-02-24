namespace InvertirNumero;

partial class Form2
{
  /// <summary>
  /// Variable del diseñador necesaria.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Limpiar los recursos que se estén utilizando.
  /// </summary>
  /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
  /// Método necesario para admitir el Diseñador. No modifiques
  /// el contenido del método con el editor de código.
  /// </summary>
  private void InitializeComponent()
  {
    this.components = new System.ComponentModel.Container();
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(800, 600);
    this.Text = "Invertir Digitos";

    textbox1 = new TextBox();
    textbox1.PlaceholderText = "Introduce el primer número a mostrar";
    textbox1.Width = 400;
    textbox1.Location = new Point(200, 100);

    label = new Label();
    label.Width = 1000;
    label.Location = new Point(200, 200);

    buttonInv = new Button();
    buttonInv.Text = "Invertir";
    buttonInv.Height = 30;
    buttonInv.Location = new Point(200, 300);

    this.Controls.Add(textbox1);
    this.Controls.Add(label);
    this.Controls.Add(buttonInv);
  }

  private TextBox textbox1;
  private Label label;
  private Button buttonInv;

  #endregion
}
