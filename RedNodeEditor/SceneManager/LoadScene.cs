using RedNodeEditor;
using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace RedNodeEditor.UnityNodes.SceneManager;

public class LoadScene : SonsNode
{
    public string SceneName { get; set; }

    [IgnoreProperty]
    public LoadSceneMode EnumValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public List<Enum> SceneModeEnums { get; set; } = new();

    public LoadScene()
    {
        Name = nameof(LoadScene);
        Description = "Loads the Scene by its name";
        NodeCategory = NodeCategories.Unity;

        foreach (var key in Enum.GetValues(typeof(LoadSceneMode)))
            SceneModeEnums.Add((LoadSceneMode)key);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsIn.Add(new ArgIn { Type = typeof(LoadSceneMode), ArgName = nameof(LoadSceneMode) });
    }
}
