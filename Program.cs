using OpenHeatMonitor.Controller;
using OpenHeatMonitor.Model;

namespace OpenHeatMonitor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Controller setup
            ComputerHardware computerHardware = new();
            HardwareUpdater hardwareUpdater = new(computerHardware);
            hardwareUpdater.Start();

            Form1 form = new Form1();
            form.Subscribe(computerHardware);

            Application.Run(form);
        }
    }
}