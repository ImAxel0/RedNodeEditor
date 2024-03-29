﻿using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class GetMainRotatorNode : SonsNode
{
    public GetMainRotatorNode()
    {
        Name = "GetMainRotator";
        Description = "Returns player MainRotator component, responsible for horizontal rotation";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Component) });
    }
}
