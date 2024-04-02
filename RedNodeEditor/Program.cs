using Veldrid.Sdl2;
using Veldrid;
using System.Diagnostics;
using Veldrid.StartupUtilities;
using ImGuiNET;
using System.Numerics;
using Vanara.PInvoke;
using IconFonts;
using System.IO.Pipes;
using System.Xml.Serialization;

namespace RedNodeEditor;

class Program
{
    public static Sdl2Window _window;
    private static GraphicsDevice _gd;
    private static CommandList _cl;
    private static ImGuiController _controller;
    private static Vector3 _clearColor = new(0.45f, 0.55f, 0.6f);

    static void Main(string[] args)
    {
        ProgramData.Initialize();

        VeldridStartup.CreateWindowAndGraphicsDevice(
            new WindowCreateInfo(50, 50, 1280, 720, WindowState.Maximized, $"RedNodeEditor (Beta)"),
            new GraphicsDeviceOptions(false, null, true, ResourceBindingModel.Improved, true, true),
            out _window,
            out _gd);
        _window.Resized += () =>
        {
            _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
            _controller.WindowResized(_window.Width, _window.Height);
        };
        _cl = _gd.ResourceFactory.CreateCommandList();
        _controller = new ImGuiController(_gd, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);

        var stopwatch = Stopwatch.StartNew();
        float deltaTime = 0f;

        ImGuiTheme.ImGuiStyle = ImGui.GetStyle();
        ImGuiTheme.ApplyTheme();
        ImGuiController.LoadImages(_gd, _controller);

        while (_window.Exists)
        {
            deltaTime = stopwatch.ElapsedTicks / (float)Stopwatch.Frequency;
            stopwatch.Restart();
            InputSnapshot snapshot = _window.PumpEvents();
            if (!_window.Exists) { break; }
            _controller.Update(deltaTime, snapshot);

            if (_window.WindowState == WindowState.Minimized)
            {
                Thread.Sleep(100);
                continue;
            }

            RenderUI();

            ImGuiController.UpdateMouseCursor();

            _cl.Begin();
            _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
            _cl.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
            _controller.Render(_gd, _cl);
            _cl.End();
            _gd.SubmitCommands(_cl);
            _gd.SwapBuffers(_gd.MainSwapchain);
        }

        _gd.WaitForIdle();
        _controller.Dispose();
        _cl.Dispose();
        _gd.Dispose();
    }

    static void RenderUI()
    {
        ImGui.SetNextWindowPos(Vector2.Zero);
        ImGui.SetNextWindowSize(ImGui.GetIO().DisplaySize);

        ImGui.Begin("MainWindow", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse
            | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.MenuBar);

        RenderMenuBar();

        NodeList.Render();

        ImGui.SameLine();

        GraphEditor.Render();

        ProjectDialogLoad.Render();
        ProjectDialogSave.Render();
        ProjectDialogBuild.Render();
        AboutDialog.Render();

        ImGui.End();

        ShortcutHelp.ShortcutListener();     
    }

    public static void RenderMenuBar()
    {
        ImGui.BeginMenuBar();

        ImGui.TextDisabled(ProjectData.ProjectName);

        if (ImGui.BeginMenu($"{FontAwesome6.File} File"))
        {
            if (ImGui.MenuItem("New Project", "Ctrl+N"))
            {
                ProjectData.CreateNewProject();
            }

            if (ImGui.MenuItem("Open Project", "Ctrl+O"))
            {
                ProjectDialogLoad.ShowDialog = true;
            }

            if (ImGui.MenuItem("Save Project", "Ctrl+S"))
            {
                ProjectData projectData = new()
                {
                    GraphNodes = GraphEditor.GraphNodes,
                    GraphComments = GraphEditor.GraphComments,
                    VariablesId = VariablesManager.VariablesId,
                    Variables = VariablesManager.Variables
                };
                ProjectData.SaveProject(projectData);
            }

            if (ImGui.MenuItem("Save Project As", "Ctrl+Shift+S"))
            {
                ProjectDialogSave.ShowDialog = true;
            }
            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.ArrowsToEye} View"))
        {
            ImGui.Checkbox("Hide Inputs/Outputs in node list", ref NodeList.HideArguments);
            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.Folder} Data"))
        {
            if (ImGui.MenuItem("Open projects folder"))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ProgramData.ProjectsFolder,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }

            if (ImGui.MenuItem("Open built mods folder"))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ProgramData.ModsFolder,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }

            if (ImGui.MenuItem("Open game mods folder"))
            {
                if (string.IsNullOrEmpty(ProgramData.GameModsFolder))
                    User32.MessageBox(IntPtr.Zero, "No RedNodeLoader/mods folder found. Did you install RedNodeLoader?");
                else
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = ProgramData.GameModsFolder,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
            }

            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.FileExport} Runtime"))
        {
            if (ImGui.MenuItem("Execute mod", "Ctrl+E"))
            {
                PipeManager.ExecuteMod();
            }
            Drawings.NodeTooltip("Directly execute the node connections while in game.\nGame must be open and RedNodeLoader installed");

            if (ImGui.MenuItem("Stop execution", "Ctrl+T"))
            {
                PipeManager.StopExecution();
            }

            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.Code} Build"))
        {
            if (ImGui.MenuItem("Build Mod", "Ctrl+B"))
            {
                ProjectDialogBuild.ShowDialog = true;
            }
            ImGui.Checkbox("Build to mods folder", ref ProgramData.OutputToGameFolder);
            Drawings.NodeTooltip("If checked and the directory exist, outputs the mod file in the SonsOfTheForest/Mods/RedNodeLoader/Mods folder");

            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.CircleInfo} Help"))
        {
            ImGui.Text("Shortcuts");
            Drawings.NodeTooltip(ShortcutHelp.ShortcutInfo);

            if (ImGui.MenuItem("Documentation"))
                Process.Start(new ProcessStartInfo("https://alexs-organization-34.gitbook.io/rednodeeditor/") { UseShellExecute = true });

            if (ImGui.MenuItem("SOTF Discord"))
                Process.Start(new ProcessStartInfo("https://discord.gg/sotf") { UseShellExecute = true });

            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu($"{FontAwesome6.CircleUser} About"))
        {
            AboutDialog.ShowDialog = true;
            ImGui.EndMenu();
        }
        ImGui.EndMenuBar();
    }
}