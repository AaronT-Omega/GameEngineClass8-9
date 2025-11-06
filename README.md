# GameEngineClass8 + 9





Very rough adaptation of Road Rage the game.



Turn Right and Left with the buttons on the top left to try and avoid the enemies. 

If you touch enemies you take damage. Run out and it's game over.

Added more details, mainly enemy collision and damage, as well as enemies spawning from an Object Pool.





What was implemented:

* Basic Turning
* Observer and Subject class
*  	HUD, and Client are supposed to observe the player for when they get hit and update health
*  	When low health, you get a warning stating low health 
* Simple States
*  	Right now there's only Turning, with the Start and Stop State not functioning
* Object Pool for Enemies
* &nbsp;	Enemies now spawn on 1 of 3 lanes. When they come in contact with you, they deal damage to you



Plans

* Add a Crash or Stop state when you run out of fuel
* Clean up old scripts that don't have much use
