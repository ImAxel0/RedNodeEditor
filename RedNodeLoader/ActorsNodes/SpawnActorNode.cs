using Sons.Ai.Vail;
using Sons.Areas;
using Sons.Atmosphere;
using SonsSdk;

namespace RedNodeLoader.ActorsNodes;

public class SpawnActorNode : SonsNode
{
    public VailActorTypeId EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ActorTools.Spawn((VailActorTypeId)args[0], SonsTools.GetPositionInFrontOfPlayer(4, 2));
    }
}
