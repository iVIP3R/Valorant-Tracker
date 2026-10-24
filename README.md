# Valorant Tracker

A desktop tracker for Riot's **Valorant**, written in C# / WinForms on .NET 8.
Shows account details, the daily store rotation, competitive rank per act, and
match history — all through Riot's client API, authenticated via the official
Riot login page embedded in WebView2.

> **Status:** post-refactor baseline. The app builds and runs end-to-end;
> further cleanup is in progress.

## Screenshots

_Screenshots coming soon._

## Requirements

- Windows 10 / 11
- [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft Edge WebView2 Evergreen Runtime](https://developer.microsoft.com/microsoft-edge/webview2/)
  — required for Riot sign-in. The app disables the login button with an
  explanatory message if the runtime is missing.
- A Riot account with Valorant access.

## Build

```cmd
git clone https://github.com/iVIP3R/Valorant-Tracker.git
cd Valorant-Tracker
dotnet build "Valorant Tracker/Valorant Tracker.csproj" -c Release
```

Run it from the same folder:

```cmd
dotnet run --project "Valorant Tracker/Valorant Tracker.csproj"
```

Or open `Valorant Tracker.sln` in Visual Studio 2022 (17.8+) and press F5.

## How sign-in works

1. Clicking **Continue** opens Riot's official authorize page inside an embedded
   WebView2 control.
2. Once the user signs in, Riot redirects to `playvalorant.com/opt_in` with an
   `access_token` and `id_token` in the URL fragment. `WebViewAuthHandler`
   intercepts that redirect.
3. `Auth.CreateFromAccessTokenAsync` exchanges the access token for an
   **entitlement token** (`entitlements.auth.riotgames.com/api/token/v1`) and
   resolves the current Valorant client version from
   [valorant-api.com](https://valorant-api.com/v1/version).
4. All subsequent Riot player-data calls go through `ValorantApiClient`, which
   attaches `Authorization`, `X-Riot-Entitlements-JWT`, `X-Riot-ClientPlatform`,
   and `X-Riot-ClientVersion` headers on every request.

Tokens live in memory only. Nothing is sent anywhere except Riot's own
endpoints and valorant-api.com.

The store panel resolves skin UUIDs from Riot's storefront via valorant-api.com's
`/v1/weapons/skinlevels/{uuid}` endpoint (Riot returns **skin-level** UUIDs in
`Rewards[].ItemID`).

## Project layout

```
Valorant Tracker/
├── Auth.cs                  Riot identity + entitlement exchange
├── RiotSession.cs           Immutable view of the current session for API calls
├── ValorantApiClient.cs     Authenticated HTTP transport for player-data calls
├── WebViewAuthHandler.cs    Redirect parsing for the WebView login flow
├── frmLogin.cs              WebView-based login form
├── frmMain.cs               Main dashboard (account, store, rank, history)
├── frmMatchDetails.cs       Per-match detail window
├── Content.cs               valorant-api.com lookups + Riot content-service DTOs
├── Store.cs                 Storefront client
├── Rank.cs, Balances.cs, PlayerAccountDetails.cs, ...
├── Enums.cs                 Region + static UI constants
└── Objects/                 DTOs for Riot's responses
```

## Known limitations

- Act UUIDs are still hardcoded in `Enums.cs` / `Seasons`.
- Agent and map tables are incomplete.
- Store panel assumes exactly 4 offers.
- Match history loads matches one at a time.
- WebView login is required whenever Riot's cookies expire; there is no
  explicit silent re-auth or token-refresh flow yet.

## Disclaimer

This project is **not affiliated with or endorsed by Riot Games**. Valorant and
Riot Games are trademarks of Riot Games, Inc. The app uses Riot's undocumented
client API, which can change without notice.

## License

[MIT](LICENSE) — © 2026 @iVIP3R