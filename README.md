# monopoly-unity

## Notes
### Players Turn :sunglasses:
 
The players turn is consists of three main stages:
1. [Roll the dice](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Dice/RollTheDice.cs) - Wait until the dice was rolled. :game_die:
2. [Move the player](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Player/Mover.cs) - Send the number of steps and move :feet:
    - :point_up:  We do not want players to pass in the middle of the board.
Move to the edge if needed before go to the destination.
3. [Check location](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Player/CheckLocation.cs) - check the type of the tile :moneybag:

### Reward tiles :gift:

The requirement of having randomly distributed rewards is somewhat reminiscent of the problem of finding the x-value given a percentile.(glad I listened in probability courses lol).  
The general approach to solving this problem is feeding random values from the 0-1 interval to the [quantile function](https://en.wikipedia.org/wiki/Quantile_function) of the desired distribution,
which is exactly the approach I used in [`RewardTile`](https://github.com/ChenOst/monopoly-unity/blob/main/Assets/Scripts/Tiles/RewardTile.cs).

### Spawn Board :repeat:

The baord is spwan automaticly in the beggining of the game.
allows us to create even biggers board then. 
