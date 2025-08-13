using System.Threading.Tasks;
using VaultForce.Canvas.Canvas2D;
using VaultForce.Canvas.WebGL;

namespace VaultForce.Canvas;

public static class CanvasContextExtensions
{
    public static Canvas2DContext CreateCanvas2D(this BeCanvas canvas)
    {
        return (new Canvas2DContext(canvas).InitializeAsync().GetAwaiter().GetResult() as Canvas2DContext)!;
    }

    public static async Task<Canvas2DContext> CreateCanvas2DAsync(this BeCanvas canvas)
    {
        return (await new Canvas2DContext(canvas).InitializeAsync().ConfigureAwait(false) as Canvas2DContext)!;
    }

    public static WebGLContext CreateWebGL(this BeCanvas canvas)
    {
        return (new WebGLContext(canvas).InitializeAsync().GetAwaiter().GetResult() as WebGLContext)!;
    }

    public static async Task<WebGLContext> CreateWebGLAsync(this BeCanvas canvas)
    {
        return (await new WebGLContext(canvas).InitializeAsync().ConfigureAwait(false) as WebGLContext)!;
    }

    public static WebGLContext CreateWebGL(this BeCanvas canvas, WebGLContextAttributes attributes)
    {
        return (new WebGLContext(canvas, attributes).InitializeAsync().GetAwaiter().GetResult() as WebGLContext)!;
    }

    public static async Task<WebGLContext> CreateWebGLAsync(this BeCanvas canvas, WebGLContextAttributes attributes)
    {
        return (await new WebGLContext(canvas, attributes).InitializeAsync().ConfigureAwait(false) as WebGLContext)!;
    }
    public static async Task<WebGL2Context> CreateWebGL2Async(this BeCanvas canvas, WebGLContextAttributes? attributes = null)
    {
        return (await new WebGL2Context(canvas, attributes).InitializeAsync().ConfigureAwait(false) as WebGL2Context)!;
    }

}