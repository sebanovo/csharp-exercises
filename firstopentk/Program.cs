using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.IO;

namespace FirstProgram
{
    public class Game : GameWindow
    {
        private int VertexBufferObject;
        private int VertexArrayObject;
        private int ShaderProgram;
        private int ElementBufferObject;

        // Vértices de la letra "T" en 3D
        private readonly float[] vertices = {
            // Cubo superior (barra horizontal de la "T")
            -0.5f,  0.8f,  0.0f,  // Vértice 1
             0.5f,  0.8f,  0.0f,  // Vértice 2
             0.5f,  1.0f,  0.0f,  // Vértice 3
            -0.5f,  1.0f,  0.0f,  // Vértice 4

            // Cubo vertical (barra vertical de la "T")
            -0.1f, -0.5f,  0.0f,  // Vértice 5
             0.1f, -0.5f,  0.0f,  // Vértice 6
             0.1f,  0.8f,  0.0f,  // Vértice 7
            -0.1f,  0.8f,  0.0f,  // Vértice 8
        };

        // Índices para formar los triángulos de la letra "T"
        private readonly uint[] indices = {
            // Barra horizontal superior
            0, 1, 2,
            2, 3, 0,

            // Barra vertical
            4, 5, 6,
            6, 7, 4,
        };

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // Configurar el color de fondo
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            // Crear el VBO
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // Crear el VAO
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // Crear el EBO
            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            // Cargar y compilar shaders
            string vertexShaderSource = LoadShader("shader.vert");
            string fragmentShaderSource = LoadShader("shader.frag");

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            ShaderProgram = GL.CreateProgram();
            GL.AttachShader(ShaderProgram, vertexShader);
            GL.AttachShader(ShaderProgram, fragmentShader);
            GL.LinkProgram(ShaderProgram);

            // Limpieza
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        static private string LoadShader(string filePath)
        {
            string path = Path.Combine("../../../Shaders", filePath);
            return File.ReadAllText(path);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            // Limpiar el buffer de color
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Dibujar la letra "T"
            GL.UseProgram(ShaderProgram);
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            // Intercambiar los buffers
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Cerrar la ventana al presionar Escape
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            // Liberar recursos
            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteVertexArray(VertexArrayObject);
            GL.DeleteProgram(ShaderProgram);
            GL.DeleteBuffer(ElementBufferObject);
        }

        [STAThread]
        public static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 600),
                Title = "Letra T en 3D"
            };

            using (Game game = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                game.Run();
            }
        }
    }
}
