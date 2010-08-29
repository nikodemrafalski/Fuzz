using System.ComponentModel;

namespace Logic
{
    public class AlgorithmParameter
    {
        private double value;

        public AlgorithmParameter(string name, double defaultValue)
        {
            Name = name;
            DefaultValue = value = defaultValue;
        }

        public string Name { get; private set; }

        public double Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public double DefaultValue { get; private set; }
        public event PropertyChangingEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangingEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    }
}