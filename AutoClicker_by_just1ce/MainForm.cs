using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;



namespace AutoClicker_by_just1ce
{
    public partial class MainForm : Form
    {
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);


        #region Fields
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x0010; /* right button up */
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; /* middle button down */
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040; /* middle button up */
        private const int MOUSEEVENTF_XDOWN = 0x0080; /* x button down */
        private const int MOUSEEVENTF_XUP = 0x0100; /* x button down */
        private const int MOUSEEVENTF_WHEEL = 0x0800; /* wheel button rolled */
        private const int MOUSEEVENTF_VIRTUALDESK = 0x4000; /* map to entire virtual desktop */
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000; /* absolute move */
        #endregion


        BackgroundWorker bk_worker_eternal = new BackgroundWorker();  //responsible for cur_color,Pos_x, Pos_y (always refreshing)
        BackgroundWorker bk_worker_play_record = new BackgroundWorker(); //runs after pushing button Play.
        Color cur_color;                //current color under cursor
        int Pos_x, Pos_y;               //current coordinates under cursor
        List<Action_object> record;     //List which stores all actions during the record
        UserActivityHook hook;          //Hook on mouse and keyboard
        #region BackgroundWorkerParams
        struct BackgroundWorkerParams
        {
            public List<Action_object> r;
        }
        #endregion
        public MainForm()
        {
            InitializeComponent();
            TopMost = true;
            label1.Text += "Instuction:\r\n F10 - Stop recording/Stop playing.\r\n ";
            
            
            bk_worker_eternal.WorkerReportsProgress = true;
            bk_worker_eternal.WorkerSupportsCancellation = true;
            bk_worker_eternal.DoWork += bk_worker_eternalDoWork;
            bk_worker_eternal.ProgressChanged += bk_worker_eternalProgressChanged;
            bk_worker_eternal.RunWorkerAsync();

            bk_worker_play_record.WorkerReportsProgress = true;
            bk_worker_play_record.WorkerSupportsCancellation = true;
            bk_worker_play_record.DoWork += bk_worker_play_recordDoWork;
            bk_worker_play_record.ProgressChanged += bk_worker_play_recordProgressChanged;
           
        }
        #region description bk_worker_play_record
        private void bk_worker_play_recordDoWork(object sender, DoWorkEventArgs e)
        {
            var bk_params = (BackgroundWorkerParams)e.Argument;
            List<Action_object> recs = bk_params.r;
            Action_object[] rec=recs.ToArray();
            int tmp = 0;
                
            Thread.Sleep(50);
            while (!bk_worker_play_record.CancellationPending)
            {
                foreach (Action_object a in record)
                {

                    if (bk_worker_play_record.CancellationPending) break;
                    try { Thread.Sleep(a.Get_time() - tmp); }
                    catch { };
                    tmp = a.Get_time();
                    if (a.Get_KeyName().Length==1)
                    {
                        SendKeys.SendWait(a.Get_KeyName().ToLower());
                        Thread.Sleep(64);
                        continue;
                    }
                    switch (a.Get_KeyName())
                    {
                        case "Left":
                            {
                                SetCursorPos(a.Get_PosXY().Item1, a.Get_PosXY().Item2);
                                mouse_event(MOUSEEVENTF_LEFTDOWN, a.Get_PosXY().Item1, a.Get_PosXY().Item2, 0, 0);
                                Thread.Sleep(64);
                                mouse_event(MOUSEEVENTF_LEFTUP, a.Get_PosXY().Item1, a.Get_PosXY().Item2, 0, 0);
                                break;
                            }
                        case "Right":
                            {
                                SetCursorPos(a.Get_PosXY().Item1, a.Get_PosXY().Item2);
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, a.Get_PosXY().Item1, a.Get_PosXY().Item2, 0, 0);
                                Thread.Sleep(64);
                                mouse_event(MOUSEEVENTF_RIGHTUP, a.Get_PosXY().Item1, a.Get_PosXY().Item2, 0, 0);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }        
        }
        private void bk_worker_play_record_Start()
        {
            if (!bk_worker_eternal.IsBusy)
            {
                bk_worker_play_record.RunWorkerAsync();
            }
        }
        private void bk_worker_play_recordProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion

        #region description bk_worker_eternal
        private void bk_worker_eternalDoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<Tuple<int, int>, Color> t;
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            while (!bk_worker_eternal.CancellationPending)
            {
                t = new Tuple< Tuple<int, int>, Color>(new Tuple<int, int>(Cursor.Position.X, Cursor.Position.Y), bitmap.GetPixel(0, 0));
                graphics.CopyFromScreen(new Point(Cursor.Position.X, Cursor.Position.Y), new Point(0, 0), new Size(1, 1));
                bk_worker_eternal.ReportProgress(0, t);
                Thread.Sleep(10);
            }
        }
        public void bk_worker_eternal_Start()
        {
            if (!bk_worker_eternal.IsBusy)
            {
                bk_worker_eternal.RunWorkerAsync();
            }
        }
        private void bk_worker_eternalProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tuple<Tuple<int, int>, Color> t = (Tuple<Tuple<int, int>, Color>)e.UserState;
            Tuple<int, int> t1 = t.Item1;
            Pos_x = t1.Item1;
            Pos_y = t1.Item2;
            label_cur_position.Text = "X: "+ Pos_x.ToString() + "   " +"Y: "+ Pos_y.ToString();
            cur_color = t.Item2;
            label_color.BackColor = cur_color;
            
            
        }
        #endregion  


