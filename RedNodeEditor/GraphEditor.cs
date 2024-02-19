using System.Reflection;
using IconFonts;
using ImGuiNET;
using RedNodeEditor.EventNodes;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace RedNodeEditor;

public class GraphEditor
{
    /// <summary>
    /// The list of SonsNodes placed in the editor, connected and unconnected
    /// </summary>
    public static List<SonsNode> GraphNodes = new();

    public static List<GraphComment> GraphComments = new();

    public static Vector2 EditorScrollPos = new();

    public static Vector2 CurrentEditorWinSize = new();

    public static Vector2 WindowPos = new();

    public static bool IsEditorHovered;

    public static bool DraggingNode;

    public static bool DraggingOutput;

    public static bool IsPanning;

    public static float Zoom = 1f;

    static float _panSpeed = 10f;

    static float _gridSize = 50f;

    static Vector2 _gridOffset = Vector2.Zero;

    static Vector4 _gridColor = new(1, 1, 1, 0.08f);

    static float _gridThickness = 1;

    static SonsNode _selectedNode;

    static Vector2 _selectedNodeSize;

    static Vector2? _commentPreviewStart;
    static Vector2 _commentPreviewEnd;

    public static void Render()
    {
        ImGuiTheme.EditorTheme();

        IsEditorHovered = ImGui.IsMouseHoveringRect(WindowPos, WindowPos + CurrentEditorWinSize);

        ImGui.SetNextWindowScroll(EditorScrollPos);      
        ImGui.BeginChild("EditorWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border, 
             ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);
        CurrentEditorWinSize = ImGui.GetWindowSize();

        EditorScrollPos = new Vector2(ImGui.GetScrollX(), ImGui.GetScrollY());

        RenderMenuBar();
        DrawGrid();

        DraggingNode = GraphNodes.Any(x => x.IsDragging);

        ImGuiTheme.CommentTheme();
        foreach (var comment in GraphComments.ToList())
            comment.Render();

        if (_commentPreviewStart != null)
        {           
            GraphComment.RenderRectPreview(_commentPreviewStart.Value);
            _commentPreviewEnd = ImGui.GetIO().MousePos;
            ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeNWSE);
        }
        
        int index = 0;
        foreach (var node in GraphNodes.ToList())
        {
            RenderNode(node, index);
            index++;
        }

        ShortcutLisener();

        if (QuickNodeSelector.ShowSelector)
            QuickNodeSelector.Render();

        ImGui.SetCursorScreenPos(new Vector2(ImGui.GetIO().DisplaySize.X - 100, ImGui.GetIO().DisplaySize.Y - 90));
        ImGui.Image(ProgramData.LogoImage, new(50, 50), Vector2.Zero, Vector2.One, new(1, 1, 1, .5f));

