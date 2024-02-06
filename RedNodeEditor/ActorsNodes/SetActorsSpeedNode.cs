namespace RedNodeEditor.ActorsNodes;

public class SetActorsSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public SetActorsSpeedNode()
    {
        Name = "SetActorsSpeed";
        Description = "Sets the actors animation speed";
        NodeCategory = NodeCategories.Actors;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Speed) });
    }
}
