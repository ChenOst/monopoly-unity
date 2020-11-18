# monopoly-unity

## Notes
### Players Turn :sunglasses:
 
The players turn is consists of three main stages:
1. [Roll the dice](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Dice/RollTheDice.cs) - Wait until the dice was rolled. :game_die:
2. [Move the player](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Player/Mover.cs) - Send the number of steps and move :paw_prints:
    - :point_up:  We do not want players to pass in the middle of the board.
Move to the edge if needed before go to the destination.
3. [Check location](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Player/CheckLocation.cs) - Check the type of the tile :moneybag:

The palyer has `_playerStepStatus` variable where 1-3 represent the steps.
`0` - represent intermediate mode, we do not want that Update function perform the same operation over and over again after
 it has been performed (Roll the dice over and over even if the player rolled this turj), so 0 help us to prevent those kind of situations.

### Reward tiles :gift:

The requirement of having randomly distributed rewards is somewhat reminiscent of the problem of finding the x-value given a percentile (glad I listened in probability courses lol).  
The general approach to solving this problem is feeding random values from the 0-1 interval to the [quantile function](https://en.wikipedia.org/wiki/Quantile_function) of the desired distribution,
which is exactly the approach I used in [RewardTile](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Tiles/RewardTile.cs).

### Spawn Board :repeat:

The baord is spwan automaticly in the beggining of the game.
allows us to create even bigger boards nX4. 
