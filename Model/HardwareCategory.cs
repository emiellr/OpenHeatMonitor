namespace OpenHeatMonitor.Model
{
    /// <summary>
    /// Category of hardware.
    /// </summary>
    /// <example>CPU, GPU etc</example>
    public class HardwareCategory
    {
        /// <summary>
        /// Name of the HardwareCategory.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// List of HardwareProperties.
        /// </summary>
        public IList<HardwareProperty> Properties { get; set; }

        /// <summary>
        /// Constructor of HardwareCategory class.
        /// </summary>
        /// <param name="name"></param>
        public HardwareCategory(string name)
        {
            Name = name;
            Properties = new List<HardwareProperty>();
        }

        /// <summary>
        /// Creates and adds a HardwareProperty to the list of HardwareProperties.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddHardwareProperty(string name, string value)
        {
            HardwareProperty prop = new HardwareProperty(name, value);
            Properties.Add(prop);
        }

        /// <summary>
        /// Removes a HardwareProperty from the list.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveHardwareProperty(string name)
        {
            HardwareProperty ?prop = Properties.FirstOrDefault(p => p.Name == name);
            if (prop != null) Properties.Remove(prop);
        }

        /// <summary>
        /// Updates the value of a HardwareProperty.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void UpdateHardwareProperty(string name, string value)
        {
            HardwareProperty ?prop = Properties.FirstOrDefault(p => p.Name == name);
            if (prop != null) prop.Value = value;
        }
    }
}
