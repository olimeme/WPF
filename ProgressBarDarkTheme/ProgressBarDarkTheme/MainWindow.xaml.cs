using System.ComponentModel;
using System.Windows;
namespace ProgressBarDarkTheme
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        private int workerState;

        public event PropertyChangedEventHandler PropertyChanged;

        public int WorkerState
        {
            get { return workerState; }
            set { workerState = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkerState"));
                }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            backgroundWorker.DoWork += (s, e) =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    WorkerState = i;
                    progressText = i.ToString() + "%";
                }
                MessageBox.Show("Done");
            };
            backgroundWorker.RunWorkerAsync();
        }
    }
}
