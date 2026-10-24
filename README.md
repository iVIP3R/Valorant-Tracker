# Valorant Tracker

[![.NET Build](https://github.com/iVIP3R/Valorant-Tracker/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iVIP3R/Valorant-Tracker/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A lightweight, modern desktop tracker for Riot's **Valorant**, written in C# / WinForms on .NET 8. 

## Features

- **Seamless Authentication**: Uses embedded WebView2 and OAuth to safely log in via Riot's official page. Includes silent re-auth using secure, persistent cookies.
- **Dynamic Game Data**: Acts, Agents, and Maps are dynamically fetched from the community API (`valorant-api.com`). No more broken hardcoded UUIDs when Riot releases a new patch.
- **Player Store**: Instantly view your daily rotating store offers with images and prices.
- **Match History**: Features a progressive lazy-loading architecture. The grid populates instantly with start times, while details (Map, Agent, KDA) are fetched in the background.
- **Caching**: Clicking a match row opens the detailed 10-player scoreboard instantly (0ms delay) thanks to an in-memory cache.
- **Resilience**: Global exception handlers and detailed file logging ensure the app never silently crashes.

## Requirements

- Windows 10 / 11
- [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft Edge WebView2 Runtime](https://developer.microsoft.com/microsoft-edge/webview2/)

## Build

```cmd
git clone https://github.com/iVIP3R/Valorant-Tracker.git
cd Valorant-Tracker
dotnet build "Valorant Tracker/Valorant Tracker.csproj" -c Release
```

## Architecture Highlights

- **`ValorantApiClient`**: A resilient HTTP wrapper that automatically attaches the required `Bearer` token, `Entitlement` JWT, and `ClientVersion` headers to every Riot request.
- **`ValorantDataService`**: A static caching service that fetches live maps/agents/acts once per session, preventing rate limits and reducing UI delay.
- **Async-First**: Network requests use native `async/await` to ensure the UI thread never locks up. 
- **Resilience**: A global `Logger` writes stack traces to `%LOCALAPPDATA%\Valorant_Tracker\logs\`, keeping the UI free of technical jargon while allowing developers to debug crashes.

## Disclaimer

This project is not affiliated with or endorsed by Riot Games. Valorant and Riot Games are trademarks of Riot Games, Inc. The app uses Riot's undocumented client API, which can change without notice.

## License

[MIT](LICENSE)