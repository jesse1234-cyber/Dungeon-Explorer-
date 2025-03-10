class Room:
    def __init__(self, description, item=None):
        self.__description = description
        self.__item = item  # Item available in the room

    def get_description(self):
        """Returns the room's description."""
        return self.__description

    def get_item(self):
        """Returns the item in the room (if any)."""
        return self.__item

    def remove_item(self):
        """Removes the item from the room."""
        self.__item = None