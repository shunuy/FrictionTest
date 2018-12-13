using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SDAF.DataOperateLib;

namespace FrictionTester
{
    public partial class FormConfigure : Form
    {
       private static readonly EnumValueStringPair m_PreparePhase = new EnumValueStringPair(TestTypes.Ԥ������);
        private static readonly EnumValueStringPair m_MainPhase = new EnumValueStringPair(TestTypes.��ʽ���� );
       


        public FormConfigure()
        {
            InitializeComponent();

            if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.BFD)
            {
                label4.Text = "��׼ֵ��:";
                label5.Text = "ʵ��ֵ��:";
                tabControl1.TabPages.Remove(tabPage12);
            }
            else tabControl1.TabPages.Remove(tabPage5);

            if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.JDGD)
            {

                lblStep.Text = "����(kV)��";
                label4.Text = "��׼ֵkV:";
                label5.Text = "ʵ��ֵkV:";
                lblH0.Text = "��ʼ��ѹH0(kV)";
                lblPrepareH0.Text = "Ԥ������H0(kV)";
                //edtMaxFireDistance.Visible = false;
                lblHeight.Text = "����϶(um):";
                //AutoFireFallDelayTime.Visible = true;
                //label3.Visible = false;
                //lblHeight.Visible = false;

                lblPower.Visible = true;
                lblCapacity.Visible = true;
                lblResister.Visible = true;
                cmbCapacity.Visible = true;
                cmbResister.Visible = true;
                cmbPower.Visible = true;
                cmbPower.Text = ( GlobalCofigData.SystemConfig).PowerPolar;

                cmbResister.Text= ( GlobalCofigData.SystemConfig).Resister;
                cmbCapacity.Text=( GlobalCofigData.SystemConfig).Capacity;

            }

            List<EnumValueStringPair> list4 = new List<EnumValueStringPair>();

            list4.Add(m_PreparePhase);
            list4.Add(m_MainPhase);
            
     
        
