using System.Xml.Serialization;
using RedLoader.Utils;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class LoadAssetBundleNode : SonsNode
{
    public string BundlePath { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public AssetBundle Bundle { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Bundle = AssetBundle.LoadFromFile(Path.Combine(LoaderEnvironment.ModsDirectory, "RedNodeLoader\\Mods", (string)args[0]));
    }
}
