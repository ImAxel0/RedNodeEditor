using RedLoader;
using System.Xml.Serialization;

namespace RedNodeLoader;

public class SonsNode
{
    public string Id;

    [XmlArray("ArgsIn"), XmlArrayItem(typeof(ArgIn))]
    public List<ArgIn> ArgsIn = new();

    [XmlArray("ArgsOut"), XmlArrayItem(typeof(ArgOut))]
    public List<ArgOut> ArgsOut = new();

    public virtual void Execute()
    {
        RLog.Msg("Base Node");
    }

    public virtual bool Execute(string args)
    {
        RLog.Msg("Base Node");
        return true;
    }
}
