<p align="center">
 <img src="https://i.imgur.com/EeBBqDU.png" width="300" height="300" />
</p>

# RedNodeEditor [![Github All Releases](https://img.shields.io/github/downloads/ImAxel0/RedNodeEditor/total.svg)]()  [![Github All Releases](https://img.shields.io/github/v/release/ImAxel0/RedNodeEditor)]()
  **A custom node editor to make mods for Sons of the Forest without programming knowledge** 
  
  :orange_book: [Documentation](https://app.gitbook.com/o/NHbK8lCm0flXIHLC9Bun/s/16eHiWrLvkdzPgx4n88e/) :orange_book:

---
 ## FEATURES :star:
 - Made specifically for [**RedLoader**](https://github.com/ToniMacaroni/RedLoader/tree/main)
 - **Shareable projects**: share you mod projects with others
 - **Error detection**: detects common errors during the mod making process
 - **Colored graph comments**: comment your node sections with what they do
 - **Node descriptions**: each node when hovered shows a description about what it does or how should be used
 - **Zoom**: zoomable graph editor
 - **Variables**: store values in containers to later use them
 - **Custom events**: alter the node flow and keeps a tidy editor visual
 - **Generic nodes**: expand the modding capabilities beyond the provided nodes
 - **200+** available nodes to use

---
## Installation :arrow_down:
1. Download the latest **RedNodeEditor Setup.exe** from the [release](https://github.com/ImAxel0/RedNodeEditor/releases) section
2. Run the setup as administrator and install the application
3. Open the app and start making mods

---
## General infos
Mod project files end with `.rproj` extension

Mod files end with `.rmod` extension
> The custom extensions are only there for clarity, in reality they are just .json and .xml respectively

---
## Requirements :warning:
- [.NET 6.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0#runtime-6.0.15)

---
## FAQ :question:
### **Can I make all type of mods with this?**

While it's surely not possible to make all types of mods, it should offer a vast arsenal to make easy and more complex type of mods like the two provided mod examples. 
By providing both premade and generic nodes it pretty much depends on the user capabilities and understanding of the tool.

### **Can I still make something out of this if I don't know how to program and/or unity game development?**

Absolutely yes! Some nodes may sound unfamiliar like the **Unity** node category, but a big chunk of them are self-explanatory and are shortly described when hovered.

### **How is this related to RedLoader?**

The application was built with a focus on RedLoader by using it's functionalities and making nodes based on it. The mods themselves are read and resolved by a RedLoader mod (*RedNodeLoader*), which executes each node accordingly.

### **Will an eventual application/loader update break my mods?**

Depending if the mod used some nodes which where greatly changed in functionalities the mod may break or not. (Reverting to an older version of the loader is always possible to keep using it).

---
## Pics :camera:
![RedNodeEditor](https://github.com/ImAxel0/RedNodeEditor/assets/124681710/1ae6cbf8-b80c-407c-914c-de3c39e2b87d)

### Plane mod example
![PlaneMod](https://github.com/ImAxel0/RedNodeEditor/assets/124681710/32bbeb7d-b899-4f5e-b43c-08c7babbc741)

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
If the input argument isn't of the common types (int, float, bool, string, Vector3, Vector2) the property must still be written and marked with the [XmlIgnore] attribute like shown in the example below.

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
