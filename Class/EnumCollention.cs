using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KHK_portfolio
{
    public delegate void ToolBarButtonClickHandler(string frmName, string buttonName, string scanData);
    public delegate void SerialPortReceivedHandler(string frmName, string buttonName, string scanData);

    public enum MsgType
    {
        INFO,
        OK,
        ERROR,
        WARNING
    }

    public enum RegistryType
    {
        SERVER_IP,
        SERVER_URL,
        USER_ID,
        ENTP_CODE
    }

    //메뉴 추가 및 삭제시 변경
    public enum MenuType
    {
        MES,
        SPC,
        FAVORITES
    }
    public enum WorkType
    {
        GET,
        SET
    }

    public enum FormEventString
    {
        LOAD,
        CLOSING
    }

    public enum SerialPortName
    {
        SERIAL1,
        SERIAL2,
        SERIAL3,
        SERIAL4
    }

    public enum SerialUseType
    {
        SCANNER,
        WEIGHT
    }

    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    
}
