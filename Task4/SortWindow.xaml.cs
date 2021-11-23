using System;
using System.Collections;
using System.Windows;
using Queue;

namespace Task4
{
    public partial class SortWindow : Window
    {
        private ArrayList Data;
        private DataType DataType;
        public SortWindow(ArrayList data, DataType dataType)
        {
            Data = data;
            DataType = dataType;
            
            
            InitializeComponent();
            FillDataTextBox();
        }

        private void FillDataTextBox()
        {
            DataTextBox.Text = String.Join(" ", Data.ToArray());
        }

        private void BtnM1Sort_OnClick(object sender, RoutedEventArgs e)
        {
            if (M1SortData.Text != "") return;

            Queue<IComparable> queue = new();
            switch (DataType)
            {
                case DataType.INT:
                    foreach (int el in Data) queue.Push(el);
                    break;
                case DataType.STRING:
                    foreach (string el in Data) queue.Push(el);
                    break;
                case DataType.DOUBLE:
                    foreach (double el in Data) queue.Push(el);
                    break;
            }
            QueueSortTools.SelectionSort(queue);
            M1SortData.Text = queue.ToString();
        }
        
        private void BtnM5Sort_OnClick(object sender, RoutedEventArgs e)
        {
            if (M5SortData.Text != "") return;

            Queue<IComparable> queue = new();
            switch (DataType)
            {
                case DataType.INT:
                    foreach (int el in Data) queue.Push(el);
                    break;
                case DataType.STRING:
                    foreach (string el in Data) queue.Push(el);
                    break;
                case DataType.DOUBLE:
                    foreach (double el in Data) queue.Push(el);
                    break;
            }
            QueueSortTools.SelectionSort(queue);
            M5SortData.Text = queue.ToString();

        }
    }
}