using Sons.Characters;

namespace RedNodeLoader.ActorsNodes;

public class SpawnActorNode : SonsNode
{
    public string name { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        CharacterManager.Instance.DebugAddCharacter((string)args[0], true);
    }
}
