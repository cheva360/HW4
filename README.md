# HW4
## Devlog

The Bird class demonstrates the Model-View-Control pattern by acting as the controller of the project that processes player input (space presses) and game logic, and delegating event notifications to the GameController Singleton. The singleton notifies the events to the AudioSystem and TextSystem classes (view layer) via subscription to said events. This decoupling logic ensures that Bird remains  of UI and audio implementations by routing the events through the gamecontroller. 

For example when the player scores, Bird calls GameController.Instance.OnScoreChanged(score) rather than directly updating the score text or playing audio, allowing TextSystem and AudioSystem to respond to the same event without Bird knowing they exist.




## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites