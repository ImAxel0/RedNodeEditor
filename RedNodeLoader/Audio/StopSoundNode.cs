namespace RedNodeLoader.Audio;

public class StopSoundNode : SonsNode
{
    public string SoundId { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        AudioController.StopSound((string)args[0]);
    }
}
