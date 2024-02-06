namespace RedNodeEditor.ActorsNodes;

public class GetActiveCountNode : SonsNode
{
    public GetActiveCountNode()
    {
        Name = "GetActiveCount";
        Description = "Gets the number of active actors in world";
        NodeCategory = NodeCategories.Actors;

        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
