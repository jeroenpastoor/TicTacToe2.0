# TicTacToe2.0
## By Jeroen Pastoor
This project, named Tic Tac Toe 2.0, is a look into several ways in which the simple game of Tic Tac Toe can be improved to be more interesting to the players. 

### Game Types
It currently implements four game types:
#### Classic Tic Tac Toe
Of course, the place to start is classic Tic Tac Toe the way we all know it:
Players take turns placing their symbols, X and O, on the 3x3 grid. The first player to line up three of their own symbol either horizontally, vertically or diagonally, is the winner.

#### Inverse Tic Tac Toe
This game is very much like the original game of Tic Tac Toe, however the win condition is reversed.
The goal here is to force your opponent to line up three of their own symbol.

#### Multi-board Tic Tac Toe
Here, there are nine boards laid out in a 3x3 grid similar to a smaller Tic Tac Toe board.
Player one starts their move in the middle board. After each turn, the next player makes their move in the board corresponding with the cell the previous player placed their symbol in.

For example: If player 1 starts the game by placing an X in the top-right corner of the middle board, player 2 will have to place their O on any of the available cells in the top right board.

#### Inverse Multi-board Tic Tac Toe
Essentially the same as Multi-bard Tic Tac Toe, but once again with the win condition reversed, with the goal being to force the opponent to line up three of their own symbol.

### Future Additions
Possible other game types I have come up with to add in the future would be:
- Single-symbol Tic Tac Toe
  - Here, players both use the same symbol, and try to make the finishing move. The win condition here could also be reversed and multi-board could be added here too.
- Extended Multi-Board Tic Tac Toe
  - For this, instead of ending the game when one player lines up three anywhere, the game ends when all boards are full. The winner is the player with the most wins.
  
### Extra
In addition to the above game types, the code is also set up in such a way that the grid size of the boards is variable.
This way, any of the above mentioned modes could be set up to play with a smaller or larger grid.
