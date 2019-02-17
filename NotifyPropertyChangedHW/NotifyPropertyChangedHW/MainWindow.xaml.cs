using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NotifyPropertyChangedHW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Division> divisions;

        string comboBoxName = "division";
        //string buttonName = "button";
        //string textBoxName = "employeeName";

        public MainWindow()
        {
            InitializeComponent();

            divisions = new ObservableCollection<Division>
            {
                new Division()
                {
                    Name = "First Division",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Doger",
                        },
                        new Employee()
                        {
                            Name = "Doger1",
                        },
                    }
                },
                new Division()
                {
                    Name = "Second Division",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Roger",
                        },
                        new Employee()
                        {
                            Name = "Roger1",
                        },
                        new Employee()
                        {
                            Name = "Roger2",
                        },
                    }
                },
                new Division()
                {
                    Name = "Third Division",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Booper",
                        },
                    }
                }
            };

            for (int i = 0; i < divisions.Count; i++)
            {
                ComboBox divisionComboBox = new ComboBox
                {
                    Name = comboBoxName + i.ToString(),
                    Width = 200,
                    Height = 22,
                    Margin = new Thickness(0, 40, 0, 0)
                };

                for (int j = 0; j < divisions[i].Employees.Count;j++)
                    divisionComboBox.Items.Add(divisions[i].Employees[j].Name);


                //------------------------------------Не рабочая часть----------------------------------------------
                // При запуске оно для каждой категории создает текстовое поле и кнопку с добавлением данных в comboBox из текстового поля

                //Button addEmployeeBtn = new Button
                //{
                //    Name = buttonName + i.ToString(),
                //    Content = "Добавить в " + (i+1),
                //    Width = 100,
                //    Height = 22,
                //    Margin = new Thickness(0, 10, 0, 0)
                //};

                //TextBox employeeNameTextBox = new TextBox
                //{
                //    Name = textBoxName + i.ToString(),
                //    Width = 150,
                //    Height = 22,
                //    Margin = new Thickness(0, 10, 0, 0),
                //};

                //добавление элеметов


                divisionItems.Items.Add(divisionComboBox);
                //divisionItems.Items.Add(addEmployeeBtn);
                //divisionItems.Items.Add(employeeNameTextBox);
                //addEmployeeBtn.Click += AddEmployee;
            }
        }

        // Событие при нажатии на кнопку 
        //private void AddEmployee(object sender, RoutedEventArgs e)
        //{
        //    var currentlyNeededTextBoxId = int.Parse(Regex.Replace((sender as Button).Name.ToString(), "[A-Za-z ]", ""));
        //    var currentlyNeededTextBoxName = textBoxName + currentlyNeededTextBoxId;
        //    TextBox textBox = (TextBox)divisionItems.FindName(currentlyNeededTextBoxName);
        //}
    }
}
