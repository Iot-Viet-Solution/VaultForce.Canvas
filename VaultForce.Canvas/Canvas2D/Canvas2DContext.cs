using System.Globalization;
using VaultForce.Canvas.Model;
using Microsoft.AspNetCore.Components;

namespace VaultForce.Canvas.Canvas2D
{
    public class Canvas2DContext : RenderingContext
    {
        #region Constants

        private const string ContextName = "Canvas2d";
        private const string FillStyleProperty = "fillStyle";
        private const string StrokeStyleProperty = "strokeStyle";
        private const string FillRectMethod = "fillRect";
        private const string ClearRectMethod = "clearRect";
        private const string StrokeRectMethod = "strokeRect";
        private const string FillTextMethod = "fillText";
        private const string StrokeTextMethod = "strokeText";
        private const string MeasureTextMethod = "measureText";
        private const string LineWidthProperty = "lineWidth";
        private const string LineCapProperty = "lineCap";
        private const string LineJoinProperty = "lineJoin";
        private const string MiterLimitProperty = "miterLimit";
        private const string GetLineDashMethod = "getLineDash";
        private const string SetLineDashMethod = "setLineDash";
        private const string LineDashOffsetProperty = "lineDashOffset";
        private const string ShadowBlurProperty = "shadowBlur";
        private const string ShadowColorProperty = "shadowColor";
        private const string ShadowOffsetXProperty = "shadowOffsetX";
        private const string ShadowOffsetYProperty = "shadowOffsetY";
        private const string BeginPathMethod = "beginPath";
        private const string ClosePathMethod = "closePath";
        private const string MoveToMethod = "moveTo";
        private const string LineToMethod = "lineTo";
        private const string BezierCurveToMethod = "bezierCurveTo";
        private const string QuadraticCurveToMethod = "quadraticCurveTo";
        private const string ArcMethod = "arc";
        private const string ArcToMethod = "arcTo";
        private const string RectMethod = "rect";
        private const string FillMethod = "fill";
        private const string StrokeMethod = "stroke";
        private const string DrawFocusIfNeededMethod = "drawFocusIfNeeded";
        private const string ScrollPathIntoViewMethod = "scrollPathIntoView";
        private const string ClipMethod = "clip";
        private const string IsPointInPathMethod = "isPointInPath";
        private const string IsPointInStrokeMethod = "isPointInStroke";
        private const string RotateMethod = "rotate";
        private const string ScaleMethod = "scale";
        private const string TranslateMethod = "translate";
        private const string TransformMethod = "transform";
        private const string SetTransformMethod = "setTransform";
        private const string GlobalAlphaProperty = "globalAlpha";
        private const string SaveMethod = "save";
        private const string RestoreMethod = "restore";
        private const string DrawImageMethod = "drawImage";
        private const string CreatePatternMethod = "createPattern";
        private const string GlobalCompositeOperationProperty = "globalCompositeOperation";

        private readonly string[] _repeatNames =
        [
            "repeat", "repeat-x", "repeat-y", "no-repeat"
        ];

        private const string GetImageDataMethod = "getImageData";
        private const string PutImageDataMethod = "putImageData";

        #endregion

        #region Properties

        public string FillStyle { get; private set; } = "#000";

        public string StrokeStyle { get; private set; } = "#000";

        public string Font { get; private set; } = "10px sans-serif";

        public TextAlign TextAlign { get; private set; }

        public TextDirection Direction { get; private set; }

        public TextBaseline TextBaseline { get; private set; }

        public float LineWidth { get; private set; } = 1.0f;

        public LineCap LineCap { get; private set; }

        public LineJoin LineJoin { get; private set; }

        public float MiterLimit { get; private set; } = 10;

        public float LineDashOffset { get; private set; }

        public float ShadowBlur { get; private set; }

        public string ShadowColor { get; private set; } = "black";

        public float ShadowOffsetX { get; private set; }

        public float ShadowOffsetY { get; private set; }

