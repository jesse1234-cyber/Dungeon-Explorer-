public class Room
{
    private string description; // Encapsulation
    private string item; // Encapsulation

    // Contructor is used to represent a single room in the game with a a dscription and a possible item.
    public Room(string description, string item = "")
    {
        this.description = description;
        this.item = item;
    }

    public string GetDesccription()
    {
        return description;
    }

    public string GetItem()
    {
        return item;
    }


}
