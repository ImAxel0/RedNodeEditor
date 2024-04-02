using RedLoader;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vanara.PInvoke;

namespace RedNodeEditor;

public class PipeManager
{
    static readonly string _pipeName = "RedNodePipe";

    public static void ExecuteMod()
    {
        var modData = ModBuilder.MakeModData("RedNodeEditor", "1.0.0", true);
        if (modData != null)
        {
            var modContent = ModBuilder.SerializeModDataAsString(modData);
            if (Send(modContent, _pipeName))
            {
                Logger.Append("Mod executed successfully!");
                User32.MessageBox(IntPtr.Zero, "Mod executed successfully!", "Runtime mod execution", User32.MB_FLAGS.MB_TOPMOST);
                return;
            }
        }
        Logger.Append("Couldn't execute mod at runtime");
        User32.MessageBox(IntPtr.Zero, "Couldn't execute mod at runtime. Check if the game is running and RedNodeLoader is correctly installed"
            , "Runtime mod execution", User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
    }

    public static void StopExecution()
    {
        if (Send("stop", _pipeName))
        {
            Logger.Append("Mod stopped successfully!");
            User32.MessageBox(IntPtr.Zero, "Mod stopped successfully!", "Runtime mod execution", User32.MB_FLAGS.MB_TOPMOST);
            return;
        }
        Logger.Append("Couldn't stop mod runtime mod");
        User32.MessageBox(IntPtr.Zero, "Couldn't stop runtime mod", "Runtime mod execution", User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
    }

    private static bool Send(string modContent, string pipeName, int TimeOut = 1000)
    {
        try
        {
            NamedPipeClientStream pipeStream = new(".", pipeName, PipeDirection.Out, PipeOptions.Asynchronous);

            pipeStream.Connect(TimeOut);
            Logger.Append("Pipe connection established");

            using (StreamWriter writer = new StreamWriter(pipeStream))
            {
                writer.WriteLine(modContent.Length);
                writer.Write(modContent);
            }
            return true;
        }
        catch (Exception oEX)
        {
            Logger.Append(oEX.Message);
        }
        return false;  
    }
}
