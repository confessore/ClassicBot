using ClassicBot.GUI.Utilities;
using ClassicBot.GUI.Utilities.Interfaces;
using ClassicBot.GUI.ViewModels.Abstractions;
using ClassicBot.Statics;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ClassicBot.GUI.ViewModels
{
    internal class PIDViewModel : BaseViewModel
    {
        [DllImport(Strings.Injector)]
        static extern bool Inject(int pid, string dll);

        public PIDViewModel()
        {
            RefreshPIDsAsync();
            RefreshPIDsAsyncCommand = new AsyncCommand(RefreshPIDsAsync);
            InjectAsyncCommand = new AsyncCommand(InjectAsync, CanInjectAsync);
        }

        public IAsyncCommand RefreshPIDsAsyncCommand { get; }
        public IAsyncCommand InjectAsyncCommand { get; }

        ObservableCollection<System.Diagnostics.Process> pids;
        public ObservableCollection<System.Diagnostics.Process> PIDs
        {
            get => pids;
            set
            {
                pids = value;
                OnPropertyChanged();
            }
        }

        System.Diagnostics.Process selectedPID;
        public System.Diagnostics.Process SelectedPID
        {
            get => selectedPID;
            set
            {
                selectedPID = value;
                InjectAsyncCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        Task RefreshPIDsAsync()
        {
            var tmp = new ObservableCollection<System.Diagnostics.Process>();
            var processes = System.Diagnostics.Process.GetProcessesByName(Strings.Process);
            foreach (var process in processes)
                tmp.Add(process);
            PIDs = tmp;
            return Task.CompletedTask;
        }

        bool CanInjectAsync() =>
            SelectedPID != null;

        Task InjectAsync()
        {
            Inject(SelectedPID.Id, Paths.Loader);
            Environment.Exit(0);
            return Task.CompletedTask;
        }
    }
}
