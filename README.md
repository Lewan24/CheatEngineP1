# 🎮 Palworld Cheater – .NET 9 + MAUI

![.NET 9](https://img.shields.io/badge/.NET-9.0-purple)
![MAUI](https://img.shields.io/badge/MAUI-Cross_Platform-blue)
![Platform](https://img.shields.io/badge/Platform-Windows%2064--bit-orange)
![License](https://img.shields.io/badge/license-MIT-green)

## ✨ O Projekcie

**Palworld Cheater** to aplikacja desktopowa oparta o .NET 9 oraz MAUI, umożliwiająca:
- **Podgląd stanu ekwipunku** pierwszych **6 slotów postaci**
- **Modyfikację ilości przedmiotów** znajdujących się w tych slotach w czasie rzeczywistym
- Działanie w oparciu o **pointery** bez potrzeby ręcznego szukania adresów za każdym razem

---

## 🧠 Edukacyjny Cel

Projekt powstał w celach **edukacyjnych**, by zgłębić:
- techniki analizy pamięci procesów (reverse engineering light)
- działanie pointerów i offsetów w aplikacjach natywnych
- integrację MAUI z backendem pracującym na pamięci innego procesu
- tworzenie rozdzielnych warstw UI / logicznej / niskopoziomowej (inspiracja DDD)

Nie zachęcamy do wykorzystywania projektu w celu uzyskania nieuczciwej przewagi w grze online

---

## 🛠️ Technologie

- [.NET 9](https://github.com/dotnet/core)
- [MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)
- C#
- Windows 64-bit (ze wsparciem dla gier uruchamianych w architekturze x64)

---

## 📸 Zrzuty ekranu

> *(Będą tu zrzuty ekranu, np. UI z ekwipunkiem lub edytorem wartości)*

---

## 🚀 Funkcje

- 🔍 **Auto-resolving pointerów** (brak potrzeby ręcznego odświeżania adresów)
- 🧪 **Czytelna warstwa do odczytu/zapisu** danych w pamięci gry
- 📊 **UI w MAUI** pozwalające na intuicyjne podejrzenie i edytowanie wartości
- 💡 **Generyczne API** do pracy z `unmanaged` typami (`int`, `float`, `long`, itd.)

---

## 📦 Jak uruchomić

1. Upewnij się, że masz zainstalowane:
   - [.NET 9 SDK (Preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
   - Visual Studio z wsparciem dla MAUI

2. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Lewan24/CheatEngineP1.git
   cd CheatEngineP1
