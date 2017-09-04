using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace 网格背景
{
	public static class Corn
	{
		public static Grid GetCorn()
		{
			Grid grid = new Grid();
			grid.Width = 20;
			grid.Height = 10;

			ColumnDefinition cd1 = new ColumnDefinition();
			cd1.Width = new GridLength(1,GridUnitType.Star);
			ColumnDefinition cd2 = new ColumnDefinition();
			cd2.Width = new GridLength(1,GridUnitType.Star);
			grid.ColumnDefinitions.Add(cd1);
			grid.ColumnDefinitions.Add(cd2);

			TextBlock textblockL = new TextBlock();
			textblockL.Width = 10;
			textblockL.Height = 10;

			LinearGradientBrush linearBrushL = new LinearGradientBrush();

			linearBrushL.SpreadMethod = GradientSpreadMethod.Repeat;
			linearBrushL.StartPoint = new Point(0,0);
			linearBrushL.EndPoint = new Point(1,1);
			linearBrushL.GradientStops.Add(new GradientStop(Colors.White,0.0));
			linearBrushL.GradientStops.Add(new GradientStop(Colors.White,0.5));
			linearBrushL.GradientStops.Add(new GradientStop(Colors.LightGray,0.5));
			linearBrushL.GradientStops.Add(new GradientStop(Colors.LightGray,1.0));


			DrawingBrush drawingBrushL = new DrawingBrush(
				new GeometryDrawing(
					linearBrushL,
					new Pen(new SolidColorBrush(Colors.Black),double.NaN)
					{
						//DashStyle = dashstyle
					},
					new RectangleGeometry(
						new Rect(0,0,10,10)
						)
					)
				);

			drawingBrushL.Stretch = Stretch.Fill;
			drawingBrushL.TileMode = TileMode.FlipXY;
			drawingBrushL.Viewbox = new Rect(0,0,10,10);
			drawingBrushL.ViewboxUnits = BrushMappingMode.Absolute;
			textblockL.Background = drawingBrushL;
			grid.Children.Add(textblockL);
			Grid.SetColumn(textblockL,0);
			Grid.SetRow(textblockL,0);

			TextBlock textblockR = new TextBlock();
			textblockR.Width = 10;
			textblockR.Height = 10;

			LinearGradientBrush linearBrushR = new LinearGradientBrush();

			linearBrushR.SpreadMethod = GradientSpreadMethod.Repeat;
			linearBrushR.StartPoint = new Point(1,0);
			linearBrushR.EndPoint = new Point(0,1);
			linearBrushR.GradientStops.Add(new GradientStop(Colors.White,0.0));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.White,0.5));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.LightGray,0.5));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.LightGray,1.0));


			DrawingBrush drawingBrushR = new DrawingBrush(
				new GeometryDrawing(
					linearBrushR,
					new Pen(new SolidColorBrush(Colors.Black),double.NaN)
					{
						//DashStyle = dashstyle
					},
					new RectangleGeometry(
						new Rect(0,0,10,10)
						)
					)
				);

			drawingBrushR.Stretch = Stretch.Fill;
			drawingBrushR.TileMode = TileMode.FlipXY;
			drawingBrushR.Viewbox = new Rect(0,0,10,10);
			drawingBrushR.ViewboxUnits = BrushMappingMode.Absolute;
			textblockR.Background = drawingBrushR;
			grid.Children.Add(textblockR);
			Grid.SetColumn(textblockR,1);
			Grid.SetRow(textblockR,0);

			return grid;
		}
	}
}