        public float GlobalAlpha { get; private set; } = 1.0f;
        public string GlobalCompositeOperation { get; private set; } = "source-over";

        #endregion Properties

        public Canvas2DContext(BeCanvas reference) : base(reference, ContextName)
        {
        }

        #region Property Setters

        public async Task SetFillStyleAsync(string value)
        {
            FillStyle = value;
            await BatchCallAsync(FillStyleProperty, isMethodCall: false, value);
        }

        public async Task SetStrokeStyleAsync(string value)
        {
            StrokeStyle = value;
            await BatchCallAsync(StrokeStyleProperty, isMethodCall: false, value);
        }

        public async Task SetFontAsync(string value)
        {
            Font = value;
            await BatchCallAsync("font", isMethodCall: false, value);
        }

        public async Task SetTextAlignAsync(TextAlign value)
        {
            TextAlign = value;
            await BatchCallAsync("textAlign", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetDirectionAsync(TextDirection value)
        {
            Direction = value;
            await BatchCallAsync("direction", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetTextBaselineAsync(TextBaseline value)
        {
            TextBaseline = value;
            await BatchCallAsync("textBaseline", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineWidthAsync(float value)
        {
            LineWidth = value;
            await BatchCallAsync(LineWidthProperty, isMethodCall: false, value);
        }

        public async Task SetLineCapAsync(LineCap value)
        {
            LineCap = value;
            await BatchCallAsync(LineCapProperty, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineJoinAsync(LineJoin value)
        {
            LineJoin = value;
            await BatchCallAsync(LineJoinProperty, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetMiterLimitAsync(float value)
        {
            MiterLimit = value;
            await BatchCallAsync(MiterLimitProperty, isMethodCall: false, value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }

        public async Task SetLineDashOffsetAsync(float value)
        {
            LineDashOffset = value;
            await BatchCallAsync(LineDashOffsetProperty, isMethodCall: false, value);
        }

        public async Task SetShadowBlurAsync(float value)
        {
            ShadowBlur = value;
            await BatchCallAsync(ShadowBlurProperty, isMethodCall: false, value);
        }

        public async Task SetShadowColorAsync(string value)
        {
            ShadowColor = value;
            await BatchCallAsync(ShadowColorProperty, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetXAsync(float value)
        {
            ShadowOffsetX = value;
            await BatchCallAsync(ShadowOffsetXProperty, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetYAsync(float value)
        {
            ShadowOffsetY = value;
            await BatchCallAsync(ShadowOffsetYProperty, isMethodCall: false, value);
        }

        public async Task SetGlobalAlphaAsync(float value)
        {
            GlobalAlpha = value;
            await BatchCallAsync(GlobalAlphaProperty, isMethodCall: false, value);
        }

        public async Task SetGlobalCompositeOperationAsync(string value)
        {
            GlobalCompositeOperation = value;
            await BatchCallAsync(GlobalCompositeOperationProperty, isMethodCall: false, value);
        }

        #endregion Property Setters

        #region Methods

        public async Task FillRectAsync(double x, double y, double width, double height) => await BatchCallAsync(FillRectMethod, isMethodCall: true, x, y, width, height);


        public async Task ClearRectAsync(double x, double y, double width, double height) => await BatchCallAsync(ClearRectMethod, isMethodCall: true, x, y, width, height);


        public async Task StrokeRectAsync(double x, double y, double width, double height) => await BatchCallAsync(StrokeRectMethod, isMethodCall: true, x, y, width, height);


        public async Task FillTextAsync(string text, double x, double y, double? maxWidth = null) =>
            await BatchCallAsync(FillTextMethod, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });


        public async Task StrokeTextAsync(string text, double x, double y, double? maxWidth = null) =>
            await BatchCallAsync(StrokeTextMethod, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });


        public async Task<TextMetrics> MeasureTextAsync(string text) => await CallMethodAsync<TextMetrics>(MeasureTextMethod, text);

        public async Task<float[]> GetLineDashAsync() => await CallMethodAsync<float[]>(GetLineDashMethod);


        public async Task SetLineDashAsync(float[] segments) => await BatchCallAsync(SetLineDashMethod, isMethodCall: true, segments);


        public async Task BeginPathAsync() => await BatchCallAsync(BeginPathMethod, isMethodCall: true);


        public async Task ClosePathAsync() => await BatchCallAsync(ClosePathMethod, isMethodCall: true);

        public async Task MoveToAsync(double x, double y) => await BatchCallAsync(MoveToMethod, isMethodCall: true, x, y);


        public async Task LineToAsync(double x, double y) => await BatchCallAsync(LineToMethod, isMethodCall: true, x, y);

        public async Task BezierCurveToAsync(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => await BatchCallAsync(BezierCurveToMethod, isMethodCall: true, cp1X, cp1Y, cp2X, cp2Y, x, y);

        public async Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y) => await BatchCallAsync(QuadraticCurveToMethod, isMethodCall: true, cpx, cpy, x, y);

        public async Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => await BatchCallAsync(ArcMethod, isMethodCall: true,
            anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });

        public async Task ArcToAsync(double x1, double y1, double x2, double y2, double radius) => await BatchCallAsync(ArcToMethod, isMethodCall: true, x1, y1, x2, y2, radius);

        public async Task RectAsync(double x, double y, double width, double height) => await BatchCallAsync(RectMethod, isMethodCall: true, x, y, width, height);

        public async Task FillAsync() => await BatchCallAsync(FillMethod, isMethodCall: true);

        public async Task StrokeAsync() => await BatchCallAsync(StrokeMethod, isMethodCall: true);

        public async Task DrawFocusIfNeededAsync(ElementReference elementReference) => await BatchCallAsync(DrawFocusIfNeededMethod, isMethodCall: true, elementReference);

        public async Task ScrollPathIntoViewAsync() => await BatchCallAsync(ScrollPathIntoViewMethod, isMethodCall: true);

        public async Task ClipAsync() => await BatchCallAsync(ClipMethod, isMethodCall: true);


        public async Task<bool> IsPointInPathAsync(double x, double y) => await CallMethodAsync<bool>(IsPointInPathMethod, x, y);

        public async Task<bool> IsPointInStrokeAsync(double x, double y) => await CallMethodAsync<bool>(IsPointInStrokeMethod, x, y);

        public async Task RotateAsync(float angle) => await BatchCallAsync(RotateMethod, isMethodCall: true, angle);

        public async Task ScaleAsync(double x, double y) => await BatchCallAsync(ScaleMethod, isMethodCall: true, x, y);

        public async Task TranslateAsync(double x, double y) => await BatchCallAsync(TranslateMethod, isMethodCall: true, x, y);

        public async Task TransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await BatchCallAsync(TransformMethod, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        public async Task SetTransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await BatchCallAsync(SetTransformMethod, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        public async Task SaveAsync() => await BatchCallAsync(SaveMethod, isMethodCall: true);

        public async Task RestoreAsync() => await BatchCallAsync(RestoreMethod, isMethodCall: true);

        public async Task<ImageData> GetImageDataAsync(double sx, double sy, double sh, double sw) => await CallMethodAsync<ImageData>(GetImageDataMethod, sx, sy, sh, sw);

        public async Task PutImageDataAsync(ImageData imageData, double dx, double dy) => await CallMethodAsync<object>(PutImageDataMethod, imageData, dx, dy);

        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy) => await BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, dx, dy);
        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy, double dWidth, double dHeight) => await BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, dx, dy, dWidth, dHeight);

        public async Task DrawImageAsync(ElementReference elementReference, double sx, double sy, double sWidth, double sHeight, double dx, double dy, double dWidth, double dHeight) =>
            await BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public async Task<object> CreatePatternAsync(ElementReference image, RepeatPattern repeat) => await CallMethodAsync<object>(CreatePatternMethod, image, _repeatNames[(int)repeat]);

        #endregion Methods
    }
}