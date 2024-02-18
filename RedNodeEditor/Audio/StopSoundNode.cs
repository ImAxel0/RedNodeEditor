namespace RedNodeEditor.Audio;

public class StopSoundNode : SonsNode
{
    public string SoundId { get; set; }

    public StopSoundNode()
    {
        Name = "StopSound";
        Description = "Stops a playing looping sound by id";
        NodeCategory = NodeCategories.Audio;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SoundId) });
    }
}
