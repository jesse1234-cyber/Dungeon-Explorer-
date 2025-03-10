using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items = new List<string>();
        private readonly string roomName;

        public Room(string roomName, string description, List<string> items) {
            this.roomName = roomName;
            this.SetDescription(description);
            this.SetItems(items);
        }

        public string GetRoomName() {
            return this.roomName;
        }

        private void SetDescription(string description) {
            if (description != null) {
                this.description = description;
            }
        }

        public string GetDescription() {
            return this.description;
        }

        public void SetItems(List<string> items) {
            if (items != null && items.Count > 0) {
                items.ForEach(item => {
                    this.AddItem(item);
                });
            }
            else {
                this.items = new List<string>();
            }
        }

        public void AddItem(string item) {
            this.items.Add(item);
        }

        public void RemoveItem(string item) {
            this.items.Remove(item);
        }

        public bool DoItemsExist() {
            return items != null && items.Count > 0;
        }
    }
}