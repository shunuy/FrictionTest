using System;
using System.Collections.Generic;
using System.Text;

namespace FrictionTester
{
    enum SystemStatuses
    {
        NotConnected,
        SystemReady,//系统就绪 样盘位于燃烧位
        BeTesting,
        BeManualTest,
        WaitingReturnStatus,
        Preparing,//预压过程中
        SamplePositionError,//
        //  SampleOut
    };
    enum TestPhases
    {
        AshConeNone,
        AshConeDetect,
        AshConeIdentify
    }
    enum ConstantTempModes
    {
        ON=0,
        OFF=1,
        ORIGIN_HEAT=2,
        ORIGIN=3
    }
    public delegate void SystemStatusChangedEventHandler(object sender, EventArgs e);
    public delegate void ConstantTemperatureStatusChangedEventHandler(object sender, EventArgs e);
    public delegate void RealTemperatureChangedEventHandler();
    class GlobalData
    {
        public static SerialPortControl serialPort;




        // static int timerCount = 0;
        static long oldTime = DateTime.Now.Ticks;
        /// <summary>
        /// 人工检测窗口是否已经显示
        /// </summary>
        public static bool ManualTestShown = false;
        /// <summary>
        /// 通过位标志判定是否已经有相关错误的提示
        /// </summary>
        public static int ErrorShown;
        public static int ErrorCode;
        /// <summary>
        /// 实时温度改变引发的事件 
        /// </summary>
        //         public static event RealTemperatureChangedEventHandler RealTemperatureChanged;
        /// <summary>
        /// 实时温度
        /// </summary>

        public static float TemperatureMax = 0;
        public static float TemperatureOrigin = 0;
        public static float SmokeSensorMax = 0;
        public static float SmokeSensorOrigin = 0;

        private static float timercount = 0;
        public static float TimerCount
        {
            get
            {
                return timercount;
            }
            set
            {
                timercount = value;
            }
        }



        public static event ConstantTemperatureStatusChangedEventHandler ConstantTempModeChanged;
        private static ConstantTempModes constantTempMode = ConstantTempModes.ORIGIN;
        public static ConstantTempModes ConstantTempMode
        {
            get
            {
                return constantTempMode;
            }
            set
            {
                ConstantTempModes tempt = constantTempMode;
                constantTempMode = value;
                if (tempt != value )
                {

                    ConstantTempModeChanged(new Object(), new EventArgs());
                }
            }
        }




        public static int RealTemperatureTop;
        public static int RealTemperatureBottom;

        /// <summary>
        /// 是否第一次识别 即950度之前自动识别灰锥位置，用户又没作出反应
        /// </summary>
        public static bool IsFirstIdentify = true;

        public static  ServerUtil serverUtil;

        private static float sensorData1;
        /// <summary>
        /// 传感器数据1
        /// </summary>
        public static float Temperature
        {
            get
            {
                return sensorData1;
            }
            set
            {
                sensorData1 = value;

            }
        }


        private static float press;
        /// <summary>
        /// 传感器数据2
        /// </summary>
        public static float Press
        {
            get
            {
                return press;
            }
            set
            {
                press = value;

            }
        }

        private static float smokeSensor;
        /// <summary>
        /// 传感器数据3
        /// </summary>
        public static float SmokeSensor
        {
            get
            {
                return smokeSensor;
            }
            set
            {
                smokeSensor = value;

            }
        }

        private static float fireDistance;
        /// <summary>
        /// 传感器数据4
        /// </summary>
        public static float FireDistance
        {
            get
            {
                return fireDistance;
            }
            set
            {
                fireDistance = value;
            }
        }

        private static float mainTemperature;
        public static float MainTemperature
        {
            get
            {
                return mainTemperature;
            }
            set
            {
                mainTemperature = value;
            }
        }

        /// <summary>
        /// 实验状态改变引发的事件
        /// </summary>
        public static event SystemStatusChangedEventHandler SystemStatusChanged;


        public static int DebugTemperature = 0;
        /// <summary>
        /// 实验状态
        /// </summary>
        private static SystemStatuses systemStatus = SystemStatuses.NotConnected;
        public static bool SystemChangeEventEnabled = true;
        public static SystemStatuses SystemStatus
        {
            get
            {
                return systemStatus;
            }
            set
            {
                SystemStatuses tempt = systemStatus;
                systemStatus = value;
                if (tempt != value && SystemChangeEventEnabled)
                {
                    //  SystemStatusChangedEventHandler handler = SystemStatusChanged;
                    SystemStatusChanged(new Object(), new EventArgs());
                }
            }
        }

       /// <summary>
       /// 
       /// </summary>
        public static int DataRowIndex=0;

        /// <summary>
        /// 用于判断与USBCAN连接是否断开(>10时表示断开)
        /// </summary>
        public static int connectedCount = 100;

        public static String TestNo = "";


        public static FormStatus frmStatus;
        public static DateTime timeStartTest = DateTime.Now;

        public static bool BeDebug = true;
        public static int coldTemperatur = 0;
        /// <summary>
        /// 实验恢复界面
        /// </summary>
        public static bool BeRestoring = false;
        public static bool BeEnglsih = false;

        public static ClassControlDisp DispCotrol = new ClassControlDisp();
       


        public static float targetTemperature=0;
        public static float tempDiff = 0;
        public static int heatSpeed=0;
        public static int verSion = 0;
    
    };
}
