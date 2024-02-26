using UnityEngine;
using SUI;
using TMPro;
using static SUI.SUI;
using AnchorType = SUI.AnchorType;
using Color = UnityEngine.Color;
using SonsSdk;
using RedLoader;
using System.Collections;

namespace RedNodeLoader;

public class AXSUI
{
    private static Vector2 AutoPos(Vector2 size, AnchorType anchorType)
    {
        return anchorType switch
        {
            AnchorType.TopRight => new Vector2(-size.x, -size.y),
            AnchorType.MiddleRight => new Vector2(-size.x, -size.y / 2),
            AnchorType.BottomRight => new Vector2(-size.x, 0),
            AnchorType.BottomCenter => new Vector2(-size.x / 2, 0),
            AnchorType.BottomLeft => new Vector2(0, 0),
            AnchorType.MiddleLeft => new Vector2(0, -size.y / 2),
            AnchorType.TopLeft => new Vector2(0, -size.y),
            AnchorType.TopCenter => new Vector2(-size.x / 2, -size.y),
            AnchorType.MiddleCenter => new Vector2(-size.x / 2, -size.y / 2),
            _ => Vector2.zero,
        };
    }

    /// <summary>
    /// Creates a new panel with auto position adjustment when the anchor is set on screen borders
    /// </summary>
    /// <param name="id"></param>
    /// <param name="canMoveAndResize"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreatePanel(string id, bool canMoveAndResize, Vector2 size, AnchorType anchorType, Color? color = null, EBackground style = EBackground.None, bool enableInput = false)
    {
        color ??= Color.black;

        Vector2 pos = AutoPos(size, anchorType);

        if (pos == Vector2.zero)
        {
            var panel = RegisterNewPanel(id, enableInput)
                .Pivot(0, 0)
                .Background((Color)color, style)
                .Anchor(anchorType)
                .Size(size.x, size.y);

            if (canMoveAndResize)
            {
                var moveButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.TopLeft).Background(style).Color(Color.cyan.WithAlpha(color.Value.a));
                panel.Add(moveButton);
                MovePanel(moveButton, id).RunCoro();

                var resizeButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.BottomRight).Background(style).Color(Color.yellow.WithAlpha(color.Value.a));
                panel.Add(resizeButton);
                ResizePanel(resizeButton, id).RunCoro();
            }
            return (SPanelOptions)panel;
        }

        var panel1 = RegisterNewPanel(id, enableInput)
            .Pivot(0, 0)
            .Background((Color)color, style)
            .Anchor(anchorType)
            .Size(size.x, size.y)
            .Position(pos.x, pos.y);

        if (canMoveAndResize)
        {
            var moveButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.TopLeft).Background(style).Color(Color.cyan.WithAlpha(color.Value.a));
            panel1.Add(moveButton);
            MovePanel(moveButton, id).RunCoro();

            var resizeButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.BottomRight).Background(style).Color(Color.yellow.WithAlpha(color.Value.a));
            panel1.Add(resizeButton);
            ResizePanel(resizeButton, id).RunCoro();
        }
        return (SPanelOptions)panel1;
    }

    /// <summary>
    /// Creates a new panel which fills the entire screen
    /// </summary>
    /// <param name="id"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreateFillPanel(string id, Color? color = null, bool enableInput = false)
    {
        color ??= Color.black;

        return (SPanelOptions)RegisterNewPanel(id, enableInput)
            .Background((Color)color, EBackground.None)
            .Dock(EDockType.Fill);
    }

    /// <summary>
    /// Creates a text in a panel or container
    /// </summary>
    /// <param name="text"></param>
    /// <param name="fontSize"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static SLabelOptions AxText(string text, int fontSize = 18, TextAlignmentOptions alignment = TextAlignmentOptions.Center)
    {
        return SLabel
            .Text(text)
            .FontSize(fontSize).Dock(EDockType.Fill).Alignment(alignment);
    }

    /// <summary>
    /// Creates a text with autosize to fit the panel, container
    /// </summary>
    /// <param name="text"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static SLabelOptions AxTextAutoSize(string text, TextAlignmentOptions alignment = TextAlignmentOptions.Center)
    {
        return SLabel
            .Text(text)
            .FontAutoSize(true).Dock(EDockType.Fill).Alignment(alignment);
    }

    /// <summary>
    /// Creates a text which can be changed dynamically during runtime
    /// </summary>
    /// <param name="text"></param>
    /// <param name="fontSize"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static SLabelOptions AxTextDynamic(Observable<string> text, int fontSize = 18, TextAlignmentOptions alignment = TextAlignmentOptions.Center)
    {
        return SLabel
            .Bind(text)
            .FontSize(fontSize).Dock(EDockType.Fill).Alignment(alignment);
    }

    /// <summary>
    /// Creates a text which can be changed dynamically during runtime with autosize to fit the panel, container
    /// </summary>
    /// <param name="text"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static SLabelOptions AxTextDynamicAutoSize(Observable<string> text, TextAlignmentOptions alignment = TextAlignmentOptions.Center)
    {
        return SLabel
            .Bind(text)
            .FontAutoSize(true).Dock(EDockType.Fill).Alignment(alignment);
    }

    /// <summary>
    /// Creates an interactable button in a panel or container with specified size
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <returns></returns>
    public static SBgButtonOptions AxButton(string label, Action onClick, Vector2 size, AnchorType anchorType = AnchorType.MiddleCenter)
    {
        Vector2 pos = AutoPos(size, anchorType);

        if (pos == Vector2.zero)
        {
            return SBgButton
            .Pivot(0, 0)
            .Text(label)
            .Anchor(anchorType)
            .Size(size)
            .Notify(onClick);
        }

        return SBgButton
        .Pivot(0, 0)
        .Text(label)
        .Anchor(anchorType)      
        .Size(size)
        .Position(pos.x, pos.y)
        .Notify(onClick);
    }

    /// <summary>
    /// Creates an interactable button in a panel or container with specified size
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <returns></returns>
    public static SBgButtonOptions AxButton(string label, Action<SBgButtonOptions> onClick, Vector2 size, AnchorType anchorType = AnchorType.MiddleCenter)
    {
        Vector2 pos = AutoPos(size, anchorType);

        if (pos == Vector2.zero)
        {
            return SBgButton
            .Pivot(0, 0)
            .Text(label)
            .Anchor(anchorType)
            .Size(size)
            .Notify(onClick);
        }

        return SBgButton
        .Pivot(0, 0)
        .Text(label)
        .Anchor(anchorType)
        .Size(size)
        .Position(pos.x, pos.y)
        .Notify(onClick);
    }

    /// <summary>
    /// Creates an interactable button with specified dock type
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="eDockType"></param>
    /// <returns></returns>
    public static SBgButtonOptions AxButton(string label, Action onClick, EDockType eDockType = EDockType.Fill)
    {
        return SBgButton
        .Pivot(0, 0)
        .Text(label)
        .Dock(eDockType)
        .Notify(onClick);
    }

    /// <summary>
    /// Creates an interactable button with specified dock type
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="eDockType"></param>
    /// <returns></returns>
    public static SBgButtonOptions AxButton(string label, Action<SBgButtonOptions> onClick, EDockType eDockType = EDockType.Fill)
    {
        return SBgButton
        .Pivot(0, 0)
        .Text(label)
        .Dock(eDockType)
        .Notify(onClick);
    }

    /// <summary>
    /// Creates an interactable button with a background container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuButton(string label, Action onClick, Color? color = null, EBackground style = EBackground.None, float height = 50f)
    {
        color ??= new Color(0.63f, 0.04f, 0.04f, 0.75f);

        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - SBgButton
            .Text(label)
            .Dock(EDockType.Fill)
            .Color(color.Value)
            .Background(style)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates an interactable button with a background container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuButton(string label, Action<SBgButtonOptions> onClick, Color? color = null, EBackground style = EBackground.None, float height = 50f)
    {
        color ??= new Color(0.63f, 0.04f, 0.04f, 0.75f);

        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - SBgButton
            .Text(label)
            .Dock(EDockType.Fill)
            .Color(color.Value)
            .Background(style)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates a text button like the ones in the main menu
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="fontSize"></param>
    /// <returns></returns>
    public static SButtonOptions AxButtonText(string label, Action onClick, int fontSize = 18)
    {
        return SButton
            .Text(label)
            .Dock(EDockType.Fill)
            .FontSize(fontSize)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates a text button like the ones in the main menu
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="fontSize"></param>
    /// <returns></returns>
    public static SButtonOptions AxButtonText(string label, Action<SButtonOptions> onClick, int fontSize = 18)
    {
        return SButton
            .Text(label)
            .Dock(EDockType.Fill)
            .FontSize(fontSize)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates a text button like the ones in the main menu with a background container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="fontSize"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuButtonText(string label, Action onClick, int fontSize = 18, float height = 50f)
    {
        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
           - SButton
            .Text(label)
            .Dock(EDockType.Fill)
            .FontSize(fontSize)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates a text button like the ones in the main menu with a background container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onClick"></param>
    /// <param name="strArg"></param>
    /// <param name="fontSize"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuButtonText(string label, Action<SButtonOptions> onClick, string strArg = null, int fontSize = 18, float height = 50f)
    {
        if (strArg == null)
        {
            return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
               - SButton
                .Text(label)
                .Dock(EDockType.Fill)
                .FontSize(fontSize)
                .Notify(onClick);
        }

        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
           - SButton.Id(strArg)
            .Text(label)
            .Dock(EDockType.Fill)
            .FontSize(fontSize)
            .Notify(onClick);
    }

    /// <summary>
    /// Creates a slider of type int in a panel or container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="onValueChange"></param>
    /// <returns></returns>
    public static SSliderOptions AxSliderInt(string label, int min, int max, int defaultValue, Action<float> onValueChange = null)
    {
        return SSlider
            .Text(label)
            .Dock(EDockType.Fill)
            .Range(min, max)
            .IntStep()
            .Value(defaultValue)
            .Notify(onValueChange);
    }

    /// <summary>
    /// Creates a slider of type int in a panel or container with a visual binded value
    /// </summary>
    /// <param name="label"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValue"></param>
    /// <param name="onValueChange"></param>
    /// <returns></returns>
    public static SSliderOptions AxSliderInt(string label, int min, int max, Observable<float> bindValue, Action<float> onValueChange = null)
    {
        return SSlider
            .Text(label)
            .Dock(EDockType.Fill)
            .Range(min, max)
            .IntStep()
            .Bind(bindValue)
            .Notify(onValueChange);
    }

    /// <summary>A
    /// Creates a slider of type float in a panel or container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="onValueChange"></param>
    /// <param name="step"></param>
    /// <returns></returns>
    public static SSliderOptions AxSliderFloat(string label, float min, float max, float defaultValue, float step = 0.1f, Action<float> onValueChange = null)
    {
        return SSlider
            .Text(label)
            .Dock(EDockType.Fill)
            .Range(min, max)
            .Step(step)
            .Format("0.0")
            .Value(defaultValue)
            .Notify(onValueChange);
    }

    /// <summary>
    /// Creates a slider of type float in a panel or container with a visual binded value
    /// </summary>
    /// <param name="label"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValue"></param>
    /// <param name="step"></param>
    /// <param name="onValueChange"></param>
    /// <returns></returns>
    public static SSliderOptions AxSliderFloat(string label, float min, float max, Observable<float> bindValue, float step = 0.1f, Action<float> onValueChange = null)
    {
        return SSlider
            .Text(label)
            .Dock(EDockType.Fill)
            .Range(min, max)
            .Step(step)
            .Format("0.0")
            .Bind(bindValue)
            .Notify(onValueChange);
    }

    /// <summary>
    /// Creates an input textbox inside a panel or container with a bigger max character limit
    /// </summary>
    /// <param name="label"></param>
    /// <param name="placeholder"></param>
    /// <param name="input"></param>
    /// <param name="onValueChange"></param>
    /// <returns></returns>
    public static STextboxOptions AxInputText(string label, string placeholder, Observable<string> input, Action<string> onValueChange = null)
    {
        if (onValueChange == null)
        {
            var textInput = STextbox
                            .Text(label)
                            .Dock(EDockType.Fill)
                            .Placeholder(placeholder)
                            .Bind(input);

            textInput.InputFieldObject.characterLimit = 10000;
            return textInput;
        }

        var textInput1 = STextbox
                        .Text(label)
                        .Dock(EDockType.Fill)
                        .Placeholder(placeholder)
                        .Bind(input)
                        .Notify(onValueChange);

        textInput1.InputFieldObject.characterLimit = 10000;
        return textInput1;
    }

    /// <summary>
    /// Creates a toggleable checkbox inside a panel or container
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onValueChange"></param>
    /// <returns></returns>
    public static SToggleOptions AxCheckBox(string label, Action<bool> onValueChange)
    {
        return SToggle
            .Text(label)
            .Dock(EDockType.Fill)
            .Notify(onValueChange);
    }

    /// <summary>
    /// Creates an horizontal divider like the ones in game settings
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public static SLabelDividerOptions AxDivider(string label = null)
    {
        return SLabelDivider
            .Text(label)
            .Dock(EDockType.Fill);
    }

    /// <summary>
    /// Used to create a container inside a panel
    /// </summary>
    /// <param name="anchorType"></param>
    /// <param name="size"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static SContainerOptions AxContainer(AnchorType anchorType, Vector2 size, Color? color = null, EBackground style = EBackground.None)
    {
        color ??= Color.black;
        Vector2 pos = AutoPos(size, anchorType);

        return SContainer
            .Pivot(0, 0)
            .Anchor(anchorType)
            .Size(size)
            .Position(pos.x, pos.y)
            .Background((Color)color, style);
    }

    /// <summary>
    /// Used to access a container of a created NxN panel given the panel id (e.g <see langword="AxCreate2x2Panel"/>)
    /// </summary>
    /// <param name="panelId"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static SContainerOptions AxGetContainerAt(string panelId, int index)
    {
        return (SContainerOptions)GetPanel(panelId)[$"{index}"];
    }

    /// <summary>
    /// Used to access a container of a created NxN panel given the panel itself (e.g <see langword="AxCreate2x2Panel"/>)
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static SContainerOptions AxGetContainerAt(SPanelOptions panel, int index)
    {
        return (SContainerOptions)GetPanel(panel.Id)[$"{index}"];
    }

    /// <summary>
    /// Used to access a container of a created NxN panel given the panel id (e.g <see langword="AxCreate2x2Panel"/>)
    /// </summary>
    /// <param name="panelId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    internal static SContainerOptions AxGetContainerAt(string panelId, string id)
    {
        return (SContainerOptions)GetPanel(panelId)[id];
    }

    /// <summary>
    /// Creates a 2x2 panel with 4 containers, you can access each container with <see langword="AxGetContainerAt"/>(this panel id, containerIndex) with upper left being 0 then moving horizontally adding 1
    /// </summary>
    /// <param name="id"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreate2x2Panel(string id, Vector2 size, AnchorType anchorType, Color? color = null, EBackground style = EBackground.None, bool enableInput = false)
    {
        color ??= Color.black;
        Vector2 pos = AutoPos(size, anchorType);

        var panel = RegisterNewPanel(id, enableInput)
        .Pivot(0, 0)
        .Background((Color)color, style)
        .Anchor(anchorType)
        .Size(size.x, size.y)
        .Position(pos.x, pos.y)
        .LayoutMode("XX");

        panel.Add(AxContainer(AnchorType.TopLeft, new Vector2(size.x / 2, size.y / 2), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), EBackground.RoundedStandard).Id("0"));
        panel.Add(AxContainer(AnchorType.TopRight, new Vector2(size.x / 2, size.y / 2), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), EBackground.RoundedStandard).Id("1"));
        panel.Add(AxContainer(AnchorType.BottomLeft, new Vector2(size.x / 2, size.y / 2), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), EBackground.RoundedStandard).Id("2"));
        panel.Add(AxContainer(AnchorType.BottomRight, new Vector2(size.x / 2, size.y / 2), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), EBackground.RoundedStandard).Id("3"));

        return (SPanelOptions)panel;
    }

    /// <summary>
    /// Creates a 3x3 panel with 9 containers, you can access each container with <see langword="AxGetContainerAt"/>(this panel id, containerIndex) with upper left being 0 then moving horizontally adding 1
    /// </summary>
    /// <param name="id"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreate3x3Panel(string id, Vector2 size, AnchorType anchorType, Color? color = null, EBackground style = EBackground.None, bool enableInput = false)
    {
        color ??= Color.black;
        Vector2 pos = AutoPos(size, anchorType);

        var panel = RegisterNewPanel(id, enableInput)
        .Pivot(0, 0)
        .Background((Color)color, style)
        .Anchor(anchorType)
        .Size(size.x, size.y)
        .Position(pos.x, pos.y)
        .LayoutMode("XX");

        panel.Add(AxContainer(AnchorType.TopLeft, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("0"));
        panel.Add(AxContainer(AnchorType.TopCenter, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("1"));
        panel.Add(AxContainer(AnchorType.TopRight, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("2"));
        panel.Add(AxContainer(AnchorType.MiddleLeft, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("3"));
        panel.Add(AxContainer(AnchorType.MiddleCenter, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("4"));
        panel.Add(AxContainer(AnchorType.MiddleRight, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("5"));
        panel.Add(AxContainer(AnchorType.BottomLeft, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("6"));
        panel.Add(AxContainer(AnchorType.BottomCenter, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("7"));
        panel.Add(AxContainer(AnchorType.BottomRight, new Vector2(size.x / 3, size.y / 3), color.Value.WithAlpha(Mathf.Clamp(color.Value.a + 0.2f, 0, 1)), style).Id("8"));

        return (SPanelOptions)panel;
    }

    /// <summary>
    /// <para>Gets the main container of next panels to which you can add other AxMenuComponents (e.g <see langword="AxMenuSlider"/>) or SUI elements</para>
    /// <para>Used for: <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/></para>
    /// </summary>
    /// <param name="panelId"></param>
    /// <returns></returns>
    public static SScrollContainerOptions AxGetMainContainer(string panelId)
    {
        var scrollbar = (SContainerOptions)GetPanel(panelId)["scrollbar"];
        return (SScrollContainerOptions)scrollbar["scrollcontainer"];
    }

    /// <summary>
    /// <para>Gets the main container of next panels to which you can add other AxMenuComponents (e.g <see langword="AxMenuSlider"/>) or SUI elements</para>
    /// <para>Used for: <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/></para>
    /// </summary>
    /// <param name="panel"></param>
    /// <returns></returns>
    public static SScrollContainerOptions AxGetMainContainer(SPanelOptions panel)
    {
        var scrollbar = (SContainerOptions)GetPanel(panel.Id)["scrollbar"];
        return (SScrollContainerOptions)scrollbar["scrollcontainer"];
    }

    /// <summary>
    /// Gets the title of a <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="panelId"></param>
    /// <returns></returns>
    public static SLabelOptions AxGetMenuTitle(string panelId)
    {
        return (SLabelOptions)GetPanel(panelId)["menutitle"];
    }

    /// <summary>
    /// Gets the title of a <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="panel"></param>
    /// <returns></returns>
    public static SLabelOptions AxGetMenuTitle(SPanelOptions panel)
    {
        return (SLabelOptions)GetPanel(panel.Id)["menutitle"];
    }

    /// <summary>
    /// Creates a vertical settings like menu panel with scrollbar to which you can add sliders, input text etc.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="canMoveAndResize"></param>
    /// <param name="title"></param>
    /// <param name="size"></param>
    /// <param name="anchorType"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreateMenuPanel(string id, bool canMoveAndResize, string title, Vector2 size, AnchorType anchorType = AnchorType.MiddleCenter, Color? color = null, EBackground style = EBackground.RoundedStandard, bool enableInput = true)
    {
        color ??= Color.black.WithAlpha(0.92f);

        var menuPanel = AxCreatePanel(id, false, size, anchorType, color, style, enableInput).Vertical(2, "EC").Padding(2);

        var titleContainer = SContainer.Background((Color)color, style).PaddingVertical(10).PHeight(size.y / 10)
            - AxTextAutoSize(title).Id("menutitle")
            - AxButton("X", CloseMenuPanel, new Vector2(size.x / 20, size.y / 20), AnchorType.TopRight).Background(style).Id($"close{id}");

        if (canMoveAndResize)
        {
            var moveButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.TopLeft).Background(style).Color(Color.cyan.WithAlpha(color.Value.a));
            titleContainer.Add(moveButton);
            MovePanel(moveButton, id).RunCoro();

            var resizeButton = AxButton("", Dummy, new Vector2(size.x / 20, size.y / 40), AnchorType.MiddleLeft).Background(style).Color(Color.yellow.WithAlpha(color.Value.a));
            titleContainer.Add(resizeButton);
            ResizePanel(resizeButton, id).RunCoro();
        }
        menuPanel.Add(titleContainer);

        var scrollBar = SDiv.FlexHeight(1);
        scrollBar.Id("scrollbar");
        menuPanel.Add(scrollBar);

        var settingsScroll = SScrollContainer
        .Dock(EDockType.Fill)
        .Background(Color.black.WithAlpha(0), style)
        .Size(-20, -20)
        .As<SScrollContainerOptions>();
        settingsScroll.ContainerObject.Spacing(10);
        settingsScroll.ContainerObject.PaddingHorizontal(10);
        settingsScroll.Id("scrollcontainer");
        scrollBar.Add(settingsScroll);

        var bottomContainer = SContainer.Background((Color)color, style).PaddingVertical(10).PHeight(size.y / 15);
        menuPanel.Add(bottomContainer);

        return (SPanelOptions)menuPanel;
    }

    internal static void Dummy()
    {

    }

    internal static void CloseMenuPanel(SBgButtonOptions id)
    {
        TogglePanel(id._id.Remove(0, 5), false);
    }

    internal static IEnumerator MovePanel(SBgButtonOptions buttonId, string panelId)
    {
        var panelTr = GetPanel(panelId).RectTransform;
        while (true)
        {
            if (buttonId.ButtonObject.isPointerDown)
            {
                panelTr.SetPositionAndRotation(new Vector2(Input.mousePosition.x, Input.mousePosition.y - panelTr.sizeDelta.y), Quaternion.identity);
            }
            yield return null;
        }
    }

    internal static IEnumerator ResizePanel(SBgButtonOptions buttonId, string panelId)
    {
        float x;
        float y;

        var panelTr = GetPanel(panelId).RectTransform;
        while (true)
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            if (buttonId.ButtonObject.isPointerDown)
            {
                panelTr.sizeDelta = new Vector2(panelTr.sizeDelta.x + x, panelTr.sizeDelta.y + y);
            }
            yield return null;
        }
    }

    internal static IEnumerator ResizePanelHoriz(SBgButtonOptions buttonId, string panelId)
    {
        float x;

        var panelTr = GetPanel(panelId).RectTransform;
        while (true)
        {
            x = Input.GetAxis("Mouse X");

            if (buttonId.ButtonObject.isPointerDown)
            {
                panelTr.sizeDelta = new Vector2(panelTr.sizeDelta.x + x, panelTr.sizeDelta.y);
            }
            yield return null;
        }
    }

    internal static void MovePanel(SBgButtonOptions id)
    {
        float moveFactor = 30;
        string[] split = id._id.Split('_', StringSplitOptions.None);
        var panelTr = GetPanel(split[1]).RectTransform;

        switch (split[0])
        {
            case "up":
                panelTr.SetPositionAndRotation(new Vector2(panelTr.transform.position.x, panelTr.transform.position.y + moveFactor), Quaternion.identity);
                break;
            case "lt":
                panelTr.SetPositionAndRotation(new Vector2(panelTr.transform.position.x - moveFactor, panelTr.transform.position.y), Quaternion.identity);
                break;
            case "rt":
                panelTr.SetPositionAndRotation(new Vector2(panelTr.transform.position.x + moveFactor, panelTr.transform.position.y), Quaternion.identity);
                break;
            case "dn":
                panelTr.SetPositionAndRotation(new Vector2(panelTr.transform.position.x, panelTr.transform.position.y - moveFactor), Quaternion.identity);
                break;
        }
    }

    public enum LabelPosition
    {
        Left,
        Top,
        Right,
        Bottom,
    }

    /// <summary>
    /// Creates an <see langword="int"/> slider with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>   
    /// <param name="labelPosition"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderInt(string label, LabelPosition labelPosition, int min, int max, int defaultValue, Action<float> onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxSliderInt(label, min, max, defaultValue, onValueChange).HOffset(10, -10).Options(visibility),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxSliderInt(label, min, max, defaultValue, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxSliderInt(label, min, max, defaultValue, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                        - AxText(label, (int)(50 * (height / 100)))
                        - AxSliderInt(label, min, max, defaultValue, onValueChange).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates an <see langword="int"/> slider with a background container and a visual binded value, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="labelPosition"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValue"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderInt(string label, LabelPosition labelPosition, int min, int max, Observable<float> bindValue, Action<float> onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxSliderInt(label, min, max, bindValue, onValueChange).HOffset(10, -10).Options(visibility),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxSliderInt(label, min, max, bindValue, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxSliderInt(label, min, max, bindValue, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                        - AxText(label, (int)(50 * (height / 100)))
                        - AxSliderInt(label, min, max, bindValue, onValueChange).HOffset(10, -10).Options(visibility),
        };
    }

    public enum LayoutMode
    {
        Horizontal,
        Vertical
    }

    /// <summary>
    /// Creates 3 <see langword="int"/> sliders with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="layoutMode"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderInt3(string[] label, LayoutMode layoutMode, int min, int max, int[] defaultValue, Action<float>[] onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return layoutMode switch
        {
            LayoutMode.Horizontal => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[0], min, max, defaultValue[0], onValueChange?[0]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[1], min, max, defaultValue[1], onValueChange?[1]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[2], min, max, defaultValue[2], onValueChange?[2]).HOffset(10, -10).Options(visibility),

            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 5f).Vertical(0, "EC").PaddingVertical(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[0], min, max, defaultValue[0], onValueChange?[0]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[1], min, max, defaultValue[1], onValueChange?[1]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[2], min, max, defaultValue[2], onValueChange?[2]).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates 3 <see langword="int"/> sliders with a background container and visual binded values, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="layoutMode"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValues"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderInt3(string[] label, LayoutMode layoutMode, int min, int max, Observable<float>[] bindValues, Action<float>[] onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return layoutMode switch
        {
            LayoutMode.Horizontal => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[0], min, max, bindValues[0], onValueChange?[0]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[1], min, max, bindValues[1], onValueChange?[1]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[2], min, max, bindValues[2], onValueChange?[2]).HOffset(10, -10).Options(visibility),

            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 5f).Vertical(0, "EC").PaddingVertical(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[0], min, max, bindValues[0], onValueChange?[0]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[1], min, max, bindValues[1], onValueChange?[1]).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderInt(label[2], min, max, bindValues[2], onValueChange?[2]).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates a <see langword="float"/> slider with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="labelPosition"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="step"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderFloat(string label, LabelPosition labelPosition, float min, float max, float defaultValue, float step = 0.1f, Action<float> onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxSliderFloat(label, min, max, defaultValue, step, onValueChange).HOffset(10, -10).Options(visibility),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxSliderFloat(label, min, max, defaultValue, step, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxSliderFloat(label, min, max, defaultValue, step, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                        - AxText(label, (int)(50 * (height / 100)))
                        - AxSliderFloat(label, min, max, defaultValue, step, onValueChange).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates a <see langword="float"/> slider with a background container and a visual binded value, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="labelPosition"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValue"></param>
    /// <param name="step"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderFloat(string label, LabelPosition labelPosition, float min, float max, Observable<float> bindValue, float step = 0.1f, Action<float> onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxSliderFloat(label, min, max, bindValue, step, onValueChange).HOffset(10, -10).Options(visibility),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxSliderFloat(label, min, max, bindValue, step, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 1.70f).Vertical(0, "EC").PaddingVertical(5)
                                - AxSliderFloat(label, min, max, bindValue, step, onValueChange).HOffset(10, -10).Options(visibility)
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                        - AxText(label, (int)(50 * (height / 100)))
                        - AxSliderFloat(label, min, max, bindValue, step, onValueChange).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates 3 <see langword="float"/> sliders with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="layoutMode"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="defaultValue"></param>
    /// <param name="step"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderFloat3(string[] label, LayoutMode layoutMode, float min, float max, float[] defaultValue, float step = 0.1f, Action<float>[] onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return layoutMode switch
        {
            LayoutMode.Horizontal => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[0], min, max, defaultValue[0], step, onValueChange?.ElementAt(0)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[1], min, max, defaultValue[1], step, onValueChange?.ElementAt(1)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[2], min, max, defaultValue[2], step, onValueChange?.ElementAt(2)).HOffset(10, -10).Options(visibility),

            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 5f).Vertical(0, "EC").PaddingVertical(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[0], min, max, defaultValue[0], step, onValueChange?.ElementAt(0)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[1], min, max, defaultValue[1], step, onValueChange?.ElementAt(1)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[2], min, max, defaultValue[2], step, onValueChange?.ElementAt(2)).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates 3 <see langword="float"/> sliders with a background container and visual binded values, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="layoutMode"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="bindValue"></param>
    /// <param name="step"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuSliderFloat3(string[] label, LayoutMode layoutMode, float min, float max, Observable<float>[] bindValue, float step = 0.1f, Action<float>[] onValueChange = null, float height = 50f)
    {
        SSliderOptions.VisibilityMask visibility = SSliderOptions.VisibilityMask.Readout | SSliderOptions.VisibilityMask.Buttons;

        return layoutMode switch
        {
            LayoutMode.Horizontal => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[0], min, max, bindValue[0], step, onValueChange?.ElementAt(0)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[1], min, max, bindValue[1], step, onValueChange?.ElementAt(1)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[2], min, max, bindValue[2], step, onValueChange?.ElementAt(2)).HOffset(10, -10).Options(visibility),

            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 5f).Vertical(0, "EC").PaddingVertical(5)
                                    - AxText(label[0], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[0], min, max, bindValue[0], step, onValueChange?.ElementAt(0)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[1], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[1], min, max, bindValue[1], step, onValueChange?.ElementAt(1)).HOffset(10, -10).Options(visibility)
                                    - AxText(label[2], (int)(50 * (height / 100)))
                                    - AxSliderFloat(label[2], min, max, bindValue[2], step, onValueChange?.ElementAt(2)).HOffset(10, -10).Options(visibility),
        };
    }

    /// <summary>
    /// Creates an input text box with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="labelPosition"></param>
    /// <param name="placeHolder"></param>
    /// <param name="input"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuInputText(string label, LabelPosition labelPosition, string placeHolder, Observable<string> input, Action<string> onValueChange = null, float height = 50f)
    {
        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 2f).Vertical(0, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxInputText(label, placeHolder, input, onValueChange).HOffset(10, -10).HideLabel(),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxInputText(label, placeHolder, input, onValueChange).HOffset(10, -10).HideLabel()
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 2f).Vertical(0, "EC").PaddingVertical(5)
                                - AxInputText(label, placeHolder, input, onValueChange).HOffset(10, -10).HideLabel()
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - AxInputText(label, placeHolder, input, onValueChange).HOffset(10, -10).HideLabel()
        };
    }

    /// <summary>
    /// Creates an input text box with a background container with width control, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="placeHolder"></param>
    /// <param name="inputWidth"></param>
    /// <param name="input"></param>
    /// <param name="onValueChange"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuInputText(string label, string placeHolder, float inputWidth, Observable<string> input, Action<string> onValueChange = null, float height = 50f)
    {
        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - AxInputText(label, placeHolder, input, onValueChange).HOffset(10, -10).InputFlexWidth(inputWidth);
    }

    /// <summary>
    /// Creates an options box with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="labelPosition"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuOptions(string label, LabelPosition labelPosition, Observable<string> value, string[] options, float height = 50f)
    {
        return labelPosition switch
        {
            LabelPosition.Top => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 2f).Vertical(5, "EC").PaddingVertical(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - SOptions.Text(label).Options(options).Bind(value).Dock(EDockType.Fill).HOffset(10, -10).HideLabel(),
            LabelPosition.Right => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - SOptions.Text(label).Options(options).Bind(value).Dock(EDockType.Fill).HOffset(10, -10).HideLabel()
                                - AxText(label, (int)(50 * (height / 100))),
            LabelPosition.Bottom => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height * 2f).Vertical(5, "EC").PaddingVertical(5)
                                - SOptions.Text(label).Options(options).Bind(value).Dock(EDockType.Fill).HOffset(10, -10)
                                - AxText(label, (int)(50 * (height / 100))),
            _ => SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height).Horizontal(5, "CE").PaddingHorizontal(5)
                                - AxText(label, (int)(50 * (height / 100)))
                                - SOptions.Text(label).Options(options).Bind(value).Dock(EDockType.Fill).HOffset(10, -10)
        };
    }

    /// <summary>
    /// Creates a toggleable checkbox with a background container, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onValueChange"></param>
    /// <param name="defValue"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuCheckBox(string label, Action<bool> onValueChange, bool defValue = false, float height = 50f)
    {
        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - AxCheckBox(label, onValueChange).Value(defValue).HOffset(10, -10);
    }

    public static SContainerOptions NodeAxMenuCheckBox(string label, Action<bool> onValueChange, bool defValue = false, float height = 50f)
    {
        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - AxCheckBox(label, onValueChange).Value(defValue).HOffset(10, -10);
    }

    /// <summary>
    /// Creates a toggleable checkbox with a background container binded to a value, mainly used with <see langword="AxCreateMenuPanel"/>, <see langword="AxCreateSidePanel"/>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="onValueChange"></param>
    /// <param name="bindValue"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static SContainerOptions AxMenuCheckBox(string label, Action<bool> onValueChange, Observable<bool> bindValue, float height = 50f)
    {
        return SContainer.Background(Color.black.WithAlpha(0.9f), EBackground.None).PHeight(height)
            - AxCheckBox(label, onValueChange).Bind(bindValue).HOffset(10, -10);
    }

    public enum Side
    {
        Left,
        Right
    }

    /// <summary>
    /// Creates a vertical panel on a side of the screen which fills it vertically on which you can add sliders, input text etc.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="canResize"></param>
    /// <param name="title"></param>
    /// <param name="side"></param>
    /// <param name="hSize"></param>
    /// <param name="color"></param>
    /// <param name="style"></param>
    /// <param name="enableInput"></param>
    /// <returns></returns>
    public static SPanelOptions AxCreateSidePanel(string id, bool canResize, string title, Side side, float hSize, Color? color = null, EBackground style = EBackground.None, bool enableInput = true)
    {
        color ??= Color.black.WithAlpha(0.92f);
        AnchorType anchorType = (side == Side.Left) ? AnchorType.TopLeft : AnchorType.TopRight;
        var pos = (anchorType == AnchorType.TopLeft) ? new Vector2(0, -0) : new Vector2(-hSize, -0);

        var sidePanel = RegisterNewPanel(id, enableInput)
            .Pivot(0, 0)
            .Anchor(anchorType)
            .Background((Color)color, style)
            .Size(hSize)
            .Position(pos.x, pos.y)
            .Vertical(5, "EC")
            .VFill();

        var titleContainer = SContainer.Background((Color)color, style).PaddingVertical(10).PHeight(50).Id("titlecontainer")
            - AxTextAutoSize(title).Id("menutitle")
            - AxButton("X", CloseMenuPanel, new Vector2(50, 50), AnchorType.TopRight).Background(EBackground.RoundedStandard).Color(new Color(1.00f, 0.13f, 0.29f)).Id($"close{id}");

        if (canResize)
        {
            var resizeButton = AxButton("", Dummy, new Vector2(hSize / 20, hSize / 40), AnchorType.TopLeft).Background(style).Color(Color.yellow.WithAlpha(color.Value.a));
            titleContainer.Add(resizeButton);
            ResizePanelHoriz(resizeButton, id).RunCoro();
        }
        sidePanel.Add(titleContainer);

        var scrollBar = SDiv.FlexHeight(1);
        scrollBar.Id("scrollbar");
        sidePanel.Add(scrollBar);

        var settingsScroll = SScrollContainer
        .Dock(EDockType.Fill)
        .Background(Color.black.WithAlpha(0), style)
        .Size(-20, -20)
        .As<SScrollContainerOptions>();
        settingsScroll.ContainerObject.Spacing(10);
        settingsScroll.ContainerObject.PaddingHorizontal(10);
        settingsScroll.Id("scrollcontainer");
        scrollBar.Add(settingsScroll);

        return (SPanelOptions)sidePanel;
    }
}
