using System.Collections.Generic;

namespace DungeonExplorer {
    public class Room {
        private string description;
        private List<string> items;
        private string roomName;

        public Room(string roomName, string description, List<string> items) {
            this.roomName = roomName;
            this.SetDescription(roomName);
            this.items = new List<string>();
        }
        public string GetRoomName() {
            return this.roomName;
        }

        public string GetDescription() {
            return this.description;
        }
        private void SetDescription(string description) {
            if (description != null) {
                this.description = description;
            }
        }

        private void AddItems(string roomName) {
            if (roomName == "Library") {
                this.items.Add("Spell Book");
                this.items.Add("Mysterious Potion");
                this.items.Add("Bone Key");
            }
        }

        private void RemoveItems(string item) {
            this.items.Remove(item);
        }
    }
}