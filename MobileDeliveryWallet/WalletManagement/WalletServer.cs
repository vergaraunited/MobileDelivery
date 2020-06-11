using System;
using System.Collections.Generic;
using MobileDeliveryLogger;
using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.Interfaces;
using MobileDeliveryGeneral.Interfaces.DataInterfaces;
using MobileDeliveryGeneral.Threading;
using static MobileDeliveryGeneral.Definitions.enums;
using static MobileDeliveryGeneral.Definitions.MsgTypes;
using System.Threading.Tasks;
using MobileDeliveryClient.API;
using MobileDeliveryGeneral.Settings;

namespace MobileDeliveryWallet.WalletManagement
{
    public class WalletServer
    {
        //static GETH BlockchainBPIDData;
        //static UMDDB UMD_Data;
        ClientToServerConnection conn;
        string cnn;
        DateTime dt;
        SendMsgDelegate sm;
        ReceiveMsgDelegate rm;

        #region collections
          public List<WalletData> manifestMasterData = new List<WalletData>();
        #endregion

        #region backgroundworkers
        UMBackgroundWorker<WalletData> walletData;

        #endregion

        #region progressupdates
        UMBackgroundWorker<WalletData>.ProgressChanged<WalletData> pcWallet;
        #endregion

        public WalletServer(UMDAppConfig config)
        {
            Logger.Info($"WalletServer::Websocket connection: {config.srvSet.srvurl}");
            
            conn = new ClientToServerConnection(
                config.srvSet, ref sm, rm);
            conn.Connect();
        }

        public double SubscribeGetNewHeads() {

            Logger.Debug("GetNewHeadds");
            conn.SendCommandToServer(new Command() { command = eCommand.GetNewHeads });
            
            return 0.0;
        }
        public IMDMMessage QueryData(Func<byte[], Task> cb, isaCommand dat)
        {
            return null;
        }


        public IEnumerable<IMDMMessage> Persist(SPCmds sp, IMDMMessage md)
        {
            Logger.Info($"Persist {md.ToString()}");
           // foreach (var it in UMD_Data.InsertData(sp, md))
                yield return null;
        }
    
    }
}
