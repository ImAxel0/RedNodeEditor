using RedNodeEditor;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace RedNodeEditor.UnityNodes.SceneManager;

public class LoadSceneAsync : SonsNode
{
    public string SceneName { get; set; }

    [IgnoreProperty]
    public LoadSceneMode EnumValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public List<Enum> SceneModeEnums { get; set; } = new();

    public LoadSceneAsync()
    {
        Name = nameof(LoadSceneAsync);
        Description = "Loads the Scene asynchronously in the background.";
        NodeCategory = NodeCategories.Unity;

        foreach (var key in Enum.GetValues(typeof(LoadSceneMode)))
            SceneModeEnums.Add((LoadSceneMode)key);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsIn.Add(new ArgIn { Type = typeof(LoadSceneMode), ArgName = nameof(LoadSceneMode) });
    }
}
