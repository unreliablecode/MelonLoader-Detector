# MelonLoader Detector

[![GitHub License](https://img.shields.io/github/license/unreliablecode/MelonLoader-Detector)](LICENSE)
[![GitHub Stars](https://img.shields.io/github/stars/unreliablecode/MelonLoader-Detector)](https://github.com/unreliablecode/MelonLoader-Detector/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/unreliablecode/MelonLoader-Detector)](https://github.com/unreliablecode/MelonLoader-Detector/issues)

## Overview

The MelonLoader Detector is a sophisticated utility designed to enhance the security of your game by identifying the presence of external modifications, specifically targeting MelonLoader and BepInEx.

## How It Works

This utility employs a robust mechanism to scan for the existence of known mod loader files and folders within your game's directory. The core logic is encapsulated within the `ModLoaderDetector` class, which can be seamlessly integrated into your project.

## Key Features

- **Comprehensive Scanning:** The utility meticulously checks for the presence of critical mod loader files and folders, such as "MelonLoader.dll," "Harmony0.dll," "BepInEx.Core.dll," "MelonLoader" folder, and "BepInEx" folder.

- **Immediate Action:** Upon detection of any of the specified mod loader components, the utility takes decisive action by promptly logging the event and gracefully exiting the application.

- **Developer-Friendly:** The provided C# code, found in the [`ModLoaderDetector.cs`](ModLoaderDetector.cs) file, is straightforward and well-documented, making integration and customization a seamless process.

## Integration Steps

1. Clone the repository: `git clone https://github.com/unreliablecode/MelonLoader-Detector.git`
2. Add the [`ModLoaderDetector.cs`](ModLoaderDetector.cs) script to your Unity project.
3. Attach the `ModLoaderDetector` script to an appropriate GameObject in your scene.
4. Run your game and observe the console for any mod loader detection messages.

## Limitations

While the MelonLoader Detector provides a significant layer of protection, it's important to acknowledge that no solution can guarantee absolute security. Continued vigilance and proactive measures are crucial to maintaining a secure gaming environment.

## License

This project is licensed under the [MIT License](LICENSE).

## Support

For any inquiries or assistance, please [create an issue](https://github.com/unreliablecode/MelonLoader-Detector/issues) or contact us at [admin@unreliablecode.com](mailto:admin@unreliablecode.com).

---

**Disclaimer:** The MelonLoader Detector serves as a valuable tool to deter potential threats associated with MelonLoader and BepInEx. However, its effectiveness may be subject to updates and modifications by the gaming community. Developers are encouraged to adapt and expand the utility in response to evolving security challenges.
