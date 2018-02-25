using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patient_Cards.ViewModels.Dictionaries
{
    public class DictionaryViewModel : BindableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set { SetProperty(ref isChecked, value); }
        }

        public DictionaryViewModel(int id, string name)
        {
            Id = id;
            Name = name;
            IsChecked = false;
        }
    }
}
