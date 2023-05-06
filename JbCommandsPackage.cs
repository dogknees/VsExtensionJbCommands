using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace JbCommands
{
    /// <summary>
    /// This is the class that implements the package. This is the class that Visual Studio will create
    /// when one of the commands will be selected by the user, and so it can be considered the main
    /// entry point for the integration with the IDE.
    /// Notice that this implementation derives from Microsoft.VisualStudio.Shell.Package that is the
    /// basic implementation of a package provided by the Managed Package Framework (MPF).
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true)]

    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidsList.guidJbCommandsPkg_string)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ComVisible(true)]
    public sealed class JbCommandsPackage : Package
    {
        /// <summary>
        /// Constructs a new instance of <see cref="JbCommandsPackage"/>.
        /// </summary>
        public JbCommandsPackage()
        {
        }

        /// <summary>
        /// Initialization of the package; this is the place where you can put all the initialization
        /// code that relies on services provided by Visual Studio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                CommandID id = new CommandID(GuidsList.guidJbCommandsCmdSet, PkgCmdIDList.cmdidJbCleanUpCode);
                OleMenuCommand command = new OleMenuCommand(new EventHandler(CleanUpCodeCallback), id);
                mcs.AddCommand(command);

                id = new CommandID(GuidsList.guidJbCommandsCmdSet, PkgCmdIDList.cmdidJbInspectCode);
                command = new OleMenuCommand(new EventHandler(InspectCodeCallback), id);
                mcs.AddCommand(command);
            }
        }

        #region Commands Actions

        /// <summary>
        /// The clean up code callback.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Microsoft.Samples.VisualStudio.MenuCommands.MenuCommandsPackage.OutputCommandString(System.String)")]
        private void CleanUpCodeCallback(object caller, EventArgs args)
        {
            DTE dte = (DTE)GetService(typeof(DTE));

            if (dte.ActiveDocument == null)
            {
                return;
            }

            string filePath = dte.ActiveDocument.FullName;
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string solutionPath = dte.Solution.FullName;
            if (string.IsNullOrEmpty(solutionPath))
            {
                return;
            }

            string solutionFullDir = Path.GetDirectoryName(solutionPath);
            string fileShortPath = filePath.Substring(solutionFullDir.Length + 1);
            string solutionShortPath = solutionPath.Substring(solutionFullDir.Length + 1);
            string dotsettingsShortPath = $"{solutionShortPath}.DotSettings";

            string command = string.Join(
                " ",
                "/C",
                "(",
                    "pushd",
                    solutionFullDir,
                ")",
                "&",
                "(",
                    "jb",
                    JbCleanUpCode.Name,
                    // todo : try to read the toolset from the solution. may need to install 15.0 toolset?
                    Option(JbCleanUpCode.Toolset, "14.0"),
                    Option(JbCleanUpCode.Settings, dotsettingsShortPath),
                    // todo : read the profiles?
                    Option(JbCleanUpCode.Profile, "Full Cleanup & File Header"),
                    Option(JbCleanUpCode.Include, fileShortPath),
                    Quote(solutionShortPath),
                ")");

            System.Diagnostics.Process.Start("CMD.exe", command);
        }

        /// <summary>
        /// Quotes a string.
        /// </summary>
        private string Quote(string text)
        {
            return $"\"{text.Trim('\"')}\"";
        }

        /// <summary>
        /// Formats an option string.
        /// </summary>
        private string Option(string option, object value = null)
        {
            return Option(option, value?.ToString() ?? null);
        }

        /// <summary>
        /// Formats an option string.
        /// </summary>
        private string Option(string option, string value = null)
        {
            string text = $"--{option}";

            if (!string.IsNullOrEmpty(value))
            {
                text += $"={Quote(value)}";
            }

            return text;
        }

        /// <summary>
        /// The inspect code callback.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Microsoft.Samples.VisualStudio.MenuCommands.MenuCommandsPackage.OutputCommandString(System.String)")]
        private void InspectCodeCallback(object caller, EventArgs args)
        {
            DTE dte = (DTE)GetService(typeof(DTE));

            if (dte.ActiveDocument == null)
            {
                return;
            }

            string filePath = dte.ActiveDocument.FullName;
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string solutionPath = dte.Solution.FullName;
            if (string.IsNullOrEmpty(solutionPath))
            {
                return;
            }

            string solutionFullDir = Path.GetDirectoryName(solutionPath);
            string fileShortPath = filePath.Substring(solutionFullDir.Length + 1);
            string solutionShortPath = solutionPath.Substring(solutionFullDir.Length + 1);
            string dotsettingsShortPath = $"{solutionShortPath}.DotSettings";

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string outputPath = Path.Combine(appdata, "VsExtensionJbCommands", "jbInspectCode.txt");

            string command = string.Join(
                " ",
                "/C",
                "(",
                    "pushd",
                    solutionFullDir,
                ")",
                "&",
                "(",
                    "jb",
                    JbInspectCode.Name,
                    Quote(solutionShortPath),
                    Option(JbInspectCode.Output, outputPath),
                    Option(JbInspectCode.Format, JbInspectCode.FormatValue.Text),
                    // todo : try to read the toolset from the solution. may need to install 15.0 toolset?
                    Option(JbInspectCode.Toolset, "14.0"),
                    Option(JbInspectCode.Profile, dotsettingsShortPath),
                    Option(JbInspectCode.Include, fileShortPath),
                ")",
                // todo : check for errors before continuing
                "&",
                "(",
                    // todo : write the output to the window.
                    "type",
                    Quote(outputPath),
                ")",
                "&",
                "(",
                    "echo .",
                ")",
                "&",
                "(",
                    "pause",
                ")");

            System.Diagnostics.Process.Start("CMD.exe", command);
        }

        #endregion
    }
}
