# 🎮 Palworld Cheater – .NET 9 + MAUI

![.NET 9](https://img.shields.io/badge/.NET-9.0-purple)
![MAUI](https://img.shields.io/badge/MAUI-Cross_Platform-blue)
![Platform](https://img.shields.io/badge/Platform-Windows%2064--bit-orange)
![License](https://img.shields.io/badge/license-MIT-green)

## ✨ About the Project

**Palworld Cheater** is a desktop application built with **.NET 9** and **MAUI** that allows you to:

- 🔍 **View the inventory state** of the first **6 item slots**
- 🛠 **Modify item amounts** in those slots in real-time
- 🎯 Use **memory pointers** to reliably access game data (no need to re-scan addresses manually)

---

## 🧠 Educational Purpose

This project was created for **educational purposes only**, with goals including:

- Learning how to analyze process memory (reverse engineering basics)
- Understanding pointer chains and offset navigation
- Integrating MAUI UI with low-level memory interaction logic
- Practicing clean separation of concerns (inspired by DDD-like structure)

> ⚠️ This tool is designed only for **offline/single-player use**.  
> Do **not** use it in online environments or multiplayer modes.

---

## 🛠️ Technologies Used

- [.NET 9](https://github.com/dotnet/core)
- [MAUI (Multi-platform App UI)](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)
- C#
- Windows 64-bit (compatible with x64 architecture)

---

## 📸 Screenshots

> *(Screenshots coming soon: e.g., inventory preview and value editor views)*

---

## 🚀 Features

- 🧭 **Automatic pointer resolution** (no manual updates needed)
- 📖 **Clear API for reading/writing** unmanaged memory values
- 🧩 **User-friendly MAUI interface** for interacting with game data
- 🔧 **Generic API support** for `unmanaged` types (`int`, `float`, `long`, etc.)

---

## 📦 How to Run

You can run the project in two ways:

### 🧑‍💻 Option 1 – Build from source

1. Make sure you have installed:
   - [.NET 9 SDK (Preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
   - Visual Studio **or** JetBrains Rider with **MAUI support** enabled

2. Clone the repository:
   ```bash
   git clone https://github.com/Lewan24/CheatEngineP1.git
   cd CheatEngineP1
   ```
3. Open the solution file (CheatEngineP1.sln) in your IDE.
4. Set the MAUI project as startup and run the app.
   ```bash
   💡 Make sure the game (Palworld) is already running before you start the cheat tool.
   ```

### 📦 Option 2 – Download Prebuilt App
Visit the Releases section of this repository and download the latest version of the compiled application.

1. Unzip the package
2. Run the .exe file directly
3. Enjoy full functionality without building from source!
