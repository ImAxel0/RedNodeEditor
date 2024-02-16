using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class GetCamRotatorNode : SonsNode
{
    public GetCamRotatorNode()
    {
        Name = "GetCamRotator";
        Description = "Returns player CamRotator component, responsible for vertical rotation";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Component) });
    }
}
