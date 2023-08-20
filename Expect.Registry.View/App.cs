﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Expect.Registry.View
{
    public class App : Application
    {
        private readonly MainWindow _mainWindow;

		public App(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			_mainWindow.Show();
			base.OnStartup(e);
		}
	}
}