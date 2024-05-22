using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTKTest;

internal class Game(int width, int height)
    : GameWindow(GameWindowSettings.Default, NativeWindowSettings.Default)
{
    private int vao;
    private int vbo;
    private int shaderProgram;

    private readonly float[] vertices = [
        0f, 0.5f, 0f,
        -0.5f, -0.5f, 0f,
        0.5f, -0.5f, 0f
    ];

    protected override void OnLoad()
    {
        CenterWindow(new Vector2i(width, height));

        vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        vao = GL.GenVertexArray();
        GL.BindVertexArray(vao);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexArrayAttrib(vao, 0);

        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);

        shaderProgram = GL.CreateProgram();

        var vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, File.ReadAllText("Shaders/Default.vert"));
        GL.CompileShader(vertexShader);
        GL.AttachShader(shaderProgram, vertexShader);

        var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, File.ReadAllText("Shaders/Default.frag"));
        GL.CompileShader(fragmentShader);
        GL.AttachShader(shaderProgram, fragmentShader);

        GL.LinkProgram(shaderProgram);

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);

        base.OnLoad();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.ClearColor(0, 0.5f, 0.5f, 1f);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram(shaderProgram);
        GL.BindVertexArray(vao);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        Context.SwapBuffers();

        base.OnRenderFrame(args);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        width = e.Width;
        height = e.Height;

        base.OnResize(e);
    }

    protected override void OnUnload()
    {
        GL.DeleteBuffer(vbo);
        GL.DeleteVertexArray(vao);
        GL.DeleteProgram(shaderProgram);

        base.OnUnload();
    }
}
