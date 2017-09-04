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
	public static class Dart
	{

		public static Grid GetDart()
		{
			int[,] array = new int[4,2];

			array[0,0] = 0;
			array[0,1] = 1;
			array[1,0] = 1;
			array[1,1] = 2;
			array[2,0] = 2;
			array[2,1] = 1;
			array[3,0] = 1;
			array[3,1] = 0;

			Grid corn = Corn.GetCorn();

			Grid grid = new Grid();
			grid.Height = 30;
			grid.Width = 30;

			RowDefinition rd1 = new RowDefinition();
			rd1.Height = new GridLength(1,GridUnitType.Star);

			RowDefinition rd2 = new RowDefinition();
			rd2.Height = new GridLength(1,GridUnitType.Star);

			RowDefinition rd3 = new RowDefinition();
			rd2.Height = new GridLength(1,GridUnitType.Star);

			ColumnDefinition cd1 = new ColumnDefinition();
			cd1.Width = new GridLength(1,GridUnitType.Star);

			ColumnDefinition cd2 = new ColumnDefinition();
			cd2.Width = new GridLength(1,GridUnitType.Star);

			ColumnDefinition cd3 = new ColumnDefinition();
			cd2.Width = new GridLength(1,GridUnitType.Star);

			grid.RowDefinitions.Add(rd1);
			grid.RowDefinitions.Add(rd2);
			grid.RowDefinitions.Add(rd3);
			grid.ColumnDefinitions.Add(cd1);
			grid.ColumnDefinitions.Add(cd2);
			grid.ColumnDefinitions.Add(cd3);

			for(int i = 0;i <= 3;i++)
			{
				TextBlock tb = new TextBlock();
				tb.Width = 10;
				tb.Height = 10;

				VisualBrush visualbrush = new VisualBrush(corn);

				DrawingBrush drawingBrushTest = new DrawingBrush(
					new GeometryDrawing(
						visualbrush,
						new Pen(new SolidColorBrush(Colors.Black),double.NaN)
						{
							//DashStyle = dashstyle
						},
						new RectangleGeometry(
							new Rect(0,0,10,10)
							)
						)
					);

				drawingBrushTest.Stretch = Stretch.Fill;
				drawingBrushTest.Viewbox = new Rect(0,0,10,10);
				drawingBrushTest.ViewboxUnits = BrushMappingMode.Absolute;
				tb.Background = drawingBrushTest;
				grid.Children.Add(tb);
				Grid.SetRow(tb,array[i,0]);
				Grid.SetColumn(tb,array[i,1]);

				RotateTransform rotateTransform1 = new RotateTransform(i * 90,5,5);
				TransformGroup transformGroup1 = new TransformGroup();
				transformGroup1.Children.Add(rotateTransform1);
				tb.RenderTransform = transformGroup1;
			}

			Grid gridC = new Grid();
			gridC.Width = 10;
			gridC.Height = 10;
			gridC.Background = new SolidColorBrush(Colors.LightGray);
			grid.Children.Add(gridC);
			Grid.SetColumn(gridC,1);
			Grid.SetRow(gridC,1);

			Ellipse ellipse = new Ellipse();
			ellipse.Width = 10;
			ellipse.Height = 10;
			ellipse.Fill = new SolidColorBrush(Colors.White);
			gridC.Children.Add(ellipse);

			return grid;
		}
	}
}
