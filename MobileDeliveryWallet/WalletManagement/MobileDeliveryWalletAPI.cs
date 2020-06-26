using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileDeliveryGeneral.DataManager.Interfaces;
using MobileDeliveryGeneral.Interfaces;
using MobileDeliveryGeneral.Settings;
using MobileDeliveryGeneral.Utilities;
using MobileDeliveryLogger;
using MobileDeliverySettings.Settings;
using static MobileDeliveryGeneral.Definitions.MsgTypes;

namespace MobileDeliveryWallet.WalletManagement
{
    public class MobileDeliveryWalletAPI : isaMDM
    {
        public static string AppName;
        public ProcessMsgDelegateRXRaw pmRx { get; private set; }
        ReceiveMsgDelegate rm;
        SendMsgDelegate sm;
        SendMessages WinSysSM;

        public MobileDeliveryWalletAPI()
        {
        }

        WalletServer wsrv;

        public void Init(UMDAppConfig config)
        {
            rm = new ReceiveMsgDelegate(ReceiveMessage);
            pmRx = new ProcessMsgDelegateRXRaw(HandleClientCmd);
            AppName = config.AppName;
            Logger.Debug($"{config.AppName} Connection init");

            if (config.srvSet == null)
            {
                Logger.Error($"{config.AppName} Missing Configuration Server Settings");
                throw new Exception($"{config.AppName} Missing Configuration Server Settings.");
            }

            wsrv = new WalletServer(config);
        }

        Dictionary<Guid, Func<byte[], Task>> dRetCall = new Dictionary<Guid, Func<byte[], Task>>();
        public isaCommand ReceiveMessage(isaCommand cmd)
        {
            switch (cmd.command)
            {
                case eCommand.Ping:
                    Logger.Debug($"ReceiveMessage - Received Ping / Replying Pong..");
                    WinSysSM.SendMessage(new Command() { command = eCommand.Pong });
                    break;
                case eCommand.Pong:
                    Logger.Debug($"ReceiveMessage - Received Pong");
                    break;
                case eCommand.GetNewHeads:
                    Logger.Debug("GetNewHeads");
                    manifestRequest req = (manifestRequest)cmd;
                    dRetCall[NewGuid(cmd.requestId)](req.ToArray());
//                    cbsend(new Command() { command = eCommand.GetNewHeads }.ToArray());
                    break;
                case eCommand.CreateCustomerAccount:
                    Logger.Debug("CreateCustomerAccount");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                   // cbsend(new Command() { command = eCommand.CreateCustomerAccount }.ToArray());
                    break;
                case eCommand.GetCustomerBalance:
                    Logger.Debug("GetCustomerBalance");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                case eCommand.CreateOrder:
                    Logger.Debug("CreateOrder");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                case eCommand.ConfirmDelivery:
                    Logger.Debug("ConfirmDelivery");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                case eCommand.Withdraw:
                    Logger.Debug("Withdraw");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                case eCommand.SweepToCold:
                    Logger.Debug("SweepToCold");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                case eCommand.TransferToHot:
                    Logger.Debug("TransferToHot");
                    dRetCall[NewGuid(cmd.requestId)](cmd.ToArray());
                    break;
                default:
                    Logger.Error("ReceiveMessage - ERROR Unknown command.  Parse Error MDM-API");
                    break;
            }
            return cmd;
        }
        public void HandleClientCmd(byte[] bytes_cmd, Func<byte[], Task> cbsend)
        {
            isaCommand cmd = new Command().FromArray(bytes_cmd);
            switch (cmd.command)
            {
                case eCommand.GetNewHeads:
                    Logger.Debug("GetNewHeads");
                    cbsend(new Command() { command = eCommand.GetNewHeads}.ToArray());
                    break;
                case eCommand.CreateCustomerAccount:
                    Logger.Debug("CreateCustomerAccount");
                    cbsend(new Command() { command = eCommand.CreateCustomerAccount }.ToArray());
                    break;
            case eCommand.GetCustomerBalance:
                    Logger.Debug("GetCustomerBalance");
                    cbsend(new Command() { command = eCommand.GetCustomerBalance }.ToArray());
                    break;
                case eCommand.CreateOrder:
                    Logger.Debug("CreateOrder");
                    cbsend(new Command() { command = eCommand.CreateOrder }.ToArray());
                    break;
                case eCommand.ConfirmDelivery:
                    Logger.Debug("ConfirmDelivery");
                    cbsend(new Command() { command = eCommand.ConfirmDelivery }.ToArray());
                    break;
                case eCommand.Withdraw:
                    Logger.Debug("Withdraw");
                    cbsend(new Command() { command = eCommand.Withdraw }.ToArray());
                    break;
                case eCommand.SweepToCold:
                    Logger.Debug("SweepToCold");
                    cbsend(new Command() { command = eCommand.SweepToCold }.ToArray());
                    break;
                case eCommand.TransferToHot:
                    Logger.Debug("TransferToHot");
                    cbsend(new Command() { command = eCommand.TransferToHot }.ToArray());
                    break;
                default:
                    Logger.Error("HandleWalletClientCmd - ERROR Unknown command.  Parse Error MDM-API");
                    break;
            }
        }
        public bool SendMessage(isaCommand cmd)
        {
            return WinSysSM.SendMessage(cmd);
        }
            
    }
}
