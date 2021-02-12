using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace FlyReplay {
    public class BindableBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Set<T>(ref T reference, T value, [CallerMemberName] string caller = null) {
            reference = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
