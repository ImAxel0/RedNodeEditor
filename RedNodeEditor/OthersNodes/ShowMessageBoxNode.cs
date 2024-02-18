namespace RedNodeEditor.OthersNodes;

public class ShowMessageBoxNode : SonsNode
{
    public string Title { get; set; }
    public string Text { get; set; }

    public ShowMessageBoxNode()
    {
        Name = "ShowMessageBox";
        Description = "Shows a fullscreen messagebox with a title and text";

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Title) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Text) });
    }
}
