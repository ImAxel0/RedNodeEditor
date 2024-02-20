using RedLoader;
using SonsSdk;
using System.Xml.Serialization;

namespace RedNodeLoader.EventsNodes;

public class UnsubscribeEventFromNode : SonsNode
{
    public string EventId { get; set; }
    public string EventName { get; set; }
    public BaseNode EnumValue { get; set; }

    [XmlType("UnsubscribeEventFromNode_BaseNode")]
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
                GlobalEvents.OnPreModsLoaded.Unsubscribe(cEvent.Execute);
                break;
            case BaseNode.OnSdkInitialized:
                SdkEvents.OnSdkInitialized.Unsubscribe(cEvent.Execute);
                break;
            case BaseNode.OnGameStart:
                SdkEvents.OnGameStart.Unsubscribe(cEvent.Execute);
                break;
            case BaseNode.OnWorldUpdate:
                SdkEvents.OnInWorldUpdate.Unsubscribe(cEvent.Execute);
                break;
            case BaseNode.OnUpdate:
                GlobalEvents.OnUpdate.Unsubscribe(cEvent.Execute);
                break;
        }
    }
}
