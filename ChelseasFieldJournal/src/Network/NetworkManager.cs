using static Ele.ChelseasFieldJournal.ModConstants;
using System;
using Vintagestory.API.Client;
using Vintagestory.API.Server;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace Ele.ChelseasFieldJournal;

public class NetworkManager : ModSystem
{
    public override double ExecuteOrder() => 0.04;

    #region Client
    ICoreClientAPI _capi;
    ICoreServerAPI _sapi;
    IClientNetworkChannel _clientChannel;
    
    public override void StartClientSide(ICoreClientAPI capi)
    {
        _capi = capi;
        _clientChannel =
            capi.Network.RegisterChannel(Main_Channel)
                .RegisterMessageType(typeof(PlaceholderMessage.Request))
                .RegisterMessageType(typeof(PlaceholderMessage.Response))
                .SetMessageHandler<PlaceholderMessage.Response>(OnServerMessageReceived);
    }
    
    private void OnServerMessageReceived(PlaceholderMessage.Response response)
    {
        
    }
    #endregion
    
    #region Server
    IServerNetworkChannel _serverChannel;
    ICoreServerAPI sapi;

    public override void StartServerSide(ICoreServerAPI sapi)
    {
        _sapi = sapi;
        _serverChannel =
            sapi.Network.RegisterChannel(Main_Channel)
                .RegisterMessageType(typeof(PlaceholderMessage.Request))
                .RegisterMessageType(typeof(PlaceholderMessage.Response))
                .SetMessageHandler<PlaceholderMessage.Request>(OnClientMessageRequested);
    }
    
    private void OnClientMessageRequested(IServerPlayer player, PlaceholderMessage.Request request)
    {
        
    }
    #endregion
}