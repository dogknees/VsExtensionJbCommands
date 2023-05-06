namespace JbCommands
{
    /// <summary>
    /// The jb InspectCode helper.
    /// </summary>
    /// Usage: inspectcode [options] [solution or project file]
    public static class JbInspectCode
    {
        /// <summary>
        /// Gets the inspect code command name.
        /// </summary>
        public static string Name = "InspectCode";

        /// <summary>
        /// Write inspections report to specified file.
        /// </summary>
        public static string Output = "output";

        /// <summary>
        /// Write inspections report in specified format [Xml, Html, Text, Json] (default: Xml).
        /// </summary>
        public static string Format = "format";

        /// <summary>
        /// Analyze only files selected by provided wildcards (default: analyze all files in solution).
        /// </summary>
        public static string Include = "include";

        /// <summary>
        /// Path to the file to use custom settings from (default: Use R#'s solution shared settings if exists).
        /// </summary>
        public static string Profile = "profile";

        /// <summary>
        /// MsBuild toolset version. Highest available is used by default. Example: --toolset=12.0.
        /// </summary>
        public static string Toolset = "toolset";

        /// <summary>
        /// Path to configuration file where parameters are specified (use 'config-create' option to create sample file).
        /// </summary>
        public static string Config = "config";

        /// <summary>
        /// Write command line parameters to specified file.
        /// </summary>
        public static string ConfigCreate = "config-create";

        /// <summary>
        /// Run up to N jobs in parallel. 0 means as many as possible (default: 0).
        /// </summary>
        public static string Jobs = "jobs";

        /// <summary>
        /// Use absolute paths in inspections report (default: False).
        /// </summary>
        public static string AbsolutePaths = "absolute-paths";

        /// <summary>
        /// Force disable solution-wide analysis (default: False).
        /// </summary>
        public static string NoSolutionWideAnalysis = "no-swea";

        /// <summary>
        /// Force enable solution-wide analysis (default: False).
        /// </summary>
        public static string SolutionWideAnalysis = "swea";

        /// <summary>
        /// Analyze only projects selected by provided wildcards (default: analyze all projects in solution).
        /// </summary>
        public static string Project = "project";

        /// <summary>
        /// Exclude files selected by provided wildcards from analysis (default: analyze all files in solution).
        /// </summary>
        public static string Exclude = "exclude";

        /// <summary>
        /// Dump issues types (default: False).
        /// </summary>
        public static string DumpIssuesTypes = "dumpIssuesTypes";

        /// <summary>
        /// Minimal severity level to report [INFO, HINT, SUGGESTION, WARNING, ERROR] (default: SUGGESTION).
        /// </summary>
        public static string Severity = "severity";

        /// <summary>
        /// Measure own tool's performance [MEMORY, SAMPLING, TIMELINE].
        /// </summary>
        public static string Measure = "measure";

        /// <summary>
        /// Show debugging messages (default: False).
        /// </summary>
        public static string Debug = "debug";

        /// <summary>
        /// Display this amount of information in the log [OFF, FATAL, ERROR, WARN, INFO, VERBOSE, TRACE] (default: INFO).
        /// </summary>
        public static string Verbosity = "verbosity";

        /// <summary>
        /// Show help and exit.
        /// </summary>
        public static string Help = "help";

        /// <summary>
        /// Show tool version and exit.
        /// </summary>
        public static string Version = "version";

        /// <summary>
        /// MsBuild toolset (exe/dll) path. Example: --toolset-path=/usr/local/msbuild/bin/current/MSBuild.exe.
        /// </summary>
        public static string ToolsetPath = "toolset-path";

        /// <summary>
        /// Mono path. Empty to ignore Mono. Not specified for autodetect. Example: --mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.
        /// </summary>
        public static string Mono = "mono";

        /// <summary>
        /// .NET Core path. Empty to ignore .NET Core. Not specified for autodetect. Example: --dotnetcore=/usr/local/share/dotnet/dotnet.
        /// </summary>
        public static string DotNetCore = "dotnetcore";

        /// <summary>
        /// .NET Core SDK version. Example: --dotnetcoresdk=3.0.100.
        /// </summary>
        public static string DotNetCoreSDK = "dotnetcoresdk";

        /// <summary>
        /// Disable specified settings layers. Possible values: GlobalAll, GlobalPerProduct, SolutionShared, SolutionPersonal, ProjectShared, ProjectPersonal.
        /// </summary>
        public static string DisableSettingsLayers = "disable-settings-layers";

        /// <summary>
        /// Suppress global, solution and project settings profile usage. Alias for --disable-settings-layers:GlobalAll;GlobalPerProduct;SolutionShared;SolutionPersonal;ProjectShared;ProjectPersonal (default: False).
        /// </summary>
        public static string NoBuildInSettings = "no-buildin-settings";

        /// <summary>
        /// Path to the directory where produced caches will be stored.
        /// </summary>
        public static string CachesHome = "caches-home";

        /// <summary>
        /// MSBuild properties.
        /// </summary>
        public static string Properties = "properties";

        /// <summary>
        /// MSBuild targets. These targets will be executed to get referenced assemblies of projects..
        /// </summary>
        public static string TargetsForReferences = "targets-for-references";

        /// <summary>
        /// MSBuild targets. These targets will be executed to get other items (e.g. Compile item) of projects..
        /// </summary>
        public static string TargetsForItems = "targets-for-items";

        /// <summary>
        /// Install and use specified extensions.
        /// </summary>
        public static string Extensions = "eXtensions";

        /// <summary>
        /// Install extensions from specified source(s).
        /// </summary>
        public static string Source = "source";

        /// <summary>
        /// The format values.
        /// </summary>
        public enum FormatValue
        {
            Xml,
            Html,
            Text,
            Json
        }

        /// <summary>
        /// The severity values.
        /// </summary>
        public enum SeverityValue
        {
            INFO,
            HINT,
            SUGGESTION,
            WARNING,
            ERROR
        }

        /// <summary>
        /// The measure values.
        /// </summary>
        public enum MeasureValues
        {
            MEMORY,
            SAMPLING,
            TIMELINE
        }

        /// <summary>
        /// The verbosity values.
        /// </summary>
        public enum VerbosityValues
        {
            OFF,
            FATAL,
            ERROR,
            WARN,
            INFO,
            VERBOSE,
            TRACE
        }
    }
}
