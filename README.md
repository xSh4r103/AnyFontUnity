# 👾 AnyFontUnity v1.0.0

**AnyFontUnity** is an automated patching tool designed to help modders, translators, and gamers easily inject custom TrueType Fonts (`.ttf`) into Unity games. It eliminates the need to unpack or modify the original game assets.

By utilizing the power of **MelonLoader**, AnyFontUnity supports both **IL2CPP** and **Mono** architectures, making it a versatile solution for fan translations (Asian languages, Cyrillic, etc.) that frequently encounter missing characters or "square box" issues in Unity.

---

### 🌟 Key Features
*   **1-Click Automated Hooking:** No more manual folder copying. The tool handles MelonLoader extraction and installation completely automatically.
*   **Dual Architecture Support:** Fully supports both IL2CPP and Mono engine builds.
*   **Custom TTF Injection:** Use the pre-packaged universal system font or inject your own `.ttf` file into the game.
*   **Multi-language UI:** Built-in UI localization supporting 7 languages (EN, VI, ZH, TW, RU, KO, JA).

---

### 🚀 How to Use
1. Download the latest `.exe` file from the **[Releases](../../releases)** page.
2. Run `AnyFontUnity.exe`.
3. Click the `...` button and select your target Unity game's `.exe` file.
4. **Step 1:** Click `PATH LOADER GAME` and select the MelonLoader version.
5. **Step 2:** Click `RUN & LOADER GAME`. The game will launch automatically. Wait until the game reaches the Main Menu, then manually close it.
6. **Step 3:** Click `PATH .dll + .tff`. Choose the game's architecture (IL2CPP / MONO) and select the font you want to inject.
7. Done! Restart the game and enjoy.

---

### 🙏 Credits & Acknowledgments
This project stands on the shoulders of giants. A sincere thank you to the creators of the core hooking framework:
   **[MelonLoader](https://github.com/LavaGang/MelonLoader):** Thank you for providing an incredible and universal modding architecture for Unity games. AnyFontUnity acts as an automated installer based on MelonLoader to simplify the font-patching process for end-users.

### 📜 License
This project is licensed under the [MIT License](LICENSE).
