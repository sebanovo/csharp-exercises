using System.Diagnostics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.IO;
using System.Drawing;
using OpenTK.Audio.OpenAL;
using StbImageSharp;

namespace FirstProgram
{
    public class Game : GameWindow
    {
        private int VertexBufferObject;
        private int VertexArrayObject;
        private int ShaderProgram;
        private int ElementBufferObject;
        private int texture;
        readonly private Stopwatch _timer;

        // Vértices de la letra "T" en 3D
        private readonly float[] vertices = {
            // positions       // colors   // textures coords
            0.5f,  0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 1.0f,    // top right
            0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f, 1.0f, 0.0f,   // bottom right
           -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f,  // bottom left
           -0.5f,  0.5f, 0.0f, 1.0f, 1.0f, 0.0f, 0.0f, 1.0f    // top left
        };

        // Índices para formar los triángulos de la letra "T"
        private readonly uint[] indices = {
            // note that we start from 0!
            0, 1, 3,  // first Triangle
            1, 2, 3   // second Triangle
        };

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            _timer = new Stopwatch();
            _timer.Start();
            Console.WriteLine("Comenzo el programa");
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

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
            GL.EnableVertexAttribArray(2);

            // load texture    
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            // set the texture wrapping/filtering options (on the currently bound texture object)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            // load texture
            using (Stream stream = File.OpenRead("./resources/container.jpg"))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, GL.GenTexture());

            // Crear el EBO
            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            // Cargar y compilar shaders
            string vertexShaderSource = File.ReadAllText("./resources/shader.vert");
            string fragmentShaderSource = File.ReadAllText("./resources/shader.frag");

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

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            // Limpiar el buffer de color
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            float position = (float)Math.Sin(_timer.Elapsed.TotalSeconds) / 2.0f + 0.5f;
            int vertexOffSetLocation = GL.GetUniformLocation(ShaderProgram, "xOffSet");
            GL.UseProgram(ShaderProgram);
            GL.Uniform1(vertexOffSetLocation, position);

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

            if (KeyboardState.IsKeyPressed(Keys.Q))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }

            if (KeyboardState.IsKeyPressed(Keys.W))
            {
                GL.PointSize(30);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);
            }

            if (KeyboardState.IsKeyPressed(Keys.E))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            // Liberar recursos
            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteVertexArray(VertexArrayObject);
            GL.DeleteProgram(ShaderProgram);
            GL.DeleteBuffer(ElementBufferObject);

            _timer.Stop();
            Console.WriteLine("Finalizo el programa");
        }

        [STAThread]
        public static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 600),
                Title = "Letra T en 3D"
            };

            using Game game = new(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}
