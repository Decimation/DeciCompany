using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;

// ReSharper disable UnusedMember.Local
// using HarmonyLib;

namespace DeciCompany;

public class HyperHook
{

	[HarmonyPatch(nameof(PlayerControllerB), nameof(PlayerControllerB.AllowPlayerDeath))]
	[HarmonyPrefix]
	private static void AllowPlayerDeath(PlayerControllerB __instance, ref bool __result)
	{
		/*
		if (!StartOfRound.Instance.allowLocalPlayerDeath) {
			return false;
		}

		if (__instance.playersManager.testRoom == null) {
			if (StartOfRound.Instance.timeSinceRoundStarted < 2f) {
				return false;
			}

			if (!__instance.playersManager.shipDoorsEnabled) {
				return false;
			}
		}

		return true;
	*/

		Plugin.Logger.LogInfo($"{__instance} -> {__result}");
		__result = false;
		// return __result;
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x000C1EA8 File Offset: 0x000C00A8
	// public bool AllowPlayerDeath()

	// Token: 0x060014C3 RID: 5315 RVA: 0x000C1EFC File Offset: 0x000C00FC
	// public void DamagePlayer(int damageNumber, bool hasDamageSFX = true, bool callRPC = true,
	//    CauseOfDeath causeOfDeath = CauseOfDeath.Unknown, int deathAnimation = 0, bool fallDamage = false, Vector3 force = default(Vector3))

}

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
// [BepInDependency(LethalLib.Plugin.ModGUID)]
public class Plugin : BaseUnityPlugin
{

	internal new static ManualLogSource Logger;

	private void Awake()
	{
		// Plugin startup logic
		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

		Harmony.CreateAndPatchAll(typeof(HyperHook));
	}


}