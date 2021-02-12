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
        string AircraftName;
        /// <summary>
        /// The altitude of the plane in feet.
        /// </summary>
        double? Altitude;
        /// <summary>
        /// The heading of the plane in degrees.
        /// </summary>
        double? Heading;
        /// <summary>
        /// The ground speed of the plane in knots.
        /// </summary>
        double? GndSpeed;
        /// <summary>
        /// The indicated airspeed of the plane in knots.
        /// </summary>
        double? AirSpeed;
        /// <summary>
        /// The latitude of the plane in degrees.
        /// </summary>
        double? Latitude;
        /// <summary>
        /// The longitude of the plane in degrees.
        /// </summary>
        double? Longtiude;
        /// <summary>
        /// The pitch of the plane in degrees.
        /// </summary>
        double? Pitch;
        /// <summary>
        /// The bank / roll of the plane in degrees.
        /// </summary>
        double? Bank;
        /// <summary>
        /// How far out the spoilers are extended from 0 to 255, with 255 being fully extended.
        /// </summary>
        byte? Spoilers;
        /// <summary>
        /// How much the ailerons are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        sbyte? Ailerons;
        /// <summary>
        /// How much the elevators are extended, with -127 being fully down, and 127 being fully u.
        /// </summary>
        sbyte? Elevators;
        /// <summary>
        /// How far the rudders are extended, with -127 being fully extended to the left, and 127 being fully extended to the right.
        /// </summary>
        sbyte? Rudder;
        /// <summary>
        /// The thrust of each zero-index engine, with 0 being idle, and 255 being full throttle.
        /// </summary>
        byte[] Thrust;
        /// <summary>
        /// The framerate of the simulator.
        /// </summary>
        int? Framerate;
        /// <summary>
        /// Whether the simulator is paused.
        /// </summary>
        bool? Paused;
    }
}
