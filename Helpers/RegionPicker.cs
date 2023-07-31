using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using static ToolbarTests.Helpers.EnumFactory;

namespace ToolbarTests.Helpers
{
    public static class RegionPicker
    {
        public const string UkRegionAbbreviation = "UK";
        public const string UsRegionAbbreviation = "US";
        public const string DeRegionAbbreviation = "DE";
        public static string AppRegion;
        public static string ApkFileLocation;
        public static string AppPackage;
        public static string AppWaitActivity;

        public static void Loction()
        {
            var region = (regionName)Enum.Parse(typeof(regionName), ConfigurationManager.AppSettings["resFile"]);
            switch (region)
            {
                //
                    
            }
        }
    }
}
