# Dragon Fight — Junior Unity Developer Technical Assessment

## Overview

A small 2.5D top-down dragon battle prototype created for the Dexhigh Services Pvt Ltd Junior Unity Developer technical assessment.

The prototype focuses on the core gameplay loop: player movement, target-based combat, AI combat, health, health bars, ability UI, and a simple battle arena.

This submission represents the current prototype state. Some features from the assessment brief were not completed within the available development time and are listed below.

---

## Unity Version

- **Unity:** 6.6.0f1
- **Target Platform:** Windows

---

## Controls

### Movement
- **W / A / S / D** — Move the player dragon
- **Arrow Keys** — Alternative movement controls

### Abilities
- **1 / Z** — Basic attack
- **2 / X** — Fire attack
- **3** — Third ability slot (not implemented in this version)

---

## Implemented Features

The submitted prototype currently includes:

- 2.5D angled top-down battle arena
- Player-controlled dragon
- AI-controlled dragon
- Player movement
- Dragon targeting
- Basic melee attack
- Ranged fire attack
- AI combat
- Health and damage system
- Health bars for both dragons
- Ability UI with cooldown display for implemented abilities
- Dragon animation integration
- Arena boundaries
- Basic lighting and shadows
- Battle manager / death handling foundation

The AI is able to engage the player and use the implemented combat functionality.

---

## Current Limitations

The following requested features were **not completed in the submitted version**:

- Fly attack / third ability
- Particle effects for attacks
- Dedicated hit impact effects
- Damage number / hit-feedback effects
- Attack and hit sound effects
- Final combat VFX and audio polish
- Some animation and combat transitions could be refined further
- Final winner-screen/restart presentation is not fully polished
- Overall visual polish and combat feel are still at prototype level

These limitations are stated explicitly so that the submitted build reflects the actual state of the project.

---

## Project Structure

The gameplay code is separated into focused components:

- `DragonController` — coordinates dragon behaviour
- `PlayerDragonInput` — reads player input
- `DragonMovement` — handles movement and rotation
- `DragonTargeting` — manages the current target
- `DragonCombat` — handles attacks and cooldowns
- `DragonHealth` — manages health and death
- `DragonAnimator` — handles animation calls
- `DragonHealthBarUI` — displays health
- `BattleGameManager` — manages battle setup and death/win flow

The project uses separate components for movement, combat, targeting, health, input, and UI rather than putting all gameplay logic into a single script.

---

## Assets

Dragon models, animations, and environment assets were obtained from the **Unity Asset Store**.

Source:
- Unity Asset Store: https://assetstore.unity.com/

Specific package names and package links can be added here if required by the evaluator.

No paid or ripped assets were intentionally used for this assessment.

---

# AI Usage Note

## AI Tool Used

**ChatGPT**

## What AI Was Used For

ChatGPT was used as a development assistant for:

- Discussing Unity gameplay architecture
- Reviewing C# scripts
- Debugging implementation issues
- Planning script responsibilities
- Helping with health-bar and ability cooldown UI
- Identifying possible causes of combat bugs
- Reviewing and simplifying implementation approaches

AI was used as an assistant rather than as a replacement for understanding the submitted project.

## Example of an AI Mistake

During development, an initial health-bar UI approach used the dragon's raw health value with a normalized UI Slider.

For example, if the dragon had 75 HP, assigning `75` directly to a slider expected to operate from `0` to `1` caused the slider to remain visually full until health reached zero.

The issue was identified during testing. The implementation was then changed so the Slider uses the dragon's actual maximum health as its maximum value and the current health as its value.

This demonstrated the need to test AI-generated suggestions against the actual Unity implementation rather than accepting them without verification.

## How AI Helped

AI reduced the time required to investigate implementation approaches and debug individual problems. It was particularly useful for discussing architecture, reviewing code, and identifying implementation mistakes.

The final decisions, Unity Inspector setup, integration, testing, and project configuration were performed within the Unity project.

---

## Submission Status

This is the current state of the prototype at the time of submission.

The project prioritizes the working gameplay foundation and core systems over additional visual and audio polish. The incomplete features listed above are intentionally disclosed rather than presented as implemented.

