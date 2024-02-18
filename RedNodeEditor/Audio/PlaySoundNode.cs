namespace RedNodeEditor.Audio;

public class PlaySoundNode : SonsNode
{
    public string SoundId { get; set; }
    public float Volume { get; set; } = 1f;
    public float Pitch { get; set; } = 1f;

    public PlaySoundNode()
    {
        Name = "PlaySound";
        Description = "Plays a registered sound by id, with optional volume and pitch control";
        NodeCategory = NodeCategories.Audio;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SoundId) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Volume) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Pitch) });
    }
}
