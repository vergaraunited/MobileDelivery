using MobileDeliveryGeneral.Interfaces;
using MobileDeliveryGeneral.Settings;
using MobileDeliveryLogger;
using MobileDeliveryServer;
using MobileDeliverySettings.Settings;
using MobileDeliveryWallet.WalletManagement;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MobileDeliveryWallet
{
    class MobileDeliveryWalletStartup
    {
        static Logger logger;
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var config = WinformReadSettings.GetSettings(typeof(MobileDeliveryWalletStartup));

            logger = new Logger(config.AppName + "_" + config.srvSet.port.ToString(), config.LogPath, config.LogLevel);
            Logger.Info($"Starting {config.AppName} {config.srvSet.port.ToString()} {config.Version} {DateTime.Now}");
            Logger.Info($"Logfile: {config.LogPath}");

            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };
            MobileDeliveryWalletAPI det = new MobileDeliveryWalletAPI();
            Task.Run(() => { det.Init(config); });

            Logger.Info($"Connection details {config.AppName}:/n/tUrl:/t{config.srvSet.url}/n/tPort:/t{config.srvSet.port}");
           
            ProcessMsgDelegateRXRaw pmRx = new ProcessMsgDelegateRXRaw(det.HandleClientCmd);
            
            // kick off asynchronous stuff 
            _quitEvent.WaitOne();
        }
    }
}
