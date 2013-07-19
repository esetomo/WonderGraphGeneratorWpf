using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WonderGraphGeneratorWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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

                    geometry = null;
                    RaisePropertyChanged(() => Drawing);
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

                    geometry = null;
                    RaisePropertyChanged(() => Drawing);
                }
            }
        }
        #endregion

        private MeshGeometry3D geometry;
        public MeshGeometry3D Geometry
        {
            get
            {
                if (geometry == null)
                    geometry = CreateGeometry();
                return geometry;
            }
        }

        private MeshGeometry3D CreateGeometry()
        {
            MeshGeometry3D geometry = new MeshGeometry3D();

            geometry.Positions.Add(new Point3D(OffsetX, OffsetY, 0));
            geometry.TextureCoordinates.Add(new Point(0, 0));

            geometry.Positions.Add(new Point3D(0, 1, 0));
            geometry.TextureCoordinates.Add(new Point(1, 0));

            int s = 30;
            for (int i = 0; i < s; i++)
            {
                geometry.Positions.Add(new Point3D(-OffsetX * 0.5, OffsetY * 0.5, 0));
                geometry.TextureCoordinates.Add(new Point(0, (i+1.0)/s));

                double a = (i+1.0)/s * 2 * Math.PI;
                geometry.Positions.Add(new Point3D(Math.Sin(a), Math.Cos(a), 0));
                geometry.TextureCoordinates.Add(new Point(1, (i+1.0)/s));

                geometry.TriangleIndices.Add(i * 2 + 0);
                geometry.TriangleIndices.Add(i * 2 + 2);
                geometry.TriangleIndices.Add(i * 2 + 1);

                geometry.TriangleIndices.Add(i * 2 + 1);
                geometry.TriangleIndices.Add(i * 2 + 2);
                geometry.TriangleIndices.Add(i * 2 + 3);
            }

            return geometry;
        }

        public Drawing Drawing
        {
            get
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
                    GeometryDrawing drawing = new GeometryDrawing();
                    drawing.Brush = new SolidColorBrush(item.Color);

                    PathGeometry geometry = new PathGeometry();

                    PathFigure figure = new PathFigure();
                    figure.StartPoint = new Point(OffsetX, OffsetY);
                    figure.IsClosed = true;
                    figure.IsFilled = true;

                    figure.Segments.Add(new LineSegment(new Point(Math.Sin(angle) * 2 + OffsetX, -Math.Cos(angle) * 2 + OffsetY), false));
                    double a = item.Value * 2 * Math.PI / total;
                    angle += a;
                    figure.Segments.Add(new ArcSegment(new Point(Math.Sin(angle) * 2 + OffsetX, -Math.Cos(angle) * 2 + OffsetY), new Size(1, 1), 0, a > Math.PI, SweepDirection.Clockwise, false));

                    geometry.Figures.Add(figure);
                    drawing.Geometry = geometry;

                    group.Children.Add(drawing);
                }

                return group;
            }
        }
    }
}
