using System;
using System.ComponentModel;

namespace Task3.ViewModel
{
    public class ParameterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Name { get; set; }
        public Type Type { get; set; }
        private object _value;

        public object Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}