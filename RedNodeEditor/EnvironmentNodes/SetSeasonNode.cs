using System.Xml.Serialization;
using Newtonsoft.Json;
using Sons.Atmosphere;

namespace RedNodeEditor.EnvironmentNodes;

public class SetSeasonNode : SonsNode
{
    [IgnoreProperty]
    public SeasonsManager.Season EnumValue { get; set; } = SeasonsManager.Season.Spring;

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> SeasonEnums { get; set; } = new();

    public SetSeasonNode() 
    {
        Name = "SetSeason";
        Description = "Changes the game current season";
        NodeCategory = NodeCategories.Environment;

        foreach (var season in Enum.GetValues(typeof(SeasonsManager.Season)))
            SeasonEnums.Add((SeasonsManager.Season)season);

        ArgsIn.Add(new ArgIn { Type = typeof(SeasonsManager.Season), ArgName = nameof(SeasonsManager.Season) });
    }
}
