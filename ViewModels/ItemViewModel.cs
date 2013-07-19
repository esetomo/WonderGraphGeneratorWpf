using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderGraphGeneratorWpf.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        #region bool IsEnabled
        private bool _IsEnabled;
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                if (_IsEnabled != value)
                {
                    _IsEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region int Value
        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region string Label
        private string _Label;
        public string Label
        {
            get
            {
                return _Label;
            }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region string Color1
        private string _Color1;
        public string Color1
        {
            get
            {
                return _Color1;
            }
            set
            {
                if (_Color1 != value)
                {
                    _Color1 = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region string Color2
        private string _Color2;
        public string Color2
        {
            get
            {
                return _Color2;
            }
            set
            {
                if (_Color2 != value)
                {
                    _Color2 = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region double OffsetX
        private double _OffsetX;
        public double OffsetX
        {
            get
            {
                return _OffsetX;
            }
            set
            {
                if (_OffsetX != value)
                {
                    _OffsetX = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region double OffsetY
        private double _OffsetY;
        public double OffsetY
        {
            get
            {
                return _OffsetY;
            }
            set
            {
                if (_OffsetY != value)
                {
                    _OffsetY = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        internal void CalcLabelPosition(double angle, double x, double y)
        {
            OffsetX = Math.Sin(angle) * 60 + x * 100;
            OffsetY = -Math.Cos(angle) * 60 + y * 100;
        }
    }
}
