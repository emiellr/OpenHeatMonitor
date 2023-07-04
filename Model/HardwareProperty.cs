namespace OpenHeatMonitor.Model
{
    /// <summary>
    /// HardwareProperty class for sensor information storage.
    /// </summary>
    public class HardwareProperty
    {
        public string Name { get; }
        public string Value { get; set; }

        /// <summary>
        /// HardwareProperty constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public HardwareProperty(string name, string value) 
        { 
            this.Name = name;
            this.Value = value;
        }

        public HardwareProperty(string name) : this(name, string.Empty) { }
    }
}
