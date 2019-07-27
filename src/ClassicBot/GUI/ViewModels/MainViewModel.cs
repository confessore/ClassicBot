using ClassicBot.Game;
using ClassicBot.GUI.Utilities;
using ClassicBot.GUI.Utilities.Interfaces;
using ClassicBot.GUI.ViewModels.Abstractions;
using ClassicBot.Interfaces;
using ClassicBot.Statics;
using Microsoft.Extensions.DependencyInjection;
using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ClassicBot.GUI.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ConfigureServicesAsync();
            ReloadBasesAsync();
            ReloadBasesAsyncCommand = new AsyncCommand(ReloadBasesAsync);
            StartBaseAsyncCommand = new AsyncCommand(StartBaseAsync);
            StopBaseAsyncCommand = new AsyncCommand(StopBaseAsync);
            ToggleGUIAsyncCommand = new AsyncCommand(ToggleGUIAsync);
        }

        public IAsyncCommand ReloadBasesAsyncCommand { get; }
        public IAsyncCommand StartBaseAsyncCommand { get; }
        public IAsyncCommand StopBaseAsyncCommand { get; }
        public IAsyncCommand ToggleGUIAsyncCommand { get; }

        IServiceProvider Services { get; set; }

        IBase selectedBase;
        public IBase SelectedBase
        {
            get => selectedBase;
            set
            {
                selectedBase = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<IBase> availableBases;
        [ImportMany(typeof(IBase), AllowRecomposition = true)]
        public ObservableCollection<IBase> AvailableBases
        {
            get => availableBases;
            set
            {
                availableBases = value;
                OnPropertyChanged();
            }
        }

        Task ReloadBasesAsync()
        {
            if (AvailableBases != null)
            {
                foreach (var @base in AvailableBases)
                {
                    @base.Stop();
                    @base.Dispose();
                }
            }
            var catalog = new AggregateCatalog();
            foreach (var file in Directory.GetFiles(Paths.Bases))
            {
                if (!file.EndsWith(".dll")) continue;
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.Load(File.ReadAllBytes(file))));
            }
            var container = new CompositionContainer(catalog);
            container.ComposeExportedValue(Services.GetRequiredService<EntityManager>());
            container.ComposeParts(this);
            if (AvailableBases.Count > 0)
                SelectedBase = AvailableBases[0];
            return Task.CompletedTask;
        }

        Task StartBaseAsync()
        {
            if (SelectedBase != null)
                SelectedBase.Start();
            return Task.CompletedTask;
        }

        Task StopBaseAsync()
        {
            if (SelectedBase != null)
                SelectedBase.Stop();
            return Task.CompletedTask;
        }

        Task ToggleGUIAsync()
        {
            if (SelectedBase != null)
                SelectedBase.ToggleGUI();
            return Task.CompletedTask;
        }

        Task ConfigureServicesAsync()
        {
            Services = new ServiceCollection()
                .AddSingleton(new ProcessSharp(System.Diagnostics.Process.GetCurrentProcess(), MemoryType.Local))
                .AddSingleton<EntityManager>()
                .BuildServiceProvider();
            return Task.CompletedTask;
        }
    }
}
