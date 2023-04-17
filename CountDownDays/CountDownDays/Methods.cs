using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CountDownDays
{
    internal class Methods
    {
        //private MainWindow mainWindow = new MainWindow();


        //设置窗体、字体等的大小级别
        //(sizeLevel)0:Min, 1:Normal, 2:Big, 3:Max
        public bool SetSize(int sizeLevel, TextBlock titleTextBlk, TextBlock daysTextBlk, Window window)
        {
            try
            {
                switch (sizeLevel)
                {
                    case 0:
                        titleTextBlk.FontSize = 27;
                        daysTextBlk.FontSize = 100;
                        Canvas.SetTop(daysTextBlk, 45);
                        Canvas.SetTop(titleTextBlk, 20);
                        window.Width = 250;
                        window.Height = 190;
                        break;
                    case 1:
                        titleTextBlk.FontSize = 35;
                        daysTextBlk.FontSize = 130;
                        Canvas.SetTop(daysTextBlk, 40);
                        Canvas.SetTop(titleTextBlk, 15);
                        window.Width = 300;
                        window.Height = 230;
                        break;
                    case 2:
                        titleTextBlk.FontSize = 55;
                        daysTextBlk.FontSize = 210;
                        Canvas.SetTop(daysTextBlk, 55);
                        Canvas.SetTop(titleTextBlk, 20);
                        window.Width = 410;
                        window.Height = 350;
                        break;
                    case 3:
                        titleTextBlk.FontSize = 70;
                        daysTextBlk.FontSize = 270;
                        Canvas.SetTop(daysTextBlk, 70);
                        Canvas.SetTop(titleTextBlk, 25);
                        window.Width = 590;
                        window.Height = 440;
                        break;
                    default:
                        throw new Exception();
                }
                titleTextBlk.Width = window.Width;
                daysTextBlk.Width = window.Width;
                return true;
            }
            catch
            {
                return false;
            }

        }


        //设置窗体的位置
        //(location)0:LeftTop, 1:RightTop, 2:RightBottom, 3:LeftBottom, 4:Center, 5:CenterTop
        public bool SetWindowLocation(int location, Window window)
        {
            try
            {
                switch (location)
                {
                    case 0:
                        Canvas.SetTop(window, 0);
                        Canvas.SetLeft(window, 0);
                        break;
                    case 1:
                        Canvas.SetTop(window, 0);
                        Canvas.SetLeft(window, SystemParameters.FullPrimaryScreenWidth - window.Width);
                        break;
                    case 2:
                        Canvas.SetTop(window, SystemParameters.FullPrimaryScreenHeight - window.Height);
                        Canvas.SetLeft(window, SystemParameters.FullPrimaryScreenWidth - window.Width);
                        break;
                    case 3:
                        Canvas.SetTop(window, SystemParameters.FullPrimaryScreenHeight - window.Height);
                        Canvas.SetLeft(window, 0);
                        break;
                    case 4:
                        Canvas.SetTop(window, (SystemParameters.FullPrimaryScreenHeight - window.Height) / 2);
                        Canvas.SetLeft(window, (SystemParameters.FullPrimaryScreenWidth - window.Width) / 2);
                        break;
                    case 5:
                        Canvas.SetTop(window, 0);
                        Canvas.SetLeft(window, (SystemParameters.FullPrimaryScreenWidth - window.Width) / 2);
                        break;
                    default:
                        throw new Exception();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }



        //设置字体颜色，该方法有3个重载
        public bool SetColor(SolidColorBrush brush, TextBlock text1, TextBlock text2)
        {
            try
            {
                text1.Foreground = brush;
                text2.Foreground = brush;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetColor(SolidColorBrush brush, TextBlock text1, TextBlock text2, TextBlock text3)
        {
            try
            {
                text1.Foreground = brush;
                text2.Foreground = brush;
                text3.Foreground = brush;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetColor(SolidColorBrush brush, TextBlock text1, TextBlock text2, TextBlock text3, TextBlock text4)
        {
            try
            {
                text1.Foreground = brush;
                text2.Foreground = brush;
                text3.Foreground = brush;
                text4.Foreground = brush;

                return true;
            }
            catch
            {
                return false;
            }
        }


        //设置标题
        public bool SetTitle(string title, TextBlock titleTextBlk)
        {
            try
            {
                titleTextBlk.Text = title;
                return true;
            }
            catch
            {
                return false;
            }
        }


        //设置目标日距今的天数
        public bool SetDays(DateTime targetDate, TextBlock daysTextBlk)
        {
            try
            {
                daysTextBlk.Text = Convert.ToString(GetDaysApart(DateTime.Now.ToLocalTime(), targetDate));
                return true;
            }
            catch
            {
                return false;
            }
        }


        //读取配置文件(settings.txt)，并根据其值初始化程序
        //如果在某一环节出错，则按照默认参数初始化程序
        public bool ReadAndInitApp(TextBlock titleTextBlk, TextBlock daysTextBlk, Window window)
        {
            try
            {
                //读取配置文件
                string path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                for (int i = path.Length - 1; i >= 0; i--)
                {
                    if (path[i] == '\\')
                    {
                        path += @"settings.txt";
                        break;
                    }
                    else
                    {
                        path = path.Substring(0, path.Length - 1);
                    }
                }
                StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
                string[] value = new string[5];
                for (int i = 0; i < 5; i++)//读5行
                {
                    value[i] += streamReader.ReadLine().ToLower().Trim();
                }

                //根据值设置相应属性
                if (value[0] == "min")
                    SetSize(0, titleTextBlk, daysTextBlk, window);
                else if (value[0] == "normal")
                    SetSize(1, titleTextBlk, daysTextBlk, window);
                else if (value[0] == "big")
                    SetSize(2, titleTextBlk, daysTextBlk, window);
                else if (value[0] == "max")
                    SetSize(3, titleTextBlk, daysTextBlk, window);
                else
                    throw new Exception();

                if (value[1] == "white")
                    SetColor(Brushes.White, titleTextBlk, daysTextBlk);
                else if (value[1] == "black")
                    SetColor(Brushes.Black, titleTextBlk, daysTextBlk);
                else
                    throw new Exception();

                if (value[2] == "lefttop")
                    SetWindowLocation(0, window);
                else if (value[2] == "righttop")
                    SetWindowLocation(1, window);
                else if (value[2] == "rightbottom")
                    SetWindowLocation(2, window);
                else if (value[2] == "leftbottom")
                    SetWindowLocation(3, window);
                else if (value[2] == "center")
                    SetWindowLocation(4, window);
                else if (value[2] == "centertop")
                    SetWindowLocation(5, window);
                else
                    throw new Exception();


                SetDays(Convert.ToDateTime(value[3]), daysTextBlk);
                SetTitle(value[4], titleTextBlk);


                return true;
            }
            catch
            {
                SetSize(1, titleTextBlk, daysTextBlk, window);
                SetColor(Brushes.White, titleTextBlk, daysTextBlk);
                SetWindowLocation(1, window);

                return false;
            }


        }



        //计算两个日期之间相差的天数
        public int? GetDaysApart(DateTime beginDate, DateTime endDate)
        {
            try
            {
                TimeSpan distance = endDate - beginDate;
                int days = distance.Days;
                if (days > 0)
                {
                    return days;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return null;
            }
        }



    }
}
