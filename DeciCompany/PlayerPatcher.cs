// Author: Deci | Project: DeciCompany | Name: PlayerPatcher.cs

using System;
using System.Collections;
using System.Reflection;

namespace DeciCompany;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public class PatchPointId : Attribute { }

public class PlayerPatcher : Patcher
{

	private PlayerPatcher() { }

	public override bool Init()
	{
		On.GameNetcodeStuff.PlayerControllerB.AllowPlayerDeath += Hook_AllowPlayerDeath;
		On.GameNetcodeStuff.PlayerControllerB.Update           += Hook_Update;

		/*const BindingFlags flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic
		                           | BindingFlags.Public;

		var memberInfos = GetType().GetMembers(flags);

		foreach (var v in memberInfos) {
			var id = v.GetCustomAttribute<PatchPointId>();

			if (id != null) {
				Console.WriteLine(id);
			}
		}*/


		return true;
	}

	public static readonly PlayerPatcher Instance = new();

	/// <see cref="GameNetcodeStuff.PlayerControllerB.AllowPlayerDeath"/>
	private static bool Hook_AllowPlayerDeath(On.GameNetcodeStuff.PlayerControllerB.orig_AllowPlayerDeath orig,
	                                          GameNetcodeStuff.PlayerControllerB self)
	{
		var ret = orig(self);

		Plugin.Instance.Log.LogInfo($"[ORIG :: {orig.Method.Name}] -> {ret}");

		ret = false;
		
		return ret;
	}

	/// <see cref="GameNetcodeStuff.PlayerControllerB.Update"/>
	private static void Hook_Update(On.GameNetcodeStuff.PlayerControllerB.orig_Update orig,
	                                GameNetcodeStuff.PlayerControllerB self)
	{
		orig(self);

	}

}