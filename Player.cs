class Player:
    def __init__(self, name):
        self.name = name
        self.__inventory = []  # Private attribute
        self.health = 100  # Example health attribute

    def pick_up_item(self, item):
        """Adds an item to the player's inventory."""
        self.__inventory.append(item)
        print(f"{self.name} picked up {item}!")

    def show_inventory(self):
        """Displays the player's inventory and health."""
        if self.__inventory:
            print(f"{self.name}'s Inventory: {', '.join(self.__inventory)}")
        else:
            print(f"{self.name} has an empty inventory.")
        print(f"Health: {self.health}")  # Display health