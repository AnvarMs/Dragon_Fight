DRAGON FIGHT QUICK SETUP

DRAGON PREFAB
Add:
- DragonController
- DragonMovement
- DragonCombat
- DragonHealth
- DragonTargeting
- DragonAnimator
- Animator
- Collider
- PlayerDragonInput ONLY on player
- DragonAI ONLY on AI

STATS
Create:
Project > Create > Dragon Fight > Dragon Stats
Assign the stats asset to Movement, Combat, Health and AI.

ANIMATOR PARAMETERS
DragonAnimator expects:
Float: Speed
Trigger: BasicAttack
Trigger: FireAttack
Trigger: GetHit
Trigger: Die

If the imported controller uses different parameter names, change DragonAnimator.cs.

PLAYER CONTROLS
WASD / Arrow Keys = move
Space or J = basic attack
K or E = fire attack

AI
Add DragonAI to AI dragon.
Do not add PlayerDragonInput.

BATTLE MANAGER
Create an empty GameObject named BattleGameManager.
Add BattleGameManager.cs.
Assign both dragons and optional spawn transforms.

COMBAT
Damage is applied immediately when an attack is triggered.
For the MVP this keeps the system simple.
Later, Animation Events can apply damage on the exact hit frame.
