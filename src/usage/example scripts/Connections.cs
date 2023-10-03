using Godot;
using GodotSharpSome.Drawing2D;
using static Godot.Mathf;

public partial class Connections : ExampleNodeBase
{
    private double _time;
    private Multiline _multiline = new();
    private float _r1, _r2, _r3, _r4, _r5;

    public Connections()
    {
        _r1 = 10;
        _r2 = 12;
        _r3 = 15;
        _r4 = 8;
        _r5 = 13;
    }

    protected override void NextState(double delta) => _time += 0.1f;

    public override void _Draw()
    {
        // I
        DrawSingleConnection(
            Middle(1),
            CellWidth / 2f - 20,
            8f,
            CellWidth / 2f - 28,
            12f);

        // II
        DrawTriangleConnection(
            LeftBottom(2) + new Vector2(15, 22), 8f,
            RightBottom(2) + new Vector2(-15, 22), 8f,
            MiddleTop(2) + new Vector2(0, -16), 8f);

        // III
        DrawChain(Middle(3));
    }

    private void DrawSingleConnection(Vector2 rotationCenter, float a, float ar, float b, float br)
    {
        var aa = a + 4 * Sin((float)_time);
        var bb = b + 6 * Sin((float)_time * 1.13f);
        var acenter = rotationCenter + (aa * Vector2.Left).Rotated((float)_time);
        var bcenter = rotationCenter + (bb * Vector2.Right).Rotated((float)_time);

        this.DrawCircleOutline(acenter, ar, LineColor);
        this.DrawCircleOutline(bcenter, br, LineColor);

        _multiline.Clear().AppendLine(acenter, ar, bcenter, br);
        DrawMultiline(_multiline.Points(), LineColor);
    }

    private void DrawTriangleConnection(Vector2 a, float ar, Vector2 b, float br, Vector2 c, float cr)
    {
        var crr = cr + 4 * Sin((float)_time);
        var aa = a + 4 * Sin((float)_time * 1.1f) * Vector2.Right;
        var bb = b + 10 * Sin((float)_time * 1.33f) * Vector2.Down;

        this.DrawCircleOutline(aa, ar, LineColor);
        this.DrawCircleOutline(bb, br, LineColor);
        this.DrawCircleOutline(c, crr, LineColor);

        _multiline.Clear();
        _multiline.AppendLine(aa, ar, c, crr);
        _multiline.AppendLine(bb, br, c, crr);

        _multiline.AppendLine(aa, ar, aa + new Vector2(0, -16), 0);
        _multiline.AppendLine(bb, br, bb + new Vector2(0, -16), 0);
        _multiline.AppendLine(c, crr, c + new Vector2(0, 16), 0);

        DrawMultiline(_multiline.Points(), LineColor);
    }

    private float _xOffset = 60;

    private void DrawChain(Vector2 start)
    {
        var v1 = start;
        var v2 = v1 + new Vector2(_xOffset, Sin((float)_time) * 20);
        var v3 = v1 + new Vector2(2 * _xOffset, Sin((float)_time) * 28);
        var v4 = v1 + new Vector2(3 * _xOffset, Sin((float)_time) * 15);
        var v5 = v1 + new Vector2(4 * _xOffset, 0);

        this.DrawCircle(v1, _r1, LineColor, AreaColor);
        this.DrawCircleOutline(v2, _r2, LineColor);
        this.DrawCircleOutline(v3, _r3, LineColor);
        this.DrawCircleOutline(v4, _r4, LineColor);
        this.DrawCircle(v5, _r5, LineColor, AreaColor);

        // connections
        _multiline.Clear();
        _multiline.AppendLine(v1, _r1, v2, _r2);
        _multiline.AppendLine(v2, _r2, v3, _r3);
        _multiline.AppendLine(v3, _r3, v4, _r4);
        _multiline.AppendLine(v4, _r4, v5, _r5);
        DrawMultiline(_multiline.Points(), LineColor);
    }
}