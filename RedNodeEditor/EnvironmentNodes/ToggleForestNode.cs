namespace RedNodeEditor.EnvironmentNodes;

public class ToggleForestNode : SonsNode
{
    public ToggleForestNode()
    {
        Name = "ToggleForest";
        Description = "Removes or restore all trees in world";
        NodeCategory = NodeCategories.Environment;
    }
}
