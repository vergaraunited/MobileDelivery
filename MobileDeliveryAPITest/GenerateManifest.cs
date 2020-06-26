using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileDeliveryClient.API;
using MobileDeliveryGeneral.Definitions;
using MobileDeliveryGeneral.Interfaces;
using MobileDeliveryLogger;
using MobileDeliveryMVVM.MobileDeliveryServer;
using MobileDeliverySettings.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;
using static MobileDeliveryGeneral.Definitions.MsgTypes;

namespace MobileDeliveryAPITest
{
    [TestClass]
    public class GenerateManifest
    {
        private object smWinsys;
        ClientToServerConnection srvr;
        void Connect(ref SendMsgDelegate sm, ReceiveMsgDelegate rm)
        {
            var config = WinformReadSettings.GetSettings(typeof(GenerateManifest));

            Logger logger = new Logger(config.AppName, config.LogPath, config.LogLevel);
            Logger.Level = config.LogLevel;

            Logger.Info($"Starting {config.AppName} {config.Version} {DateTime.Now}");

           //  new ReceiveMsgDelegate(ReceiveMessageCB);
            Logger.Info($"Client Socket Connection Init: {config.AppName}");

            srvr = new ClientToServerConnection(config.srvSet, ref sm, rm);

            Logger.Info($"Client {config.srvSet.name} Socket Connecting to Server ws://{config.srvSet.srvurl}:{config.srvSet.srvport}.");
            var task = Task.Run(() => srvr.Connect());
        }

        private MsgTypes.isaCommand ReceiveMessageCB(MsgTypes.isaCommand cmd)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void QueryManifest()
        {
            SendMsgDelegate sm=null;
            Connect(ref sm,
                new ReceiveMsgDelegate((isacmd) => { Logger.Info($"{isacmd.ToString()}"); return isacmd; }));

            //create a new thread and wait for the wakeup event
            sm(new manifestRequest() { command = eCommand.GenerateManifest });

            for(int i=0;i<10;i++)
                Thread.Sleep(100);
            
        }
    }
}
