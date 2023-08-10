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

    private bool hasDetectedModLoader = false;

    private void Start()
    {
        // Initial check for mod loaders
        CheckForModLoaders();
    }

    private System.Collections.IEnumerator CheckForModLoaders()
    {
        bool melonLoaderLoaded = IsModuleLoaded(MelonLoaderModuleName);
        bool harmonyLoaded = IsModuleLoaded(HarmonyModuleName);
        bool bepInExCoreLoaded = IsModuleLoaded(BepInExCoreModuleName);

        Debug.Log($"MelonLoader is{(melonLoaderLoaded ? "" : " not")} loaded.");
        Debug.Log($"Harmony is{(harmonyLoaded ? "" : " not")} loaded.");
        Debug.Log($"BepInEx.Core is{(bepInExCoreLoaded ? "" : " not")} loaded.");

        // If any mod loader is detected, exit the application
        if (melonLoaderLoaded || harmonyLoaded || bepInExCoreLoaded)
        {
            Debug.Log("Exiting application...");
            Application.Quit();
            yield break;
        }
    }

    private bool IsModuleLoaded(string moduleName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return moduleHandle != IntPtr.Zero;
    }

    private void Update()
    {
        // Start the coroutine to check for mod loaders
        StartCoroutine(CheckForModLoaders());

        // Update logic here if needed
    }
}