        public void minimize_window(object sender, EventArgs e)// minimize window
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = true;
            }
        }
        private void normal_window(object sender, MouseEventArgs e) //normal size window
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        
        public void stop_record()
        {
            hook.Stop();
        }
        public void refresh_hook()
        {
            hook.Stop();
            hook = new UserActivityHook();
        }


        private void StartRecord_button_Click(object sender, EventArgs e)
        {
             this.WindowState = FormWindowState.Minimized;
            hook = new UserActivityHook();
            DateTime Now = DateTime.Now;
            record= new  List<Action_object>();
            Action_object tmp;
            
           hook.KeyUp += (s, E) =>
           {
               if (E.KeyData.ToString()=="F10")
               {
                   stop_record();
                   this.WindowState = FormWindowState.Normal;
               }
               if (E.KeyData.ToString() == "Space")
               {
                   refresh_hook();
               }
              
               tmp= new Action_object((DateTime.Now - Now).TotalSeconds,E.KeyData.ToString(),new Tuple<int,int>(Pos_x,Pos_y),cur_color);
               record.Add(tmp);
           };
           hook.OnMouseActivity += (s, E) =>
           {
               if (E.Button.ToString() != "None")
               {
                   tmp = new Action_object((DateTime.Now - Now).TotalSeconds, E.Button.ToString(), new Tuple<int, int>(Pos_x, Pos_y), cur_color);
                   record.Add(tmp);
               }
           };
        }

        private void Play_button_Click(object sender, EventArgs e)
        {
            if (record == null)
            {
                MessageBox.Show("Please, record actions!");
                return;
            }

            
             this.WindowState = FormWindowState.Minimized;
             hook = new UserActivityHook();
             hook.KeyUp += (s, E) =>
             {
                 if (E.KeyData.ToString() == "F10")
                 {
                     this.WindowState = FormWindowState.Normal;
                     bk_worker_play_record.CancelAsync();
                 }
             };
             var bk_params = new BackgroundWorkerParams();
             bk_params.r = record;
             bk_worker_play_record.RunWorkerAsync(bk_params);
        


        }

        private void StopRecord_btn_Click(object sender, EventArgs e)
        {
            try
            {
                stop_record();
            }
            catch
            {
                MessageBox.Show("Record is not started!");
            }
        }

       

       





        
    }
}
