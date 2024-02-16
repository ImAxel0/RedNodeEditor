using ImGuiNET;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace RedNodeEditor;

public class NodeList
{
    public static string SearchBuffer = "";
    public static bool HideArguments;

    public static Type InputFilter = typeof(All);
    public static Type OutputFilter = typeof(All);

    public enum All{}

    public static List<Type> FilterTypes = new()
    {
        typeof(All),
        typeof(int), typeof(bool), typeof(float), 
        typeof(string), typeof(Vector3), typeof(Vector2), 
        typeof(GameObject), typeof(Component), typeof(Transform), 
    };

    public static Dictionary<SonsNode.NodeCategories, Dictionary<string, SonsNode>> CategoryNodesPair = new()
    {
        { SonsNode.NodeCategories.Player, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Environment, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Inventory, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.BaseNodes, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Others, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Actors, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Audio, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.RangedWeapons, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Math, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.FlowChange, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Input, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Generics, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.UI, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Unity, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Utilities, new Dictionary<string, SonsNode>() },    
    };

    public static Dictionary<SonsNode.NodeCategories, Dictionary<string, SonsNode>> OrderedCategoryNodesPair = new();

    static void OrderCategoriesAlphabetically()
    {
        var sortedKeys = CategoryNodesPair.Keys.OrderBy(key => key.ToString());

        foreach (var key in sortedKeys)
        {
            OrderedCategoryNodesPair.Add(key, CategoryNodesPair[key]);
        }
    }

    public static void Render()
    {
        ImGui.BeginChild("NodeListWindow", new(450, ImGui.GetContentRegionAvail().Y), ImGuiChildFlags.Border | ImGuiChildFlags.ResizeX);

        ImGui.BeginChild("MainNodeListTopBar", new(ImGui.GetContentRegionAvail().X, 115));
        ImGui.PushFont(Drawings.Font20);
        ImGui.InputTextWithHint($"Search node {IconFonts.FontAwesome6.MagnifyingGlass}", "...", ref SearchBuffer, 1000);
        ImGui.PopFont();

        if (ImGui.BeginCombo("Input filter", InputFilter.Name, ImGuiComboFlags.HeightLargest))
        {
            foreach (var type in FilterTypes)
            {
                if (ImGui.Selectable(type.Name))
                    InputFilter = type;
            }
            ImGui.EndCombo();
        }

        if (ImGui.BeginCombo("Output filter", OutputFilter.Name, ImGuiComboFlags.HeightLargest))
        {
            foreach (var type in FilterTypes)
            {
                if (ImGui.Selectable(type.Name))
                    OutputFilter = type;
            }
            ImGui.EndCombo();
        }

        ImGui.PushFont(Drawings.Font20);
        ImGui.SeparatorText("Node list");
        ImGui.PopFont();

        ImGui.EndChild();

        if (OrderedCategoryNodesPair.Count == 0)
            OrderCategoriesAlphabetically();
        
        ImGui.BeginChild("MainNodeList", new (ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y / 1.5f), ImGuiChildFlags.ResizeY);

        foreach (var nodeCategory in OrderedCategoryNodesPair)
        {
            if (ImGui.CollapsingHeader(nodeCategory.Key.ToString()))
            {
                int nColumn = HideArguments ? 1 : 3;
                ImGui.BeginTable(nodeCategory.Key.ToString(), nColumn, ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersOuterH | ImGuiTableFlags.PadOuterX);
                ImGui.TableSetupColumn("Name");
                ImGui.TableSetupColumn("Inputs");
                ImGui.TableSetupColumn("Outputs");
                ImGui.TableHeadersRow();

                foreach (var node in nodeCategory.Value.Values)
                {
                    if (!node.Name.ToLower().Contains(SearchBuffer.ToLower()))
                        continue;

                    if (InputFilter != typeof(All))
                    {
                        if (!node.ArgsIn.Any(x => x.Type == InputFilter))
                            continue;
                    }

                    if (OutputFilter != typeof(All))
                    {
                        if (!node.ArgsOut.Any(x => x.Type == OutputFilter))
                            continue;
                    }

                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    if (ImGui.Selectable(node.Name, false, ImGuiSelectableFlags.AllowDoubleClick))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            GraphEditor.AddToGraph(node, new(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y));
                    }
                    Drawings.NodeListTooltip(node.Name, node.Description);

                    if (HideArguments)
                        continue;

                    ImGui.TableSetColumnIndex(1);

                    int offset = 0;
                    node.ArgsIn.ForEach(argIn => {
                        Drawings.DrawNodeListArgInCircle(argIn);
                        ImGui.SameLine(offset += 15);
                    });

                    ImGui.TableSetColumnIndex(2);

                    int offset2 = 0;
                    node.ArgsOut.ForEach(argOut => {
                        Drawings.DrawNodeListArgOutCircle(argOut);
                        ImGui.SameLine(offset2 += 15);
                    });
                }
                ImGui.EndTable();
            }
        }
        ImGui.EndChild();

        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.18f, 0.18f, 0.19f, 1);
        ImGui.BeginChild("MainNodeListBottom", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        if (ImGui.BeginCombo("##", SelectedOption.ToString()))
        {
            foreach (var opt in Enum.GetValues(typeof(Options)))
            {
                if (ImGui.Selectable(opt.ToString()))
                    SelectedOption = (Options)opt;
            }
            ImGui.EndCombo();
        }
        
        switch (SelectedOption)
        {
            case Options.ErrorList:
                ErrorSense.Render();
                break;
            case Options.Log:
                Logger.Render();
                break;
            case Options.Variables:
                VariablesManager.Render();
                break;
        }
        ImGui.EndChild();

        ImGui.EndChild();
    }

    public static Options SelectedOption = Options.Variables;

    public enum Options
    {
        Variables,
        ErrorList,
        Log
    }
}
