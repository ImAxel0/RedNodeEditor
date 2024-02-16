using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetGameObjectOfComponentNode : SonsNode
{
    public GetGameObjectOfComponentNode()
    {
        Name = "GetGameObjectOfComponent";
        Description = "Gets the GameObject of the passed Component";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
