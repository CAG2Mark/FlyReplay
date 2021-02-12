using System;
using System.Collections.Generic;
using System.Text;

namespace FlyReplay.Connection {
    public interface ISimConnection {
        /// <summary>
        /// Whether or not the instance of this connection is connected to the simulator.
        /// </summary>
        bool IsConnected { get; set; }
        bool Connect();
        void Disconnect();

        /// <summary>
        /// The current sim state. For reference on how to use it, see SimStateStruct.
        /// </summary>
        SimStateStruct SimState { get; set; }
    }
}
