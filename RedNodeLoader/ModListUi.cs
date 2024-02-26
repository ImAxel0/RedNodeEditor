using SUI;
using static SUI.SUI;
using static RedNodeLoader.AXSUI;
using SonsGameManager;
using UnityEngine;
using SonsSdk;

namespace RedNodeLoader;

public class ModListUi
{
    private static readonly string ModListId = "NodeModList";

    public static void Create()
    {
        Utilities.TryGetEmbeddedResourceBytes("RedNodeEditor", out var logoBytes);
        var logoSprite = Utilities.ToSprite(Utilities.ByteToTex(logoBytes));

        var toniContainer = GetPanel(ModManagerUi.MOD_LIST_ID)
            - AxButton("", ShowModList, new(100, 100), AnchorType.TopLeft).Color(Color.white.WithAlpha(0.95f)).Background(logoSprite).Position(20, -120);

        var modsPanel = AxCreateSidePanel(ModListId, false, "<color=#454545>INSTALLED MODS</color>", Side.Left, 600, new Color(0f, 0.01f, 0.02f, 0.99f))
            .OverrideSorting(999)
            .Active(false);

        RedNodeLoader.ModsData.ForEach(modData => AxGetMainContainer((SPanelOptions)modsPanel).Add(ModContainer(modData)));

        toniContainer.Add(modsPanel);
    }

    static SContainerOptions ModContainer(ModData modData)
    {
        return SContainer.PHeight(50).Horizontal(0, "EX").Background(new Color(0.05f, 0.04f, 0.04f))
            - SLabel.Text($"<color=#BBBBBB>{modData.ModName}</color>").FontSize(22)
            - SLabel.Text($"<color=#777777>{modData.ModVersion}</color>").FontSize(22)
            - SLabel.Text($"<color=#777777>{modData.ModAuthor}</color>").FontSize(18)
            - SLabel.Text($"<color=#777777>App version: {modData.AppVersion}</color>").FontSize(12);
    }

    static void ShowModList()
    {
        GetPanel(ModListId).Active(true);
    }
}
