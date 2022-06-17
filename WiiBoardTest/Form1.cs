using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiimoteLib;
//using Rug.Osc;
using System.Net;
using System.Threading;

using MakingThings;

namespace WiiBoardTest
{
    public partial class Form1 : Form
    {
        private UdpPacket udpPacket;
        private Osc oscUdp;
        OscMessage oscMsg;
        //OscSender oscsend;
        Wiimote wm = new Wiimote();
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        // OSC送信のセクチョン
        private void oscsetup(String sendsaki, int port, bool flag)
        {
            udpPacket = new UdpPacket();
            udpPacket.RemoteHostName = sendsaki;
            udpPacket.RemotePort = port;
            udpPacket.LocalPort = 20938;
            udpPacket.Open();
            oscUdp = new Osc(udpPacket);
        }
        private void osctrans(String address, float data, bool state)
        {
            //while (true) {
                //oscMsg = Osc.StringToOscMessage(address + " " + data);
                if ((wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 > 0.15 || wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 < -0.15) && (wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 > -2 && wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 < 2))
                    oscMsg = Osc.StringToOscMessage(x_address.Text + " " + (wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20));
                else
                    oscMsg = Osc.StringToOscMessage(x_address.Text + " " + (float)0.000001);
                oscUdp.Send(oscMsg);

                if ((wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 > 0.15 || wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 < -0.15) && (wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 > -2 && wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 < 2))
                    oscMsg = Osc.StringToOscMessage(y_address.Text + " " + (-wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12));
                else
                    oscMsg = Osc.StringToOscMessage(y_address.Text + " " + (float)0.000001);
                oscUdp.Send(oscMsg);
                label10.Text = "X: " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 + "\rY: " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12;
                System.Windows.Forms.Application.DoEvents();
            //}
        }
        
        //{
        //    while (flag)
        //    {
        //        // This is the ip address we are going to send to
        //        IPAddress address = IPAddress.Parse(sendsaki);
        //        label9.Text = "address: " + sendsaki + "\rPort: " + port.ToString();
        //        // Create a new sender instance
        //        using (OscSender sender = new OscSender(address, port))
        //        {
        //            //if (shokai)
        //            //{
        //                // Connect the sender socket  
        //                sender.Connect();
        //            //    shokai = false;
        //            //}
        //            if (wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 > 0.2 || wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 < -0.2 )
        //            {
        //                // Send a new message
        //                sender.Send(new OscMessage(x_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20));
        //            }
        //            else
        //            {
        //                sender.Send(new OscMessage(x_address.Text, 0.0));
        //            }
        //            if (wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 > 0.2 || wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12 < -0.2)
        //            {
        //                sender.Send(new OscMessage(y_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / -12));
        //            }
        //            else
        //            {
        //                sender.Send(new OscMessage(y_address.Text, 0.0));
        //            }
        //            label10.Text ="X: " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20 +"\rY: " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12;
                    
        //        }
        //        //Thread.Sleep(10);
        //        System.Windows.Forms.Application.DoEvents();
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            oscsetup(addresstext.Text, (int)senderport.Value, true);
            backgroundOSC.RunWorkerAsync();
            //osctrans(x_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20, true);
            //osctrans(y_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y / 12, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oscsetup(addresstext.Text, (int)senderport.Value, false);
        }

        private void backgroundOSC_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while(true)
            osctrans(x_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20, true);
        }

        // Wiimoteのセクチョン

        private void c_button_Click(object sender, EventArgs e)
        {
            this.wm.Connect();
            this.wm.WiimoteChanged += wm_WiimoteChanged;
        }

        private void d_button_Click(object sender, EventArgs e)
        {
            this.wm.Disconnect();
        }

        private delegate void UpdateWiimoteStateDelegate(object sender, WiimoteChangedEventArgs args);

        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateWiimoteStateDelegate(wm_WiimoteChanged), sender, args);
                return;
            }
            WiimoteState ws = args.WiimoteState;
            this.DrawForms(ws);

            this.label6.Text = ws.BalanceBoardState.WeightKg.ToString();
            this.label7.Text = "X: " + ws.BalanceBoardState.CenterOfGravity.X;
            this.label8.Text = "Y: " + ws.BalanceBoardState.CenterOfGravity.Y;
        }

        private void backgroundWiimote_DoWork(object sender, DoWorkEventArgs e)
        {
            // 処理を開始する
            MessageBox.Show("接続します.");
            while (true)
                osctrans(x_address.Text, wm.WiimoteState.BalanceBoardState.CenterOfGravity.X / 20, true);
        }

        public void DrawForms(WiimoteState ws)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            g.Clear(Color.Black);

            // x,y(描画用)の計算
            float x = (wm.WiimoteState.BalanceBoardState.CenterOfGravity.X + 20.0f) * 10;
            float y = (wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y + 12.0f) * 10;

            g.FillEllipse(Brushes.Red, x, y, 10, 10);
            g.Dispose();
        }
    }
}
