using GameCheckerAPI.Database;
using GameCheckerAPI.Models;
using System;
using System.Linq;
using System.Text;

namespace GameCheckerAPI.Helper
{
    public static class MethodHelper
    {
        private static char[] startGuid = { 'A', 'B', 'B', 'C', 'D', 'E', 'F', 'G' };
        private static char[] endGuid = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private static int START_GUID_LENGTH = 4;
        private static int END_GUID_LENGTH = 6;

        public static string generateGuid(int guidLength)
        {
            Random random = new Random();

            StringBuilder sbGuid = new StringBuilder();

            for (int j = 0; j < 4; j++)
            {
                sbGuid.Append(startGuid[random.Next(START_GUID_LENGTH)]);
            }
            for (int i = 1; i <= guidLength; i++)
            {
                sbGuid.Append(endGuid[random.Next(END_GUID_LENGTH)]);
            }

            return sbGuid.ToString();
        }

        public static string generatePasswordSalt()
        {
            return "";
        }

        public static bool guidExists(ComputerHardware computerHardware, DbInject dbInject)
        {
            bool result = false;
            if (computerHardware != null && dbInject != null && computerHardware.guid != null)
            {
                result = dbInject.getGameContext.computerHardware.Any(x => x.guid == computerHardware.guid);
            }
            return result;
        }

        public static bool hardwareAndUserGuidExist(int hardwareId, int userId, DbInject dbInject)
        {
            bool result = false;
            if (hardwareId != 0 && userId != 0)
            {
                result = (dbInject.getGameContext.hardware2Users.Any(x => x.ComputerHardwareId == hardwareId && x.UserId == userId));
            }
            return result;
        }

        public static bool hardwareSpecificationExists(Specification spec, ComputerHardware computerHardware, DbInject dbInject)
        {
            bool result = false;
            if (spec != null && computerHardware != null)
            {
                result = (dbInject.getGameContext.Specification.Any(x => x.id == spec.id));
                result = (dbInject.getGameContext.computerHardware.Any(x => x.id == computerHardware.id));
            }
            return result;
        }
    }
}
