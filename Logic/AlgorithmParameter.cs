using System.ComponentModel;

namespace Logic
{
    public class AlgorithmParameter
    {
        public event PropertyChangingEventHandler PropertyChanged;
        private double value;

        public AlgorithmParameter(string name, double defaultValue)
        {
            this.Name = name;
            this.DefaultValue = this.value = defaultValue;
        }

        public string Name
        {
            get;
            private set;
        }

        public double Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                }
            }
        }

        public double DefaultValue
        {
            get;
            private set;
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    }
}