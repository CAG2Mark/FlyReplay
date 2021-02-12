using System;
using System.Collections.Generic;
using System.Text;
using FSUIPC;

namespace FlyReplay.Connection {
    public class FSUIPCSimConnection : BindableBase, ISimConnection {

        #region constructors

        public FSUIPCSimConnection() {
            SimState = new SimStateStruct();
        }

        #endregion

        #region API

        private bool isConnected;
        private SimStateStruct simState;

        /// <summary>
        /// Whether or not the instance of this connection is connected to the simulator.
        /// </summary>
        public bool IsConnected { get => isConnected; set => Set(ref isConnected, value); }
        /// <summary>
        /// The current sim state. Can be uesd to get sim data or set the sim state.
        /// </summary>
        public SimStateStruct SimState {
            get {
                readData();
                return simState;
            }
            set {
                Set(ref simState, value);
                setData();
            }
        }

        /// <summary>
        /// Tries to connect to the simulator.
        /// </summary>
        /// <returns>Whether or not the connection was successful.</returns>
        public bool Connect() {
            if (FSUIPCConnection.IsOpen) return IsConnected = true;
            try {
                FSUIPCConnection.Open();
                return IsConnected = true;
            }
            catch (Exception) {
                return IsConnected = false;
            }
        }

        /// <summary>
        /// Closes the connection to the simulator if it is active.
        /// </summary>
        public void Disconnect() {
            try {
                if (FSUIPCConnection.IsOpen) FSUIPCConnection.Close();
                IsConnected = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region Private members

        void readData() {

            throw new NotImplementedException();

        }

        void setData() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
