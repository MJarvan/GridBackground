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

namespace 飞镖
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow:Window
	{
		int[,] array = new int[4,2];

		public MainWindow()
		{
			InitializeComponent();
			UseLayoutRounding = true;
			array[0,0] = 0;
			array[0,1] = 1;
			array[1,0] = 1;
			array[1,1] = 2;
			array[2,0] = 2;
			array[2,1] = 1;
			array[3,0] = 1;
			array[3,1] = 0;
		}

		private void Window_Loaded(object sender,RoutedEventArgs e)
		{
			#region 角

			Grid grid = new Grid();
			grid.Width = 30;
			grid.Height = 10;

			ColumnDefinition cd1 = new ColumnDefinition();
			cd1.Width = new GridLength(1,GridUnitType.Star);
			ColumnDefinition cd2 = new ColumnDefinition();
			cd2.Width = new GridLength(1,GridUnitType.Star);
			grid.ColumnDefinitions.Add(cd1);
			grid.ColumnDefinitions.Add(cd2);

			TextBlock textblockL = new TextBlock();
			textblockL.Width = 15;
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
						new Rect(0,0,15,10)
						)
					)
				);

			drawingBrushL.Stretch = Stretch.Fill;
			drawingBrushL.TileMode = TileMode.FlipXY;
			drawingBrushL.Viewbox = new Rect(0,0,15,10);
			drawingBrushL.ViewboxUnits = BrushMappingMode.Absolute;
			textblockL.Background = drawingBrushL;
			grid.Children.Add(textblockL);
			Grid.SetColumn(textblockL,0);
			Grid.SetRow(textblockL,0);

			TextBlock textblockR = new TextBlock();
			textblockR.Width = 15;
			textblockR.Height = 10;

			LinearGradientBrush linearBrushR = new LinearGradientBrush();

			linearBrushR.SpreadMethod = GradientSpreadMethod.Repeat;
			linearBrushR.StartPoint = new Point(1,0);
			linearBrushR.EndPoint = new Point(0,1);
			linearBrushR.GradientStops.Add(new GradientStop(Colors.White,0.0));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.White,0.5));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.Black,0.5));
			linearBrushR.GradientStops.Add(new GradientStop(Colors.Black,1.0));


			DrawingBrush drawingBrushR = new DrawingBrush(
				new GeometryDrawing(
					linearBrushR,
					new Pen(new SolidColorBrush(Colors.Black),double.NaN)
					{
						//DashStyle = dashstyle
					},
					new RectangleGeometry(
						new Rect(0,0,15,10)
						)
					)
				);

			drawingBrushR.Stretch = Stretch.Fill;
			drawingBrushR.TileMode = TileMode.FlipXY;
			drawingBrushR.Viewbox = new Rect(0,0,15,10);
			drawingBrushR.ViewboxUnits = BrushMappingMode.Absolute;
			textblockR.Background = drawingBrushR;
			grid.Children.Add(textblockR);
			Grid.SetColumn(textblockR,1);
			Grid.SetRow(textblockR,0);

			#endregion

			for(int i = 0;i <= 3;i++)
			{
				TextBlock tb = new TextBlock();
				tb.Width = 10;
				tb.Height = 10;

				VisualBrush visualbrush = new VisualBrush(grid);

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

				drawingBrushTest.Stretch = Stretch.Uniform;
				drawingBrushTest.Viewbox = new Rect(0,0,10,10);
				drawingBrushTest.ViewboxUnits = BrushMappingMode.Absolute;
				tb.Background = drawingBrushTest;
				test.Children.Add(tb);
				Grid.SetRow(tb,array[i,0]);
				Grid.SetColumn(tb,array[i,1]);

				RotateTransform rotateTransform1 = new RotateTransform( i * 90,5,5);
				TransformGroup transformGroup1 = new TransformGroup();
				transformGroup1.Children.Add(rotateTransform1);
				tb.RenderTransform = transformGroup1;
			}

			Grid gridC = new Grid();
			gridC.Width = 10;
			gridC.Height = 10;
			gridC.Background = new SolidColorBrush(Colors.LightGray);
			test.Children.Add(gridC);
			Grid.SetColumn(gridC,1);
			Grid.SetRow(gridC,1);

			Ellipse ellipse = new Ellipse();
			ellipse.Width = 10;
			ellipse.Height = 10;
			ellipse.Fill = new SolidColorBrush(Colors.White);
			gridC.Children.Add(ellipse);
		}
	}
}
