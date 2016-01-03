$PackagePath = Join-Path $PSScriptRoot ".."
$MicrosoftBandSdkVersion = "1.3.11121"
$MicrosoftBandSdkUrl = "https://api.nuget.org/packages/microsoft.band." + $MicrosoftBandSdkVersion + ".nupkg"
$MicrosoftBandSdkPackagePath = Join-Path $PackagePath ("Microsoft.Band." + $MicrosoftBandSdkVersion + ".zip")
$MicrosoftBandSdkPath = Join-Path $PackagePath "Microsoft.Band"

if (!(Test-Path $MicrosoftBandSdkPath -PathType Container))
{
	Invoke-WebRequest $MicrosoftBandSdkUrl -OutFile $MicrosoftBandSdkPackagePath

	Expand-Archive $MicrosoftBandSdkPackagePath -DestinationPath $MicrosoftBandSdkPath
}