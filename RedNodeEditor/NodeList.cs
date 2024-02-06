﻿using ImGuiNET;

namespace RedNodeEditor;

public class NodeList
{
    public static string SearchBuffer = "";

    public static Dictionary<SonsNode.NodeCategories, Dictionary<string, SonsNode>> CategoryNodesPair = new()
    {
        { SonsNode.NodeCategories.Player, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Environment, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Inventory, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.BaseNodes, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Others, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Actors, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Math, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.FlowChange, new Dictionary<string, SonsNode>() },
        { SonsNode.NodeCategories.Input, new Dictionary<string, SonsNode>() },
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

        ImGui.BeginChild("MainNodeListTopBar", new(ImGui.GetContentRegionAvail().X, 60));
        ImGui.PushFont(Drawings.Font20);
        ImGui.InputText("Search node", ref SearchBuffer, 1000);      
        ImGui.SeparatorText("Node list");
        ImGui.PopFont();

        ImGui.EndChild();

        if (OrderedCategoryNodesPair.Count == 0)
            OrderCategoriesAlphabetically();

        ImGui.BeginChild("MainNodeList", new (ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y - 200), ImGuiChildFlags.ResizeY);

        foreach (var nodeCategory in OrderedCategoryNodesPair)
        {
            if (ImGui.CollapsingHeader(nodeCategory.Key.ToString()))
            {
                foreach (var node in nodeCategory.Value.Values)
                {
                    if (!node.Name.ToLower().Contains(SearchBuffer.ToLower()))
                        continue;

                    if (ImGui.Selectable(node.Name, false, ImGuiSelectableFlags.AllowDoubleClick))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            GraphEditor.AddToGraph(node, new(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y));
                    }
                    Drawings.NodeTooltip(node.Description);
                }
            }
        }
        ImGui.EndChild();

        if (ImGui.BeginCombo("ErrorList/Log/Variables", selectedOpt))
        {
            foreach (var opt in options)
            {
                if (ImGui.Selectable(opt))
                    selectedOpt = opt;
            }
            ImGui.EndCombo();
        }

        switch (selectedOpt)
        {
            case "ErrorList":
                ErrorSense.Render();
                break;
            case "Log":
                Logger.Render();
                break;
        }   
        ImGui.EndChild();
    }

    static string[] options = { "ErrorList", "Log" };
    static string selectedOpt = "ErrorList";
}