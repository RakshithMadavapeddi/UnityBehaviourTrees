Here is a brief summary of my implementation:

I have implemented the PATROL, CHASE, and ATTACK states using behavior trees, with conditions and sequences handling the transitions between these states.

I have set up the Animator Controller with appropriate animations and transitions, and created an NPCAnimatorController script to update the animator parameters based on the NPC state, visibility, and attack range.

To create multiple enemies with different characteristics, I have instantiated multiple instances of the NPC class with varying parameters such as patrol paths, speeds, field of view angles, and distances.

I have drawn the behavior tree I designed for this assignment, you can find it in the slides linked below (or) the PDF I attached.

The game over logic has been implemented in the PlayerHealth script, which handles the player's health and transitions to the Game Over scene when the player's health reaches 0.
