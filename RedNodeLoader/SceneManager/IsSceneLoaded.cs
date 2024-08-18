using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class IsSceneLoaded : SonsNode
{
    [XmlIgnore]
    public Scene Scene { get; set; }

    [IsArgOut]
    public bool IsLoaded { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var scene = (Scene)args[0];
        IsLoaded = scene.isLoaded;
    }
}
