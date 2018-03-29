using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static POOAlumnos.EnumApp.EnumApp;

namespace POOAlumnos.Utilities
{
    public static class ConfigUtilities
    {

        static ConfigUtilities()
        {
            // Si no tenemos variables en el archivo APP.config la leemos por variables entorno
            var EnvFormato = Environment.GetEnvironmentVariable("Formato");
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Console.WriteLine(EnvFormato);
            config.AppSettings.Settings["serializable"].Value = EnvFormato;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        // Obtenemos valor de la key configuracion
        public static OpcTypeFile getValorConfigKey(String keyConfig)
        {
            var opcSerial = ConfigurationManager.AppSettings[keyConfig];
            return (OpcTypeFile)Enum.Parse(typeof(OpcTypeFile), opcSerial, true);
        }

        public static String getValorConfig(String keyConfig)
        {
            return ConfigurationManager.AppSettings[keyConfig];
        }

        // Guardamos valor de la key en archivo configuracion "nombre.exe.config"
        public static void setValorConfigKey(String key, String value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

    }
}
