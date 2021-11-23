using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Queue;

namespace Task4
{
    public enum DataType
    {
        INT,
        STRING,
        DOUBLE
    }
    
    public partial class MainWindow : Window
    {
        
        public ArrayList DataList { get; private set; }
        public DataType DataType { get; private set; }
        
        private Random Rand = new();
        private bool IsDataValid;
        
        public MainWindow()
        {
            DataType = DataType.INT;
            DataList = new ArrayList();
        }

        public string RandomString(int size)
        {
            var builder = new StringBuilder(size);
            char offset = 'a';
            const int lettersOffset = 26; 

            for (var i = 0; i < size; i++)
            {
                var @char = (char)Rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }

        private void BtnGenerate_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsDataValid) return;
            
            var dataCount = Int32.Parse(DataCount.Text);
            DataList.Clear();
            
            for (int i = 0; i < dataCount; i++)
                switch (DataType)
                {
                    case DataType.INT:
                        DataList.Add(Rand.Next(-999, 999));
                        break;
                    case DataType.STRING:
                        DataList.Add(RandomString(Rand.Next(2, 8)));
                        break;
                    case DataType.DOUBLE:
                        DataList.Add(Rand.NextDouble() * 1000 - Rand.Next(0, 1000));
                        break;
                }
            
            ShowDataToBox();
        }
        

        private void ShowDataToBox()
        {
            DataBox.Text = String.Join(" ", DataList.ToArray());
        }
        
        private void OnDataTypeChange(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            DataType = Enum.Parse<DataType>(btn.Name);
            Debug.WriteLine(DataType);
        }

        private void DataCount_OnKeyUp(object sender, KeyEventArgs e)
        {
            var box = (TextBox)sender;
            IsDataValid = Int32.TryParse(box.Text, out int _);

            if (!IsDataValid && WarnLabel.Visibility == Visibility.Hidden) 
                WarnLabel.Visibility = Visibility.Visible;
            else if (IsDataValid && WarnLabel.Visibility == Visibility.Visible)
                WarnLabel.Visibility = Visibility.Hidden;
        }

        private void BtnOpenSort_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataList.Count == 0) return;
            
            SortWindow wnd = new (DataList, DataType);
            wnd.Show();
        }
    }
}