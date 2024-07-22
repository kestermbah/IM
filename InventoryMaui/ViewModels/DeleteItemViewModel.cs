﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using InventoryManage;

namespace InventoryMaui.ViewModels
{
    public class DeleteItemViewModel : INotifyPropertyChanged
    {
        public DeleteItemViewModel()
        {
            Items = new ObservableCollection<Item>(ItemServiceProxy.Current.Items);
            DeleteItemCommand = new Command<int>(DeleteItem);
             ItemServiceProxy.Current.ItemsChanged += OnItemsChanged;
        }

        public ObservableCollection<Item> Items { get; }

        public ICommand DeleteItemCommand { get; }

          private void DeleteItem(int itemId)
        {
            ItemServiceProxy.Current.Delete(itemId);
            
        }

        private void OnItemsChanged()
        {
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