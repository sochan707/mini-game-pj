# Falling Tile

A 3D mini-game made in Unity for the Game Development course (CS-CADT, Year 3, Term 1). You play as Blob, and you have to collect coins before time runs out without falling off the platforms.

![1794833025677](image/README/1794833025677.png)

## Contents

- [Objective](#objective)
- [Rules](#rules)
- [Controls](#controls)
- [Requirements](#requirements)
- [Setup and play](#setup-and-play)
- [Team members and contributions](#team-members-and-contributions)
- [Assets and tutorial references](#assets-and-tutorial-references)
- [Gameplay video](#gameplay-video)
- [Playable build](#playable-build)

## Objective

Collect all the required coins before the timer reaches zero.

## Rules

- You win if you collect every required coin before the timer runs out.
- You lose if the timer runs out first, if you fall off the platforms, or if a moving wall hits you.
- Each round, the top of the screen shows a safe color. When the countdown ends, every platform of another color disappears, so stand on the safe color.
- Walls slide across the arena in your lane. Jump over them or dash out of the way.

## Controls

| Key                     | Action                             |
| ----------------------- | ---------------------------------- |
| `W` `A` `S` `D` | Move                               |
| `Space`               | Jump (only on the ground)          |
| `Left Shift`          | Dash (short burst, has a cooldown) |
| Pause button (mouse)    | Pause and resume the game          |

## Requirements

| Item            | Version                                |
| --------------- | -------------------------------------- |
| Unity           | 6000.3.8f1 (Unity 6.3 LTS)             |
| Render pipeline | Universal Render Pipeline (URP) 17.3.0 |
| Input           | Input System 1.18.0                    |
| UI              | uGUI 2.0.0, TextMesh Pro               |
| OS              | Windows or macOS (Linux not tested)    |

Open the project with Unity `6000.3.8f1`. Another version will upgrade the project files.

## Setup and play

### Play in the Unity Editor

1. Clone the repository:
   ```
   git clone https://github.com/sochan707/mini-game-pj.git
   ```
2. Open Unity Hub, click Add, then Add project from disk, and select the `mini-game-pj` folder.
3. Open the project with Unity `6000.3.8f1`. The first open takes a few minutes while Unity imports the assets.
4. Open `Assets/Scenes/MainMenu.unity`.
5. Press Play, then click Start.

### Play the build

1. Download the macOS build from the [playable build](#playable-build) link.
2. Unzip it.
3. Open `mini-game-Mac.app`.

### Make a build yourself

1. In Unity, open File > Build Profiles.
2. Check that the scene list has `MainMenu` first, then `SampleScene`.
3. Pick your platform and click Build.

### Scenes

| Scene           | Purpose              |
| --------------- | -------------------- |
| `MainMenu`    | Start and Quit       |
| `SampleScene` | Gameplay             |
| `EndGame`     | Win and lose screens |

## Team members and contributions

| Member | Role | Contributions |
| --- | --- | --- |
| Sarin Meas Sochan | UI and main programmer | Project setup, repository management, pull request reviews and merges; main menu and start page; moving walls and wall spawner; coin collection. |
| Kaing Menglay | UI, gameplay, and assets | Sample scene and prefabs; URP settings; gameplay HUD (timer, coins, pause); mission UI and map. |
| Phea Sreynith | UI and game designer | Color materials; end game screen with win and lose panels. |
| Chhon Chhaychanvibol | Player movement | Walking, jumping, dashing, and facing; camera follow; color platform rounds; Blob 3D model. |

## Assets and tutorial references

### Art and audio

| Asset | Use | Credit |
| --- | --- | --- |
| [Toon Tropical Lite: Free Stylized Island Starter](https://assetstore.unity.com/packages/3d/environments/landscapes/toon-tropical-lite-free-stylized-island-starter-421052) | Island environment assets | Halfwatt Games, Unity Asset Store |
| [Stylized Coin Pack](https://assetstore.unity.com/packages/3d/props/stylized-coin-pack-15-coins-gold-silver-bronze-wood-340494) | 3D coin models | PolyKebap, Unity Asset Store |
| [`idoberg-tropical-house-melody-loop-v2-265392.mp3`](https://pixabay.com/es/sound-effects/musical-tropical-house-melody-loop-v2-265392/) | Background music | IdoBerg, Pixabay |
| `Coin.mp3`, `Win.mp3`, `lostSound.mp3` | Sound effects | Downloaded from [Pixabay](https://pixabay.com/); individual item links were not recorded |
| `winLost_bg.jpg`, `sky backgroud.jpeg`, `sky2.jpg`, `4161612.jpg` | Background images | Downloaded from [Pixabay](https://pixabay.com/); individual item links were not recorded |
| `blue-sky-and-cloud-abstract-nature-landscape-cartoon-background-decoration-vector.jpg` | Background image | Original source not confirmed |
| `clock.png`, `Coins.png`, `Pause.png` | HUD icons | Original source not confirmed |
| Blob player model | Player character | Made by the team in Blender |

### Unity packages

- [Universal Render Pipeline](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@17.3/manual/index.html)
- [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.18/manual/index.html)
- [TextMesh Pro](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/TextMeshPro/index.html)

### Tutorials

- none

### AI assistance

- OpenAI Codex assisted with debugging the URP platform materials, verifying the macOS build, and editing the submission README.

## Gameplay video

* [Watch the gameplay demo (MP4)](https://drive.google.com/file/d/1H5G6QEVo2FXxZX5zylUwr4MrscoKr2Pt/view?usp=sharing)

## Playable build

* [Download the macOS build (ZIP)](https://drive.google.com/file/d/1GMHj6ar7lzf5PAOOGyCE8iYNU3_9hmyl/view?usp=sharing)
