﻿using System;
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
using Microsoft.Research.DynamicDataDisplay.Markers2;
using Microsoft.Research.DynamicDataDisplay.Charts.Axes.Numeric;
using Microsoft.Research.DynamicDataDisplay.Charts;
using System.Collections.ObjectModel;
using Microsoft.Research.DynamicDataDisplay.Markers.DataSources;
using Microsoft.Research.DynamicDataDisplay.Charts.NewLine;

namespace Markers2Samples
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}

		ObservableCollection<Point> data = new ObservableCollection<Point>();
		const int count = 600;
		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			//lineChart.ItemsSource = new Func<double, double>(i => Math.Sin(i * 10));

			//plotter.MainHorizontalAxis = null;
			//plotter.Children.Remove(plotter.MainHorizontalAxis);

			var axis = new HorizontalAxis();

			plotter.Children.Add(axis);

			CustomBaseNumericTicksProvider ticksProvider = new CustomBaseNumericTicksProvider(Math.PI);
			CustomBaseNumericLabelProvider labelProvider = new CustomBaseNumericLabelProvider(Math.PI, "π");
			axis.LabelProvider = labelProvider;
			axis.TicksProvider = ticksProvider;

			for (int i = 0; i < count; i++)
			{
				data.Add(new Point(i, Math.Sin(i / 10)));
			}

			LineChart chart = new LineChart
			{
				ItemsSource = data,
				StrokeThickness = 3
			};
			plotter.Children.Add(chart);

			List<double> xs = Enumerable.Range(0, count).Select(i => (double)i).ToList();
			List<double> ys = Enumerable.Range(0, count).Select(i => Math.Sin(i / 10.0)).ToList();

			xAndYSeqChart.DataSource = DataSource.Create(xs, ys);
		}

		int i = count;
		private void RepeatButton_Click(object sender, RoutedEventArgs e)
		{
			data.Add(new Point(i, Math.Sin(i / 10)));
			i++;
		}
	}
}
