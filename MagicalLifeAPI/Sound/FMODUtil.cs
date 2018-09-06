using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Sound.FMOD.Studio;
using System;

namespace MagicalLifeAPI.Sound
{
    /// <summary>
    /// Some FMOD related utilities.
    /// </summary>
    public static class FMODUtil
    {
        private static FMOD.Studio.System _System;

        public static FMOD.Studio.System System
        {
            get
            {
                return _System;
            }
            set
            {
                _System = value;
            }
        }

        private static EventDescription[] MainEvents;

        public static void Init()
        {
            FMOD.Studio.System.create(out _System);
            _System.getLowLevelSystem(out FMOD.System low);

            //Preparing system for 3D sound (We'll only change x, y)
            low.setOutput(FMOD.OUTPUTTYPE.AUTODETECT);


            low.setSoftwareFormat(0, FMOD.SPEAKERMODE._7POINT1, 0);
            _System.initialize(1, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);

            //Load sound files
            _System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out Bank MainBank);
            _System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out Bank MainBankStrings);

            MainBank.getEventList(out MainEvents);
            DumpEventInformation();
        }

        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        public static void RaiseEvent(string eventPath)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);

            instance.start();
        }

        /// <summary>
        /// Raises the specified event with the specified 2D information.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        /// <param name="mapLocation">The location of the source of the sound in the map.</param>
        public static void RaiseEvent(string eventPath, Point2D mapLocation)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);

            _3D_ATTRIBUTES _3D = default;
            _3D.position.x = mapLocation.X;
            _3D.position.y = mapLocation.Y;

            instance.set3DAttributes(_3D);

            instance.start();
        }

        /// <summary>
        /// Raises the specified event and passes <paramref name="value"/> to a parameter with a name of <paramref name="parameterName"/>.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        /// <param name="parameterName">The name of the parameter to pass <paramref name="value"/> to.</param>
        /// <param name="value">The value to be passed into the event.</param>
        public static void RaiseEvent(string eventPath, string parameterName, int value)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.setParameterValue(parameterName, value);
            instance.start();
        }

        /// <summary>
        /// Raises the specified event and passes <paramref name="value"/> to a parameter with a name of <paramref name="parameterName"/>.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        /// <param name="parameterName">The name of the parameter to pass <paramref name="value"/> to.</param>
        /// <param name="value">The value to be passed into the event.</param>
        /// <param name="mapLocation">The location of the source of the sound in the map.</param>
        public static void RaiseEvent(string eventPath, string parameterName, int value, Point2D mapLocation)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.setParameterValue(parameterName, value);

            _3D_ATTRIBUTES _3D = default;
            _3D.position.x = mapLocation.X;
            _3D.position.y = mapLocation.Y;

            instance.set3DAttributes(_3D);

            instance.start();
        }

        public static void Test()
        {
            //Temp method
        }

        public static void DumpEventInformation()
        {
            MasterLog.DebugWriteLine("Dumping Sound Events");
            foreach (EventDescription item in MainEvents)
            {
                item.getPath(out string path);
                MasterLog.DebugWriteLine(path);

                item.getParameterCount(out int length);

                for (int i = 0; i < length; i++)
                {
                    item.getParameterByIndex(i, out PARAMETER_DESCRIPTION parameter);
                    MasterLog.DebugWriteLine("Parameter name: " + parameter.name);
                    MasterLog.DebugWriteLine("Parameter type: " + parameter.type);
                    MasterLog.DebugWriteLine("Parameter index: " + parameter.index);
                    MasterLog.DebugWriteLine("Parameter default value: " + parameter.defaultvalue);
                    MasterLog.DebugWriteLine("Parameter minimum: " + parameter.minimum);
                    MasterLog.DebugWriteLine("Parameter maximum: " + parameter.maximum);
                    
                    item.is3D(out bool is3D);
                    MasterLog.DebugWriteLine("Is 3D: " + is3D.ToString());
                }
            }
            MasterLog.DebugWriteLine("End of Sound Events");
        }

        public static void Update(int listenerX, int listenerY)
        {
            _3D_ATTRIBUTES attributes = default;

            attributes.position.x = listenerX;
            attributes.position.y = listenerY;

            _System.setListenerAttributes(0, attributes);
            _System.update();
        }
    }
}