        ImGui.Dummy(new(1000000, 1000000));
        ImGuiTheme.ApplyTheme();
        ImGui.EndChild();
    }

    static void ShortcutLisener()
    {
        if (ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.Delete), false) && !DraggingOutput)
        {
            if (_selectedNode != null)
            {
                DeleteNode(_selectedNode);
                _selectedNode = null;
            }
        }

        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.D), false) && !DraggingOutput)
        {
            if (_selectedNode != null)
            {
                DuplicateNode(_selectedNode);
                _selectedNode = null;
            }
        }

        if (ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.F1), false) && IsEditorHovered && !DraggingOutput && !DraggingNode)
            QuickNodeSelector.ToggleSelector();

        if (ImGui.IsMouseDown(ImGuiMouseButton.Middle))
            PanVisual();  
        else IsPanning = false;

        if (ImGui.GetIO().KeyCtrl && ImGui.GetIO().MouseWheel != 0 && IsEditorHovered)
            Zoom = Math.Clamp(Zoom + ImGui.GetIO().MouseWheel * Zoom / (10 * Zoom), 0.6f, 1f);  

        if (ImGui.IsMouseReleased(ImGuiMouseButton.Left) && _commentPreviewStart != null)
        {
            var size = _commentPreviewEnd - _commentPreviewStart;
            
            if (size.Value.X > 100 && size.Value.Y > 100)
                GraphComments.Add(new GraphComment { P1 = (_commentPreviewStart.Value - WindowPos + EditorScrollPos) / Zoom, 
                    P2 = (_commentPreviewEnd - WindowPos + EditorScrollPos) / Zoom });
        }              
        
        if (ImGui.GetIO().KeyCtrl && ImGui.IsMouseDown(ImGuiMouseButton.Left) && IsEditorHovered && !DraggingOutput && !DraggingNode)
            _commentPreviewStart ??= ImGui.GetIO().MousePos;            
        else _commentPreviewStart = null;                           
    }

    static void RenderMenuBar()
    {
        ImGui.BeginMenuBar();

        if (ImGui.BeginMenu($"{FontAwesome6.SquareShareNodes} Nodes"))
        {
            if (ImGui.MenuItem("Disconnect all nodes"))
                DisconnectAllNodes();

            if (ImGui.MenuItem("Delete all nodes"))
                DeleteAllNodes();

            if (ImGui.MenuItem("Delete all nodes except base ones"))
                DeleteAllNodes(false);

            ImGui.EndMenu();
        }

        ImGui.SetNextItemWidth(ImGui.CalcTextSize("Grid size").X);
        ImGui.DragFloat("Grid size", ref _gridSize, 1, 20, 250, "%.0f", ImGuiSliderFlags.AlwaysClamp);
        if (ImGui.IsItemHovered())
            ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeEW);

        ImGui.SetNextItemWidth(ImGui.CalcTextSize("Pan speed").X);
        ImGui.DragFloat("Pan speed", ref _panSpeed, 0.1f, 1f, 20, "%.1f", ImGuiSliderFlags.AlwaysClamp);
        if (ImGui.IsItemHovered())
            ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeEW);

        ImGui.SetCursorPosX(CurrentEditorWinSize.X / 2 + EditorScrollPos.X - ImGui.CalcTextSize($"Zoom: {Zoom:N2}x").X);
        ImGui.TextDisabled($"{FontAwesome6.Eye} Zoom: {Zoom:N2}x");

        ImGui.EndMenuBar();
    }

    static void DrawGrid()
    {
        Vector2 windowSize = ImGui.GetIO().DisplaySize;
        Vector2 canvasSize = windowSize + EditorScrollPos;

        var drawList = ImGui.GetWindowDrawList();

        // Draw vertical grid lines
        for (float x = _gridOffset.X; x < canvasSize.X; x += _gridSize * Zoom)
        {
            drawList.AddLine(new Vector2(x, 0), new Vector2(x, canvasSize.Y), ImGui.GetColorU32(_gridColor), _gridThickness);           
        }

        // Draw horizontal grid lines
        for (float y = _gridOffset.Y; y < canvasSize.Y; y += _gridSize * Zoom)
        {
            drawList.AddLine(new Vector2(0, y), new Vector2(canvasSize.X, y), ImGui.GetColorU32(_gridColor), _gridThickness);
        }
    }

    static Vector2 GetWhatSizeNodeShouldBe(SonsNode node, int propertiesCount)
    {
        if (node.SizeOverride != Vector2.Zero)
            return node.SizeOverride;

        //if (propertiesCount == 0 && node.ArgsOut.Count <= 1 && node.ArgsIn.Count <= 1)
            //return new Vector2(250, 120);

        switch (node.ArgsIn.Count)
        {
            case 0:
                return new Vector2(230, 100);
            case 1:               
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 120) : new Vector2(250, 180);
            case 2:
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 150) : new Vector2(250, 220);
            case 3:
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 180) : new Vector2(250, 270);
            case 4:
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 210) : new Vector2(250, 320);
            case 5:
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 240) : new Vector2(250, 380);
            case 6:
                return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 270) : new Vector2(250, 430);
        }
        return new Vector2(250, 180);
    }

    /// <summary>
    /// Handles EventName string inputs realtime to search if a corresponding custom event with the same name exist. If it does, sets the EventId of it to the CustomEvent one
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodeProperties"></param>
    static void HandleCustomEvents(SonsNode node, IEnumerable<PropertyInfo> nodeProperties)
    {
        var eventNameProp = nodeProperties.FirstOrDefault(p => p.CustomAttributes.Any(at => at.AttributeType == typeof(IsEventName)));

        if (eventNameProp != null)
        {
            var cEventNodes = GraphNodes.Where(node => node.GetType() == typeof(CustomEventNode));

            foreach (var cEventNode in cEventNodes)
            {
                var cEvent = (CustomEventNode)cEventNode;

                if (cEvent.EventName == (string)eventNameProp.GetValue(node))
                    node.GetType().GetProperty("EventId").SetValue(node, cEvent.EventId);
            }
        }
    }

    static void RenderNode(SonsNode node, int index)
    {
        ImGuiTheme.NodeTheme(node);

        var nodeProperties = node.GetType().GetProperties().Where(p => p.DeclaringType == node.GetType()
            && !p.GetCustomAttributes(typeof(IgnoreProperty), false).Any());

        HandleCustomEvents(node, nodeProperties);

        ImGui.SetCursorPos(node.Position * Zoom);
        WindowPos = ImGui.GetWindowPos();

        ImGui.BeginChild($"Node_{index}_{node.Name}", GetWhatSizeNodeShouldBe(node, nodeProperties.Count()) * Zoom, 
            ImGuiChildFlags.Border, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

        ImGui.SetWindowFontScale(Zoom);

        node.IsDragging = ImGui.IsWindowHovered() && ImGui.IsMouseDown(ImGuiMouseButton.Left);
        if (node.IsDragging || node == _selectedNode && ImGui.IsMouseDown(ImGuiMouseButton.Left) && IsEditorHovered)
        {
            if (!DraggingOutput && !IsPanning)
            {
                node.Position += ImGui.GetIO().MouseDelta / Zoom;
                _selectedNode = node;
                _selectedNodeSize = ImGui.GetWindowSize() / Zoom;
            }
        }
        
        if (ImGui.IsMouseClicked(ImGuiMouseButton.Left) && !node.IsDragging)
            _selectedNode = null;

        ImGui.PushFont(Drawings.Font18);
        ImGui.Text(node.Name);
        ImGui.PopFont();
        Drawings.NodeTooltip(node.Description);
        ImGui.Separator();

        ImGui.Columns(2, $"Columns_{index}_{node.Name}", false);
        ImGui.SetColumnWidth(0, (GetWhatSizeNodeShouldBe(node, nodeProperties.Count()).X * Zoom) / 1.2f);

        // Left column
        if (node.NodeType != SonsNode.NodeTypes.Starter)
        {
            node.Input.Render(node);
            ImGui.Dummy(new(0, 20 * Zoom));

            if (nodeProperties.Count() > 0 || node.ArgsIn.Count() > 0)
            {
                ImGui.TextColored(new Vector4(1, 1, 1, 0.7f), "Inputs:");

                node.ArgsIn.ForEach(arg => {

                    if (!arg.Hide)
                    {
                        arg.Render(node);
                        ImGui.Dummy(new(0, 5 * Zoom));
                    }
                });
            }
        }

        ImGui.NextColumn();

        int outputNum = 1;
        // Right column
        node.Outputs.ForEach(output =>
        {
            if (node.Outputs.Count > 1)
            {
                ImGui.TextDisabled(outputNum.ToString());
                outputNum++;
            }

            output.Render(node);
            if (node.Outputs.Count > 1 && node.Outputs.Last() != output)
                ImGui.Dummy(new(0, 25 * Zoom));
        });

        ImGui.Dummy(new(0, 25 * Zoom));

        node.ArgsOut.ForEach(arg => {
            arg.Render(node);
            if (node.ArgsOut.Count > 1) // && node.ArgsOut.Last() != arg
                ImGui.Dummy(new(0, 25 * Zoom));
        });

        // End column
        ImGui.Columns(1);
        
        int idx = 0;
        foreach (var prop in nodeProperties)
        {
            if (node.ArgsIn[idx].HasConnection)
            {
                idx++; continue;
            }
            DrawStaticInput(node, prop);
            idx++;
        }
        
        ImGui.EndChild();
        
        node.Outputs.ForEach(output =>
        {
            if (output.HasConnection)
                Drawings.DrawNodeLine(output.Position, output.NextNode.Input.Position);
        });

        node.ArgsOut.ForEach(arg =>{

            if (arg.HasConnection)
                Drawings.DrawNodeArgumentLine(arg.Position, arg.InputArg.Position, Drawings.GetTypeColor(arg.Type));
        });
        
        if (_selectedNode != null)
        {
            UpdateSelectedNode(out var pos, out var size);

            ImGui.GetWindowDrawList().AddRect(pos + WindowPos - EditorScrollPos,
                new Vector2(pos.X + size.X, pos.Y + size.Y) + WindowPos - EditorScrollPos,
                ImGui.GetColorU32(Drawings.Colors.SelectedNodeColor), 5);
        }
        
        ImGuiTheme.ApplyTheme();
        GetDragInput(node);
    }

    static void UpdateSelectedNode(out Vector2 pos, out Vector2 size)
    {
        pos = _selectedNode.Position * Zoom;
        size = _selectedNodeSize * Zoom;
    }

    /// <summary>
    /// Populates data between the two connected nodes
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    public static void ConnectNodes(OutputNode first, InputNode second)
    {
        first.HasConnection = second.HasConnection = true;

        first.NextNode = second.SonsNode;
        second.PrevNode = first.SonsNode;
    }

    public static void SwapNodes(OutputNode first, InputNode second)
    {
        DisconnectNode(first, first.NextNode.Input);
        ConnectNodes(first, second);
    }

    /// <summary>
    /// Finds the first node in hierarchy of the passed node
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static SonsNode FindBaseNodeOf(SonsNode node)
    {
        if (node.NodeType == SonsNode.NodeTypes.Starter)
            return node;

        var previousNode = node.Input.PrevNode;

        while (previousNode.NodeType != SonsNode.NodeTypes.Starter)
        {
            previousNode = previousNode.Input.PrevNode;

            if (previousNode == null)
                break;
        }
        return previousNode; // the found or not found (null) base node
    }

    public static void ConnectArgs(SonsNode outNode, SonsNode inNode, ArgOut argOut, ArgIn argIn)
    {
        argOut.HasConnection = argIn.HasConnection = true;

        argOut.ConnectedNode = inNode;
        argIn.ConnectedNode = outNode;

        argOut.InputArg = argIn;
        argIn.OutputArg = argOut;

        argOut.PassTo = inNode.Id;
        argIn.ReceiveFrom = outNode.Id;

        argIn.ReceiveFromIndex = outNode.ArgsOut.IndexOf(argOut);
    }

    public static void SwapArgs(SonsNode outNode, SonsNode inNode, ArgOut argOut, ArgIn argIn)
    {
        DisconnectArgs(argOut, argOut.InputArg);
        ConnectArgs(outNode, inNode, argOut, argIn);
    }

    static void GetDragInput(SonsNode node)
    {
        node.Outputs.ForEach(output =>
        {
            if (output.IsDragging)
            {
                Drawings.DrawCursor(Drawings.CursorType.InputOutput);
                Drawings.DrawNodeLine(output.Position, ImGui.GetIO().MousePos);

                GraphNodes.ForEach(graphNode => {

                    if (Utilities.IsMouseHovering(graphNode.Input.Position, 7) && !graphNode.Input.HasConnection && ImGui.IsMouseClicked(ImGuiMouseButton.Left)) //  && ImGui.IsMouseClicked(ImGuiMouseButton.Left)
                    {
                        GraphEditor.DraggingOutput = output.IsDragging = false;
                        if (!output.HasConnection)
                            ConnectNodes(output, graphNode.Input);
                        else
                            SwapNodes(output, graphNode.Input);

                        Logger.Append($"Connected Output {node.Outputs.IndexOf(output)} of [{node.Name}] to Input of [{graphNode.Name}]");
                    }
                });
            }
        });

        node.ArgsOut.ForEach(ArgOut => {

            if (ArgOut.IsDragging)
            {
                Drawings.DrawCursor(Drawings.CursorType.Argument, ArgOut.Type);
                Drawings.DrawNodeArgumentLine(ArgOut.Position, ImGui.GetIO().MousePos, Drawings.GetTypeColor(ArgOut.Type));

                GraphNodes.ForEach(graphNode => {
                    graphNode.ArgsIn.ForEach(ArgIn => {

                        if (Utilities.IsMouseHovering(ArgIn.Position, ArgIn.Radius) && ArgOut.Type != ArgIn.Type && ArgIn.Type != typeof(object))
                            ImGui.SetMouseCursor(ImGuiMouseCursor.NotAllowed);

                        if (Utilities.IsMouseHovering(ArgIn.Position, ArgIn.Radius) && !ArgIn.HasConnection && ImGui.IsMouseClicked(ImGuiMouseButton.Left) && (ArgOut.Type == ArgIn.Type || ArgIn.Type == typeof(object)))
                        {
                            if (!ArgOut.HasConnection)
                                ConnectArgs(node, graphNode, ArgOut, ArgIn);
                            else
                                SwapArgs(node, graphNode, ArgOut, ArgIn);

                            Logger.Append($"Connected OUT ARG of [{node.Name}] to INPUT ARG of [{graphNode.Name}] as type [{ArgOut.Type.Name}]");
                        }
                    });
                });
            }
        });
    }

    public static SonsNode AddToGraph(SonsNode node, Vector2 pos)
    {
        if (ContainsType(GraphNodes, node.GetType()) && node.NodeType == SonsNode.NodeTypes.Starter && node.GetType() != typeof(CustomEventNode))
            return null;
      
        var nodeInstance = CreateNewInstance(node);
        nodeInstance.Position = pos / Zoom;
        GraphNodes.Add(nodeInstance);
        Logger.Append($"Added [{nodeInstance.Name}] node to graph");
        return nodeInstance;
    }

    static void DuplicateNode(SonsNode node)
    {
        if (node.NodeType == SonsNode.NodeTypes.Variable)
            return;

        var copy = CreateNewInstance(node);
        var added = AddToGraph(copy, new(50 + EditorScrollPos.X, 50 + EditorScrollPos.Y));
        if (added != null)
        {
            added.Position = new(node.Position.X + 20, node.Position.Y + 20);
        }
    }

    static bool ContainsType(List<SonsNode> list, Type type)
    {
        return list.Any(x => x.GetType() == type);
    }

    static SonsNode CreateNewInstance(SonsNode originalInstance)
    {
        // Get the type of the original instance
        Type originalType = originalInstance.GetType();

        // Create a new instance of the same type as the original type
        SonsNode newInstance = (SonsNode)Activator.CreateInstance(originalType);

        return newInstance;
    }

    public static void DisconnectAllNodes()
    {     
        foreach (var node in GraphNodes)
        {
            node.Outputs.ForEach(output =>
            {
                output.HasConnection = false;
                output.NextNode = null;
            });

            node.Input.HasConnection = false;
            node.Input.PrevNode = null;
        }
        
        Logger.Append("Disconnected all graph nodes");
    }

    public static void DisconnectNode(OutputNode first, InputNode second)
    {
        first.HasConnection = second.HasConnection = false;
        first.NextNode = second.PrevNode = null;
    }

    public static void DisconnectArgs(ArgOut argOut, ArgIn argIn)
    {
        if (argOut != null)
        {
            argOut.HasConnection = false;
            argOut.ConnectedNode = null;
            argOut.InputArg = null;
            argOut.PassTo = string.Empty;
        }

        if (argIn != null)
        {
            argIn.HasConnection = false;
            argIn.ConnectedNode = null;
            argIn.OutputArg = null;
            argIn.ReceiveFrom = string.Empty;
            argIn.ReceiveFromIndex = 0;
        }    
    }

    public static void DeleteAllNodes(bool includeBase = true)
    {
        GraphNodes.ToList().ForEach(node => {

            if (includeBase)
            {
                DeleteNode(node);
            }
            else if (node.NodeType != SonsNode.NodeTypes.Starter)
                DeleteNode(node);
        });
        Logger.Append("Deleted all graph nodes");
    }

    public static void DeleteNode(SonsNode node)
    {
        if (node.Input.PrevNode != null) {
            node.Input.PrevNode.Outputs.ForEach(output =>
            {
                if (output.NextNode != null)
                {
                    output.NextNode.Input.HasConnection = false;
                    output.NextNode.Input.PrevNode = null;
                }

                output.HasConnection = false;
                output.NextNode = null;
            });
        }

        node.Outputs.ForEach(output => {
            if (output.HasConnection)
            {
                output.NextNode.Input.HasConnection = false;
                output.NextNode.Input.PrevNode = null;
            }
        });

        node.ArgsIn.ForEach(argIn => {
            DisconnectArgs(argIn.OutputArg, argIn);
        });

        node.ArgsOut.ForEach(argOut => {
            DisconnectArgs(argOut, argOut.InputArg);
        });

        GraphNodes.Remove(node);
        Logger.Append($"Deleted [{node.Name}] node from graph");
    }

    static void DrawStaticInput(SonsNode node, PropertyInfo property)
    {
        ImGui.BeginChild($"Inputs_{node.Name}", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border, ImGuiWindowFlags.NoScrollbar 
            | ImGuiWindowFlags.NoScrollWithMouse);

        ImGui.SetWindowFontScale(Zoom);

        if (property.PropertyType == typeof(int))
        {
            int value = (int)property.GetValue(node);
            ImGui.DragInt(property.Name, ref value);
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(float))
        {
            float value = (float)property.GetValue(node);
            ImGui.DragFloat(property.Name, ref value, 0.1f, Mathf.Infinity, Mathf.Infinity, "%.1f");
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(bool))
        {
            bool value = (bool)property.GetValue(node);
            ImGui.Checkbox(property.Name, ref value);
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(string))
        {
            ImGuiInputTextFlags flags = (property.CustomAttributes.Any(at => at.AttributeType == typeof(IsEventName)) 
                || CharsNoBlankTypes.CharsNoBlank.Any(x => x == node.GetType())) 
                ? ImGuiInputTextFlags.CharsNoBlank : ImGuiInputTextFlags.None;

            string value = (string)property.GetValue(node);
            if (string.IsNullOrEmpty(value))
                value = "";

            ImGui.InputTextWithHint($"##{property.Name}", property.Name, ref value, 10000, flags);
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(Vector2))
        {
            Vector2 value = (Vector2)property.GetValue(node);
            ImGui.DragFloat2(property.Name, ref value, 1, Mathf.Infinity, Mathf.Infinity, "%.1f");
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(Vector3))
        {
            Vector3 value = (Vector3)property.GetValue(node);
            ImGui.DragFloat3(property.Name, ref value, 1, Mathf.Infinity, Mathf.Infinity, "%.1f");
            property.SetValue(node, value);
        }
        else if (property.PropertyType == typeof(List<Enum>))
        {
            List<Enum> value = (List<Enum>)property.GetValue(node);
            var enumProp = node.GetType().GetProperty("EnumValue");
            if (ImGui.BeginCombo(enumProp.PropertyType.Name, enumProp.GetValue(node).ToString(), ImGuiComboFlags.HeightLarge))
            {
                foreach (var option in value)
                {
                    if (ImGui.Selectable(option.ToString()))
                        enumProp.SetValue(node, option);
                }
                ImGui.EndCombo();
            }
        }

        ImGui.EndChild();
    }

    static void PanVisual()
    {
        IsPanning = true;
        ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeAll);
        EditorScrollPos -= ImGui.GetIO().MouseDelta / 10 * _panSpeed;
    }
}
