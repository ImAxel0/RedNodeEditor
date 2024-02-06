using ImGuiNET;
using RedNodeEditor.EventNodes;

namespace RedNodeEditor;

public class ErrorSense
{
    public static int Errors;
    public static int Warnings;

    public static bool ShowErrors = true;
    public static bool ShowWarnings = true;

    public static List<KeyValuePair<Type, string>> TypeMsg = new();

    public enum Type
    {
        Error, Warning
    }

    public static async void Start()
    {
        while (true)
        {
            CheckArguments();
            CheckCustomEvents();

            UpdateCounter();
            await Task.Delay(100);
            TypeMsg.Clear();
            Errors = 0; Warnings = 0;
        }  
    }

    static void UpdateCounter()
    {
        foreach (var msg in TypeMsg.ToList())
        {
            if (msg.Key == Type.Error)
                Errors++;
            else if (msg.Key == Type.Warning)
                Warnings++;
        }
    }

    public static void CheckArguments()
    {
        foreach (var node in GraphEditor.GraphNodes)
        {
            node.ArgsOut.ForEach(arg =>
            {
                if (node.Input.HasConnection && node.Outputs.All(n => n.HasConnection) && !arg.HasConnection)
                    TypeMsg.Add(new(Type.Warning, $"{arg.Type.Name} output of {node.Name} isn't connected"));
            });
        }
    }

    public static void CheckCustomEvents()
    {
        List<string> cEventsNames = new();
        var customEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEventNode));
        var callCustomEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CallCustomEventNode));

        foreach (var callEventNode in callCustomEventNodes)
        {
            var callEvent = (CallCustomEventNode)callEventNode;
            if (callEvent.Input.HasConnection && string.IsNullOrEmpty(callEvent.EventName))
                TypeMsg.Add(new(Type.Error, $"A {callEvent.Name} node doesn't have an EventName"));
        }

        foreach (var customEvent in customEventNodes)
        {
            var cEvent = (CustomEventNode)customEvent;

            cEventsNames.Add(cEvent.EventName);

            if (string.IsNullOrEmpty(cEvent.EventName))
                TypeMsg.Add(new(Type.Error, $"A {cEvent.Name} node doesn't have an EventName"));
        }       

        foreach (var node in GraphEditor.GraphNodes)
        {
            var property = node.GetType().GetProperties().FirstOrDefault(p => p.CustomAttributes.Any(at => at.AttributeType == typeof(IsEventName)));

            if (property == null)
                continue;

            if (node.Input.HasConnection && !cEventsNames.Contains(property.GetValue(node)))
                TypeMsg.Add(new(Type.Error, $"A {node.Name} node doesn't have a matching CustomEvent EventName"));
        }
    }

    public static void Render()
    {
        ImGuiTheme.LoggerTheme();

        ImGui.PushFont(Drawings.Font20);
        ImGui.SeparatorText("ErrorList");
        ImGui.PopFont();

        ImGui.BeginChild("ErrorListWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border, ImGuiWindowFlags.MenuBar);

        ImGui.BeginMenuBar();

        ImGui.TextColored(Drawings.Colors.Error, $"Errors [{Errors}]" );
        ImGui.TextColored(Drawings.Colors.Warning, $"Warnings [{Warnings}]");


        ImGui.Checkbox("Errors", ref ShowErrors);
        ImGui.Checkbox("Warnings", ref ShowWarnings);

        ImGui.EndMenuBar();

        foreach (var msg in TypeMsg.ToList())
        {
            switch (msg.Key)
            {
                case Type.Error:
                    if (ShowErrors)
                        ImGui.TextColored(Drawings.Colors.Error, msg.Value);
                    break;
                case Type.Warning:
                    if (ShowWarnings)
                        ImGui.TextColored(Drawings.Colors.Warning, msg.Value);
                    break;
            }
        }

        ImGui.EndChild();

        ImGuiTheme.ApplyTheme();
    }
}
