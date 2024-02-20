using SonsSdk;
using RedLoader.Utils;

namespace RedNodeLoader.Audio;

public class RegisterSoundNode : SonsNode
{
    public string SoundId { get; set; }
    public string SoundPath { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        SoundTools.RegisterSound((string)args[0], Path.Combine(LoaderEnvironment.ModsDirectory, "RedNodeLoader\\Mods", (string)args[1]));
    }
}
