using System.Reflection;
using UnityEngine;

namespace RedNodeLoader;

public class Utilities
{
    public static bool TryGetEmbeddedResourceBytes(string name, out byte[] bytes)
    {
        bytes = null;

        var executingAssembly = Assembly.GetExecutingAssembly();

        var desiredManifestResources = executingAssembly.GetManifestResourceNames().FirstOrDefault(resourceName => {
            var assemblyName = executingAssembly.GetName().Name;
            return !string.IsNullOrEmpty(assemblyName) && resourceName.StartsWith(assemblyName) && resourceName.Contains(name);
        });

        if (string.IsNullOrEmpty(desiredManifestResources))
            return false;

        using (var ms = new MemoryStream())
        {
            executingAssembly.GetManifestResourceStream(desiredManifestResources).CopyTo(ms);
            bytes =  ms.ToArray();
            return true;
        }
    }

    public static Texture2D ByteToTex(byte[] imgBytes)
    {
        Texture2D tex = new(2, 2);
        tex.LoadImage(imgBytes);
        return tex;
    }

    public static Sprite ToSprite(Texture2D texture)
    {
        var rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
        var pivot = new Vector2(0.5f, 0.5f);
        var border = Vector4.zero;
        var sprite = Sprite.CreateSprite_Injected(texture, ref rect, ref pivot, 100, 0, SpriteMeshType.Tight, ref border, false, null);
        sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        return sprite;
    }
}
