using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class LoadSceneAsync : SonsNode
{
    public string SceneName { get; set; }

    [XmlIgnore]
    public LoadSceneMode EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((string)args[0], (LoadSceneMode)args[1]);
    }
}
