using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                IntPtr maindHwnd = FindWindow("TXGuiFoundation", "企业QQ"); //获得QQ登陆框的句柄   
                if (maindHwnd != IntPtr.Zero)
                {
                    ShowWindow(maindHwnd, 1);
                    Thread.Sleep(200);

                    var point = new Point();
                    ClientToScreen(maindHwnd, ref point);
                    SetCursorPos(point.X + 273, point.Y + 682);
                    Thread.Sleep(200);

                    mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, maindHwnd);
                    mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, maindHwnd);
                    Thread.Sleep(200);

                    IntPtr childHwnd = FindWindow("TXGuiFoundation", "办公考勤"); //获得QQ登陆框的句柄   
                    if (childHwnd != IntPtr.Zero)
                    {

                        point = new Point();
                        ClientToScreen(childHwnd, ref point);
                        SetCursorPos(point.X + 128, point.Y + 224);
                        Thread.Sleep(200);
                        //mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, childHwnd);
                        //mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, childHwnd);
                        Thread.Sleep(200);

                    }
                    ShowWindow(maindHwnd, 0);
                }
                var ts = new TimeSpan();
                if (DateTime.Now.Hour <= 9)
                {
                    ts = GetTaskTime(1) - DateTime.Now;
                    //ts = DateTime.Now.Date.AddDays(1).AddHours(8) - DateTime.Now;
                }
                else
                {
                    var week = 1;
                    if ((int)DateTime.Now.DayOfWeek == 5)
                    {
                        week = week + 2;
                    }
                    ts = GetTaskTime(0).AddDays(week) - DateTime.Now;
                }
                Console.WriteLine("下次启动" + ts.TotalHours + "小时");
                Thread.Sleep(ts);
            }
        }
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);
        [DllImport("user32", EntryPoint = "ClientToScreen")]
        public static extern int ClientToScreen(
                IntPtr hwnd,
                ref Point lpPoint
        );

        static DateTime GetTaskTime(int type)
        {
            Random rd = new Random();
            var timeStr = string.Empty;
            if (type == 1)
                timeStr = " 08:5" + rd.Next(0, 9) + ":00";
            else
                timeStr = " 18:1" + rd.Next(0, 9) + ":00";
            var date = DateTime.Now.ToShortDateString() + timeStr;
            return DateTime.Parse(date);
        }
    }
    public enum MouseEventFlags
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        Wheel = 0x0800,
        Absolute = 0x8000
    }
}
