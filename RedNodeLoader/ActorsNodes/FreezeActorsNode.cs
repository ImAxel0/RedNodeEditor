using Sons.Ai.Vail;

namespace RedNodeLoader.ActorsNodes;

public class FreezeActorsNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        VailWorldSimulation.SetPaused((bool)args[0]);
    }
}
