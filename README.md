# ShieldAndAnimation-3D

3D game - added an amination that moves while shooting and a shield to protect the player who takes it from getting hit.

**Adiitions:**

1. Grab the shield before the other player does, there will be a force field around the player who took it and he will be protected from shooting.

2. Try to shoot and see the shooting animation.

<br/>

## Instructions:

Move with your MOUSE and W, A, S, D keys.

Shoot with the LEFT MOUSE BUTTON or LCTRL.
<br/>

## Components

Scene Path: **[Assets/Scenes/connecting/Launcher.unity](Assets/Scenes/connecting/Launcher.unity)**

### Changes (See details in the code's comments):

**[PlayerManager](Assets/scripts/Player/PlayerManager.cs) -** Added code to handle the shield and force field.

**[GameManager](Assets/scripts/Player/GameManager/GameManager.cs) -** Added code to instantiate a shield in the world on a random location.

### New Scripts:

**[ShieldPosition](Assets/scripts/ShieldPosition.cs) -** Used on a shield to make it float and rotate.

<br />

## External Links
https://littlegamers2021.itch.io/shield-animation-3d
<br/>

Enjoy the game :)
