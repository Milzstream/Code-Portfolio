using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public static class PLATFORM_HELPER
    {
        public static PLATFORM CONVERT(String platform)
        {
            PLATFORM result = PLATFORM.NULL;

            switch (platform.ToLower())
            {
                case "xboxone": result = PLATFORM.XBOX_ONE;
                    break;

                case "xbox360": result = PLATFORM.XBOX_360;
                    break;

                case "ps4": result = PLATFORM.PS_4;
                    break;

                case "ps3": result = PLATFORM.PS_3;
                    break;
            }

            return result;
        }

        public static String CONVERT(PLATFORM platform)
        {
            String result = String.Empty;

            switch (platform)
            {
                case PLATFORM.XBOX_ONE: result = "xboxone";
                    break;

                case PLATFORM.XBOX_360: result = "xbox360";
                    break;

                case PLATFORM.PS_4: result = "ps4";
                    break;

                case PLATFORM.PS_3: result = "ps3";
                    break;
            }

            return result;
        }
    }

    public enum PLATFORM
    {
        XBOX_ONE,
        XBOX_360,
        PS_3,
        PS_4,
        NULL
    }
}
