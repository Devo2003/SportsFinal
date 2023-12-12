using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace SportsFinal.ViewModels
{
    public class InputDialog : Window
    {
        public string Result { get; private set; }

        public InputDialog(string title, string label, string currentName)
        {
            Title = title;
            Label = label;
            CurrentName = currentName;

            InitializeComponents();
        }

        public string Label { get; }
        public string CurrentName { get; }

        private TextBox inputTextBox;

        private void InitializeComponents()
        {
            StackPanel stackPanel = new StackPanel();

            TextBlock labelBlock = new TextBlock();
            labelBlock.Text = Label;

            inputTextBox = new TextBox();
            inputTextBox.Text = CurrentName; // Set the current name in the input text box

            Button okButton = new Button();
            okButton.Content = "OK";
            okButton.Click += OkButton_Click;

            Button cancelButton = new Button();
            cancelButton.Content = "Cancel";
            cancelButton.Click += CancelButton_Click;

            stackPanel.Children.Add(labelBlock);
            stackPanel.Children.Add(inputTextBox);
            stackPanel.Children.Add(okButton);
            stackPanel.Children.Add(cancelButton);

            Content = stackPanel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Result = inputTextBox.Text;
            DialogResult = true; // Set DialogResult to true to indicate OK button was clicked
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = null;
            Close();
        }
    }
}
