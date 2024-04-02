using RedLoader;
using SonsSdk;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedNodeLoader;

public class PipeManager
{
    static List<string> _lastIds = new();
    static List<string> _lastCustomEventsIds = new();

    static List<LemonAction> _lastGameStart = new();
    static List<LemonAction> _lastWorldUpdate = new();
    static List<LemonAction> _lastUpdate = new();
    static List<LemonAction> _lastFixedUpdate = new();

    static readonly string _pipeName = "RedNodePipe";

    public static void WaitForConnection()
    {
        try
        {
            NamedPipeServerStream pipeServer = new NamedPipeServerStream(_pipeName,
               PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
        }
        catch (Exception oEX)
        {
            RLog.Error(oEX.Message);
        }
    }

    private static void WaitForConnectionCallBack(IAsyncResult iar)
    {
        try
        {
            NamedPipeServerStream pipeServer = (NamedPipeServerStream)iar.AsyncState;
            pipeServer.EndWaitForConnection(iar);

            using (StreamReader reader = new StreamReader(pipeServer))
            {
                try
                {
                    // Read the length of the incoming message
                    int length = int.Parse(reader.ReadLine());

                    // Read the XML string with the specified length
                    char[] buffer = new char[length];
                    reader.Read(buffer, 0, length);
                    string rmod = new string(buffer, 0, length);

                    if (rmod == "stop")
                    {
                        CleanPreviousMod();
                        CreateNewServer(pipeServer);
                        return;
                    }

                    var modData = Serialization.GetModDataFromContent(rmod);

                    CleanPreviousMod();

                    // saving nodes id's for later cleanup
                    modData.OnGameStart.ForEach(connection => {
                        var storedId = RedNodeLoader.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    modData.OnWorldUpdate.ForEach(connection => {
                        var storedId = RedNodeLoader.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    modData.OnUpdate.ForEach(connection => {
                        var storedId = RedNodeLoader.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    modData.OnFixedUpdate.ForEach(connection => {
                        var storedId = RedNodeLoader.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    var eventNodesAndCustomEvents_Ids = RedNodeLoader.PopulateCustomEvents(modData);
                    _lastIds.AddRange(eventNodesAndCustomEvents_Ids.Item1); // nodes of custom events
                    _lastCustomEventsIds.AddRange(eventNodesAndCustomEvents_Ids.Item2); // custom events nodes

                    // subscriptions
                    modData.OnGameStart.ForEach(connection => {
                        _lastGameStart.Add(connection.Node.Execute);
                        SdkEvents.OnGameStart.Subscribe(connection.Node.Execute);
                    });

                    modData.OnWorldUpdate.ForEach(connection => {
                        _lastWorldUpdate.Add(connection.Node.Execute);                     
                        SdkEvents.OnInWorldUpdate.Subscribe(connection.Node.Execute);
                    });

                    modData.OnUpdate.ForEach(connection => {
                        _lastUpdate.Add(connection.Node.Execute);
                        GlobalEvents.OnUpdate.Subscribe(connection.Node.Execute);
                    });

                    modData.OnFixedUpdate.ForEach(connection => {
                        _lastFixedUpdate.Add(connection.Node.Execute);
                        GlobalEvents.OnFixedUpdate.Subscribe(connection.Node.Execute);
                    });
                }
                catch (Exception e)
                {
                    RLog.Error("Error processing mod: " + e.Message);
                }
            }

            CreateNewServer(pipeServer);
        }
        catch
        {
            return;
        }
    }

    private static void CreateNewServer(NamedPipeServerStream pipeServer)
    {
        pipeServer.Close();
        pipeServer = null;
        pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.In,1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
    }

    private static void CleanPreviousMod()
    {
        // global cleanup of used nodes
        foreach (var id in _lastIds.ToList())
        {
            RedNodeLoader.IdNodePair.Remove(id);
            _lastIds.Remove(id);
        }

        foreach (var id in _lastCustomEventsIds.ToList())
        {
            RedNodeLoader.CustomEvents.Remove(id);
            _lastCustomEventsIds.Remove(id);
        }

        // unsubscriptions
        foreach (var action in _lastGameStart.ToList())
        {
            SdkEvents.OnGameStart.Unsubscribe(action);
            _lastGameStart.Remove(action);
        }

        foreach (var action in _lastWorldUpdate.ToList())
        {
            SdkEvents.OnInWorldUpdate.Unsubscribe(action);
            _lastWorldUpdate.Remove(action);
        }

        foreach (var action in _lastUpdate.ToList())
        {
            GlobalEvents.OnUpdate.Unsubscribe(action);
            _lastUpdate.Remove(action);
        }

        foreach (var action in _lastFixedUpdate.ToList())
        {
            GlobalEvents.OnFixedUpdate.Unsubscribe(action);
            _lastFixedUpdate.Remove(action);
        }
    }
}
