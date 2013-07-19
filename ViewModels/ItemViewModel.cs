using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        #region Color Color
        private Color _Color;
        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
