using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static RedNodeEditor.GlobalEnums;
using static RedNodeEditor.UINodes.CreateSidePanelNode;
using RedLoader;

namespace RedNodeEditor.Audio;

public class PlaySoundTypeNode : SonsNode
{
    public string SoundId { get; set; }

    [IgnoreProperty]
    public SoundType EnumValue { get; set; } = SoundType.Music;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> SoundTypeList { get; set; } = new() { SoundType.Music, SoundType.Sfx };

    public bool Loop { get; set; }
    public float Volume { get; set; } = 1f;
    public float Pitch { get; set; } = 1f;

    public PlaySoundTypeNode()
    {
        Name = "PlaySoundType";
        Description = "Plays a registered sound by id, sound type for volume adjustment and optional loop mode and volume and pitch control. Outputs the audio channel";
        NodeCategory = NodeCategories.Audio;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SoundId) });
        ArgsIn.Add(new ArgIn { Type = typeof(SoundType), ArgName = nameof(SoundType) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Loop) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Volume) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Pitch) });
        ArgsOut.Add(new ArgOut { Type = typeof(FMODCustom.Channel) });
    }
}
