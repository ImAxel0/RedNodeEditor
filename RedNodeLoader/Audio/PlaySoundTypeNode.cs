using System.Xml.Serialization;
using static RedNodeLoader.GlobalEnums;

namespace RedNodeLoader.Audio;

public class PlaySoundTypeNode : SonsNode
{
    public string SoundId { get; set; }

    public SoundType EnumValue { get; set; }

    public bool Loop { get; set; }
    public float Volume { get; set; }
    public float Pitch { get; set; }

    [IsArgOut]
    [XmlIgnore]
    public FMODCustom.Channel Channel { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Channel = AudioController.PlaySound((string)args[0], (SoundType)args[1], (bool)args[2], (float)args[3], (float)args[4]);
    }
}
