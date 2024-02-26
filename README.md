<p align="center">
 <img src="https://i.imgur.com/EeBBqDU.png" width="300" height="300" />
</p>

# RedNodeEditor [![Github All Releases](https://img.shields.io/github/downloads/ImAxel0/RedNodeEditor/total.svg)]()  [![Github All Releases](https://img.shields.io/github/v/release/ImAxel0/RedNodeEditor)]()
  **A custom node editor to make mods for [Sons of the Forest](https://store.steampowered.com/app/1326470/Sons_Of_The_Forest/)** 
  
  :orange_book: [Documentation](https://app.gitbook.com/o/NHbK8lCm0flXIHLC9Bun/s/16eHiWrLvkdzPgx4n88e/) :orange_book:

---
 ## FEATURES :star:
 - Made specifically for [**RedLoader**](https://github.com/ToniMacaroni/RedLoader/tree/main)
 - **Shareable projects**: share you mod projects with others
 - **Error detection**: detects common errors when building the mod
 - **Colored graph comments**: comment your node sections with what they do
 - **Node descriptions**: each node when hovered shows a description about what it does or how should be used
 - **Zoom**: zoomable graph editor
 - **Variables**: store values in containers to later use them
 - **Custom events**: alter the node flow and keeps a tidy editor visual
 - **Generic and Unity nodes**: expand the modding capabilities beyond the provided nodes
 - **200+** available nodes to use

---
## Installation :arrow_down:
1. Download the latest **RedNodeEditor Setup.exe** from the [release](https://github.com/ImAxel0/RedNodeEditor/releases) section
2. Run the setup as administrator and install the application
3. Open the app and start making mods

---
## Mods installation :arrow_double_down:
1. Install RedNodeLoader as a standard RedLoader mod
2. Place the `.rmod` file and eventual mod folder in the `SonsOfTheForest/Mods/RedNodeLoader/Mods` folder

---
## General infos
> Administrator privileges are required to write mod files to disk

Two project examples are provided with the editor installation:

| Project name | Description | Real mod link | Difficulty |
|:----------:|:---------:|:---------:|:-------------:|
| ModMenuExample.rproj | Simplified version of my mod menu | [link](https://sotf-mods.com/mods/imaxel/axel's-mod-menu) | easy-intermediate |
| PlaneModExample.rproj | Mod where you can pilot a plane | [link](https://sotf-mods.com/mods/imaxel/plane-mod) | harder |

Mod project files end with `.rproj` extension

Mod files end with `.rmod` extension
> The custom extensions are only there for clarity, in reality they are .json and .xml respectively

---
## Requirements :warning:
- [.NET 6.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0#runtime-6.0.15)
- [Microsoft Visual C++ Redistributable](https://aka.ms/vs/17/release/vc_redist.x64.exe) (probably)

---
## FAQ :question:
### **Can I make all type of mods with this?**

While it's surely not possible to make all types of mods, it should offer a vast arsenal to make easy and more complex type of mods like the two provided mod examples. 
By providing both premade and generic nodes it pretty much depends on the user capabilities and understanding of the tool.

### **Can I still make something out of this if I don't know how to program and/or unity game development?**

Absolutely yes! Some nodes may sound unfamiliar like the **Unity** node category, but a big chunk of them are self-explanatory and are shortly described when hovered.

### **How is this related to RedLoader?**

The application was built with a focus on RedLoader by using it's functionalities and making nodes based on it. The mods themselves are read and resolved by a RedLoader mod (*RedNodeLoader*), which executes each node accordingly.

### How can I use arrays/list?

Containers like arrays and list aren't currently supported and so aren't for loops.

### **Will an eventual application/loader update break my mods?**

Depending if the mod used some nodes which where greatly changed in functionalities the mod may break or not. (Reverting to an older version of the loader is always possible to keep using it).

---
https://github.com/ImAxel0/RedNodeEditor/assets/124681710/25c4f2b4-2096-475d-8575-71d80d7ba5c1

### Mod menu mod example
![ModMenuScreen](https://github.com/ImAxel0/RedNodeEditor/assets/124681710/cdec7ca5-fe9c-4b5c-974b-0841279e1864)

---
## Contributing to the project :video_game:
To create a new node we need to make a new class which derives from the **SonsNode** class and populate it's informations like shown below.

### Nodes having inputs only:
```cs
public class SetWalkSpeedNode : SonsNode
{
    public float Speed { get; set; } // the argument input displayed as an input field

    public SetWalkSpeedNode()
    {
        Name = "SetWalkSpeed"; // the name of the node which will be displayed in the editor
        Description = "Sets player walk speed"; // description about what the node does or how should be used
        NodeCategory = NodeCategories.Player; // the node category in which to put the node

        // the input argument displayed as a circle (ArgName is optional but preferred; nameof should always be used to maintain the right references)
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Speed) });
    }
}
```

### Nodes having an output only:
```cs
public class GetRunSpeedNode : SonsNode
{
    public GetRunSpeedNode()
    {
        Name = "GetRunSpeed"; // the name of the node which will be displayed in the editor
        Description = "Returns player run speed"; // description about what the node does or how should be used
        NodeCategory = NodeCategories.Player; // the node category in which to put the node

        // the output argument displayed as a circle
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
```

### Nodes having both inputs and an output:
```cs
public class AmountOfNode : SonsNode
{
    public int ItemId { get; set; } // the argument input displayed as an input field

    public AmountOfNode()
    {
        Name = "AmountOf"; // the name of the node which will be displayed in the editor
        Description = "Gets the owned amount of the passed item id"; // description about what the node does or how should be used
        NodeCategory = NodeCategories.Inventory; // the node category in which to put the node

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) }); // input argument displayed as a circle
        ArgsOut.Add(new ArgOut { Type = typeof(int) }); // output argument displayed as a circle
    }
}
```

### Nodes using external types:
If the input argument isn't of the common types (int, float, bool, string, Vector3, Vector2) the property must still be written and marked with the `[XmlIgnore]` attribute like shown in the example below.

```cs
public class SetActiveNode : SonsNode
{
    [XmlIgnore] // use this attribute when the property type it's not (int, float, bool, string, Vector3, Vector2)
    public GameObject GameObject { get; set; } // GameObject type isn't a common type so no input field will be displayed
    public bool Value { get; set; } // Boolean type is a common type so a checkbox will be displayed

    public SetActiveNode()
    {
        Name = "SetActive"; // the name of the node which will be displayed in the editor
        Description = "Turns the passed GameObject on or off"; // description about what the node does or how should be used
        NodeCategory = NodeCategories.Unity; // the node category in which to put the node

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) }); // 1° input argument displayed as a circle
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) }); // 2° input argument displayed as a circle
    }
}
```

## Implementing the new node
To make the node functional we need to implement it's behaviour in RedNodeLoader. To do so we need to create a new class which must have the same exact name, namespace and properties names as the one defined in the editor before.
We then need to override the **Execute** method, which is where the node behaviour will happen, and add inputs and outputs of the node as properties if any. 

The `RedNodeLoader.GetArgumentsOf(this)` method is used to retrieve both static inputs and passed arguments of a node.

Here is an example implementation for the **SetWalkSpeed** node we showed before.

```cs
public class SetWalkSpeedNode : SonsNode
{
    public float Speed { get; set; } // input arguments must be defined as public properties using the same name as chosed in the editor class

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this); // retrieves the arguments of SetWalkSpeed (only Speed value in this case) and stores them as generic objects in a list in the same order as defined in the editor class 
        LocalPlayer.FpCharacter.SetWalkSpeed((float)args[0]); // each argument must be explicitly casted to it's proper type and index. Never use the property directly like "Speed" as it won't work if the value is passed
    }
}
```

### Nodes having an output:
Nodes having an output argument must have a public property of whatever name we chose and as the same type defined in the editor class. The output property must have the `[IsArgOut]` attribute to define it's an output argument.

Here is an example implementation for the **GetRunSpeed** node we showed before.
```cs
public class GetRunSpeedNode : SonsNode
{
    [IsArgOut] // output argument must have this attribute
    public float Speed { get; set; } // output argument must be defined as a public property. The name can be whatever you want

    public override void Execute()
    {
        Speed = LocalPlayer.FpCharacter.RunSpeed; // getting the desidered value and storing it into the node output argument
    }
}
```

### Nodes having both inputs and an output:
```cs
public class AmountOfNode : SonsNode
{
    public int ItemId { get; set; } // input argument property

    [IsArgOut]
    public int OwnedAmount { get; set; } // output argument property

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this); // getting the value of "ItemId" input argument
        OwnedAmount = LocalPlayer.Inventory.AmountOf((int)args[0]); // getting and storing the output argument in the "OwnedAmount" property
    }
}
```

### Nodes using external types:
```cs
public class SetActiveNode : SonsNode
{
    [XmlIgnore] // use this attribute when the property type it's not (int, float, bool, string, Vector3, Vector2)
    public GameObject GameObject { get; set; } // 1° input argument property
    public bool Value { get; set; } // 2° input argument property

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this); // getting value of "GameObject" and "Value"
        var go = (GameObject)args[0]; // casting and storing the GameObject
        go.SetActive((bool)args[1]); // using the casted GameObject and the boolean property
    }
}
```

> **VECTORS**: when working with vectors always use `System.Numerics.Vector` as the property type and not the `UnityEngine` one, both in the editor and RedNodeLoader class.
In the implementation of the node you will then need to create a `UnityEngine.Vector` using the (X,Y,Z) values accordingly.
