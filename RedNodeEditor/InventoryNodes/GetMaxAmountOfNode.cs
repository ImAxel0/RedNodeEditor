namespace RedNodeEditor.InventoryNodes;

public class GetMaxAmountOfNode : SonsNode
{
    public int ItemId { get; set; }

    public GetMaxAmountOfNode()
    {
        Name = "GetMaxAmountOf";
        Description = "Gets the max ownable amount of the passed item id";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
