using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace FrictionTester
{
    public enum TestTypes
    {
        Ħ���ж�,
        ײ���ж�
    }

    public enum ControlTypes
    {
        PLC,
        RS232
    }

    class GlobalCofigData
    {

         public  static SystemConfigSection SystemConfig;

         public static SerialConfigSection SerialConfig;
          
         public static Configuration Config;

          /// <summary>
          /// ����λ��ͨѸ������Э��
          /// </summary>
          public static byte[] MicroControllorPreferences;
       
     }

    public class SerialConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Braudrate")]
        public int Braudrate
        {
            get { return (int)this["Braudrate"]; }
            set { this["Braudrate"] = value; }
        }

        [ConfigurationProperty("DataBites")]
        public int DataBites
        {
            get { return (int)this["DataBites"]; }
            set { this["DataBites"] = value; }
        }

        [ConfigurationProperty("StopBit")]
        public int StopBit
        {
            get { return (int)this["StopBit"]; }
            set { this["StopBit"] = value; }
        }

        [ConfigurationProperty("Parity")]
        public int Parity
        {
            get { return (int)this["Parity"]; }
            set { this["Parity"] = value; }
        }


      //  public string Syn;


        [ConfigurationProperty("PortName")]
        public string PortName
        {
            get { return (string)this["PortName"]; }
            set { this["PortName"] = value; }
        }

        public SerialConfigSection()
        {
            Braudrate = 9600;
            DataBites = 8;
            StopBit = 1;
            PortName = "COM1";
            Parity = 0;

        }
    }


    public delegate void TestTypeChangedEventHandler(object sender, EventArgs e);
    public class SystemConfigSection : ConfigurationSection
    {
        public SystemConfigSection()
        {

            //�������
            PowerPolar = "������";
            Resister = "0��";
            Capacity = "500pF";
 //�������

            if (SDAF.DataOperateLib.EquipMentTypes.JDGD == SDAF.DataOperateLib.DataOperate.EquipMentType)
            {
                H0 = 5;
                Step = 0.5f;
                PrepareH0 = 5;
            }
            else
            {
                H0 = 100;
                Step = 5;
                PrepareH0 = 100;
            }
          
            DistanceAdjust = 500f;
          
            
            SerialNo = 10;
            DisplacementCoefficient = 1.0f;
            PassWord = "";
            UserName = "Juncheng";
            RiseUpSpeed = 100;
            PrepareSpeed = 100;
            SampleNo = "";
            MicroControllorPreferences = "F0,F1,F5,F6,F7,E1,E2,E3,E5,E6,f4,E7,F8,EA,EB,FA,FB";
            //�˵ط������ã����������¼� δ�������������õ������ʵ��
            //if (SDAF.DataOperateLib.DataOperate.isHYGD) TestType = TestTypes.����ж�����;
            //else TestType = TestTypes.ײ���ж�����;
        }



     
         //�������
        [ConfigurationProperty("PowerPolar")]
        public string PowerPolar
        {
            get { return (string)this["PowerPolar"]; }
            set { this["PowerPolar"] = value; }
        }
                [ConfigurationProperty("Resister")]
        public string Resister
        {
            get { return (string)this["Resister"]; }
            set { this["Resister"] = value; }
        }
                [ConfigurationProperty("Capacity")]
        public string Capacity
        {
            get { return (string)this["Capacity"]; }
            set { this["Capacity"] = value; }
        }
        //�������


        public event TestTypeChangedEventHandler TestTypeChanged;
  
        [ConfigurationProperty("UserName")]
        public string UserName
        {
            get { return (string)this["UserName"]; }
            set { this["UserName"] = value; }
        }

        [ConfigurationProperty("SampleNo")]
        public string SampleNo
        {
            get { return (string)this["SampleNo"]; }
            set { this["SampleNo"] = value; }
        }


        [ConfigurationProperty("DisplacementCoefficient")]
        public float DisplacementCoefficient
        {
            get { return (float)this["DisplacementCoefficient"]; }
            set { this["DisplacementCoefficient"] = value; }
        }



        [ConfigurationProperty("MaxFireDistance")]
        public float DistanceAdjust
        {
            get { return (float)this["MaxFireDistance"]; }
            set { this["MaxFireDistance"] = value; }
        }


        [ConfigurationProperty("TargetDistance")]
        public float TargetDistance
        {
            get { return (float)this["TargetDistance"]; }
            set { this["TargetDistance"] = value; }
        }

        [ConfigurationProperty("H0")]
        public float H0
        {
            get { return (float)this["H0"]; }

            set { this["H0"] = value; }
        }

        [ConfigurationProperty("Step")]
        public float Step
        {
            get { return (float)this["Step"]; }
            set { this["Step"] = value; }
        }

        [ConfigurationProperty("AutoOffFireDelayTime")]
        public UInt16 AutoOffFireDelayTime
        {
            get { return (UInt16)this["AutoOffFireDelayTime"]; }
            set { this["AutoOffFireDelayTime"] = value; }
        }

        [ConfigurationProperty("RiseUpSpeed")]
        public int RiseUpSpeed
        {
            get { return (int)this["RiseUpSpeed"]; }
            set { this["RiseUpSpeed"] = value; }
        }

        [ConfigurationProperty("PrepareSpeed")]
        public int PrepareSpeed
        {
            get { return (int)this["PrepareSpeed"]; }
            set { this["PrepareSpeed"] = value; }
        }



        [ConfigurationProperty("SerialNo")]
        public int SerialNo
        {
            get { return (int)this["SerialNo"]; }
            set { this["SerialNo"] = value; }
        }


        [ConfigurationProperty("PrepareH0")]
        public float PrepareH0
        {
            get { return (float)this["PrepareH0"]; }
            set { this["PrepareH0"] = value; }
        }

        [ConfigurationProperty("TestType")]
        public TestTypes TestType
        {
            get { return (TestTypes)this["TestType"]; }

           set { this["TestType"] = value; 
            //    TestTypeChanged(new Object(), new EventArgs());
            }
        }


        [ConfigurationProperty("ControlType")]
        public ControlTypes ControlType
        {
            get { return (ControlTypes)this["ControlType"]; }

            set
            {
                this["ControlType"] = value;
                //    TestTypeChanged(new Object(), new EventArgs());
            }
        }

        /// <summary>
        /// �û����� �����ļ������������Ч ���뱣����ע����� �����ݿ������������
        /// </summary>
        [ConfigurationProperty("PassWord")]
        public string PassWord
        {
            get { return (string)this["PassWord"]; }
            set { this["PassWord"] = value; }
        }


        /// <summary>
        /// �¶�У����׼ֵ
        /// </summary>
        [ConfigurationProperty("MicroControllorPreferences")]
        public string MicroControllorPreferences
        {
            get { return (string)this["MicroControllorPreferences"]; }
            set { this["MicroControllorPreferences"] = value; }
        }


    }
}
