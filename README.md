# Coffee Rush

### Unity link: https://play.unity.com/en/games/d02b9db8-9f05-423e-82b7-3154692e0a97/coffee-rush

## Game Description (2-3 paragraphs):
### What is your game’s objective?
In coffee rush the objective is to collect power ups and avoid obstacles until the player wins or loses. In the game, players have a health of 100 at the beginning of the game and are able to move around while collecting coffee bean powerups to gain points for a short period of time. When the player runs into the tea (which is bad because we are making coffee not tea) within the game they lose health every time one collision happens. Try and keep all your health and get your score to 100 for the whole duration of the game!

### How do players win or lose?
To win my game, players need to keep their health to 100  and get their score to 100 before they lose all their health or the timer runs out. In order to lose my game players need to run into the tea five or more times because their health will run out. Avoid these! The player can also lose by the 60 second timer and when it runs out the game is over.
### What makes your game engaging or fun?
I attempted to make it fun and engaging by including power ups such as coffee beans to give players more points for a short period of time. Including the platforms and respawning of the game objects allows for players to move around the game area which makes it engaging for players.

## Technical Implementation (1-2 paragraphs per requirement):
### Describe each game object and its behavior
Player - For this game object this is the main player that when people want to play this game they are moving around and jumping from this player. The behavior of this game object consists of moving up by either pressing the up arrow key or the W key. The player can also move left and right by the right and left arrows and the A and D keys on the keyboard. This game object has collider and rigidbody components to be able to jump off the floor and the platforms. When the player hits a tea (which decreases health) there is a sound effect of explosion because this signals that you need to avoid the tea. There is also a particle effect when the player hits a tea and a different one when the player hits the coffee beans.

Boundary - The boundaries are in place to keep the player and the platforms in the game section which creates a cohesive layout. Its behavior is to prevent the player and platforms from leaving the game by a box collider to those boundaries.

Platform - The platforms are in place to create a fun aspect to the game and allow the player to jump from platform to platform to get the coffee beans. Its behavior is to move back and forth between the boundaries by having a box collier and a rigidbody to allow the platforms go from right to left and allow the player to jump from platform to platform.

Tea - The tea prefabs are to decrease the health of the player when the player runs into them with circle colliders and a tea script. Also I added a tea effect and explosion sound effects when the player runs into them to add to the player engagement.

Coffee beans - The coffee beans prefabs are to increase the score of the player when the player runs into them with circle colliders and a coffee beans script. Also I added a bean effect when the player runs into them to add to the player engagement.

Audio source - I added audio for the game so as you are playing there is a sound playing and looping the entire time. Also I added an explosion sound effect when the player hits the tea as a warning and bad sound. 

### Explain how you implemented each technical requirement
Player - I implemented the player by adding a circle collider and a rigidbody so when the player runs into either coffee beans or tea there can be an effect. The rigidbody is used to allow the player to move around and jump on the platforms by using physics and freezing the position.

Boundary - I implemented the boundaries by adding four rectangles and adding box colliders to those rectangles and positioning them in the game frame. This prevents the player and the platforms from going off the game and staying within the set size of the game aspect.

Platform - I implemented the platforms by adding box colliders, rigidbodies and tags to have them go from right to left seamlessly. For this element I made the speed 2 and made the rotation freeze in order to keep the platforms in the same position when the player jumps on the different platforms.

Tea - I implemented the tea prefabs by adding circle colliders, particle effect and a sound effect for when the player hits the tea a sound plays, particle flares and explosion sound. Also within the tea I added a health manager script because if the player runs into the tea it takes 20 off of the health and when the health is 0 the player loses. This was implemented into the tea game objects and affects the game because when the player runs into a tea the health decreases.

Coffee beans - I implemented the coffee bean prefabs by adding circle colliders and particle effects the particle flares when the player runs into the coffee beans. Also within the coffee beans I added a score manager script because if the player runs into the coffee beans it increases the score by 10 and when the score is 100 the player wins. This was implemented into the coffee beans game objects and affects the game because when the player runs into a coffee bean the score increases.

Audio source - I implemented this by including an audio source file to the game and then importing the music track for the game. I made the audio a loop to continuously play throughout the game and reduced the volume to 0.3.

### Include specific examples from your game
Player - The player is a coffee cup that can jump up and fall back down and go left and right.

Boundary - The boundaries are on the bottom, top, left and right of the game aspect to prevent the player and platforms from leaving the set game aspects.

Platform - There are three platforms that go right to left on the screen at a set speed to improve game engagement.

Tea - There are five tea prefabs and once the player goes over them there is an explosion sound and they disappear and then reappear in 10 seconds. 

Coffee beans - There are five coffee bean prefabs and once the player goes over them they disappear and then reappear in 10 seconds.

## Future Development Plan (2-3 paragraphs):
### How would you extend the game with additional levels?
I would extend coffee rush with additional levels and increase the difficulty with each level which allows players to be excited to continue playing. In these additional levels I would implement a different background appeal so the player looks forward to new levels and a different scene. Also, I would increase difficulty by faster game obstacle spawning and different kinds of power ups and obstacles.

### What new game objects or mechanics would you add?
For future development of coffee rush I would add different power ups with different qualities to them for variety within the game. One specific one I have in mind would be a power up that adds health back to the player and an obstacle that would take more health away from the player.

### How would you expand the story or theme?
In order to expand the story and theme I would create different types of drinks for example, latte, matcha, tea, etc. and in the game you would need to get certain power ups to build that specific drink. The drink would be random based on the certain level the player is on or the player could decide a theme themselves. So I could either do random drinks for players or the player picks a theme based on what they prefer.

## Development Reflection (1-2 paragraphs):
### What was the most challenging aspect of this project?
For this game the most challenging aspect of this project is integrating all of the specific elements to create a cohesive game. For the platforms, it was difficult to get them to move right to left without leaving the screen or sticking to one of the boundaries or having any other troubles. Also with the platforms at first the player wasn’t able to jump from platform to platform which meant I had to allow the player to be grounded to the platforms as well as the floor by adding a tag to them. On top of that, I struggled with the UI element and adding in the score and health and having the powerups and obstacles affect those elements with the scripts.

### What did you learn about Unity or game development?
Something important I learned about Unity and game development is that there are a lot of aspects to every little part of the game. This type of development is very detail oriented with everything including the little things within other elements. I also learned it is very time consuming in the aspect that it takes awhile to develop but also it takes awhile to learn all those little things elements.

### What would you do differently next time?
Something I would do differently next time is to break down what exactly I want my game to look like before starting. This would benefit me because then I would have a clear understanding of what I am looking to accomplish and have the steps and tools to do the best of my ability. Another thing I would do differently is to understand my ability and knowledge and when I come across something I’m not too familiar with and I would like to seek guidance sooner.
