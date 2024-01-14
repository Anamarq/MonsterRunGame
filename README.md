# MonsterRunGame
Dynamic Monster run game

The game is a "Monster run game" structured in rounds. In each round, the number of monsters generated is determined by the Fibonacci sequence, where each number in the sequence represents the number of monsters to be generated in that round. 
The Fibonacci sequence is a mathematical series where each number is the sum of the two preceding ones ( 0, 1, 1, 2, 3, 5, 8, ...).

round 1 -> 1 monster
round 2 -> 1 monster
round 3 -> 2 monsters
round 4 -> 3 monsters
round 5 -> 5 monsters
round 6 -> 8 monsters
round 7 -> 13 monsters
...

The generated monsters have randomized speeds, but all move in the same direction. Once all monsters have left the screen, the round ends, and there is a brief interval before the next round begins.

Each monster is programmed to self-destruct one second after moving out of the screen boundaries, and I use pooling techniques to manage monster creation and destruction processes.

The UI includes the display of the total number of monsters created, the number of the round and a timer that shows the elapsed time since the round started.

The game is designed to be responsive, adapting appropriately to different screen sizes.

I use Unity Test Framework to add Unit tests.
