using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class ModLoaderDetector : MonoBehaviour
{
    const string MelonLoaderModuleName = "MelonLoader.dll";
    const string HarmonyModuleName = "Harmony0.dll";
    const string BepInExCoreModuleName = "BepInEx.Core.dll";

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    private void Start()
    {
        CheckModLoaders();
    }

    private void CheckModLoaders()
    {
        bool melonLoaderLoaded = IsModuleLoaded(MelonLoaderModuleName);
        bool harmonyLoaded = IsModuleLoaded(HarmonyModuleName);
        bool bepInExCoreLoaded = IsModuleLoaded(BepInExCoreModuleName);

        Debug.Log($"MelonLoader is{(melonLoaderLoaded ? "" : " not")} loaded.");
        Debug.Log($"Harmony is{(harmonyLoaded ? "" : " not")} loaded.");
        Debug.Log($"BepInEx.Core is{(bepInExCoreLoaded ? "" : " not")} loaded.");
    }

    private bool IsModuleLoaded(string moduleName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return moduleHandle != IntPtr.Zero;
    }
}
