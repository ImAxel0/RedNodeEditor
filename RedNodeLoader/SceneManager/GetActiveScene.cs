using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetActiveScene : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Scene Scene { get; set; }

    public override void Execute()
    {
        Scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
