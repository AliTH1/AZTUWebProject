using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Constants
{
    public static class ExceptionMessages
    {
        public static string AnnouncementAlreadyExists = "Announcement is already exists";
        public static string AnnouncementNotFound = "Announcement not found";
        public static string PanelAlreadyExists = "Panel is already exists";
        internal static string PanelNotFound = "Panel not found";
        internal static string? NewsAlreadyExists = "News is already exists";
        internal static string NewsNotFound = "News not found";
        internal static string ProjectNotFound;
        internal static string? ProjectAlreadyExists;
        internal static string? EventAlreadyExists;
        internal static string EventNotFound;
        internal static string ConferenceNotFound;
        internal static string? ConferenceAlreadyExists;
    }
}
