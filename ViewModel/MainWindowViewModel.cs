using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;
using Task3.Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System;
using Task3.ViewModel;
using System.Linq;
using System.Windows;

namespace Task3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private LibLoader _loader;
        private Type _selectedType;
        private MethodInfo _selectedMethod;
        private string _methodResult;
        private string _assemblyPath;
        private Dictionary<Type, object> _instances;

        public ObservableCollection<string> EntityNames { get; set; }
        public ObservableCollection<MethodInfo> Methods { get; set; }
        public ObservableCollection<ParameterViewModel> ConstructorParameters { get; set; }
        public ICommand LoadAssemblyCommand { get; set; }
        public ICommand ExecuteMethodCommand { get; set; }

        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                _assemblyPath = value;
                OnPropertyChanged(nameof(AssemblyPath));
            }
        }

        public string SelectedEntityName
        {
            get => _selectedType?.Name;
            set
            {
                _selectedType = _loader.EntityTypes.Find(t => t.Name == value);
                Methods.Clear();
                ConstructorParameters.Clear();
                foreach (var method in _loader.GetMethods(_selectedType))
                {
                    Methods.Add(method);
                }

                var constructor = _selectedType.GetConstructors().First();
                foreach (var param in constructor.GetParameters())
                {
                    ConstructorParameters.Add(new ParameterViewModel { Name = param.Name, Type = param.ParameterType });
                }

                if (!_instances.ContainsKey(_selectedType))
                {
                    var constructorArgs = ConstructorParameters.Select(p => ConvertParameterValue(p.Type, p.Value)).ToArray();
                    var instance = constructor.Invoke(constructorArgs);
                    _instances[_selectedType] = instance;
                }
            }
        }

        public MethodInfo SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                _selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
            }
        }

        public string MethodResult
        {
            get => _methodResult;
            set
            {
                _methodResult = value;
                OnPropertyChanged(nameof(MethodResult));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            _loader = new LibLoader();
            EntityNames = new ObservableCollection<string>();
            Methods = new ObservableCollection<MethodInfo>();
            ConstructorParameters = new ObservableCollection<ParameterViewModel>();
            _instances = new Dictionary<Type, object>();
            LoadAssemblyCommand = new RelayCommand(LoadAssembly);
            ExecuteMethodCommand = new RelayCommand(ExecuteMethod);
        }

        private void LoadAssembly(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                AssemblyPath = openFileDialog.FileName;
                _loader.LoadAssembly(AssemblyPath);
                EntityNames.Clear();
                foreach (var type in _loader.EntityTypes)
                {
                    EntityNames.Add(type.Name);
                }
            }
        }

        private void ExecuteMethod(object parameter)
        {
            try { 
                if (_selectedType != null && _selectedMethod != null)
                {
                    if (!_instances.ContainsKey(_selectedType))
                    {
                        var constructor = _selectedType.GetConstructors().First();
                        var constructorArgs = ConstructorParameters.Select(p => ConvertParameterValue(p.Type, p.Value)).ToArray();
                        var instance = constructor.Invoke(constructorArgs);
                        _instances[_selectedType] = instance;
                    }

                    var existingInstance = _instances[_selectedType];
                    var result = _selectedMethod.Invoke(existingInstance, Array.Empty<object>());

                    MethodResult = result == null ? "" : result.ToString();
                }
            }
            catch{
                MessageBox.Show("Unexpected Arguments");
            }
            
        }

        private object ConvertParameterValue(Type type, object value)
        {
            return Convert.ChangeType(value, type);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
