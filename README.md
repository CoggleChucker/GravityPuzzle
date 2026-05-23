# GravityPuzzle

GravityPuzzle is a third-person puzzle game built in Unity, focused on **gravity** manipulation mechanics.  
You control a player character in levels where the direction of gravity, time pressure, and score collection all combine into spatial puzzles.

---

## Features

- Third-person character controller with smooth movement and camera.
- Gravity manipulation system that lets you alter the direction of gravity in the level.
- Visual gravity indicator so players can always see the current gravity state.
- Win / lose game flow with clear conditions.
- Level timer to add time-based challenge.
- Point collection system for scoring and replayability.

---

## Gameplay Overview

In each level, your goal is to navigate the environment using gravity shifts to reach the objective before time runs out.  
You must:

- Move the player through platforms and obstacles.
- Change gravity to access otherwise unreachable areas.
- Collect points scattered around the level.
- Avoid falling or failing conditions that cause a game lose.

This design encourages experimentation with different gravity states to find creative paths through the space.

---

## Project Structure

The core Unity project is organized as follows:

- `Assets/` – Main game content  
  - Scripts for the player controller, gravity controller, and gravity indicator.  
  - Scenes, prefabs, materials, and other Unity assets.  
- `Packages/` – Unity and third-party package configurations.  
- `ProjectSettings/` – Unity project settings.  
- `.gitignore` / `.gitattributes` – Git configuration files.  
- `GravityPuzzle.slnx` – Solution file for IDE integration.

---

## Getting Started

### Prerequisites

- Unity (Unity 6.3 LTS (6000.3.13f1) URP).
- A C#-capable IDE (Visual Studio, Rider, or VS Code) is recommended.

### Cloning the Repository

```bash
git clone https://github.com/CoggleChucker/GravityPuzzle.git
cd GravityPuzzle
```

### Opening in Unity

1. Open Unity Hub.
2. Click on “Open” and select the `GravityPuzzle` folder.
3. Let Unity import all assets and packages.
4. Open the main scene (for example, `Assets/Scenes/Main.unity` or similar, depending on your scene naming).
5. Press Play to run the game in the editor.

---

## How It Works (High Level)

- **Player Controller**  
  Handles player movement, input, and third-person camera behavior.

- **Gravity Controller**    
  Player input can change gravity direction.

- **Gravity Indicator**  
  Provides a visual representation of the active gravity direction so the player always understands the current orientation.

- **Game State & UI**  
  Implements win/lose conditions, timers, and score tracking, and can drive basic UI feedback.

---

## Roadmap / Ideas

Potential next steps and enhancements:

- Add multiple levels with increasing puzzle complexity.
- Introduce hazards and enemies affected by gravity.
- Add more UI polish (menus, pause screen, settings).
- Implement sound effects and background music.
- Add saving/loading of best times and high scores.

---

## Contributing

Contributions, ideas, and feedback are welcome. To contribute:

1. Fork the repository.
2. Create a feature branch:  
   `git checkout -b feature/my-new-feature`
3. Commit your changes:  
   `git commit -m "Add my new feature"`
4. Push the branch:  
   `git push origin feature/my-new-feature`
5. Open a Pull Request.

---

## License

This project currently does not specify a license.  

---

## Author

Created by [CoggleChucker](https://github.com/CoggleChucker).  
GravityPuzzle is an experimental project exploring gravity-based puzzle mechanics in a third-person perspective.
