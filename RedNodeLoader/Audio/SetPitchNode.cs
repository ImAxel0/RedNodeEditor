using System.Xml.Serialization;

namespace RedNodeLoader.Audio;

public class SetPitchNode : SonsNode
{
    [XmlIgnore]
    public FMODCustom.Channel Channel { get; set; }
    public float Pitch { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var ch = (FMODCustom.Channel)args[0];
        ch.setPitch((float)args[1]);
    }
}
