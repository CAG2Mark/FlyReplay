using System;
using System.Collections.Generic;
using System.Text;

namespace FlyReplay.Connection {

    /// <summary>
    /// Contains all the data that will be transfered the sim and FlyReplay. Used to abstract the transfer of data between the sim and FlyReplay.
    /// 
    /// When getting, if the data is null, then that means that data was unable to be retrieved. When setting, set a piece of data to null to not set it.
    /// </summary>
    public class SimState : BindableBase {
        private ISimValue<string> aircraftName;
        private ISimValue<double?> altitude;
        private ISimValue<double?> heading;
        private ISimValue<double?> gndSpeed;
        private ISimValue<double?> airSpeed;
        private ISimValue<double?> verticalSpeed;
        private ISimValue<double?> latitude;
        private ISimValue<double?> longtiude;
        private ISimValue<byte?> simHour;
        private ISimValue<byte?> simMinute;
        private ISimValue<byte?> simSecond;
        private ISimValue<double?> pitch;
        private ISimValue<double?> bank;
        private ISimValue<short?> spoilers;
        private ISimValue<short?> flaps;
        private ISimValue<short?> ailerons;
        private ISimValue<short?> elevators;
        private ISimValue<short?> rudder;
        private ISimValue<short?> thrust1;
        private ISimValue<short?> thrust2;
        private ISimValue<short?> thrust3;
        private ISimValue<short?> thrust4;
        private ISimValue<short?> framerate;
        private ISimValue<bool> onGround;
        private ISimValue<bool> inMenu;
        private ISimValue<bool> isPasued;

        /// <summary>
        /// The current aircraft name.
        /// </summary>
        public ISimValue<string> AircraftName { get => aircraftName; set => Set(ref aircraftName, value); }
        /// <summary>
        /// The altitude of the plane in feet.
        /// </summary>
        public ISimValue<double?> Altitude { get => altitude; set => Set(ref altitude, value); }
        /// <summary>
        /// The heading of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Heading { get => heading; set => Set(ref heading, value); }
        /// <summary>
        /// The ground speed of the plane in knots.
        /// </summary>
        public ISimValue<double?> GndSpeed { get => gndSpeed; set => Set(ref gndSpeed, value); }
        /// <summary>
        /// The indicated airspeed of the plane in knots.
        /// </summary>
        public ISimValue<double?> AirSpeed { get => airSpeed; set => Set(ref airSpeed, value); }
        /// <summary>
        /// The vertical speed of the plane in feet per minute.
        /// </summary>
        public ISimValue<double?> VerticalSpeed { get => verticalSpeed; set => Set(ref verticalSpeed, value); }
        /// <summary>
        /// The latitude of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Latitude { get => latitude; set => Set(ref latitude, value); }
        /// <summary>
        /// The longitude of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Longtiude { get => longtiude; set => Set(ref longtiude, value); }
        /// <summary>
        /// The current simulator hour.
        /// </summary>
        public ISimValue<byte?> SimHour { get => simHour; set => Set(ref simHour, value); }
        /// <summary>
        /// The current simulator minute.
        /// </summary>
        public ISimValue<byte?> SimMinute { get => simMinute; set => Set(ref simMinute, value); }
        /// <summary>
        /// The current simulator second.
        /// </summary>
        public ISimValue<byte?> SimSecond { get => simSecond; set => Set(ref simSecond, value); }
        /// <summary>
        /// The pitch of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Pitch { get => pitch; set => Set(ref pitch, value); }
        /// <summary>
        /// The bank / roll of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Bank { get => bank; set => Set(ref bank, value); }
        /// <summary>
        /// How far out the spoilers are extended from 0 to 16383, with 16383 being fully extended.
        /// </summary>
        public ISimValue<short?> Spoilers { get => spoilers; set => Set(ref spoilers, value); }
        /// <summary>
        /// The current position of the flaps from 0 to 16383.
        /// </summary>
        public ISimValue<short?> Flaps { get => flaps; set => Set(ref flaps, value); }
        /// <summary>
        /// How much the ailerons are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        public ISimValue<short?> Ailerons { get => ailerons; set => Set(ref ailerons, value); }
        /// <summary>
        /// How much the elevators are extended, with -127 being fully down, and 127 being fully u.
        /// </summary>
        public ISimValue<short?> Elevators { get => elevators; set => Set(ref elevators, value); }
        /// <summary>
        /// How far the rudders are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        public ISimValue<short?> Rudder { get => rudder; set => Set(ref rudder, value); }
        /// <summary>
        /// The thrust of engine no 1 from -4096 to 16384.
        /// </summary>
        public ISimValue<short?> Thrust1 { get => thrust1; set => Set(ref thrust1, value); }
        /// <summary>
        /// The thrust of engine no 1 from -4096 to 16384.
        /// </summary>
        public ISimValue<short?> Thrust2 { get => thrust2; set => Set(ref thrust2, value); }
        /// <summary>
        /// The thrust of engine no 2 from -4096 to 16384.
        /// </summary>
        public ISimValue<short?> Thrust3 { get => thrust3; set => Set(ref thrust3, value); }
        /// <summary>
        /// The thrust of engine no 3 from -4096 to 16384.
        /// </summary>
        public ISimValue<short?> Thrust4 { get => thrust4; set => Set(ref thrust4, value); }
        /// <summary>
        /// The framerate of the simulator.
        /// </summary>
        public ISimValue<short?> Framerate { get => framerate; set => Set(ref framerate, value); }

        /// <summary>
        /// Whether the plane is on the ground.
        /// </summary>
        public ISimValue<bool> OnGround { get => onGround; set => Set(ref onGround, value); }
        /// <summary>
        /// Whether the simulator is in a menu.
        /// </summary>
        public ISimValue<bool> InMenu { get => inMenu; set => Set(ref inMenu, value); }
        /// <summary>
        /// Whether the simulator is paused.
        /// </summary>
        public ISimValue<bool> IsPasued { get => isPasued; set => Set(ref isPasued, value); }
    }
}
