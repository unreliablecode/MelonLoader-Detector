using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

public class ModLoaderDetector : MonoBehaviour
{
    private string[] moduleNames = { "MelonLoader.dll", "Harmony0.dll", "BepInEx.Core.dll" };
    private string[] folderNames = { "MelonLoader", "BepInEx" };

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    private void Start()
    {
        StartCoroutine(CheckForModLoaders());
    }

    private System.Collections.IEnumerator CheckForModLoaders()
    {
        foreach (string moduleName in moduleNames)
        {
            if (IsModuleLoaded(moduleName))
            {
                Debug.Log($"{moduleName} is loaded. Exiting application...");
                Application.Quit();
                yield break;
            }
        }

        foreach (string folderName in folderNames)
        {
            if (Directory.Exists(folderName))
            {
                Debug.Log($"{folderName} folder is present. Exiting application...");
                Application.Quit();
                yield break;
            }
        }

        // No mod loaders or folders detected, continue with the game
    }

    private bool IsModuleLoaded(string moduleName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return moduleHandle != IntPtr.Zero;
    }

    private void Update()
    {
        // You can add any required update logic here
        StartCoroutine(CheckForModLoaders());
    }
}
