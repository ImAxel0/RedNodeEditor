namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetSceneByName : SonsNode
{
    public string SceneName { get; set; }

    public GetSceneByName()
    {
        Name = nameof(GetSceneByName);
        Description = "Searches through the Scenes loaded for a Scene with the given name.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
