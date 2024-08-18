using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetSceneIndex : SonsNode
{
    [XmlIgnore]
    public Scene Scene { get; set; }

    [IsArgOut]
    public int SceneIndex { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var scene = (Scene)args[0];
        SceneIndex = scene.buildIndex;
    }
}
