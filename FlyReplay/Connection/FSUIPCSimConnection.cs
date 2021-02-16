using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FSUIPC;

namespace FlyReplay.Connection {

    // Hack to store all the offsets in a list to call OnPropertyChanged on them
    public interface INotifiable {
        void OnPropertyChanged();
    }

    /// <summary>
    /// Wrapper around the FSUIPC offset to work with SimStateStruct
    /// </summary>
    /// <typeparam name="T">The output type, ideally nullable.</typeparam>
    /// <typeparam name="U">The value read from the FSUIPC offset.</typeparam>
    public class FSUIPCSimValue<T, U> : INotifiable, ISimValue<T> {

        /// <summary>
        /// Converts the FSUIPC offset value to the desired output value.
        /// </summary>
        public Func<U, T> ToOutVal;
        /// <summary>
        /// Convers the output value back to the FSUIPC offset value.
        /// </summary>
        public Func<T, U> ToInVal;

        /// <summary>
        /// The value of this sim value.
        /// </summary>
        public T Value {
            get {
                if (ToOutVal != null) return ToOutVal(valOffset.Value);
                else return default(T);
            }
            set {
                if (ToInVal != null) valOffset.Value = ToInVal(value);
                OnPropertyChanged();
            }
        }

        private Offset<U> valOffset;

        /// <summary>
        /// Creates a new FSUIPC sim value and links it to an offset.
        /// </summary>
        /// <param name="offsetAddr">The address of the offset.</param>
        /// <param name="toOutVal">The function to convert the FSUIPC offset value into the output value.</param>
        /// <param name="toInVal">The function to convert the outout value back in to the FSUIPC offset value.</param>
        public FSUIPCSimValue(int offsetAddr, Func<U, T> toOutVal, Func<T, U> toInVal = null) {
            this.valOffset = new Offset<U>(offsetAddr);
            this.ToOutVal = toOutVal;
            this.ToInVal = toInVal;
        }

        /// <summary>
        /// Creates a new FSUIPC sim value and links it to an offset.
        /// </summary>
        /// <param name="offsetAddr">The address of the offset.</param
        /// <param name="offsetSize">The size of the offset (ie, ArrayOrStringLength from the offset constructor).</param>
        /// <param name="toOutVal">The function to convert the FSUIPC offset value into the output value.</param>
        /// <param name="toInVal">The function to convert the outout value back in to the FSUIPC offset value.</param>
        public FSUIPCSimValue(int offsetAddr, int offsetSize, Func<U, T> toOutVal, Func<T, U> toInVal = null) {
            this.valOffset = new Offset<U>(offsetAddr, offsetSize);
            this.ToOutVal = toOutVal;
            this.ToInVal = toInVal;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        #endregion

    }

    /// <summary>
    /// Enables connections to an FSUIPC interface.
    /// </summary>
    public class FSUIPCSimConnection : BindableBase, ISimConnection {

        public string BridgeName { get; } = "FSUIPC/XPUIPC";

        #region conversions

        // divide by conversion to get output, multply to convert user value into fsuipc value
        const double gsConversion = 65536.0 * 0.514444;
        const double iasConversion = 128;
        const double altitudeConversion = 65536.0 * 65536.0 * 0.3048;
        const double headingConversion = 65536.0 * 65536.0 / 360;
        const double pitchConversion = headingConversion;
        const double bankConversion = headingConversion;
        const double latitudeConversion = 65536.0 * 65536.0 * 10001750.0 / 90.0;
        const double longitudeConversion = 65536.0 * 65536.0 * 65536.0 * 65536 / 360.0;
        const double vsConversion = 256.0 * 0.3048 / 60;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new FSUIPC connection and binds a sim state struct to it.
        /// </summary>
        /// <param name="simState">The sim state struct to bind to.</param>
        public FSUIPCSimConnection(SimState simState) {
            this.simState = simState;
            initializeOffsets();
        }

