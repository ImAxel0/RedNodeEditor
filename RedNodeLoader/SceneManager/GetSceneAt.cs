using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetSceneAt : SonsNode
{
    public int Index { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public Scene Scene { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt((int)args[0]);
    }
}
