# Mage Mania

A 2D pixel-art action-platformer built in **Unity 6 (C#)**. You play as **Miralyth ("Mira")**, a prodigy mage with an affinity for all seven schools of magic, sent to climb seven ancient towers to find a way to defeat the Dark Tower. Animations are based on PixelFX.

## Story

Thousands of years ago seven Archmages ruled the Argent Imperium from seven 100-floor towers, each mastering one magic: Fire, Water, Earth, Wind, Arcane, Light and Dark. After the empire fell, abyssal corruption twisted the Empire of the Sun, and the mad Emperor Khashion purged the mages before the surviving seven toppled him in the Battle for the Dawn. The empire split into seven nations, each teaching its own magic. Now a Dark Tower has risen and its monsters are pouring out. Mira, sent by her mentor Aurelian, must clear the seven towers, and in doing so uncover the truth behind the monsters and the eighth, forgotten tower.

## Gameplay Overview

- **Genre:** Mostly open-world 2D (Noita / Terraria / Dead Cells / Hollow Knight style) with a main questline.
- **Towers:** 7 elemental towers × 100 floors, then the Dark Tower. Each floor is a dark, abandoned-tower platform level; reach the stairs to advance. You can revisit cleared floors but never skip ahead.
- **Bosses:** A mini boss every 25 floors (matching the tower's element) and a floor-100 boss in a themed rift realm (e.g. Kraken in a deep sea). Boss rooms lock you in until the fight ends.
- **Spells:** Normal floors have a 1/4 chance to hold a spell of the tower's element, with level rising every 20 floors (levels 1–5). Spell cost = level × 10 mana; damage scales linearly with mana capacity.
- **Progression:** No XP levels. Mana capacity starts at 200 and grows by 1 per cleared floor. Monster HP scales linearly, then exponentially after floor 90; monster damage gets +10% after each mini boss.
- **Death:** Dying voids the run: the tower resets and you lose found spells, gear and materials, respawning at Misthaven.
- **Crafting:** Boss drops (dragon bone, kraken's beak, etc.) are crafted into wands, staffs and artifacts. Hidden secrets lead to the ultimate staff, **Armageddon**, which unlocks blood magic. There are intentionally no hints.
- **Misthaven (hub):** A school with a spell-practice dummy area, crafting area, a secret basement, and an almanac of enemies and bosses. A starting item teleports you back.
- **Endgame:** The Dark Tower (7 mini bosses that each add +0.5× damage) ends with **The Source**, a three-phase boss, and a choice to continue its work or stop it.
- **UI:** Noita-style hotbar (top left) with 4 accessory slots, HP / mana / shield bars at bottom centre, and a mana-crystal tracker at top right.

The full design is in [`docs/Mage_Mania_Manuscript.pdf`](docs/Mage_Mania_Manuscript.pdf).

## Tech Stack

- Unity 6 (6000.x LTS), C#, 2D URP template
- Unity Input System, Tilemaps, Cinemachine
- PixelFX-based animations

## Getting Started

1. Install **Unity Hub** and a **Unity 6** editor.
2. Clone: `git clone https://github.com/09DylanXie/Mage-Mania.git`
3. In Unity Hub, create the project (**2D (URP)** template) in the repo folder, or open it if the `ProjectSettings/` folder exists.
4. Install [Git LFS](https://git-lfs.com/) (`git lfs install`) before committing art and audio.

## Project Structure

```
Assets/_Project/
  Scripts/      Player, Combat, Spells, Enemies, Bosses, Towers, UI, Hub, Core, Data
  Art/          Sprites, Animations, Tilemaps, VFX
  Audio/        Music, SFX
  Prefabs/  Scenes/  ScriptableObjects/  Settings/  Tests/
docs/           Design documents
AGENTS.md       Guidelines for AI coding agents
```

## Status

Early setup, with no gameplay yet.