        private void initializeOffsets() {

            this.simValues.Add((INotifiable)(
                this.simState.AircraftName = new FSUIPCSimValue<string, string>(
                    0x3500, 24, v => v
            )));

            this.simValues.Add((INotifiable)(
                this.simState.GndSpeed = new FSUIPCSimValue<double?, int>(
                    0x2B4,
                    v => v / gsConversion,
                    v => Convert.ToInt32(v * gsConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.AirSpeed = new FSUIPCSimValue<double?, int>(
                    0x2BC,
                    v => v / iasConversion
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Altitude = new FSUIPCSimValue<double?, long>(
                    0x570,
                    v => v / altitudeConversion,
                    v => Convert.ToInt64(v * altitudeConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Heading = new FSUIPCSimValue<double?, int>(
                    0x580,
                    v => (v / headingConversion + 360) % 360,
                    v => {
                        if (v > 180) v -= 360;
                        return Convert.ToInt32(v * headingConversion);
                    }
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Pitch = new FSUIPCSimValue<double?, int>(
                    0x578,
                    v => v / pitchConversion,
                    v => Convert.ToInt32(v * pitchConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Bank = new FSUIPCSimValue<double?, int>(
                    0x57C,
                    v => v / bankConversion,
                    v => Convert.ToInt32(v * bankConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Latitude = new FSUIPCSimValue<double?, long>(
                    0x560,
                    v => v / latitudeConversion,
                    v => Convert.ToInt64(v * latitudeConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Longtiude = new FSUIPCSimValue<double?, long>(
                    0x568,
                    v => v / longitudeConversion,
                    v => Convert.ToInt64(v * longitudeConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.VerticalSpeed = new FSUIPCSimValue<double?, int>(
                    0x2C8,
                    v => v / vsConversion,
                    v => Convert.ToInt32(v * vsConversion)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Spoilers = new FSUIPCSimValue<short?, int>(
                    0xBD0, v => (short)v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Flaps = new FSUIPCSimValue<short?, int>(
                    0xBDC, v => (short)v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Elevators = new FSUIPCSimValue<short?, int>(
                    0xBB2, v => (short)v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Ailerons = new FSUIPCSimValue<short?, int>(
                    0xBB6, v => (short)v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Rudder = new FSUIPCSimValue<short?, int>(
                    0xBBA, v => (short)v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Thrust1 = new FSUIPCSimValue<short?, short>(
                    0x88C, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Thrust2 = new FSUIPCSimValue<short?, short>(
                    0x924, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Thrust3 = new FSUIPCSimValue<short?, short>(
                    0x9BC, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Thrust4 = new FSUIPCSimValue<short?, short>(
                    0xA54, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.Framerate = new FSUIPCSimValue<short?, short>(
                    0x274, v => (short)(32768 / v)
            )));

            this.simValues.Add((INotifiable)(
                this.simState.SimHour = new FSUIPCSimValue<byte?, byte>(
                    0x23B, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.SimMinute = new FSUIPCSimValue<byte?, byte>(
                    0x23C, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.SimSecond = new FSUIPCSimValue<byte?, byte>(
                    0x23A, v => v, v => v ?? 0
            )));

            this.simValues.Add((INotifiable)(
                this.simState.OnGround = new FSUIPCSimValue<bool, short>(
                    0x366, v => v == 1, null
            )));

            this.simValues.Add((INotifiable)(
                this.simState.IsPasued = new FSUIPCSimValue<bool, short>(
                    0x264, v => v == 1, null
            )));

            this.simValues.Add((INotifiable)(
                this.simState.InMenu = new FSUIPCSimValue<bool, byte>(
                    0x3365, v => v != 0, null
            )));
        }

        #endregion

        #region API

        private List<INotifiable> simValues = new List<INotifiable>();

        private bool isConnected;

        /// <summary>
        /// Whether or not the instance of this connection is connected to the simulator.
        /// </summary>
        public bool IsConnected { get => isConnected; set => Set(ref isConnected, value); }

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

        public void UpdateData() {
            if (FSUIPCConnection.IsOpen) {
                FSUIPCConnection.Process();
                foreach (var s in simValues) {
                    s.OnPropertyChanged();
                }
            }
        }

        public void SetData() {
            if (FSUIPCConnection.IsOpen) FSUIPCConnection.Process();
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

        #region FSUIPC implementation

        private SimState simState;

        #region Offsets

        // divide by conversion to get actual value, multiply to get the value back



        #endregion

        #endregion
    }
}
