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
        // Initial check for mod loaders
        CheckForModLoaders();
    }

    private void CheckForModLoaders()
    {
        bool modLoaded = false;
        bool folderPresent = false;

        foreach (string moduleName in moduleNames)
        {
            if (IsModuleLoaded(moduleName))
            {
                Debug.Log($"{moduleName} is loaded.");
                modLoaded = true;
                break;
            }
        }

        foreach (string folderName in folderNames)
        {
            if (Directory.Exists(folderName))
            {
                Debug.Log($"{folderName} folder is present.");
                folderPresent = true;
                break;
            }
        }

        if (modLoaded || folderPresent)
        {
            Debug.Log("Exiting application...");
            Application.Quit();
        }
    }

    private bool IsModuleLoaded(string moduleName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return moduleHandle != IntPtr.Zero;
    }

    private void Update()
    {
        // Check for mod loaders and folders
        CheckForModLoaders();
    }
}
