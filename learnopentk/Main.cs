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
using System.Reflection;

namespace FirstProgram
{
    public class Game : GameWindow
    {
        // vbo bao ebo 
        private int VertexBufferObject, VertexArrayObject, ElementBufferObject;
        // texture
        private int texture1, texture2;
        // timmer
        readonly private Stopwatch timer;
        // Shader
        readonly Shader myShader;
        // camera
        private readonly Camera camera;
        private bool firstMove = true;
        private Vector2 lastPos;
        private double time;

        private readonly float[] vertices = [
            // positions         // colors         // texture coords
            -0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f,  // Cara trasera
            0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0625f, 0.0625f,
            0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,
            0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,
            -0.5f, 0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0625f * 2,
            -0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f,

            -0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f,  // Cara frontal
            0.5f, -0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 0.0625f, 0.0625f,
            0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,
            0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,
            -0.5f, 0.5f, 0.5f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0625f * 2,
            -0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f,

            -0.5f, 0.5f, 0.5f, 1.0f, 0.0f, 1.0f, 0, 0.0625f * 2,  // Cara izquierda
            -0.5f, 0.5f, -0.5f, 0.0f, 1.0f, 1.0f, 0.0625f, 0.0625f * 2,
            -0.5f, -0.5f, -0.5f, 1.0f, 1.0f, 1.0f, 0.0625f, 0.0625f,
            -0.5f, -0.5f, -0.5f, 1.0f, 1.0f, 1.0f, 0.0625f, 0.0625f,
            -0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 1.0f, 0.0f, 0.0625f,
            -0.5f, 0.5f, 0.5f, 1.0f, 0.0f, 1.0f, 0.0f, 0.0625f * 2,

            0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,  // Cara derecha
            0.5f, 0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f * 2,
            0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 1.0f, 0.0f, 0.0625f,
            0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 1.0f, 0.0f, 0.0625f,
            0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 1.0f, 0.0625f, 0.0625f,
            0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0625f * 2,

            -0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0625f,  // Cara inferior
            0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 0.0625f, 0.0625f,
            0.5f, -0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0f,
            0.5f, -0.5f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0625f, 0.0f,
            -0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0625f,

            -0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0625f * 3.0f,  // Cara superior
            0.5f, 0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 0.0625f, 0.0625f * 3.0f,
            0.5f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 0.0625f, 0.0625f * 2.0f,
            0.5f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 0.0625f, 0.0625f * 2.0f,
            -0.5f, 0.5f, 0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0625f * 2.0f,
            -0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0625f * 3.0f,
        ];

        readonly List<Vector3> cubePositions = [];
        // Índices para formar los triángulos de la letra "T"
        private readonly uint[] indices = [
            0, 1, 3,  // first Triangle
            1, 2, 3   // second Triangle
        ];

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            timer = new Stopwatch();
            timer.Start();
            myShader = new Shader("FirstProgram.resources.main.vert", "FirstProgram.resources.main.frag");
            Console.WriteLine("Comenzo el programa");
            WindowState = WindowState.Maximized;
            camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);
            CursorState = CursorState.Grabbed;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            float cubeSize = 1.0f;
            int gridWidth = 10;
            int gridHeight = 10;
            int gridY = 10;
            for (int z = 0; z < gridHeight; z++)
            {
                for (int y = 0; y < gridY; y++)
                {
                    for (int x = 0; x < gridWidth; x++)
                    {
                        cubePositions.Add(new Vector3(x * cubeSize, -1.5f - y * cubeSize, z * cubeSize));
                    }
                }
            }

            // habilitar 
            GL.Enable(EnableCap.DepthTest);
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

            // Crear el EBO
            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            // load texture    
            StbImage.stbi__vertically_flip_on_load_global = 1;
            GL.GenTextures(1, out texture1);
            GL.BindTexture(TextureTarget.Texture2D, texture1);
            // load texture
            using (Stream? stream = Assembly.GetExecutingAssembly()?.GetManifestResourceStream("FirstProgram.resources.texture.png"))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            }

            GL.GenTextures(1, out texture2);
            GL.BindTexture(TextureTarget.Texture2D, texture2);
            // GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            // GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            // GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            // GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            using (Stream? stream = Assembly.GetExecutingAssembly()?.GetManifestResourceStream("FirstProgram.resources.awesomeface.png"))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }

            myShader.Use();
            myShader.SetInt("texture1", 0);
            myShader.SetInt("texture2", 1);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            time = 4.0 * e.Time;

            // Limpiar el buffer de color
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, texture1);
            GL.ActiveTexture(TextureUnit.Texture1);
            GL.BindTexture(TextureTarget.Texture2D, texture2);

            Matrix4 transform = Matrix4.Identity * Matrix4.CreateRotationZ((float)timer.Elapsed.TotalSeconds);

            myShader.SetMat4("projection", camera.GetProjectionMatrix());
            myShader.SetMat4("view", camera.GetViewMatrix());
            myShader.SetMat4("transform", transform);

            for (int i = 0; i < cubePositions.Count; i++)
            {
                Matrix4 model = Matrix4.Identity * Matrix4.CreateTranslation(cubePositions.ToArray()[i]);
                myShader.SetMat4("model", model);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }
            // Intercambiar los buffers
            GL.BindVertexArray(VertexArrayObject);
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (!IsFocused) return;

            var input = KeyboardState;

            // Cerrar la ventana al presionar Escape
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            else if (KeyboardState.IsKeyPressed(Keys.D1))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }
            else if (KeyboardState.IsKeyPressed(Keys.D2))
            {
                GL.PointSize(30);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);
            }
            else if (KeyboardState.IsKeyPressed(Keys.D3))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }


            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;
            if (input.IsKeyDown(Keys.W))
            {
                camera.Position += camera.Front * cameraSpeed * (float)e.Time; // Forward
            }

            if (input.IsKeyDown(Keys.S))
            {
                camera.Position -= camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                camera.Position -= camera.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                camera.Position += camera.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)e.Time; // Down
            }


            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            // Get the mouse state
            var mouse = MouseState;

            if (firstMove) // This bool variable is initially set to true.
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }

            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - lastPos.X;
                var deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                camera.Yaw += deltaX * sensitivity;
                camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
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
            GL.DeleteBuffer(ElementBufferObject);

            timer.Stop();
            Console.WriteLine("Finalizo el programa");
        }

        [STAThread]
        public static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 600),
                Title = "LearnOpentk"
            };
            using Game game = new(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}
