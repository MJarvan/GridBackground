using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace 网格背景
{
	public static class NewDart
	{
		public static Grid GetNewDart()
		{
			int[,] array = new int[4,2];

			array[0,0] = 0;
			array[0,1] = 0;
			array[1,0] = 0;
			array[1,1] = 1;
			array[2,0] = 1;
			array[2,1] = 1;
			array[3,0] = 1;
			array[3,1] = 0;

			Canvas arc = Arc.GetArc();

			Grid grid = new Grid();
			grid.Height = 400;
			grid.Width = 400;

			RowDefinition rd1 = new RowDefinition();
			rd1.Height = new GridLength(1,GridUnitType.Star);

			RowDefinition rd2 = new RowDefinition();
			rd2.Height = new GridLength(1,GridUnitType.Star);

			ColumnDefinition cd1 = new ColumnDefinition();
			cd1.Width = new GridLength(1,GridUnitType.Star);

			ColumnDefinition cd2 = new ColumnDefinition();
			cd2.Width = new GridLength(1,GridUnitType.Star);


			grid.RowDefinitions.Add(rd1);
			grid.RowDefinitions.Add(rd2);
			grid.ColumnDefinitions.Add(cd1);
			grid.ColumnDefinitions.Add(cd2);

			for(int i = 0;i <= 3;i++)
			{
				TextBlock tb = new TextBlock();
				tb.Width = 200;
				tb.Height = 200;

				VisualBrush visualbrush = new VisualBrush(arc);

				DrawingBrush drawingBrushTest = new DrawingBrush(
					new GeometryDrawing(
						visualbrush,
						new Pen(new SolidColorBrush(Colors.Black),double.NaN)
						{
							//DashStyle = dashstyle
						},
						new RectangleGeometry(
							new Rect(0,0,200,200)
							)
						)
					);

				drawingBrushTest.Stretch = Stretch.Fill;
				drawingBrushTest.Viewbox = new Rect(0,0,200,200);
				drawingBrushTest.ViewboxUnits = BrushMappingMode.Absolute;
				tb.Background = drawingBrushTest;
				grid.Children.Add(tb);
				Grid.SetRow(tb,array[i,0]);
				Grid.SetColumn(tb,array[i,1]);

				RotateTransform rotateTransform1 = new RotateTransform(i * 90,100,100);
				TransformGroup transformGroup1 = new TransformGroup();
				transformGroup1.Children.Add(rotateTransform1);
				tb.RenderTransform = transformGroup1;
			}

			return grid;
		}
	}

	public static class Arc
	{
		public static Canvas GetArc()
		{
			Canvas canvas = new Canvas();
			canvas.Height = 200;
			canvas.Width = 200;

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

			canvas.Children.Add(pathArc);

			Path pathLine1 = new Path();

			StreamGeometry streamGeomety1 = new StreamGeometry();
			StreamGeometryContext sgc1 = streamGeomety1.Open();
			sgc1.BeginFigure(new Point(0,50),true,true);
			sgc1.LineTo(new Point(50,50),true,true);
			sgc1.LineTo(new Point(0,200),true,true);
			sgc1.Close();
			pathLine1.Data = streamGeomety1;
			pathLine1.Fill = new SolidColorBrush(Colors.LightGray);
			canvas.Children.Add(pathLine1);

			Path pathLine2 = new Path();

			StreamGeometry streamGeomety2 = new StreamGeometry();
			StreamGeometryContext sgc2 = streamGeomety2.Open();
			sgc2.BeginFigure(new Point(50,0),true,true);
			sgc2.LineTo(new Point(50,50),true,true);
			sgc2.LineTo(new Point(200,0),true,true);
			sgc2.Close();
			pathLine2.Data = streamGeomety2;
			pathLine2.Fill = new SolidColorBrush(Colors.LightGray);
			canvas.Children.Add(pathLine2);

			return canvas;
		}
	}
}
