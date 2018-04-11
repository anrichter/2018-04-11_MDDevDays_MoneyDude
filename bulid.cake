// Tools
#tool "nuget:?package=GitVersion.CommandLine"

// Addins
#addin "Cake.Plist"
#addin "MagicChunks"

// Variables
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var androidManifestFilePath = "./MoneyDude/MoneyDude.Android/Properties/AndroidManifest.xml";
var iOSPListFilePath = "./MoneyDude/MoneyDude.iOS/Info.plist";

// Tasks
Task("Default")
    .Does(() => {
    });

Task("Set-BuildVersions")
    .Description("Set Major and Minor Versions in Apps for building according to Git-Version number")
    .Does(() => {
        var gitVersion = GitVersion(new GitVersionSettings { UpdateAssemblyInfo = false });
        SetVersionsTo(gitVersion.Major, gitVersion.Minor, gitVersion.CommitsSinceVersionSource ?? 0);
    });

void SetVersionsTo(int major, int minor, int build)
{
    var versionCode = major * 100000 +
                      minor *   1000 +
                      build;

    TransformConfig(androidManifestFilePath,
        new TransformationCollection {
            { "manifest/@android:versionName", $"{major}.{minor}" },
            { "manifest/@android:versionCode", $"{versionCode}" }
    });
    Information($"Android VersionName set to {major}.{minor}");
    Information($"Android VersionCode set to {versionCode}");

    // iOS
    dynamic data = DeserializePlist(iOSPListFilePath);
    data["CFBundleShortVersionString"] = $"{major}.{minor}";
    data["CFBundleVersion"] = $"{build}";
    SerializePlist(iOSPListFilePath, data);

    Information($"iOS Version set to {major}.{minor}");
    Information($"iOS Build Version set to {build}");
}

// Run the target
RunTarget(target);
