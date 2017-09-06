using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 圆弧
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow:Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender,RoutedEventArgs e)
		{
			Path pathArc = new Path();
			
			PathGeometry pathGeometry = new PathGeometry();
			ArcSegment arc = new ArcSegment(new Point(0,50),new Size(50,50),0,false,SweepDirection.Clockwise,true);
			PathFigure figureArc = new PathFigure();
			figureArc.StartPoint = new Point(50,0);
			figureArc.Segments.Add(arc);

			LineSegment line1 = new LineSegment(new Point(50,0),true);
			LineSegment line2 = new LineSegment(new Point(0,50),true);
			PathFigure figureLine = new PathFigure();
			figureLine.StartPoint = new Point(50,50);
			figureLine.Segments.Add(line1);
			figureLine.Segments.Add(line2);

			pathGeometry.Figures.Add(figureArc);
			pathGeometry.Figures.Add(figureLine);
			pathArc.Data = pathGeometry;
			pathArc.Fill = new SolidColorBrush(Colors.LightGray);

			this.canvas.Children.Add(pathArc);

			Path pathLine1 = new Path();

			StreamGeometry streamGeomety1 = new StreamGeometry();
			StreamGeometryContext sgc1 = streamGeomety1.Open();
			sgc1.BeginFigure(new Point(0,50),true,true);
			sgc1.LineTo(new Point(50,50),true,true);
			sgc1.LineTo(new Point(0,200),true,true);
			sgc1.Close();
			pathLine1.Data = streamGeomety1;
			pathLine1.Fill = new SolidColorBrush(Colors.LightGray);
			this.canvas.Children.Add(pathLine1);

			Path pathLine2 = new Path();

			StreamGeometry streamGeomety2 = new StreamGeometry();
			StreamGeometryContext sgc2 = streamGeomety2.Open();
			sgc2.BeginFigure(new Point(50,0),true,true);
			sgc2.LineTo(new Point(50,50),true,true);
			sgc2.LineTo(new Point(200,0),true,true);
			sgc2.Close();
			pathLine2.Data = streamGeomety2;
			pathLine2.Fill = new SolidColorBrush(Colors.LightGray);
			this.canvas.Children.Add(pathLine2);

		}
	}
}
