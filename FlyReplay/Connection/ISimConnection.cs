using System;
using System.Collections.Generic;
using System.Text;

namespace FlyReplay.Connection {
    public interface ISimConnection {
        string BridgeName { get; }
        /// <summary>
        /// Whether or not the instance of this connection is connected to the simulator.
        /// </summary>
        bool IsConnected { get; set; }
        bool Connect();
        void Disconnect();

        void UpdateData();
        void SetData();
    }
}
