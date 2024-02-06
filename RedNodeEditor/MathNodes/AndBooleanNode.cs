﻿namespace RedNodeEditor.MathNodes;

public class AndBooleanNode : SonsNode
{
    public AndBooleanNode()
    {
        Name = "AND Boolean (&&)";
        Description = "Returns true if both of the inputs are true";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}