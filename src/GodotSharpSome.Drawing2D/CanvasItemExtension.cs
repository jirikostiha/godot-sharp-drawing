﻿namespace GodotSharpSome.Drawing2D
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Godot;
    using static Godot.Mathf;

    public static class CanvasItemExtension
    {
        public static void DrawCircleLine(this CanvasItem canvas, Vector2 center, float radius, Color lineColor, float lineWidth = 1, bool antialiased = false)
        {
            canvas.DrawArc(center, radius, 0, Pi * 2, (int)radius * 16, lineColor, lineWidth, antialiased);
        }

        public static void DrawCircleArea(this CanvasItem canvas, Vector2 center, float radius, Color areaColor)
        {
            canvas.DrawCircle(center, radius, areaColor);
        }

        public static void DrawCircle(this CanvasItem canvas, Vector2 center, float radius, Color lineColor, Color areaColor, float lineWidth = 1, bool antialiased = false)
        {
            canvas.DrawCircleArea(center, radius, areaColor);
            canvas.DrawCircleLine(center, radius, lineColor, lineWidth, antialiased);
        }

        public static void DrawRectangleLine(this CanvasItem canvas, Vector2 center, float length, float width, float rotationAngle, Color lineColor, float lineWidth = 1, bool antialiased = false)
        {
            canvas.DrawMultiline(
                Multiline.Rectangle(center, length/2, width/2, rotationAngle),
                lineColor, lineWidth, antialiased);
        }

        public static void DrawRectangleArea(this CanvasItem canvas, Vector2 center, float length, float width, float rotationAngle, Color areaColor)
        {
            canvas.DrawPolygon(
                Multiline.Rectangle(center, length / 2, width / 2, rotationAngle),
                new Color[] { areaColor });
        }

        public static void DrawRectangle(this CanvasItem canvas, Vector2 center, float length, float width, float rotationAngle, Color lineColor, Color areaColor, float lineWidth = 1, bool antialiased = false)
        {
            canvas.DrawRectangleArea(center, length, width, rotationAngle, areaColor);
            canvas.DrawRectangleLine(center, length, width, rotationAngle, lineColor, lineWidth, antialiased);
        }
    }
}