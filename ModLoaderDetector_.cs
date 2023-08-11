using UnityEngine;

public class ModLoaderDetector : MonoBehaviour
{
    private bool melonLoaderDetected = false;
    private bool bepInExDetected = false;

    private void Awake()
    {
        DetectMelonLoader();
        DetectBepInEx();

        if (melonLoaderDetected)
        {
            Debug.Log("MelonLoader detected!");
            // Perform actions specific to MelonLoader
        }
        else if (bepInExDetected)
        {
            Debug.Log("BepInEx detected!");
            // Perform actions specific to BepInEx
        }
        else
        {
            Debug.Log("No mod loader detected.");
        }
    }

    private void DetectMelonLoader()
    {
        // Check if the MelonLoader assembly is loaded
        melonLoaderDetected = AppDomain.CurrentDomain
            .GetAssemblies()
            .Any(assembly => assembly.FullName.Contains("MelonLoader"));
    }

    private void DetectBepInEx()
    {
        // Check if the BepInEx core assembly is loaded
        bepInExDetected = AppDomain.CurrentDomain
            .GetAssemblies()
            .Any(assembly => assembly.FullName.Contains("BepInEx"));
    }
}
