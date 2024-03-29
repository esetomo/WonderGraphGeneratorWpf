﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WonderGraphGeneratorWpf.ViewModels;

namespace WonderGraphGeneratorWpf.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveAs_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            MainViewModel viewModel = this.DataContext as MainViewModel;
            if (viewModel == null)
                return;

            ICommand command = viewModel.SaveAsCommand;
            if (command == null)
                return;

            e.Handled = true;
            e.CanExecute = command.CanExecute(this.viewPort);
        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainViewModel viewModel = this.DataContext as MainViewModel;
            if (viewModel == null)
                return;

            ICommand command = viewModel.SaveAsCommand;
            if (command == null)
                return;

            e.Handled = true;
            command.Execute(this.viewPort);
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
