using System;
using System.Timers;
using LibreHardwareMonitor.Hardware;
using OpenHeatMonitor.Model;

namespace OpenHeatMonitor.Controller
{
    internal class HardwareUpdater
    {
        private readonly int DEFAULT_TIMER_INTERVAL = 5000;
        private System.Timers.Timer updateTimer;

        // LibreHardwareMonitor
        private readonly Computer computerSensors;
        private readonly UpdateVisitor updateVisitor;

        private readonly ComputerHardware computerHardware;

        public HardwareUpdater(ComputerHardware hw)
        {
            // Initialize new timer
            updateTimer = new System.Timers.Timer { Interval = DEFAULT_TIMER_INTERVAL };
            updateTimer.Elapsed += Run;

            // Create a new computer for reading sensors
            computerSensors = new Computer {
                IsCpuEnabled = true
            };
            computerSensors.Open();
            updateVisitor = new UpdateVisitor();
            UpdateSensors();

            computerHardware = hw;
            InitHardware();
        }

        public void Start() { updateTimer.Start(); }

        public void Stop() { updateTimer.Stop(); }

        private void Run(object? source, ElapsedEventArgs e) 
        {
            Console.WriteLine("Updating sensors");
            UpdateSensors();
        }

        private void UpdateSensors() { computerSensors.Accept(updateVisitor); }

        private void InitHardware()
        {
            foreach (IHardware hardware in computerSensors.Hardware)
            {
                computerHardware.AddHardwareCategory(hardware.Name);
            }
        }
    }
}
