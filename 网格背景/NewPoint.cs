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
	public static class NewPoint
	{
		public static Grid GetNewPoint()
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

			Canvas point = RoundPoint.GetPoint();

			Grid grid = new Grid();
			grid.Height = 1200;
			grid.Width = 1200;

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

				VisualBrush visualbrush = new VisualBrush(point);

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

	public static class RoundPoint
	{
		public static Canvas GetPoint()
		{
			Canvas canvas = new Canvas();
			canvas.Height = 200;
			canvas.Width = 200;

			Path pathPoint = new Path();

			PathGeometry pathGeometry = new PathGeometry();
			ArcSegment arc = new ArcSegment(new Point(0,50),new Size(50,50),0,false,SweepDirection.Clockwise,true);
			PathFigure figureArc = new PathFigure();
			figureArc.StartPoint = new Point(50,0);
			figureArc.Segments.Add(arc);

			LineSegment line1 = new LineSegment(new Point(50,0),true);
			LineSegment line2 = new LineSegment(new Point(0,50),true);
			PathFigure figureLine = new PathFigure();
			figureLine.StartPoint = new Point(0,0);
			figureLine.Segments.Add(line1);
			figureLine.Segments.Add(line2);

			pathGeometry.Figures.Add(figureArc);
			pathGeometry.Figures.Add(figureLine);
			pathPoint.Data = pathGeometry;
			pathPoint.Fill = new SolidColorBrush(Colors.LightGray);

			canvas.Children.Add(pathPoint);

			Path pathPoint2 = new Path();

			PathGeometry pathGeometry2 = new PathGeometry();
			ArcSegment arc2 = new ArcSegment(new Point(0,10),new Size(10,10),0,false,SweepDirection.Clockwise,true);
			PathFigure figureArc2 = new PathFigure();
			figureArc2.StartPoint = new Point(10,0);
			figureArc2.Segments.Add(arc2);

			LineSegment line3 = new LineSegment(new Point(10,0),true);
			LineSegment line4 = new LineSegment(new Point(0,10),true);
			PathFigure figureLine2 = new PathFigure();
			figureLine2.StartPoint = new Point(0,0);
			figureLine2.Segments.Add(line3);
			figureLine2.Segments.Add(line4);

			pathGeometry2.Figures.Add(figureArc2);
			pathGeometry2.Figures.Add(figureLine2);
			pathPoint2.Data = pathGeometry2;
			pathPoint2.Fill = new SolidColorBrush(Colors.Black);

			canvas.Children.Add(pathPoint2);

			return canvas;
		}
	}
}
