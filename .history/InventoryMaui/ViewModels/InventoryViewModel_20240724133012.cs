﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using InventoryManage;

namespace InventoryMaui.ViewModels
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ItemDTO> items;

        public InventoryViewModel()
        {
            Items = new ObservableCollection<ItemDTO>(ItemServiceProxy.Current.Items);
            DeleteItemCommand = new Command<int>(DeleteItem);
            ItemServiceProxy.Current.ItemsChanged += OnItemsChanged;
            
        }

        public ObservableCollection<ItemDTO> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteItemCommand { get; }

        private void DeleteItem(int itemId)
        {
            ItemServiceProxy.Current.Delete(itemId);
        }

        private void OnItemsChanged()
        {
            // Clear and repopulate the ObservableCollection to notify the view
            Items.Clear();
            foreach (var item in ItemServiceProxy.Current.Items)
            {
                Items.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}