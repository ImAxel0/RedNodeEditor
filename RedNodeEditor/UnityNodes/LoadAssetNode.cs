using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class LoadAssetNode : SonsNode
{
    public LoadAssetNode()
    {
        Name = "LoadAsset";
        Description = "Must be called OnGameStart\nLoads the asset of an assetbundle outputting a gameobject which can later be spawned (instantiated)";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(AssetBundle), ArgName = nameof(AssetBundle) });
        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
