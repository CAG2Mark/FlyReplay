using System;
using System.Collections.Generic;
using System.Text;

namespace FlyReplay.Connection {

    /// <summary>
    /// Contains all the data that will be transfered the sim and FlyReplay. Used to abstract the transfer of data between the sim and FlyReplay.
    /// 
    /// When getting, if the data is null, then that means that data was unable to be retrieved. When setting, set a piece of data to null to not set it.
    /// </summary>
    public struct SimStateStruct {

        /// <summary>
        /// The current aircraft name.
        /// </summary>
        public ISimValue<string> AircraftName;
        /// <summary>
        /// The altitude of the plane in feet.
        /// </summary>
        public ISimValue<double?> Altitude;
        /// <summary>
        /// The heading of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Heading;
        /// <summary>
        /// The ground speed of the plane in knots.
        /// </summary>
        public ISimValue<double?> GndSpeed;
        /// <summary>
        /// The indicated airspeed of the plane in knots.
        /// </summary>
        public ISimValue<double?> AirSpeed;
        /// <summary>
        /// The vertical speed of the plane in feet per minute.
        /// </summary>
        public ISimValue<double?> VerticalSpeed;
        /// <summary>
        /// The latitude of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Latitude;
        /// <summary>
        /// The longitude of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Longtiude;
        /// <summary>
        /// The current simulator hour.
        /// </summary>
        public ISimValue<byte?> SimHour;
        /// <summary>
        /// The current simulator minute.
        /// </summary>
        public ISimValue<byte?> SimMinute;
        /// <summary>
        /// The current simulator second.
        /// </summary>
        public ISimValue<byte?> SimSecond;
        /// <summary>
        /// The pitch of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Pitch;
        /// <summary>
        /// The bank / roll of the plane in degrees.
        /// </summary>
        public ISimValue<double?> Bank;
        /// <summary>
        /// How far out the spoilers are extended from 0 to 16383, with 16383 being fully extended.
        /// </summary>
        public ISimValue<short?> Spoilers;
        /// <summary>
        /// The current position of the flaps from 0 to 16383.
        /// </summary>
        public ISimValue<short?> Flaps;
        /// <summary>
        /// How much the ailerons are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        public ISimValue<short?> Ailerons;
        /// <summary>
        /// How much the elevators are extended, with -127 being fully down, and 127 being fully u.
        /// </summary>
        public ISimValue<short?> Elevators;
        /// <summary>
        /// How far the rudders are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        public ISimValue<short?> Rudder;
        /// <summary>
        /// The thrust of each zero-index engine, with 0 being idle, and 255 being full throttle.
        /// </summary>
        public ISimValue<byte[]> Thrust;
        /// <summary>
        /// The framerate of the simulator.
        /// </summary>
        public ISimValue<short?> Framerate;

        /// <summary>
        /// Whether the plane is on the ground.
        /// </summary>
        public ISimValue<bool> OnGround;
        /// <summary>
        /// Whether the simulator is in a menu.
        /// </summary>
        public ISimValue<bool> InMenu;
        /// <summary>
        /// Whether the simulator is paused.
        /// </summary>
        public ISimValue<bool> IsPasued;
    }
}
