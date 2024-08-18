using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetSceneByName : SonsNode
{
    public string Scenename { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public Scene Scene { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName((string)args[0]);
    }
}
