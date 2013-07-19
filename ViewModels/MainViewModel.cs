using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WonderGraphGeneratorWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {            
            UpdateDrawing();
        }

        #region ItemCollectionViewModel Items
        private readonly ItemCollectionViewModel _Items = new ItemCollectionViewModel();
        public ItemCollectionViewModel Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        #region int Angle
        private int _Angle;
        public int Angle
        {
            get
            {
                return _Angle;
            }
            set
            {
                if (_Angle != value)
                {
                    _Angle = value;
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
                    UpdateDrawing();
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
                    UpdateDrawing();
                }
            }
        }
        #endregion

        private Drawing drawing;
        public Drawing Drawing
        {
            get
            {
                return this.drawing;
            }
        }

        private void UpdateDrawing()
        {
            var enabledItems = from item in Items
                               where item.IsEnabled
                               select item;

            int total = enabledItems.Sum((item) => item.Value);

            DrawingGroup group = new DrawingGroup();
            group.ClipGeometry = new EllipseGeometry(new Rect(-1, -1, 2, 2));

            double angle = 0.0;

            foreach (var item in enabledItems)
            {
                Color color1 = (Color)ColorConverter.ConvertFromString(item.Color1);
                Color color2 = (Color)ColorConverter.ConvertFromString(item.Color2);

                GeometryDrawing drawing = new GeometryDrawing();
                drawing.Brush = new RadialGradientBrush(color2, color1)
                {
                    Center = new Point(0, 0),
                    RadiusX = 1,
                    RadiusY = 1,
                    MappingMode = BrushMappingMode.Absolute,
                    GradientOrigin = new Point(0, 0),
                };

                PathGeometry geometry = new PathGeometry();

                PathFigure figure = new PathFigure();
                figure.StartPoint = new Point(OffsetX, OffsetY);
                figure.IsClosed = true;
                figure.IsFilled = true;

                figure.Segments.Add(new LineSegment(new Point(Math.Sin(angle) * 2 + OffsetX, -Math.Cos(angle) * 2 + OffsetY), false));
                double a = item.Value * 2 * Math.PI / total;

                item.CalcLabelPosition(angle + a / 2, OffsetX, OffsetY);

                angle += a;
                figure.Segments.Add(new ArcSegment(new Point(Math.Sin(angle) * 2 + OffsetX, -Math.Cos(angle) * 2 + OffsetY), new Size(1, 1), 0, a > Math.PI, SweepDirection.Clockwise, false));

                geometry.Figures.Add(figure);
                drawing.Geometry = geometry;

                group.Children.Add(drawing);
            }

            this.drawing = group;
            RaisePropertyChanged(() => Drawing);
        }
    }
}
