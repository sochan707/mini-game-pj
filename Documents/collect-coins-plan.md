# Collect Five Coins: Guided Build Plan

## Goal

Collect five coins before the existing three-minute timer reaches zero. One coin initially appears above a random active tile and floats and spins there until collected, even if its tile later becomes inactive. After each pickup, the next coin appears above an active tile, preferably at a different position.

We will build this together in small checkpoints. I will explain the Unity concept and give you one manageable task. You will make the change, then we will inspect and test it before moving on.

## Checkpoints

1. **Make a coin pickup.** Use the supplied `Coin_Skull` model to create a game prefab with a trigger collider. Add a script that makes it float and spin. Learn how trigger events detect the player.
2. **Spawn on active tiles.** Expose the currently usable tiles from `PlatformManager`. Spawn exactly one coin on a random active tile, preferably away from the player's current tile. After collection, choose a different active tile when possible. If a platform round removes the coin's tile, leave the existing coin where it is until collected.
3. **Show progress.** Update the existing coin HUD from `0/5` through `5/5`, with the count beside the coin icon.
4. **Connect the timer and results.** Keep the existing 180-second limit. The fifth valid pickup opens the `EndGame` win panel. Timeout, falling, and moving-wall contact open its lose panel. Add `EndGame` to Build Settings so scene loading works in builds. Pause should freeze the timer and coin animation.
5. **Playtest the complete loop.** Confirm each pickup counts once; only one coin exists; respawning and tile changes work; pause works; and each win or loss condition shows the correct panel.

## Implementation notes

- The live floor is the 8×8 grid created by `PlatformManager`. The older `Platform` object in the scene is disabled.
- The chosen skull coin asset is in `Assets/Models/PolyKebap/Stylized Coin Pack/`. Our `CoinPickup` prefab adds the pickup collider.
- `SampleScene` already contains a coin HUD and `CountdownTimer`. `EndGame` already contains separate win and lose panels, but it is not yet listed in Build Settings.
- Coin collection is valid only while time remains. At the fifth coin, stop spawning and show the win result. A new random spawn should avoid the prior position when another active tile is available. The current code excludes the prior tile object within a round; after `PlatformManager` rebuilds the grid, it can choose the same position again.

## Working agreement

You write the game changes. I guide one checkpoint at a time, explain the relevant Unity ideas and code, review your work, and help debug unexpected behavior before we continue.

## Progress for the next chat

- `Assets/Prefabs/CoinPickup.prefab` uses `Coin_Skull`, a trigger collider, `CoinMovement`, and `CoinPickup`.
- `PlatformManager.GetActivePlatforms()` returns tiles that are currently active.
- `Assets/Scripts/Coin/CoinSpawner.cs` is attached to `GameManager` in `SampleScene`, with its platform manager and coin prefab references assigned. It spawns one coin on a random active tile. The player can collect it, and the pickup notifies the spawner to create the next coin on an active tile. This was playtested.
- The coin intentionally stays in place if its tile becomes inactive or is replaced. The relocation code was removed at the student's request.
- The existing coin HUD displays the count beside the coin icon, and `CoinSpawner` stops spawning after five pickups. The direction arrow was removed from the plan at the student's request.
- **Next lesson:** Connect the fifth pickup and timer to the win and lose results, one small step at a time. Keep the round-reset position limitation in mind if a strict different-position rule becomes important.
