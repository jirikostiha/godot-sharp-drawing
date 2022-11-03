﻿using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using GodotSharpSome.Drawing2D;
using static Godot.Mathf;
using V = Godot.Vector2;

public class Node2D : Godot.ColorRect
{
    private static Color BackColor = Color.ColorN("white");
    private static Color LineColor = Color.ColorN("black");
    private static Color AreaColor = Color.ColorN("lightgray");
    private static Color TextColor = Color.ColorN("black");
    private Grid _grid = new Grid(10, 100, 100);

    public override void _Ready()
    {
        Color = BackColor;
    }

    public override void _Draw()
    {
        DrawCrosses(1);

        DrawArrows(2);

        DrawSegmenedLines(3);

        DrawRectangles(4);

        DrawCandleBars(5);

        DrawCircles(6);

        DrawConnections(7);
    }

    private void DrawCrosses(int row)
    {
        DrawMultiline(
            Multiline.Cross(_grid.Middle(row, column: 1), radius: 15),
            LineColor);

        DrawMultiline(
            Multiline.Cross2(_grid.Middle(row, column: 2), outerRadius: 15, innerRadius: 5),
            LineColor, width: 2);
    }

    private void DrawArrows(int row)
    {
        DrawMultiline(
            Multiline.Arrow(_grid.LeftBottom(row, column: 1), _grid.RightTop(row, column: 1), headRadius: 15),
            LineColor);

        DrawMultiline(
            Multiline.Arrow(_grid.LeftBottom(row, column: 2), _grid.RightTop(row, column: 2), headRadius: 10, arrowAngle: Pi * 5 / 6),
            LineColor);

        DrawMultiline(
            Multiline.DoubleArrow(_grid.LeftBottom(row, column: 3), _grid.RightTop(row, column: 3), headRadius: 15),
            LineColor);

        DrawDimmensionLength(4);

        void DrawDimmensionLength(int column)
        {
            var a = _grid.LeftMiddle(row, column);
            var b = _grid.RightMiddle(row, column);
            var points = new List<Vector2>(14);
            Multiline.AppendLine(points, a + new V(0, 8), a + new V(0, -4));
            Multiline.AppendLine(points, b + new V(0, 8), b + new V(0, -4));
            Multiline.AppendDoubleArrow(points, a, b, 16);
            DrawMultiline(points.ToArray(), LineColor);
            DrawString(GetFont(null), _grid.Middle(row, column) + new V(-8, -3), "42", TextColor);
        }
    }

    private void DrawSegmenedLines(int row)
    {
        DrawMultiline(
            Multiline.SegmentedLine(_grid.LeftMiddle(row, column: 1), _grid.RightMiddle(row, column: 1), segmentCount: 4),
            LineColor);

        DrawMultiline(
            Multiline.SegmentedArrow(_grid.LeftTop(row, column: 2), _grid.RightBottom(row, column: 3), segmentSize: 20, headRadius: 15),
            LineColor);
    }

    private void DrawRectangles(int row)
    {
        var length = 68f;
        var width = 24f;
        var rotationAngle = Pi / 5.1f;

        this.DrawRectangleLine(_grid.Middle(row, column: 1), length, width, rotationAngle, LineColor);

        this.DrawRectangleArea(_grid.Middle(row, column: 2), length, width, rotationAngle, AreaColor);

        this.DrawRectangle(_grid.Middle(row, column: 3), length, width, rotationAngle, LineColor, AreaColor);
    }

    private void DrawCandleBars(int row)
    {
        DrawMultiline(
           Multiline.CandleBar(
                _grid.BottomMiddle(row, column: 1), bottomOffset: 30,
                _grid.TopMiddle(row, column: 1), topOffset: 16, 4f),
           LineColor);
    }

    private void DrawCircles(int row)
    {
        var radius = 20;

        this.DrawCircleLine(_grid.Middle(row, column: 1), radius, LineColor);

        this.DrawCircleArea(_grid.Middle(row, column: 2), radius, AreaColor);

        this.DrawCircle(_grid.Middle(row, column: 3), radius, LineColor, AreaColor);
    }

    private void DrawConnections(int row)
    {
        DrawSingleConnection(
            _grid.LeftMiddle(row, column: 1) + new V(15, 0), 8f, 
            _grid.RightMiddle(row, column: 1) + new V(-15, 0), 12f);

        DrawTriangleConnection(
            _grid.LeftBottom(row, column: 2) + new V(15, 16), 8f,
            _grid.RightBottom(row, column: 2) + new V(-15, 16), 8f,
            _grid.TopMiddle(row, column: 2) + new V(0, -16), 8f);

        void DrawTriangleConnection(V a, float ar, V b, float br, V c, float cr)
        {
            DrawArc(a, ar, 0, Pi * 2, 64, LineColor);
            DrawArc(b, br, 0, Pi * 2, 64, LineColor);
            DrawArc(c, cr, 0, Pi * 2, 64, LineColor);

            var points = new List<Vector2>();
            Multiline.AppendLine(points, a, ar, c, cr);
            Multiline.AppendLine(points, b, br, c, cr);

            Multiline.AppendLine(points, a, ar, a + new V(0, -16), 0);
            Multiline.AppendLine(points, b, br, b + new V(0, -16), 0);
            Multiline.AppendLine(points, c, cr, c + new V(0, 16), 0);

            DrawMultiline(points.ToArray(), LineColor);
        }

        void DrawSingleConnection(V a, float ar, V b, float br)
        {
            DrawArc(a, ar, 0, Pi * 2, 64, LineColor);
            DrawArc(b, br, 0, Pi * 2, 64, LineColor);
            DrawMultiline(
                Multiline.AppendLine(new List<Vector2>(2), a, ar, b, br).ToArray(),
                LineColor);
        }
    }
}