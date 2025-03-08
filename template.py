# Create three functions replicating "Game, Program and Player as a (semi?) representation of a class would work for these"

# Potentially learn how instances of a class are to work/see the example code for first week of how it runs

def Program(startGame): # Calls the function of game
    # Also prints the main menu for the game, allows user to exit/start#
    startGame = input("Wlecome to the game ")
    if startGame == True:
        Game()

def Game():
    pass
    # Game logic here, and would end, but also *could be* called again with a prompt to call back "Program.". Now figure this out within
    # classes + objects from the tutorial

# Player is a class, and would be an object 

#Try except; entering commands/catching errors if player doesn't properly enter the correct command

# Item ideas; torch, exit key, knife (if need to defend themselves from a fight. Remember; simple text base; can defend yourself) 
# 
# (max four items? key should always be availble in one room)

# How will ItemPicker work? Will it be a part of the Room class via polymorphism?

#(ItemPicker as its own class)

            # private List<string> potentialItems = new List<string> {"sample object 1", "sample 2", "sample 3", "sample 4"};
            # private Random r = new Random();
            # int totalItems = potentialItems.Count;
            # int randomInt = r.Next(0, totalItems);