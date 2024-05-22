using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTKTest;

internal class Game(int width, int height)
    : GameWindow(GameWindowSettings.Default, NativeWindowSettings.Default)
{
    protected override void OnLoad()
    {
        this.CenterWindow(new Vector2i(width, height));
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
        base.OnUnload();
    }
}
