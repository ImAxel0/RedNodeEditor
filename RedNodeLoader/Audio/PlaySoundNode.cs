using SonsSdk;

namespace RedNodeLoader.OthersNode;

public class PlaySoundNode : SonsNode
{
    public string SoundId { get; set; }
    public float Volume { get; set; }
    public float Pitch { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        SoundTools.PlaySound((string)args[0], (float)args[1], (float)args[2]);
    }
}
