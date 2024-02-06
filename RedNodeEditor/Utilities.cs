using ImGuiNET;
using System.Numerics;
using System.Reflection;

namespace RedNodeEditor;

public class Utilities
{
    public static bool IsMouseHovering(Vector2 center, float radius)
    {
        Vector2 mousePos = ImGui.GetMousePos();
        float distanceSquared= Vector2.DistanceSquared(mousePos, center);
        
        // Check if the distance squared is less than the radius squared
        return distanceSquared <= (radius * radius);
    }

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
}
