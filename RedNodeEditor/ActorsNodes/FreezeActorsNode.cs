namespace RedNodeEditor.ActorsNodes;

public class FreezeActorsNode : SonsNode
{
    public bool Value { get; set; }

    public FreezeActorsNode()
    {
        Name = "FreezeActors";
        Description = "Freeze all actors (SP or HOST only)";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
