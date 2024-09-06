using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;

// ReSharper disable UnusedMember.Local

//cp .\DeciCompany\bin\Debug\netstandard2.1\DeciCompany.dll 'F:\SteamLibrary\steamapps\common\Lethal Company\BepInEx\plugins\'


namespace DeciCompany;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{

	private void Awake()
	{
		Instance = this;
		Log      = Logger;

		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is awake!");


		foreach (var patcher in Patchers) {
			patcher.Init();

		}

		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} IT'S GO TIME!");
	}

	public readonly Patcher[] Patchers =
	[
		PlayerPatcher.Instance
	];

	public ManualLogSource Log { get; private set; }

	public static Plugin Instance { get; private set; }

}