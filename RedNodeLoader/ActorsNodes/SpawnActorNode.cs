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
        SpawnCharacter((VailActorTypeId)args[0]);
    }

    private void SpawnCharacter(VailActorTypeId typeId)
    {
        int family = VailWorldSimulation.NewFamily();

        var prefab = ActorTools.GetPrefab(typeId);
        var spawnedActor = VailWorldSimulation.Instance().SpawnActor(prefab, SonsTools.GetPositionInFrontOfPlayer(5, 3), Pathfinding.GraphMask.everything, null, State.None, family);
        VailWorldSimulation.Instance().ConvertToRealActor(spawnedActor, false, prefab);
        AreaMask currentAreaMask = CaveEntranceManager.CurrentAreaMask;
        spawnedActor.SetAreaMask(currentAreaMask);
        spawnedActor.SetGraphMask(VailWorldSimulation.Instance().GetNavGraphMaskForArea(currentAreaMask));
        spawnedActor.IsDebugSpawned = true;
    }
}
