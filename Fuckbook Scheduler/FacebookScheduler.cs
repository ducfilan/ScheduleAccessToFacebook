using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Facebook_Scheduler.Properties;
using Microsoft.Win32;

namespace Facebook_Scheduler
{
    public partial class FacebookScheduler : Form
    {
        private Timer _timer;
        private static string APP_NAME = "Facebook Scheduler";

        private DataTable _reasonDataTable;

        public FacebookScheduler()
        {
            InitializeComponent();
            InitializeReasonDatatable();
            InitializeCsvFilePath();
            FillSavedConfigs();

            InitializeTimer();
            if (Settings.Default.IsSettingDone)
            {
                MinimizeProgramAtStart();
            }

            Load += Main_Load;
        }

        private void InitializeCsvFilePath()
        {
            CsvHelper.Instance.FilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Reasons.csv";
        }

        private void InitializeReasonDatatable()
        {
            _reasonDataTable = new DataTable();
            _reasonDataTable.Columns.AddRange(new[] 
                {
                    new DataColumn("Reason", typeof(string)),
                    new DataColumn("Stop Time", typeof(string)),
                });
        }

        private void MinimizeProgramAtStart()
        {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            ProcessScheduling();
        }

        void Main_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                RestartElevated();
            }

            FillReasonsGrid();
        }
        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            if (id == null) return false;

            var p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void RestartElevated()
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                CreateNoWindow = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            try
            {
                Process.Start(startInfo);
            }
            catch { }

            Application.Exit();
        }

        private void FillReasonsGrid()
        {
            _reasonDataTable = CsvHelper.Instance.ConvertCsvToDataTable();

            gridReasons.DataSource = _reasonDataTable;
        }

        private void btnBem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ProcessScheduling();
            Settings.Default.IsSettingDone = true;
            Settings.Default.Save();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var confirmDialog = new FormDialog();
            if (confirmDialog.ShowDialog() != DialogResult.OK) return;
            
            _reasonDataTable.Rows.Add(confirmDialog.Reason, DateTime.Now.ToString("g"));

            //CsvHelper.Instance.WriteDataTable(_reasonDataTable);

            Settings.Default.IsSettingDone = false;
            Settings.Default.Save();
            EnableFacebookFromHostFile();
            _timer.Stop();
            //MessageBox.Show(@"OK done!", @"Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            Settings.Default.IsAutoStart = chkAutoStart.Checked;
            Settings.Default.Save();
            if (chkAutoStart.Checked)
            {
                if (!IsStartupItem() && (key != null))
                {
                    key.SetValue(APP_NAME, Application.ExecutablePath);
                }
            }
            else if (IsStartupItem() && (key != null))
            {
                key.DeleteValue(APP_NAME, false);
            }
        }

        private void DisableFacebookFromHostFile()
        {
            string input = File.ReadAllText(@"C:\Windows\System32\drivers\etc\hosts");
            File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", Regex.Replace(input, "^.*?facebook\\.com.*?$[\r\n]*", string.Empty, RegexOptions.Multiline).Trim() + Environment.NewLine + @"127.0.0.1 facebook.com" + Environment.NewLine + @"127.0.0.1 m.facebook.com" + Environment.NewLine + @"127.0.0.1 www.facebook.com");
        }

        private void dtPkEnd_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.EndTime = dtPkEnd.Value;
            Settings.Default.IsSettingDone = true;
            Settings.Default.Save();
        }

        private void dtPkStart_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.StartTime = dtPkStart.Value;
            Settings.Default.IsSettingDone = true;
            Settings.Default.Save();
        }

        private static void EnableFacebookFromHostFile()
        {
            string input = File.ReadAllText(@"C:\Windows\System32\drivers\etc\hosts");
            File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", Regex.Replace(input, "^.*?facebook\\.com.*?$[\r\n]*", string.Empty, RegexOptions.Multiline).Trim());
        }

        private void FillSavedConfigs()
        {
            dtPkStart.Value = Settings.Default.StartTime;
            dtPkEnd.Value = Settings.Default.EndTime;
            chkAutoStart.Checked = Settings.Default.IsAutoStart;
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 0x3e8;
        }

        private bool IsStartupItem()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (key != null)
            {
                return (key.GetValue(APP_NAME) != null);
            }
            return true;
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Stay focused with this app! This tiny app will block your accessing to Facebook almost of the day and open back just on the time you setup. Config the time and ""BEM"". Everything is just so.", @"About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Settings.Default.IsSettingDone = false;
            Settings.Default.Save();
        }

        private void ProcessScheduling()
        {
            _timer.Start();
            if ((DateTime.Now.Ticks >= Settings.Default.StartTime.Ticks) && (DateTime.Now.Ticks <= Settings.Default.EndTime.Ticks))
            {
                EnableFacebookFromHostFile();
            }
            else
            {
                DisableFacebookFromHostFile();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("T").Equals(Settings.Default.StartTime.ToString("T")))
            {
                EnableFacebookFromHostFile();
            }
            else if (DateTime.Now.ToString("T").Equals(Settings.Default.EndTime.ToString("T")))
            {
                DisableFacebookFromHostFile();
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipTitle = @"Happy learning! ^^";
            notifyIcon.BalloonTipText = @"Stop the fucking FB from making you disturbed!";
            switch (WindowState)
            {
                case FormWindowState.Normal:
                    notifyIcon.Visible = false;
                    return;

                case FormWindowState.Minimized:
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(0x3e8);
                    Hide();
                    return;
            }
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void itmEnable_Click(object sender, EventArgs e)
        {
            ProcessScheduling();
        }

        private void itmDisable_Click(object sender, EventArgs e)
        {
            Settings.Default.IsSettingDone = false;
            Settings.Default.Save();
            EnableFacebookFromHostFile();
            _timer.Stop();
        }
    }
}
