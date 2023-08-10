using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class ModLoaderDetector : MonoBehaviour
{
    private string[] moduleNames = { "MelonLoader.dll", "Harmony0.dll", "BepInEx.Core.dll" };
    private string[] folderNames = { "MelonLoader", "BepInEx" };

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    private WaitForSeconds checkInterval = new WaitForSeconds(5.0f); // Check every 5 seconds

    private void Start()
    {
        StartCoroutine(CheckForModLoadersContinuously());
    }

    private IEnumerator CheckForModLoadersContinuously()
    {
        while (true)
        {
            CheckForModLoaders();

            // Wait for the specified interval before checking again
            yield return checkInterval;
        }
    }

    private void CheckForModLoaders()
    {
        if (IsAnyModuleLoaded() || AreAnyFoldersPresent())
        {
            Debug.Log("Mod loader or folder detected. Exiting application...");
            Application.Quit();
        }
    }

    private bool IsModuleLoaded(string moduleName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return moduleHandle != IntPtr.Zero;
    }

    private bool IsAnyModuleLoaded()
    {
        foreach (string moduleName in moduleNames)
        {
            if (IsModuleLoaded(moduleName))
            {
                return true;
            }
        }
        return false;
    }

    private bool AreAnyFoldersPresent()
    {
        foreach (string folderName in folderNames)
        {
            if (Directory.Exists(folderName))
            {
                return true;
            }
        }
        return false;
    }
}
