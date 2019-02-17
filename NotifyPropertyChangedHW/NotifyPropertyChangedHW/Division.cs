using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyPropertyChangedHW
{
    public class Division : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
