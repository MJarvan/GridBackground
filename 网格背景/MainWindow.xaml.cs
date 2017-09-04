using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 网格背景
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow:Window
	{
		public MainWindow()
		{
			InitializeComponent();
			UseLayoutRounding = true;
			this.InitItem();
        }

		public void InitItem()
		{
			
		}
	}

	public class MyCanvas:Canvas
	{
		public static double HORIZONTAL_OFFSET = 10;
		public static double VERTICAL_OFFSET = 10;

		public MyCanvas()
		{
			#region 点

			//DoubleCollection doubleCollection = new DoubleCollection();
			//doubleCollection.Add(5);
			//DashStyle dashstyle = new DashStyle();
			//dashstyle.Dashes = doubleCollection;
			//dashstyle.Offset = 2;

			//DrawingBrush drawingBrush = new DrawingBrush(
			//	new GeometryDrawing(
			//		new SolidColorBrush(Colors.Transparent),
			//		new Pen(new SolidColorBrush(Colors.Black),1)
			//		{
			//			DashStyle = dashstyle
			//		},
			//		new RectangleGeometry(
			//			new Rect(0,0,HORIZONTAL_OFFSET,VERTICAL_OFFSET)
			//			)
			//		)
			//	);

			//drawingBrush.Stretch = Stretch.None;
			//drawingBrush.TileMode = TileMode.Tile;
			//drawingBrush.Viewport = new Rect(0.0,0.0,HORIZONTAL_OFFSET,VERTICAL_OFFSET);
			//drawingBrush.ViewportUnits = BrushMappingMode.Absolute;
			//this.Background = drawingBrush;

			#endregion

			#region 线

			//LinearGradientBrush linearBrush = new LinearGradientBrush();

			//linearBrush.SpreadMethod = GradientSpreadMethod.Repeat;
			//linearBrush.StartPoint = new Point(0,0);
			//linearBrush.EndPoint = new Point(1,0);
			//linearBrush.GradientStops.Add(new GradientStop(Colors.LightGray,0.0));
			//linearBrush.GradientStops.Add(new GradientStop(Colors.LightGray,0.5));
			//linearBrush.GradientStops.Add(new GradientStop(Colors.White,0.5));
			//linearBrush.GradientStops.Add(new GradientStop(Colors.White,1.0));


			//DrawingBrush drawingBrush = new DrawingBrush(
			//	new GeometryDrawing(
			//		linearBrush,
			//		new Pen(new SolidColorBrush(Colors.Gray),1)
			//		{
			//			//DashStyle = dashstyle
			//		},
			//		new RectangleGeometry(
			//			new Rect(0,0,20,10)
			//			)
			//		)
			//	);
			//drawingBrush.Stretch = Stretch.Fill;
			//drawingBrush.TileMode = TileMode.FlipX;
			//drawingBrush.Viewbox = new Rect(0,0,20,10);
			//drawingBrush.ViewboxUnits = BrushMappingMode.Absolute;
			//drawingBrush.Viewport = new Rect(0,0,40,10);
			//drawingBrush.ViewportUnits = BrushMappingMode.Absolute;
			//this.Background = drawingBrush;

			#endregion

			#region 格子
			//this.Width = 40;
			//this.Height = 40;

			//double width = this.Width;
			//double height = this.Height;
			//bool colors = false;//false是白色,true是黑色

			//int widthCount = (int)(width / HORIZONTAL_OFFSET);
			//int heightCount = (int)(height / VERTICAL_OFFSET);

			////长和宽双数
			//if(heightCount % 2 == 0 && widthCount % 2 == 0)
			//{
			//	for(var i = 0;i <= heightCount;i++)//行循环添加label
			//	{
			//		for(var j = 0;j <= widthCount;j++)//列循环添加label
			//		{
			//			#region 涂色
			//			if(colors == false)
			//			{
			//				Point startpoint = new Point();
			//				startpoint.X = j * 10;
			//				startpoint.Y = i * 10;

			//				Point secondpoint = new Point();
			//				secondpoint.X = j * 10 + 10;
			//				secondpoint.Y = i * 10;

			//				Point thirdpoint = new Point();
			//				thirdpoint.X = j * 10 + 10;
			//				thirdpoint.Y = i * 10 + 10;

			//				Point endpoint = new Point();
			//				endpoint.X = j * 10;
			//				endpoint.Y = i * 10 + 10;

			//				Path path = new Path();
			//				StreamGeometry streamGeomety = new StreamGeometry();
			//				StreamGeometryContext sgc = streamGeomety.Open();
			//				sgc.BeginFigure(startpoint,true,true);
			//				sgc.LineTo(secondpoint,true,true);
			//				sgc.LineTo(thirdpoint,true,true);
			//				sgc.LineTo(endpoint,true,true);
			//				sgc.Close();
			//				path.Data = streamGeomety;
			//				path.Fill = new SolidColorBrush(Colors.White);
			//				path.Stroke = new SolidColorBrush(Colors.White);
			//				path.StrokeThickness = 1;
			//				this.Children.Add(path);
			//				SetLeft(path,0);
			//				SetTop(path,0);
			//				colors = true;
			//			}
			//			else if(colors == true)
			//			{
			//				Point startpoint = new Point();
			//				startpoint.X = j * 10;
			//				startpoint.Y = i * 10;

			//				Point secondpoint = new Point();
			//				secondpoint.X = j * 10 + 10;
			//				secondpoint.Y = i * 10;

			//				Point thirdpoint = new Point();
			//				thirdpoint.X = j * 10 + 10;
			//				thirdpoint.Y = i * 10 + 10;

			//				Point endpoint = new Point();
			//				endpoint.X = j * 10;
			//				endpoint.Y = i * 10 + 10;

			//				Path path = new Path();
			//				StreamGeometry streamGeomety = new StreamGeometry();
			//				StreamGeometryContext sgc = streamGeomety.Open();
			//				sgc.BeginFigure(startpoint,true,true);
			//				sgc.LineTo(secondpoint,true,true);
			//				sgc.LineTo(thirdpoint,true,true);
			//				sgc.LineTo(endpoint,true,true);
			//				sgc.Close();
			//				path.Data = streamGeomety;
			//				path.Fill = new SolidColorBrush(Colors.Gray);
			//				path.Stroke = new SolidColorBrush(Colors.Gray);
			//				path.StrokeThickness = 1;
			//				this.Children.Add(path);
			//				SetLeft(path,0);
			//				SetTop(path,0);
			//				colors = false;
			//			}
			//			#endregion
			//		}
			//	}
			//}


			#endregion

			#region 新格子

			//Grid grid = new Grid();

			//grid.Width = 20;
			//grid.Height = 20;

			//RowDefinition rd1 = new RowDefinition();
			//rd1.Height = new GridLength(1,GridUnitType.Star);

			//RowDefinition rd2 = new RowDefinition();
			//rd2.Height = new GridLength(1,GridUnitType.Star);

			//ColumnDefinition cd1 = new ColumnDefinition();
			//cd1.Width = new GridLength(1,GridUnitType.Star);

			//ColumnDefinition cd2 = new ColumnDefinition();
			//cd2.Width = new GridLength(1,GridUnitType.Star);

			//grid.RowDefinitions.Add(rd1);
			//grid.RowDefinitions.Add(rd2);
			//grid.ColumnDefinitions.Add(cd1);
			//grid.ColumnDefinitions.Add(cd2);

			//for(int i = 0;i < grid.RowDefinitions.Count;i++)
			//{
			//	for(int j = 0;j < grid.ColumnDefinitions.Count;j++)
			//	{
			//		if((i == 0 && j ==0) ||(i == 1 && j == 1))
			//		{
			//			Rectangle rect = new Rectangle();
			//			rect.Fill = new SolidColorBrush(Colors.White);
			//			grid.Children.Add(rect);
			//			Grid.SetRow(rect,i);
			//			Grid.SetColumn(rect,j);
			//		}
			//		else
			//		{
			//			Rectangle rect = new Rectangle();
			//			rect.Fill = new SolidColorBrush(Colors.LightGray);
			//			grid.Children.Add(rect);
			//			Grid.SetRow(rect,i);
			//			Grid.SetColumn(rect,j);
			//		}
			//	}
			//}

			//VisualBrush visualbrush = new VisualBrush(grid);

			//DrawingBrush drawingBrush = new DrawingBrush(
			//	new GeometryDrawing(
			//		visualbrush,
			//		new Pen(new SolidColorBrush(Colors.Gray),double.NaN)
			//		{
			//						//DashStyle = dashstyle
			//					},
			//		new RectangleGeometry(
			//			new Rect(0,0,20,20)
			//			)
			//		)
			//	);
			//drawingBrush.Stretch = Stretch.Fill;
			//drawingBrush.TileMode = TileMode.Tile;
			//drawingBrush.Viewbox = new Rect(0,0,20,20);
			//drawingBrush.ViewboxUnits = BrushMappingMode.Absolute;
			//drawingBrush.Viewport = new Rect(0,0,20,20);
			//drawingBrush.ViewportUnits = BrushMappingMode.Absolute;
			//this.Background = drawingBrush;

			#endregion

			#region 飞镖

			Grid grid = Dart.GetDart();

			VisualBrush visualbrush = new VisualBrush(grid);

			DrawingBrush drawingBrushAll = new DrawingBrush(
				new GeometryDrawing(
					visualbrush,
					new Pen(new SolidColorBrush(Colors.Gray),double.NaN)
					{
						//DashStyle = dashstyle
					},
					new RectangleGeometry(
						new Rect(0,0,30,30)
						)
					)
				);
			drawingBrushAll.Stretch = Stretch.Fill;
			drawingBrushAll.TileMode = TileMode.Tile;
			drawingBrushAll.Viewbox = new Rect(0,0,30,30);
			drawingBrushAll.ViewboxUnits = BrushMappingMode.Absolute;
			drawingBrushAll.Viewport = new Rect(0,0,30,30);
			drawingBrushAll.ViewportUnits = BrushMappingMode.Absolute;
			this.Background = drawingBrushAll;

			#endregion
		}

		protected override Geometry GetLayoutClip(Size layoutSlotSize)//也可以
		{
			double doubleMaxHeight = 0.0;
			double doubleMaxWidth = 0.0;
			foreach(UIElement uiElement in this.Children)
			{
				double doubleLeft = Canvas.GetLeft(uiElement);
				double doubleTop = Canvas.GetTop(uiElement);
				double doubleWidth = uiElement.RenderSize.Width;
				double doubleHeight = uiElement.RenderSize.Height;

				if((doubleLeft + doubleWidth) > doubleMaxWidth)
				{
					doubleMaxWidth = doubleLeft + doubleWidth;
				}

				if((doubleTop + doubleHeight) > doubleMaxHeight)
				{
					doubleMaxHeight = doubleTop + doubleHeight;
				}
			}

			double doubleCanvasWidth = doubleMaxWidth;
			double doubleCanvasHeight = doubleMaxHeight;
			FrameworkElement frameworkElement = this.Parent as FrameworkElement;
			if(frameworkElement != null)
			{
				if(!double.IsNaN(frameworkElement.ActualWidth))
				{
					doubleCanvasWidth = Math.Max(doubleMaxWidth,frameworkElement.ActualWidth);
				}
				if(!double.IsNaN(frameworkElement.ActualHeight))
				{
					doubleCanvasHeight = Math.Max(doubleMaxHeight,frameworkElement.ActualHeight);
				}
			}

			this.Width = doubleCanvasWidth;
			this.Height = doubleCanvasHeight;

			//System.Console.WriteLine(DateTime.Now.ToString());

			return base.GetLayoutClip(layoutSlotSize);
		}

		#region YL 20170724 也可以解决Canvas滚动条的问题，但仅仅是拖拽子空间大小才能触发
		//protected override Size MeasureOverride(Size constraint)
		//{
		//	Size size = new Size();
		//	foreach(UIElement uiElement in this.Children)
		//	{
		//		double doubleLeft = Canvas.GetLeft(uiElement);
		//		double doubleTop = Canvas.GetTop(uiElement);
		//		doubleLeft = double.IsNaN(doubleLeft) ? 0 : doubleLeft;
		//		doubleTop = double.IsNaN(doubleTop) ? 0 : doubleTop;

		//		uiElement.Measure(constraint);

		//		Size sizeDesired = uiElement.DesiredSize;
		//		if(!double.IsNaN(sizeDesired.Width) && !double.IsNaN(sizeDesired.Height))
		//		{
		//			size.Width = Math.Max(size.Width,doubleLeft + sizeDesired.Width);
		//			size.Height = Math.Max(size.Height,doubleTop + sizeDesired.Height);
		//		}
		//	}

		//	//System.Console.WriteLine(size.ToString());
		//	return size;
		//}
		#endregion YL 20170724 也可以解决Canvas滚动条的问题，但仅仅是拖拽子空间大小才能触发
	}

}
