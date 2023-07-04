using LibreHardwareMonitor.Hardware;
using OpenHeatMonitor.Model;

namespace OpenHeatMonitor
{
    public partial class Form1 : Form, IObserver<ComputerHardware>
    {
        private IDisposable unsubscriber;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void UpdateView(ComputerHardware computerHardware)
        {
            richTextBox1.Clear();
            foreach (HardwareCategory hardwareCategory in computerHardware.HardwareCategories)
            {
                richTextBox1.AppendText(hardwareCategory.Name + '\n');
            }
        }

        public virtual void Subscribe(IObservable<ComputerHardware> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        void IObserver<ComputerHardware>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        void IObserver<ComputerHardware>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<ComputerHardware>.OnNext(ComputerHardware computerHardware)
        {
            UpdateView(computerHardware);
        }
    }
}