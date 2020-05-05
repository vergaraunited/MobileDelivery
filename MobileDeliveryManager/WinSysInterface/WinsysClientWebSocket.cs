//using MobileDeliveryClient.API;
//using MobileDeliveryLogger;
//using System;
//using UMDGeneral.Data;
//using UMDGeneral.Definitions;
//using UMDGeneral.Interfaces;
//using UMDGeneral.Settings;
//using UMDGeneral.Utilities;
//using static UMDGeneral.Definitions.MsgTypes;

//namespace MobileDataManager.WinSysInterface
//{                           
//    public class WinsysClientWebSocket : isaMobileDeliveryClient
//    {
//        const ushort defPort = 80;
//        UMDServerConnection conn;
//        ReceiveMessages rmsg;
////        ReceiveMessages WinSysMsg;
//        SendMessages smsg;
//        //MsgProcessor proc;
//        //private WinsysClientWebSocket WinSysServer;
//        static string URL;
//        static ushort nport;
//        static string Name;
//        public string Url { get => URL; set => URL = value; }
//        public ushort Port { get => nport; set => nport = value; }

//        //public string APIUrl { get => throw new Exception("No API in WinSys"); set => throw new Exception("No API in WinSys"); }
//        //public ushort APIPort { get => throw new Exception("No API in WinSys"); set => throw new Exception("No API in WinSys"); }

//        public string name { get => Name; set => Name = value; }

//        //public static WinsysClientWebSocket isaDriver()
//        //{
//        //    if (WinSysServer == null)
//        //    {
//        //        WinSysServer = new WinsysClientWebSocket();
//        //    }
                
//        //    return WinSysServer;
//        //}
//        public WinsysClientWebSocket()
//        {

//        }

//        void isaMobileDeliveryClient.Init(SocketSettings settings, ref SendMsgDelegate sm, ReceiveMsgDelegate rcvMsg=null)
//        {
//            throw new NotImplementedException();
//        }

//        bool isaSendMessageCallback.SendMessage(isaCommand cmd)
//        {
//            throw new NotImplementedException();
//        }



//        public void Init(SocketSettings srvSet, ref SendMsgDelegate sm, ReceiveMsgDelegate rm = null)
//        {
//            if (rm != null)
//                rmsg = new ReceiveMessages(rm);
//            else
//                rmsg = new ReceiveMessages(new ReceiveMsgDelegate(MsgProcessor.ReceiveMessage));
            
//            Url = srvSet.url;
//            Port = srvSet.port;
//            name = srvSet.name;

//            //Darwin builds work with Android and Android Emulator has it's own virtual network thus need to use the actual machine IP.
//            string urlo = Environment.OSVersion.Platform.CompareTo(PlatformID.MacOSX) != 0 ? Url : "192.168.1.6";
//            conn = new UMDServerConnection(srvSet, ref sm, rmsg);
//        }

//        public bool Connect()
//        {
//            conn.StartAsync();
//            return true;
//        }
//        public bool Disconnect()
//        {
//            conn.Disconnect();
//            return true;
//        }
//        isaCommand isaReceiveMessageCallback.ReceiveMessage(isaCommand cmd)
//        { return ReceiveMessage(cmd); }
//        isaCommand ReceiveMessage(isaCommand cmd)
//        {
//            switch (cmd.command)
//            {
//                case eCommand.Ping:
//                    Logger.Debug("Command Ping recevied!");
//                    SendMsg(new Command { command = eCommand.Pong });
//                    break;
//                //case eCommand.LogOff:
//                //    break;
//                case eCommand.Pong:
//                    Logger.Debug("Command Pong recevied!");
//                    break;
//                case eCommand.Manifest:
//                    Logger.Debug("Manifest Load Update!");
//                    //cmd = WinSysMsg.ReceiveMessage(cmd);
//                    //ManifestUpdateReceived()
//                    break;
//                case eCommand.ManifestLoadComplete:
//                    Logger.Debug("Manifest Load Complete!");
//                   // cmd = WinSysMsg.ReceiveMessage(cmd);
//                    //ManifestUpdateReceived()
//                    break;
//                case eCommand.ManifestDetails:
//                    Logger.Debug("Manifest Details Update!");
//                   // cmd = WinSysMsg.ReceiveMessage(cmd);
//                    break;
//                case eCommand.Orders:
//                    Logger.Debug("OrderUpdates");
//                    //cmd = WinSysMsg.ReceiveMessage(cmd);
//                    break;
//                case eCommand.OrderDetails:
//                    Logger.Debug("OrderDetails");
//                    //cmd = WinSysMsg.ReceiveMessage(cmd);
//                    break;
//                case eCommand.GenerateManifest:
//                    Logger.Debug("Generate Manifest");
//                   // cmd = WinSysMsg.ReceiveMessage(cmd);
//                    break;
//                default:
//                    Logger.Debug("Manifest Load Update!");
//                    //cmd = WinSysMsg.ReceiveMessage(cmd);
//                    break;
//            }
//            return cmd;
//        }

//        public Boolean SendMessage(isaCommand cmd)
//        {
//            return conn.SendWinsysCommand(cmd);
//        }

//        public bool SendMsg(isaCommand outCmd)
//        {
//            //conn.StartLoadingData();
//            switch(outCmd.command)
//            {
//                case eCommand.DeliveryComplete:
//                    //conn.CompleteStop(new Command { command = eCommand.DeliveryComplete });
//                break;
//                default:
//                    Logger.Error("Unknown command : SendMsg Server Comm - Universal");
//                    break;
//            }
//            return true;
//        }
//    }
//}
