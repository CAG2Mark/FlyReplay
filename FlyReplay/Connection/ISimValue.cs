using System;
using System.Collections.Generic;
using System.Text;

namespace FlyReplay.Connection {
    public interface ISimValue<T> {
        T Value { get; set; }
    }
}
