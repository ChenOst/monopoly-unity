# monopoly-unity
Unity Version: 2020.1.12f1  
OS: Windows

<img src="screenshots/board.png" width=200> 

## Notes
### Players Turn :sunglasses:
 
The players turn consists of three main stages:
1. [Roll dice](Assets/Scripts/Dice/RollTheDice.cs) - Wait until rolled. :game_die:
2. [Move player](Assets/Scripts/Player/Mover.cs) - Move `n` steps accordingly. :feet:
    - :point_up:  Players can only move on the edges of the board - we wouldn't want the player objects passing through the middle of the board.  
    Therefore, if needed, the player object moves forward on the current edge before proceeding to the destination.
3. [Check location](Assets/Scripts/Player/CheckLocation.cs) - Check the type of the tile :moneybag:

The players `_playerStepStatus` field represents the step which the player is in.  
`0` - Represents Intermediate Mode, we do not want the `Update()` function to perform the same operation over and over again after
 it has been performed (for example, rolling the dice multiple times in the same turn);  
this value helps us prevent such situations.

In order to create a board game atmosphere, there is a cooldown between the steps.

### Reward tiles :gift:

The requirement of having randomly distributed rewards is somewhat reminiscent of the problem of finding the x-value given a percentile (glad I listened in probability course lol).  
The general approach to solving this problem is feeding random values from the 0-1 interval to the [quantile function](https://en.wikipedia.org/wiki/Quantile_function) of the desired distribution,
which is exactly the approach I used in [RewardTile](Assets/Scripts/Tiles/RewardTile.cs).

### Spawn Board :repeat:

The board is spawned automatically at the beginning of the game.  
This allows us some extra scalability in increasing the board size to `n X 4`. 

### Animation :high_brightness:

The animation exists as a friendly reminder that should encourage the player to roll the dice,  
and of course contributes to the board game environment.