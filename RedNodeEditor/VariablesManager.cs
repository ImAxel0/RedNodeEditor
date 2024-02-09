using ImGuiNET;
using RedNodeEditor.VariablesNodes;
using System.Numerics;
using Vanara.PInvoke;

namespace RedNodeEditor;

/// <summary>
/// All variables must be "Set" atleast once before using the "Get"
/// </summary>
public class VariablesManager
{
    public static string NameBuffer = string.Empty;
    public static Type SelectedType = typeof(int);

    public static List<string> VariablesId = new();
    public static Dictionary<string, Type> Variables = new();

    public static List<Type> VariableTypes = new()
    {
        typeof(int), typeof(float), typeof(bool), 
        typeof(string), typeof(Vector3), typeof(object)
    };

    public static void DeleteVariable(KeyValuePair<string, Type> variable, int idIndex)
    {       
        var varNodes = GraphEditor.GraphNodes.Where(n => n.Id == VariablesId[idIndex]);
        foreach (var varNode in varNodes.ToList())
            GraphEditor.DeleteNode(varNode);

        VariablesId.RemoveAt(idIndex);
        Variables.Remove(variable.Key);
    }

    static void RenderTopInputs()
    {
        ImGui.InputText("Name", ref NameBuffer, 1000, ImGuiInputTextFlags.CharsNoBlank);

        if (ImGui.BeginCombo("Type", SelectedType.Name))
        {
            foreach (var varType in VariableTypes)
            {
                if (ImGui.Selectable(varType.Name))
                    SelectedType = varType;
            }
            ImGui.EndCombo();
        }

        if (ImGui.Button("Add", new(ImGui.GetContentRegionAvail().X, 25)))
        {
            if (string.IsNullOrEmpty(NameBuffer))
            {
                User32.MessageBox(IntPtr.Zero, "Variable name field can't be empty", "Error creating variable",
                    User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                return;
            }

            if (!Variables.ContainsKey(NameBuffer))
            {
                VariablesId.Add(Guid.NewGuid().ToString());
                Variables.Add(NameBuffer, SelectedType);
            }
            else
                User32.MessageBox(IntPtr.Zero, "Can't add a variable with the same name as another one", "Error",
                    User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
        }
    }

    static void RenderVariables()
    {
        int idx = 0;
        foreach (var variable in Variables)
        {
            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new(0.13f, 0.13f, 0.13f, 1);
            ImGui.BeginChild(idx.ToString(), new(ImGui.GetContentRegionAvail().X, ImGui.CalcTextSize(variable.Key).Y * 2), ImGuiChildFlags.Border);

            ImGui.Columns(4, idx.ToString(), false);

            ImGui.TextColored(Drawings.GetTypeColor(variable.Value), variable.Key);
            Drawings.NodeTooltip(variable.Value.Name);
            ImGui.NextColumn();

            if (ImGui.Selectable("Get"))
            {
                var newPos = new Vector2(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y);
                SonsNode varNode = new();
                switch (variable.Value)
                {
                    case Type t when t == typeof(bool):
                        varNode = new BooleanGetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"BoolGet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(int):
                        varNode = new IntGetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"IntGet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(float):
                        varNode = new FloatGetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"FloatGet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(string):
                        varNode = new StringGetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"StringGet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(Vector3):
                        varNode = new Vector3GetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"Vector3Get ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(object):
                        varNode = new ObjectGetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"ObjectGet ({variable.Key})",
                            Position = newPos
                        };
                        break;
                }
                GraphEditor.GraphNodes.Add(varNode);
            }

            ImGui.NextColumn();

            if (ImGui.Selectable("Set"))
            {
                var newPos = new Vector2(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y);
                SonsNode varNode = new();
                switch (variable.Value)
                {
                    case Type t when t == typeof(bool):
                        varNode = new BooleanSetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"BoolSet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(int):
                        varNode = new IntSetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"IntSet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(float):
                        varNode = new FloatSetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"FloatSet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(string):
                        varNode = new StringSetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"StringSet ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(Vector3):
                        varNode = new Vector3SetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"Vector3Set ({variable.Key})",
                            Position = newPos
                        };
                        break;

                    case Type t when t == typeof(object):
                        varNode = new ObjectSetNode()
                        {
                            Id = VariablesId[idx],
                            Name = $"ObjectSet ({variable.Key})",
                            Position = newPos
                        };
                        break;
                }
                GraphEditor.GraphNodes.Add(varNode);
            }

            ImGui.NextColumn();

            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Text] = Drawings.Colors.SelectedNodeColor;

            if (ImGui.Selectable("Delete", false, ImGuiSelectableFlags.AllowDoubleClick))
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                    DeleteVariable(variable, idx);
            }
            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Text] = Vector4.One;

            ImGui.EndChild();
            idx++;
        }
    }

    public static void Render()
    {
        ImGuiTheme.LoggerTheme();

        ImGui.PushFont(Drawings.Font20);
        ImGui.SeparatorText("Variables");
        ImGui.PopFont();

        ImGui.BeginChild("VariablesWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        RenderTopInputs();
        ImGui.SeparatorText("##");
        RenderVariables();

        ImGui.EndChild();

        ImGuiTheme.ApplyTheme();

        HandleObjectVariablesOutput();
    }

    /// <summary>
    /// Converts output of object type variables to the corresponding attached input type
    /// To fix: attaching another input type to the SetNode converts the already converted output type causing a mismatch in types
    /// </summary>
    static void HandleObjectVariablesOutput()
    {
        var objectVariables = GraphEditor.GraphNodes.Where(n => n.GetType() == typeof(ObjectGetNode) || n.GetType() == typeof(ObjectSetNode));
        foreach (var node in objectVariables)
        {
            if (node.GetType() == typeof(ObjectGetNode))
            {
                var setNodes = GraphEditor.GraphNodes.Where(x => x.Id == node.Id && x.GetType() == typeof(ObjectSetNode));

                foreach (var setNode in setNodes)
                {
                    if (setNode.ArgsIn[0].HasConnection)
                        node.ArgsOut[0].Type = setNode.ArgsOut[0].Type;
                }
            }

            if (node.GetType() == typeof(ObjectSetNode) && node.ArgsIn[0].OutputArg != null)
                    node.ArgsOut[0].Type = node.ArgsIn[0].OutputArg.Type;             
        }
    }
}
