using System.Numerics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace FirstProgram;

public class Shader
{
    public int ID;
    public Shader(string vertexPath, string fragmentPath)
    {
        string vertexCode, fragmentCode;
        try
        {
            vertexCode = File.ReadAllText(vertexPath);
            fragmentCode = File.ReadAllText(fragmentPath);

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexCode);
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentCode);
            GL.CompileShader(fragmentShader);

            ID = GL.CreateProgram();
            GL.AttachShader(ID, vertexShader);
            GL.AttachShader(ID, fragmentShader);
            GL.LinkProgram(ID);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

        }
        catch (System.Exception e)
        {
            Console.Write(e.Message);
        }
    }

    public void Use()
    {
        GL.UseProgram(ID);
    }
    public void SetInt(string name, int value)
    {
        GL.Uniform1(GL.GetUniformLocation(ID, name), value);
    }

    public void SetFloat(string name, float value)
    {
        GL.Uniform1(GL.GetUniformLocation(ID, name), value);
    }

    public void SetMat4(string name, Matrix4 value)
    {
        GL.UniformMatrix4(GL.GetUniformLocation(ID, name), true, ref value);
    }
}
