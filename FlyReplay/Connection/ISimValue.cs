using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlyReplay.Connection {
    public interface ISimValue<T> : INotifyPropertyChanged {
        T Value { get; set; }
    }
}
