namespace RedNodeEditor.InventoryNodes;

public class AmountOfNode : SonsNode
{
    public int ItemId { get; set; }

    public AmountOfNode()
    {
        Name = "AmountOf";
        Description = "Gets the owned amount of the passed item id";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
