using RedLoader;
using SonsSdk;
using System.Xml.Serialization;

namespace RedNodeLoader.EventsNodes;

public class SubscribeEventToNode : SonsNode
{
    public string EventId { get; set; }
    public string EventName { get; set; }
    public BaseNode EnumValue { get; set; }

    [XmlType("SubscribeEventToNode_BaseNode")]
    public enum BaseNode
    {
        OnInitializeMod, OnSdkInitialized, OnGameStart, OnWorldUpdate, OnUpdate
    }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);

        var cEvent = RedNodeLoader.GetCustomEvent((string)args[0]);

        switch ((BaseNode)args[2])
        {
            case BaseNode.OnInitializeMod:
                GlobalEvents.OnPreModsLoaded.Subscribe(cEvent.Execute);
                break;
            case BaseNode.OnSdkInitialized:
                SdkEvents.OnSdkInitialized.Subscribe(cEvent.Execute);
                break;
            case BaseNode.OnGameStart:
                SdkEvents.OnGameStart.Subscribe(cEvent.Execute);
                break;
            case BaseNode.OnWorldUpdate:
                SdkEvents.OnInWorldUpdate.Subscribe(cEvent.Execute);
                break;
            case BaseNode.OnUpdate:
                GlobalEvents.OnUpdate.Subscribe(cEvent.Execute);
                break;
        }
    }
}
