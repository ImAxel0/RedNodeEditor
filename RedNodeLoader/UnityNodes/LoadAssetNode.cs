using Il2CppInterop.Runtime;
using SonsSdk;
using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class LoadAssetNode : SonsNode
{
    [XmlIgnore]
    public AssetBundle Bundle { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public GameObject BundleObject { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var bundle = (AssetBundle)args[0];
        BundleObject = bundle.LoadAsset(bundle.GetAllAssetNames().ElementAtOrDefault(0), Il2CppType.Of<GameObject>()).Cast<GameObject>();
        LoadShaders(BundleObject);
        RedNodeLoader.AssetBundleGameObjects.Add(BundleObject);
    }

    private static void LoadShaders(GameObject gameObject)
    {
        MeshRenderer goMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (goMeshRenderer != null)
        {
            foreach (var material in goMeshRenderer.materials)
            {
                if (material.shader.isSupported)
                    material.shader = Shader.Find("Sons/HDRPLit");
            }
        }

        foreach (var child in gameObject.GetChildren())
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer == null)
                continue;

            foreach (var material in meshRenderer.materials)
            {
                if (material.shader.isSupported)
                    material.shader = Shader.Find("Sons/HDRPLit");
            }
        }
    }
}
