namespace OpenHeatMonitor.Model
{

    /// <summary>
    /// Class holding sensor readings from the computer
    /// </summary>
    public class ComputerHardware : IObservable<ComputerHardware>
    {
        /// <summary>
        /// Observers for ComputerHardware.
        /// </summary>
        private readonly HashSet<IObserver<ComputerHardware>> _observers;

        /// <summary>
        /// List of hardware categories.
        /// </summary>
        public IList<HardwareCategory> HardwareCategories { get; set; }

        /// <summary>
        /// Constructor for ComputerStats class
        /// </summary> 
        public ComputerHardware()
        {
            _observers = new();
            HardwareCategories = new List<HardwareCategory>();
        }

        /// <summary>
        /// Adds new hardware categories to the list of categories
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void AddHardwareCategory(string name) 
        {
            HardwareCategory newCat = new(name);
            HardwareCategories.Add(newCat);
            
            // Update the observers
            foreach (IObserver<ComputerHardware> obs in _observers)
            {
                obs.OnNext(this);
            }
        }

        /// <summary>
        /// Add a property to the computer hardware
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddHardwareProperty(string CategoryName, string propertyName, string value) 
        {
            HardwareCategory ?cat = HardwareCategories.FirstOrDefault(c => c.Name == CategoryName);
            cat?.AddHardwareProperty(propertyName, value);

            // Update the observers
            foreach (IObserver<ComputerHardware> obs in _observers)
            {
                obs.OnNext(this);
            }
        }

        IDisposable IObservable<ComputerHardware>.Subscribe(IObserver<ComputerHardware> observer)
        {
            // Add observer to list of observers, if not already there.
            if (_observers.Add(observer))
            {
                // Provide 
                observer.OnNext(this);
            }

            return new Unsubscriber(_observers, observer);
        }
        
        /// <summary>
        /// Unsubscriber class so observers can unsubscribe themselves.
        /// </summary>
        private class Unsubscriber : IDisposable
        {
            private HashSet<IObserver<ComputerHardware>> _observers;
            private IObserver<ComputerHardware> _observer;

            public Unsubscriber(HashSet<IObserver<ComputerHardware>> observers, IObserver<ComputerHardware> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            // Remove observer from list of observers
            public void Dispose()
            {
                if (!(_observer != null)) { _observers.Remove(_observer); }
            }
        }
    }
}
