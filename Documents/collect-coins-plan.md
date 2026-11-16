# Collect Five Coins: Guided Build Plan

## Goal

Collect five coins before the existing three-minute timer reaches zero. One coin floats and spins above a random active tile at a time. After each pickup, the next coin appears on another tile. A small arrow above the player points toward the current coin.

We will build this together in small checkpoints. I will explain the Unity concept and give you one manageable task. You will make the change, then we will inspect and test it before moving on.

## Checkpoints

1. **Make a coin pickup.** Use the supplied `Coin_Skull` model to create a game prefab with a trigger collider. Add a script that makes it float and spin. Learn how trigger events detect the player.
2. **Spawn on active tiles.** Expose the currently usable tiles from `PlatformManager`. Spawn exactly one coin on a random active tile, preferably away from the player's current tile. After collection, choose a different tile. If a platform round removes the coin's tile, move the coin to an active tile without counting a pickup.
3. **Show progress and direction.** Update the existing coin HUD from `0/5` through `5/5`. Add a small world-space arrow above the player and rotate it toward the active coin.
4. **Connect the timer and results.** Keep the existing 180-second limit. The fifth valid pickup opens the `EndGame` win panel. Timeout, falling, and moving-wall contact open its lose panel. Add `EndGame` to Build Settings so scene loading works in builds. Pause should freeze the timer and coin animation.
5. **Playtest the complete loop.** Confirm each pickup counts once; only one coin exists; respawning and tile changes work; the arrow points to the new coin; pause works; and each win or loss condition shows the correct panel.

## Implementation notes

- The live floor is the 8×8 grid created by `PlatformManager`. The older `Platform` object in the scene is disabled.
- The chosen skull coin asset is in `Assets/Models/PolyKebap/Stylized Coin Pack/`. Our `CoinPickup` prefab adds the pickup collider.
- `SampleScene` already contains a coin HUD and `CountdownTimer`. `EndGame` already contains separate win and lose panels, but it is not yet listed in Build Settings.
- Coin collection is valid only while time remains. At the fifth coin, stop spawning and show the win result. A new random spawn should avoid the prior tile when another active tile is available.

## Working agreement

You write the game changes. I guide one checkpoint at a time, explain the relevant Unity ideas and code, review your work, and help debug unexpected behavior before we continue.

## Progress for the next chat

- `Assets/Prefabs/CoinPickup.prefab` uses `Coin_Skull`, a trigger collider, `CoinMovement`, and `CoinPickup`.
- `PlatformManager.GetActivePlatforms()` returns tiles that are currently active.
- `Assets/Scripts/Coin/CoinSpawner.cs` is attached to `GameManager` in `SampleScene`, with its platform manager and coin prefab references assigned. It spawns one coin on a random active tile. The player can collect it.
- **Next lesson:** Have the pickup notify the spawner so a new coin appears after collection, preferably on a different active tile. Give a short explanation and let the student write the code. The current `CoinPickup` destroys itself without notifying the spawner.
