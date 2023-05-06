using System;

namespace JbCommands
{
    /// <summary>
    /// This class is used only to expose the list of Guids used by this package.
    /// This list of guids must match the set of Guids used inside the VSCT file.
    /// </summary>
    internal static class GuidsList
    {
        public const string guidJbCommandsPkg_string = "91DAE0B4-5959-4C85-A99F-C85E0AE3A725";
        public static readonly Guid guidJbCommandsCmdSet = new Guid("{5A0375CE-55AF-4FAA-8928-B4F24B8DFC44}");
    }
}
