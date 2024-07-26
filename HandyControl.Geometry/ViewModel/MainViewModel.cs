using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace HandyControl.Geometry.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private GeometryList _geometryList;
        public GeometryList GeometryList
        {
            get => _geometryList;
            set
            {
                _geometryList = value;
                RaisePropertyChanged(nameof(GeometryList));
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            this.GeometryList = new GeometryList();
            //this.GeometryList.LoadGeometry();
        }
    }

    public class GeometryInfo
    {
        public string Name { get; set; }
        public System.Windows.Media.Geometry Geometry { get; private set; }

        public GeometryInfo(string name)
        {
            this.Name = name;
            this.Geometry = Application.Current.TryFindResource(name) as System.Windows.Media.Geometry;
        }

        public GeometryInfo()
        {

        }
    }

    public class GeometryList : ObservableCollection<GeometryInfo>
    {
        public GeometryList()
        {
            this.LoadGeometry();
        }

        public GeometryList LoadGeometry()
        {
            var names = new List<string>();

            if (this.IsInDesignMode)
            {
                names = new List<string>() { "CalendarGeometry","DeleteGeometry", "DeleteFillCircleGeometry", "CloseGeometry", "DownGeometry",
                "UpGeometry","ClockGeometry", "LeftGeometry", "RightGeometry", "RotateLeftGeometry",
            "RotateRightGeometry","EnlargeGeometry", "ReduceGeometry", "DownloadGeometry", "SaveGeometry",
            "WindowsGeometry","FullScreenGeometry", "FullScreenReturnGeometry", "SearchGeometry", "UpDownGeometry",
            "WindowMinGeometry","WindowRestoreGeometry","WindowMaxGeometry","CheckedGeometry","PageModeGeometry",
            "TwoPageModeGeometry","ScrollModeGeometry","EyeOpenGeometry","EyeCloseGeometry","AudioGeometry",
            "BubbleTailGeometry","StarGeometry","AddGeometry","SubGeometry","WarningGeometry",
            "InfoGeometry","ErrorGeometry","SuccessGeometry","FatalGeometry","AskGeometry",
            "AllGeometry","DragGeometry"};
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Select(a => a.Keys).ToList().ForEach(keys =>
                {
                    foreach (var key in keys)
                    {
                        if (key is string skey)
                        {
                            //if (skey.EndsWith("Geometry"))
                            {
                                names.Add(skey);
                            }
                        }
                    }
                });
            }

            names.Where(a => a.EndsWith("Geometry")).ToList().ForEach(a => this.AddGeometry(a));
            return this;
        }

        /// <summary>
        /// https://blog.csdn.net/sleeper1982/article/details/40818959
        /// </summary>
        private bool IsInDesignMode
        {
            get => DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }

        private bool IsInDesignMode2
        {
            get
            {
                return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
            }
        }
        //private bool IsInDesignMode3
        //{
        //    get { return DesignerProperties.GetIsInDesignMode(this); }
        //}

        private void AddGeometry(string name)
        {
            //// 从资源中获取Geometry
            //var geometry = Application.Current.TryFindResource(name) as System.Windows.Media.Geometry;
            //if (geometry == null)
            //{
            //    //throw new ArgumentException("Geometry not found in resources.");
            //    return;
            //}
            //this.GeometryList.Add(geometry);

            this.Add(new GeometryInfo(name));
        }


        private void LoadGeometryFixed()
        {
            var geometryNames = new string[] { "CalendarGeometry","DeleteGeometry", "DeleteFillCircleGeometry", "CloseGeometry", "DownGeometry",
                "UpGeometry","ClockGeometry", "LeftGeometry", "RightGeometry", "RotateLeftGeometry",
            "RotateRightGeometry","EnlargeGeometry", "ReduceGeometry", "DownloadGeometry", "SaveGeometry",
            "WindowsGeometry","FullScreenGeometry", "FullScreenReturnGeometry", "SearchGeometry", "UpDownGeometry",
            "WindowMinGeometry","WindowRestoreGeometry","WindowMaxGeometry","CheckedGeometry","PageModeGeometry",
            "TwoPageModeGeometry","ScrollModeGeometry","EyeOpenGeometry","EyeCloseGeometry","AudioGeometry",
            "BubbleTailGeometry","StarGeometry","AddGeometry","SubGeometry","WarningGeometry",
            "InfoGeometry","ErrorGeometry","SuccessGeometry","FatalGeometry","AskGeometry",
            "AllGeometry","DragGeometry"};
            foreach (var name in geometryNames)
            {
                this.AddGeometry(name);
            }
        }
    }
}