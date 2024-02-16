using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedNodeEditor.Audio;

public class RegisterSoundNode : SonsNode
{
    public string SoundId { get; set; }
    public string SoundPath { get; set; }

    public RegisterSoundNode()
    {
        Name = "RegisterSound";
        Description = "Must be called OnSdkInitialized.\nRegister a sound file by id and path to later play it\n- Path starts from RedNodeLoader/Mods folder, so it's recommended to ship the .rmod " +
            "file with an associated folder of the same name including the sound file.\n" +
            "Example path: ModExample/mysound.mp3";
        NodeCategory = NodeCategories.Audio;

        if (ProjectData.ProjectName != "unsaved")
            SoundPath = $"{ProjectData.ProjectName.Replace(".rproj", string.Empty)}/";

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SoundId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SoundPath) });
    }
}
