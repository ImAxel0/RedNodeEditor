﻿using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetTagNode : SonsNode
{
    public GetTagNode()
    {
        Name = "GetTag";
        Description = "Gets the tag of the passed GameObject";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