            this.cmbTestTypes.DataSource = list4;
            this.cmbTestTypes.DisplayMember ="EnumString";
            this.cmbTestTypes.ValueMember = "Enum";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SDAF.DataOperateLib.DataOperate.dataAdapterSampleTable.Update(SDAF.DataOperateLib.DataOperate.dataSet11.Tables["SampleTable"]);
            }
            catch (Exception err)
            {
                //if (err.Message == "���ڱ� 'TestData' ���˰�����ؼ�¼������ɾ����ı�ü�¼��") MessageBox.Show("�Ѳ���������Ʒ�����޸���Ч��", "��ʾ��Ϣ");
                //else
                //{
                //    MessageBox.Show("��Ʒ�����޸���Ч��", "��ʾ��Ϣ");
                //}
                GlobalData.frmStatus.WriteLog("FormConfigure.btnOK_Click: " + err.Message, false);
            }
           GlobalCofigData.SerialConfig.PortName= cmbPortNo.Text;
           try
           { //���û����ʱ���û��޷�ѡ��ʱ��SelectedValueΪnull ������
               GlobalCofigData.SystemConfig.TestType = (TestTypes)cmbTestTypes.SelectedValue;
           }
           catch (Exception err)
           {
           }
           GlobalCofigData.SystemConfig.PrepareSpeed = int.Parse(edtTempJuge.Text);
           GlobalCofigData.SystemConfig.RiseUpSpeed = int.Parse(edtSmogJuge.Text);
           GlobalCofigData.SystemConfig.DisplacementCoefficient = float.Parse(edtDispCoeff.Text);
           GlobalCofigData.SystemConfig.DistanceAdjust = float.Parse(edtMaxFireDistance.Text );
           GlobalCofigData.SystemConfig.PrepareH0 = float.Parse(edtPrepareH0.Text);

           if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) GlobalCofigData.SystemConfig.PrepareH0 = (int)GlobalCofigData.SystemConfig.PrepareH0;//V1.14


           //V1.14CS GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;


           GlobalCofigData.SystemConfig.SerialNo = int.Parse(edtSerialNo.Text);
  
           GlobalCofigData.SystemConfig.H0 = float.Parse(edtH0.Text);
           if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) GlobalCofigData.SystemConfig.H0 = (int)GlobalCofigData.SystemConfig.H0;//V1.14
           GlobalCofigData.SystemConfig.Step = float.Parse(edtStep.Text);

           if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) GlobalCofigData.SystemConfig.Step = (int)GlobalCofigData.SystemConfig.Step;//V1.14


           GlobalCofigData.SystemConfig.AutoOffFireDelayTime = UInt16.Parse(AutoFireFallDelayTime.Text);

           GlobalCofigData.SystemConfig.UserName = edtCurrentUser.Text;

           GlobalCofigData.SystemConfig.SampleNo = edtSampleNo.Text;

           SDAF.DataOperateLib.DataOperate.UpdateUserTable();
           GlobalCofigData.Config.Save(ConfigurationSaveMode.Modified);
           //if (GlobalCofigData.SystemConfig.PrepareH0 > GlobalCofigData.SystemConfig.MaxFireDistance)
           //{
           //    System.Windows.Forms.MessageBox.Show("�����趨���趨ֵ�Ѿ������������룡", "������ʾ");
           //    return;
           //}


           //V1.14CS
           if (GlobalCofigData.SystemConfig.TestType == TestTypes.Ԥ������)
           {
               if (GlobalCofigData.SystemConfig.SerialNo == 1)
                   GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;
           }
           else
           {
               if (GlobalCofigData.SystemConfig.SerialNo == 1)
                   GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.H0;
           }


           if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.JDGD)
           {

              ( GlobalCofigData.SystemConfig).PowerPolar= cmbPower.Text;
              ( GlobalCofigData.SystemConfig).Resister = cmbResister.Text;
              ( GlobalCofigData.SystemConfig).Capacity = cmbCapacity.Text;

           }

           if (checkBox1.Checked) GlobalCofigData.SystemConfig.ControlType = ControlTypes.PLC;
           else GlobalCofigData.SystemConfig.ControlType = ControlTypes.RS232;
         

           this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConfigure_Load(object sender, EventArgs e)
        {
            if (GlobalCofigData.SystemConfig.ControlType == ControlTypes.PLC) checkBox1.Checked = true;
            else checkBox1.Checked = false;

            c1FlexGrid1.DataSource = SDAF.DataOperateLib.DataOperate.dataSet11.Tables["SampleTable"];
            c1FlexGrid1.Cols["ID"].Visible = false;
            c1FlexGrid1.Cols["����"].Visible = false;
            c1FlexGrid1.Cols["��������"].Visible = false;
            c1FlexGrid1.Cols["��������"].Visible = false;
            c1FlexGrid1.Cols.Frozen = 1;
            for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
            {
                c1FlexGrid1.Cols[i].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                c1FlexGrid1.Cols[i].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                c1FlexGrid1.Cols[i].Width = 150;
            }
            c1FlexGrid1.Cols["�˹����"].Caption = "�������";



            if (GlobalData.SystemStatus == SystemStatuses.NotConnected)
            {
                //tabControl1.TabPages.Remove(tabPage12);
                //tabControl1.TabPages.Remove(tabPage2);

            }
            edtCurrentUser.Text = GlobalCofigData.SystemConfig.UserName;
            dgUser.DataSource = SDAF.DataOperateLib.DataOperate.dataSet11.Tables["UserTable"];
            dgUser.Cols["�û�����"].Width = 100;
            dgUser.Cols["�û�����"].Caption = Properties.Resources.ConfigureUserName;

            dgUser.Cols["ID"].Visible = false;
            dgUser.Cols["�û�����"].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            dgUser.Cols["�û�����"].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            dgUser.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;

           cmbPortNo.Text= GlobalCofigData.SerialConfig.PortName;
           cmbTestTypes.SelectedValue = GlobalCofigData.SystemConfig.TestType;
           edtDispCoeff.Text = GlobalCofigData.SystemConfig.DisplacementCoefficient.ToString("f4");
           edtMaxFireDistance.Text = GlobalCofigData.SystemConfig.DistanceAdjust.ToString("f1");
           AutoFireFallDelayTime.Text = GlobalCofigData.SystemConfig.AutoOffFireDelayTime.ToString();
           edtH0.Text = GlobalCofigData.SystemConfig.H0.ToString("f1");
           edtStep.Text = GlobalCofigData.SystemConfig.Step.ToString("f1");

           edtPrepareH0.Text = GlobalCofigData.SystemConfig.PrepareH0.ToString("f1");
           edtSerialNo.Text = GlobalCofigData.SystemConfig.SerialNo.ToString();

           edtTempJuge.Text = GlobalCofigData.SystemConfig.PrepareSpeed.ToString();
           edtSmogJuge.Text = GlobalCofigData.SystemConfig.RiseUpSpeed.ToString();
           edtSampleNo.Text=  GlobalCofigData.SystemConfig.SampleNo;

           label6.Text = "";


           edtTargeTemperatue.Text = GlobalData.targetTemperature.ToString("f1");
           edtHeatSpeed.Text = GlobalData.heatSpeed.ToString();
           edtTempDiff.Text = GlobalData.tempDiff.ToString("f1");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBiaoDing_Click(object sender, EventArgs e)
        {
            float biaoZhun = float.Parse(edtBiaoZhun.Text);
            float shiChe = float.Parse(edtShiChe.Text);
            float oldXishu = GlobalCofigData.SystemConfig.DisplacementCoefficient;
            float newXishu = oldXishu * biaoZhun / shiChe;
            edtDispCoeff.Text = newXishu.ToString("f4");
        }

        private void cmbPortNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "�ı�˿ں������������Ч��";
        }

        private void btnPasswordModify_Click(object sender, EventArgs e)
        {
            //FormPassword frmPassword = new FormPassword();
            //frmPassword.ShowDialog();
            //if (frmPassword.DialogResult == DialogResult.OK)
            {
                PasswordClear();
                btnPasswordOK.Enabled = true;
                btnPasswordModify.Visible = false;
            }
        }
        private void PasswordClear()
        {
            this.PassTxt1.Text = "";
            this.PassTxt2.Text = "";
            this.PassTxt3.Text = "";
            this.PassTxt1.Enabled = true;
            this.PassTxt2.Enabled = true;
            this.PassTxt3.Enabled = true;
        }

        private void btnPasswordOK_Click(object sender, EventArgs e)
        {
            if (!PassTxt3.Enabled) return;
            if (PassTxt1.Text == GlobalCofigData.SystemConfig.PassWord)
            {
                if (PassTxt2.Text == PassTxt3.Text)
                {
                    GlobalCofigData.SystemConfig.PassWord = PassTxt3.Text;
                    Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", GlobalCofigData.SystemConfig.PassWord);
                    StringBuilder Str = new StringBuilder(Properties.Resources.DataBaseName);
                    IntPtr hWnd = WindowsDll.FindWindow(null, Str);
                    if (hWnd != null)
                    {
                        WindowsDll.SendMessage(hWnd, 0x501, 0, 0);//֪ͨ���ݿ��������
                    }
                    //   PasswordClear();
                    label33.Text = "�����޸ĳɹ�!"; //(String)configureResources.GetObject("label33.Text");
                    label33.Visible = true;
                }
                else
                {
                    //"����ȷ�ϴ���!";
                    label33.Text = Properties.Resources.NewPasswordErr;
                    label33.Visible = true;
                    //   PasswordClear();
                    PassTxt3.Focus();
                }
            }
            else
            {
                //"ԭ�����������!";
                label33.Text = Properties.Resources.OldPasswordErr;
                label33.Visible = true;
                // PasswordClear();
                PassTxt1.Focus();
            }
        }
        private void addBut_Click(object sender, EventArgs e)
        {
            //int index = DataOperate.dataSet11.Tables["UserTable"].Rows.Count - 1;
            //if (dgUser.Rows[dgUser.Rows.Count - 1]["�û�����"] is DBNull) return;
            //if (index < 9)
            //{
            //     DataRow newRow = DataOperate.dataSet11.Tables["UserTable"].NewRow();
            //     newRow["ID"] = dgUser.Rows.Count - 1;//dgUser.Rows=DataOperate.dataSet11.Tables["UserTable"].Rows+1
            //     DataOperate.dataSet11.Tables["UserTable"].Rows.Add(newRow);
            //}
        }

        private void FormConfig_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {

        }
        private void FormConfig_RowChanged(object sender, DataRowChangeEventArgs e)
        {
        }
        private void dgUser_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                //if (((string)dgUser.Rows[e.Row - 1]["�û�����"]).Trim() == "") 
                //     e.Cancel = true;
                //else
                {
                    System.Random random = new Random();
                    dgUser.Rows[e.Row]["ID"] = e.Row * 10000 + random.Next(9999);
                }
            }
            catch (Exception)
            {
            }
        }
        private void dteBut_Click(object sender, EventArgs e)
        {
            try
            {
                dgUser.FinishEditing(true);
                dgUser.Redraw = false;

                foreach (C1.Win.C1FlexGrid.Row r in dgUser.Rows.Selected) dgUser.Rows.Remove(r);

                //������ʱɾ����������
                //ArrayList deletedArray = new ArrayList();
                //int deletedIndex = 0;
                //foreach (C1.Win.C1FlexGrid.Row r in dgUser.Rows.Selected)
                //{
                //    deletedIndex = r.Index - 1;
                //    deletedArray.Add(deletedIndex);
                //}
                //for (int i = deletedArray.Count; i > 0; i--)
                //{
                //    int index = (int)deletedArray[i - 1];
                //    if (index >= 0 && index < DataOperate.dataSet11.Tables["UserTable"].Rows.Count) DataOperate.dataSet11.Tables["UserTable"].Rows[index].Delete();
                //}
                dgUser.Redraw = true;
            }
            catch (Exception err)
            {
                GlobalData.frmStatus.WriteLog(err.ToString(), false);
            }
            //int m = dgUser.Row;
            //int n = dgUser.Rows.Count ;//ɾ����¼�� ����ֵ��һ�� dgUser.Rows.Count  DataOperate.dataSet11.Tables["UserTable"].Rows.Count;
            //if (n <4)
            //{
            //     //"����Ԥ��һ����¼��"
            //    MessageBox.Show(this,Properties.Resources.MustOneLeft, SDAF.Properties.Resources.HintCaption, MessageBoxButtons.OK , MessageBoxIcon.Asterisk);
            //    return;
            //}
            //else
            //{
            //     //"��ȷ��Ҫɾ��ѡ����¼��"
            //     DialogResult result = MessageBox.Show(this, Properties.Resources.AskDeleteRecord, SDAF.Properties.Resources.HintCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //     if (result == DialogResult.Yes)              dgUser.Rows.Remove(m); 
            //}
        }
        private void btnSetUser_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgUser.Row;
                if (dgUser.Rows[index]["�û�����"] == null || dgUser.Rows[index]["�û�����"] is DBNull)
                {
                    edtCurrentUser.Text = "";
                }
                else edtCurrentUser.Text = (string)dgUser.Rows[index]["�û�����"];
            }
            catch (Exception err)
            {
            }
        }
        private void dgUser_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == dgUser.Rows.Count-1 && ((string)dgUser.Rows[e.Row - 1]["�û�����"]).Trim() == "")
            //{
            //     e.Cancel = true;
            //}
            //else
            //{
            try
            {
                dgUser.Editor = numberTextBox1;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString().ToString(), Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // }
        }

        private void btnSetSample_Click(object sender, EventArgs e)
        {
            try
            {
                 
                DataTable dtSample = DataOperate.dataSet11.Tables["SampleTable"];
                int index = c1FlexGrid1.Row-1;
                if (index > 0 && index < dtSample.Rows.Count)
                {
                    if (dtSample.Rows[index]["�˹����"] == null || dtSample.Rows[index]["�˹����"] is DBNull)
                    {
                        // edtSample.Text = "ͨ��";
                    }
                    else edtSampleNo.Text = (string)dtSample.Rows[index]["�˹����"];
                }
            }
            catch (Exception err)
            {
            }
        }

  

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbTestTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
                    
           if(cmbTestTypes.SelectedIndex == 0)
            {

 
            }
           else
               {

       

            }
        }

        private void edtPrepareH0_TextChanged(object sender, EventArgs e)
        {

        }

        private void edtStep_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.������_���Ϸ������ò���);
            timer1.Enabled = true;
          
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int16 aa = (Int16 )(float.Parse(edtTargeTemperatue.Text)*10);
            GlobalData.serialPort.TxdCommand(0xE4, aa);
            timer1.Enabled = true;
            
       

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int16 aa = Int16.Parse(edtHeatSpeed.Text);
            GlobalData.serialPort.TxdCommand(SerialPortControl.������_�������ò���, aa);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
              edtTargeTemperatue.Text = GlobalData.targetTemperature.ToString("f1") ;
              edtTempDiff.Text = GlobalData.tempDiff.ToString("f1");
            edtHeatSpeed.Text = GlobalData.heatSpeed.ToString();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Int16 aa = (Int16)(float.Parse(edtTempDiff.Text) * 10);
            GlobalData.serialPort.TxdCommand(0xE2, aa);
            timer1.Enabled = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void disabled1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            label16.Visible = true;
            button3.Visible = true;
            edtTempDiff.Visible = true;
        }

        private void lblHeight_Click(object sender, EventArgs e)
        {

        }



   

 

     
    }
}