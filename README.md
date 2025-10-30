# AdultHub Desktop App (Prototype)

A Windows-first desktop prototype for an offline adult media hub built with Clean Architecture + MVVM. The repo ships a WPF shell (Windows) and a runnable cross‑platform Avalonia UI (Linux/macOS dev). Core layers (Domain, Application, Infrastructure) are UI‑agnostic.

## Solution Overview
- Domain (net8.0): entities, value objects, invariants (pure .NET)
- Application (net8.0): use cases, DTOs, interfaces; no framework coupling
- Infrastructure (net8.0): external integrations (video player, future HTTP APIs), DI
- UI.Wpf (net8.0-windows): Windows-only WPF shell
- UI.Avalonia (net8.0): cross-platform UI, the active prototype
- tests/*: xUnit + Moq

Principles: MVVM, SOLID, DI, testability, interface-driven design.

## Run / Build
```bash
# From repo root
 dotnet restore
 dotnet build -c Debug

 # Avalonia (cross‑platform)
 dotnet run --project ./src/UI.Avalonia/UI.Avalonia.csproj

 # Tests
 dotnet test
```
Windows-only WPF won’t run on Linux; use Avalonia for non‑Windows.

## Project Structure
```
/src
  /Domain
  /Application
  /Infrastructure
  /UI.Wpf
  /UI.Avalonia
/tests
  /Application.Tests
```
UI.Avalonia key folders: Views (windows), ViewModels, Models, Converters, Dialogs.

## MVVM Conventions
- Each window: `*.axaml`, `*.axaml.cs` (DataContext wiring), `*ViewModel.cs`
- Views bind to VM properties/commands only
- No business logic in code-behind; only navigation/event wiring

## Navigation (prototype)
- MainWindow: click performer card → `PerformerDetailWindow` (modal). Click “Media” on top bar → `MediaWindow`.
- MediaWindow: grid of thumbnails (Title, Duration, Favorite). Hook to open `MediaDetailWindow` on click.

## Dependency Injection
Configured in `src/UI.Avalonia/App.axaml.cs`:
- `AddInfrastructure()` registers infrastructure
- ViewModels/Windows registered for injection

Add a new service:
1) Interface in `Application/Common/Interfaces`
2) Implementation + DI in `Infrastructure`
3) Use from Application use cases; UI calls use cases only

## Adding a Porn API (pattern)
- Define `IPornApiClient` in Application
- Implement with `HttpClient` in Infrastructure
- Register with `AddHttpClient<IPornApiClient, PornApiClient>`
- Consume via Application use cases (UI stays clean)

## Collaboration Guide
- Branch per feature (`feat/media-detail`, `fix/dialog-crash`)
- Keep framework types out of Domain/Application
- Update DI when adding/removing services
- Write tests for new use cases; mock infrastructure in tests
- Keep dialogs/styles consistent (see `App.axaml`)

## Crash/Lifecycle: Workarounds
Detail windows are opened as modal dialogs with an owner to avoid lifetime issues:
```csharp
var child = App.HostApp.Services.GetRequiredService<PerformerDetailWindow>();
await child.ShowDialog(this); // this = owner window
```
Prefer modal dialogs for transient windows. If you add modeless windows, do not change the `MainWindow` reference in `ApplicationLifetime`.

## Roadmap
- Wire MediaWindow item click → MediaDetailWindow
- Replace sample data with real API-backed use cases
- Persist favorites/filters
- Add tests for new scenarios

---
Prototype code; add license and contribution policy as needed.
