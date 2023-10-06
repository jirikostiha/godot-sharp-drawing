using System.Linq;
using Godot;

public sealed class DimensioningList : Control
{
    public static readonly Color LightBack = Color.ColorN("white");
    public static readonly Color DarkBack = Color.ColorN("black");
    public static readonly Color LightStroke = Color.ColorN("white");
    public static readonly Color DarkStroke = Color.ColorN("black");
    public static readonly Color LightRegion = Color.ColorN("lightgray");
    public static readonly Color DarkRegion = Color.ColorN("darkgray");

    public bool AnimateAll { get; set; }

    public bool InvertAll { get; set; }

    public void _on_AnimateAll_pressed()
    {
        AnimateAll = !AnimateAll;
        var nodes = GetTree().GetNodesInGroup("ExampleContents").OfType<ExampleNodeBase>();
        foreach (var node in nodes)
            node.Animate = AnimateAll;
    }

    public void _on_InvertAll_pressed()
    {
        InvertAll = !InvertAll;
        if (!InvertAll)
        {
            var nodes = GetTree().GetNodesInGroup("ExampleContents").OfType<ExampleNodeBase>();
            foreach (var node in nodes)
            {
                node.Color = LightBack;
                node.LineColor = DarkStroke;
                node.AreaColor = LightRegion;
                node.TextColor = DarkStroke;
            }
        }
        else
        {
            var nodes = GetTree().GetNodesInGroup("ExampleContents").OfType<ExampleNodeBase>();
            foreach (var node in nodes)
            {
                node.Color = DarkBack;
                node.LineColor = LightStroke;
                node.AreaColor = DarkRegion;
                node.TextColor = LightStroke;
            }
        }
    }
}
