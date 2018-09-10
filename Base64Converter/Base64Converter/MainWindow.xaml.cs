using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Base64Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string outputFilename;

        public MainWindow()
        {
            InitializeComponent();
            outputFilename = Converter.CreateFilename();
        }

        private void OutputSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileChooser = new SaveFileDialog
            {
                DefaultExt      = "pdf",
                AddExtension    = true
            };

            if (fileChooser.ShowDialog() == true)
            {
                outputFilename = fileChooser.FileName;
                OutputResetButton.Visibility = Visibility.Visible;
            }
        }

        private void OutputResetButton_Click(object sender, RoutedEventArgs e)
        {
            outputFilename = Converter.CreateFilename();
            OutputResetButton.Visibility = Visibility.Hidden;
        }

        private void FileSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();

            if (fileChooser.ShowDialog() == true)
            {
                B64box.Text = File.ReadAllText(fileChooser.FileName);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBoxResult.Yes;

            if (File.Exists(outputFilename)) {
                msgResult = MessageBox.Show(
                    "Output file already exists, do you wish to overwrite?",
                    "File exists",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
            }

            if (msgResult == MessageBoxResult.Yes && !string.IsNullOrWhiteSpace(B64box.Text)){
                try
                {
                    File.WriteAllBytes(outputFilename, Converter.Base64Decode(B64box.Text));
                    Process.Start(outputFilename);
                    outputFilename = Converter.CreateFilename();
                    OutputResetButton.Visibility = Visibility.Hidden;
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "Invalid base64 string",
                        "Invalid text",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );
                }
            }
        }
    }
}
