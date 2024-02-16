using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class LoadAssetBundleNode : SonsNode
{
    public string BundlePath { get; set; }

    public LoadAssetBundleNode()
    {
        Name = "LoadAssetBundle";
        Description = "Must be called OnSdkInitialized\nLoads an assetbundle file from the given path.\n" +
            "- Path starts from RedNodeLoader/Mods folder, so it's recommended to ship the .rmod file with " +
            "an associated folder of the same name including the assetbundle file";
        NodeCategory = NodeCategories.Unity;

        if (ProjectData.ProjectName != "unsaved")
            BundlePath = $"{ProjectData.ProjectName.Replace(".rproj", string.Empty)}/";

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(BundlePath) });
        ArgsOut.Add(new ArgOut { Type = typeof(AssetBundle) });
    }
}
