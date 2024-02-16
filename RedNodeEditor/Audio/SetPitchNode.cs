using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RedNodeEditor.Audio;

public class SetPitchNode : SonsNode
{
    [XmlIgnore]
    public FMODCustom.Channel Channel { get; set; }
    public float Pitch { get; set; } = 1f;

    public SetPitchNode()
    {
        Name = "SetPitch";
        Description = "Sets the pitch of the passed channel";
        NodeCategory = NodeCategories.Audio;

        ArgsIn.Add(new ArgIn { Type = typeof(FMODCustom.Channel), ArgName = nameof(Channel) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Pitch) });
    }
}
