using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
