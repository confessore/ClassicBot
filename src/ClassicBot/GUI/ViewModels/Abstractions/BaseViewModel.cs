using ClassicBot.Statics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClassicBot.GUI.ViewModels.Abstractions
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        DialogResult? result;
        public DialogResult? Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        bool enabled = true;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                OnPropertyChanged();
            }
        }

        public string WindowTitle =>
            $"{Strings.Name} - {Strings.Version}";


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
