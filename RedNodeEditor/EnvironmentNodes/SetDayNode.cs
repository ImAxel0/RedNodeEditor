namespace RedNodeEditor.EnvironmentNodes;

public class SetDayNode : SonsNode
{
    public int Day { get; set; }

    public SetDayNode()
    {
        Name = "SetDay";
        Description = "Sets the day in game";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Day) });
    }
}
