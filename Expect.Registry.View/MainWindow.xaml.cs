﻿using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using Expect.Registry.View.Pages;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Expect.Registry.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DataPage _dataPage;
		public MainWindow(DataPage dataPage)
		{
			InitializeComponent();
			_dataPage = dataPage;
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Main.Content = _dataPage;	
		}
	}
}
