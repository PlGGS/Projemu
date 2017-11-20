using System;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace Projemu
{
    public partial class frmMain : Form
    {
        //Import window changing function
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Import find window finding function
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        //Import force window draw function
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        //Import window placement function
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        private const int gwlStyle = -16;
        private const int wsBorder = 0x00800000;
        private const int wsCaption = 0x00C00000;
        private const int wsSysMenu = 0x00080000;
        private const int wsMinimizeBox = 0x00020000;
        private const int wsMenuStrip = 19;
        private int projectorScreen = Properties.Settings.Default.screenNum;
        Screen[] screens = Screen.AllScreens;
        IntPtr[] cemuWindows;

        /// <summary>
        /// Creates a new shortcut of a selected program. In this case we use it to create Halo Online shortcuts that don't need to be run by the default launcher.
        /// </summary>
        /// <param name="shortcutName"></param>
        /// <param name="shortcutPath"></param>
        /// <param name="shortcutTargetFileLocation"></param>
        /// <param name="shortcutArguments"></param>
        /// <param name="shortcutStartInDirectory"></param>
        /// <param name="shortcutIconLocation"></param>
        /// <param name="shortcutDescription"></param>
        public static void CreateShortcut(string shortcutName, string shortcutPath, string shortcutTargetFileLocation, string shortcutArguments, string shortcutStartInDirectory, string shortcutIconLocation, string shortcutDescription)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = shortcutDescription;
            shortcut.IconLocation = shortcutIconLocation;
            shortcut.TargetPath = shortcutTargetFileLocation;
            shortcut.Arguments = shortcutArguments;
            shortcut.WorkingDirectory = shortcutStartInDirectory;
            shortcut.Save();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Taskbar.Show();
            this.Icon = Properties.Resources.Projemu;
            cemuWindows = new IntPtr[Process.GetProcessesByName("cemu").Length + 1];

            for (int i = 0; i < screens.Length; i++)
            {
                cbxScreenNum.Items.Add(i + 1);
            }

            cbxScreenNum.SelectedIndex = Properties.Settings.Default.screenNum;

            if (Properties.Settings.Default.appRunBefore == false)
            {
                CreateShortcut("Projemu", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Application.StartupPath + "\\Projemu.exe", "", Application.StartupPath, Application.StartupPath + "\\Projemu.ico", "Cemu on your projector! Woah!");
                Properties.Settings.Default.appRunBefore = true;
                Properties.Settings.Default.Save();
            }

            Process.Start(Application.StartupPath + "\\Cemu");
            Process.GetProcessesByName("cemu")[0].WaitForInputIdle();
            for (int i = 0; i < Process.GetProcessesByName("cemu").Length; i++)
            {
                cemuWindows[i] = Process.GetProcessesByName("cemu")[i].MainWindowHandle;
            }

            for (int i = 0; i < cemuWindows.Length; i++)
            {
                SetWindowLong(cemuWindows[i], gwlStyle, wsSysMenu);
                SetWindowPos(cemuWindows[i], 0, screens[projectorScreen].Bounds.X, screens[projectorScreen].Bounds.Y, screens[projectorScreen].Bounds.Width, screens[projectorScreen].Bounds.Height, 0x0040);
                DrawMenuBar(cemuWindows[i]);
            }
        }
        
        private void setWindow()
        {
            if (chkShowMenuStrip.CheckState == CheckState.Checked)
            {
                try
                {
                    for (int i = 0; i < cemuWindows.Length; i++)
                    {
                        SetWindowLong(cemuWindows[i], gwlStyle, wsSysMenu);
                        SetWindowPos(cemuWindows[i], 0, screens[projectorScreen].Bounds.X, screens[projectorScreen].Bounds.Y, screens[projectorScreen].Bounds.Width, screens[projectorScreen].Bounds.Height + wsMenuStrip, 0x0040);
                        DrawMenuBar(cemuWindows[i]);
                        Taskbar.Hide();
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to properly place Cemu into borderless window mode.", "Cemu Borderless Window");
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < cemuWindows.Length; i++)
                    {
                        SetWindowLong(cemuWindows[i], gwlStyle, wsSysMenu);
                        SetWindowPos(cemuWindows[i], 0, screens[projectorScreen].Bounds.X, screens[projectorScreen].Bounds.Y - wsMenuStrip, screens[projectorScreen].Bounds.Width, screens[projectorScreen].Bounds.Height + wsMenuStrip, 0x0040);
                        DrawMenuBar(cemuWindows[i]);
                        Taskbar.Hide();
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to properly place Cemu into borderless window mode.", "Cemu Borderless Window");
                }
            }
        }

        private void chkShowMenuStrip_CheckedChanged(object sender, EventArgs e)
        {
            setWindow();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Taskbar.Show();
        }

        private void cbxScreenNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            projectorScreen = cbxScreenNum.SelectedIndex;
            Properties.Settings.Default.screenNum = cbxScreenNum.SelectedIndex;
            Properties.Settings.Default.Save();
            setWindow();
        }
    }
}
