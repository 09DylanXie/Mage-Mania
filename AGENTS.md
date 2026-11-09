# AGENTS.md

Guidance for AI coding agents working on **Mage Mania**. For the full design, read `docs/Mage_Mania_Manuscript.pdf` and `README.md`.

## Project

- 2D pixel-art action-platformer in **Unity 6 (C#)**. Animations are based on PixelFX.
- Seven elemental towers (Fire, Water, Earth, Wind, Arcane, Light, Dark) × 100 floors, then the Dark Tower. The hub is **Misthaven**. The protagonist is **Miralyth (Mira)**.

## Layout

- All project code and assets go in `Assets/_Project/` (Scripts, Art, Audio, Prefabs, Scenes, ScriptableObjects, Settings, Tests).
- Design docs go in `docs/`.
- Never edit `Library/`, `Temp/`, `Logs/` or `UserSettings/`. They are generated and git-ignored.

## Conventions

- C#: `PascalCase` for types and methods, `_camelCase` for private fields, `[SerializeField] private` rather than public fields.
- One `MonoBehaviour` per file, with the file name matching the class name.
- Use a namespace per area, e.g. `MageMania.Combat`, `MageMania.Spells`.
- Put tunable data in `ScriptableObject`s (spells, enemies, items) rather than hardcoding it.
- Avoid `Find*` calls and per-frame allocations. Cache references and use events for decoupling.
- Use the Input System package, not the legacy `Input` class.
- Never delete or hand-edit `.meta` files. Commit them with their assets.
- Don't hand-edit `.unity`, `.prefab` or `.asset` YAML unless necessary.

## Game rules (gameplay constants, keep in data/config)

- Mana capacity starts at 200 and gains +1 per cleared floor. There are no XP levels.
- Spell cost = spell level × 10 mana. Spell damage = base + linear scaling with mana capacity.
- Floor 1–19 spells are level 1, 20–39 level 2, and so on, up to level 5. Each normal floor has a 1/4 chance of a spell.
- Mini boss every 25 floors, with its tower's element. The floor 100 boss has multiple phases and a themed rift arena.
- Monster HP rises linearly per floor, then exponentially from floor 90. Monster damage gets +10% after each mini boss.
- Players can revisit lower cleared floors but can't skip ahead. Boss rooms lock the player in until the boss is cleared.
- Death voids the run: the tower resets and the player loses spells, gear and materials.
- Dark Tower: 7 mini bosses (3 on floor 99, 4 every 20 floors) give +0.5× player damage each. The final boss is The Source (3 phases).
- **Armageddon** (blood magic) secrets must never be hinted at in-game, UI or tutorial text.

## Workflow

- Make small, focused changes, and keep the project compiling.
- Run tests in `Assets/_Project/Tests` (EditMode and PlayMode) via the Unity Test Runner or `Unity -batchmode -runTests` when logic changes.
- Use clear commit messages. Don't commit large binaries outside Git LFS (see `.gitattributes`).
- Ask before adding third-party packages or making large architectural changes.
