using OpenTK.Mathematics;
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
}
