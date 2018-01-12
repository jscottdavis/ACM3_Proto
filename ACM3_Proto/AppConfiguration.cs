using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using CommonCore;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Container of persistent configuration information
    /// </summary>
    public class AppConfiguration : DebugEventHandler, IDisposable
    {
        #region Configuration Info Tags

        public const string EnvironmentFolder = "EnvironmentFolder";
        public const string ChannelModelFolder = "ChannelModelFolder";
        public const string BaseStationFolder = "BaseStationFolder";
        public const string MobileStationFolder = "MobileStationFolder";
        public const string IQDataOutputFolder = "IQDataOutputFolder";
        public const string PhamDataOutputFolder = "PhamDataOutputFolder";

        #endregion

        #region ConfigInfo

        public class ConfigInfo
        {
            public string RegistKey;
            public string DefaultValue;
        }

        #endregion

        #region Fields

        static private AppConfiguration _instance;
        Dictionary<string, ConfigInfo> _publicToPrivateKeyDict;
        string RegistryKeyPrefix = String.Format(@"Software\{0}\ACM\AppConfiguration", ProductConstant.MANUFACTURE);

        #endregion

        #region Constructor

        private AppConfiguration()
        {
            string ProgDataPrefix = String.Format(@"{0}\{1}\{2}\", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ProductConstant.MANUFACTURE, ProductConstant.PRODUCT_FOLDER);
            _publicToPrivateKeyDict = new Dictionary<string, ConfigInfo>()
            {
                {EnvironmentFolder, new ConfigInfo() { RegistKey = EnvironmentFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.ENV_FOLDER }},
                {ChannelModelFolder, new ConfigInfo() { RegistKey = ChannelModelFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.CHANNEL_MODEL_FOLDER }},
                {BaseStationFolder, new ConfigInfo() { RegistKey = BaseStationFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.BASESTATION_FOLDER }},
                {MobileStationFolder, new ConfigInfo() { RegistKey = MobileStationFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.MOBILE_STATION_FOLDER }},
                {IQDataOutputFolder, new ConfigInfo() { RegistKey = IQDataOutputFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.ACM_OUTPUT_FOLDER }},
                {PhamDataOutputFolder, new ConfigInfo() { RegistKey = PhamDataOutputFolder,
                    DefaultValue = ProgDataPrefix + ProductConstant.PHAM_OUTPUT_FOLDER }},
            };
        }

        #endregion

        #region Properties

        static public AppConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfiguration();
                }
                return _instance;
            }
        }

        #endregion

        public object GetValue(string key)
        {
            RegistryKey regKey = Registry.CurrentUser;
            object value = null;
            try
            {
                RegistryKey appConfigKey = regKey.OpenSubKey(RegistryKeyPrefix);
                value = appConfigKey.GetValue(_publicToPrivateKeyDict[key].RegistKey, _publicToPrivateKeyDict[key].DefaultValue);
                // assign default value if the registry value is an empty string
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    value = _publicToPrivateKeyDict[key].DefaultValue;
                }
            }
            catch (Exception exc)
            {
                OnLogException(exc, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return value;
        }

        public void SetValue(string key, object value)
        {
            RegistryKey regKey = Registry.CurrentUser;
            try
            {
                RegistryKey appConfigKey = regKey.OpenSubKey(RegistryKeyPrefix, true);
                appConfigKey.SetValue(_publicToPrivateKeyDict[key].RegistKey, value);
            }
            catch (Exception exc)
            {
                OnLogException(exc, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public void Dispose()
        {
        }
    }
}
