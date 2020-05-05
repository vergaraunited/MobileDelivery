//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using UMDGeneral.Data;
//using UMDGeneral.Interfaces;
//using UMDGeneral.Settings;
//using UMDGeneral.Utilities;
//using static UMDGeneral.Definitions.MsgTypes;

//namespace MobileDataManager.WinSysInterface
//{
   
//    public class WinsysManifest
//    {
//        static SocketSettings srvSet;
//        SendMsgDelegate sm;

//        public WinsysManifest(WinSysDBFile srcWinsysFile=null, ReceiveMsgDelegate cbClient=null)
//        {
//            if (srvSet==null)
//                srvSet = new SocketSettings() { url = "localhost", port = 8181, name="Manager API"};

//            WinsysClientWebSocket.isaDriver().Init(srvSet, ref sm, cbClient);
//            WinsysClientWebSocket.isaDriver().Connect();
//        }

//        public bool Persist(ManifestMasterData md)
//        {
//            //WinsysData.InsertData("Insert into tableManifest values {}");
//            return true;
//        }
//        public bool QueryWinsys(manifestRequest req)
//        {
//            return WinsysClientWebSocket.isaDriver().SendMessage( req );
//        }


//    }
//}
