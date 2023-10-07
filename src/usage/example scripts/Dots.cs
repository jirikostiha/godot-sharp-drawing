using Godot;
using GodotSharpSome.Drawing2D;
using System.Linq;
using static Godot.Mathf;

namespace GodotSharpSome.Examples;

public partial class Dots : ExampleNodeBase
{
    private float _time;

    private Multiline _multiline = new(30, new DottedLine());

    private float[] _sinSamplePointsX = Enumerable.Range(0, 150).Select(i => 2f * i).ToArray();

    private int[] _powerSamplePointsX = Enumerable.Range(-25, 51).ToArray();
    private int _powerPointCount;

    public Dots()
    {
        _powerPointCount = _powerSamplePointsX.Length;
    }

    protected override void NextState(double delta)
    {
        _time += 0.02f;

        _powerPointCount = _powerPointCount <= _powerSamplePointsX.Length
            ? _powerPointCount + 1
            : 0;
    }

    public override void _Draw()
    {
        // I
        DrawPower(MiddleBottom(1));

        // II
        DrawSin(LeftMiddle(2));
    }

    private void DrawPower(Vector2 origin)
    {
        var functionPoints = _powerSamplePointsX.Take(_powerPointCount).Select(x => origin +
            new Vector2(x, (x / 10f) * (x / 10f) * 10));

        var points = _multiline
            .Clear()
            .AppendLine(origin + new Vector2(0, -4), origin + new Vector2(0, 70))
            .AppendLine(origin + new Vector2(-30, 0), origin + new Vector2(30, 0))
            .AppendDots(functionPoints)
            .Points();

        DrawMultiline(points, LineColor);
    }

    private void DrawSin(Vector2 start)
    {
        var points = _sinSamplePointsX.Select(x => start + new Vector2(x, 40 * Sin(_time + 0.1f * x)));
        this.DrawDots(points.ToArray(), LineColor);
    }
}