using HandyControl.Geometry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyControl.Geometry
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var keys= this.Resources.Keys;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var geometryName = string.Empty;
            if ((e?.OriginalSource is Button btn) && (btn.Content is string text))
            {
                geometryName = text;
            }
            if (string.IsNullOrEmpty(geometryName))
            {
                return;
            }

            // 设置剪贴板
            Clipboard.SetText(geometryName);
            // 通知用户
            //MessageBox.Show("已复制到剪贴板");

            HandyControl.Controls.Growl.Info(Properties.Resources.GrowlInfo, "");
        }
    }
}
