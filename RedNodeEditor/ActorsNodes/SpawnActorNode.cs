namespace RedNodeEditor.ActorsNodes;

public class SpawnActorNode : SonsNode
{
    public string name { get; set; }

    public SpawnActorNode()
    {
        Name = "SpawnActor";
        Description = "Spawn the actor by name (SP or HOST only)";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(name)});
    }
}
