using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OpenHeatMonitor.Controller
{
    internal class UpdateVisitor : IVisitor
    {
        void IVisitor.VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        void IVisitor.VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }

        void IVisitor.VisitParameter(IParameter parameter) { }

        void IVisitor.VisitSensor(ISensor sensor) { }
    }
}
