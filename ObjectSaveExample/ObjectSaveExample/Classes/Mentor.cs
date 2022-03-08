
using CodeLouisvilleLibrary.Serialization.Interfaces;

namespace ObjectSaveExample.Classes
{
    public class Mentor : IEntityWithID
    {
        // IEntityWithID.ID is required to use the EntitySerializationService
        public int ID { get; set; }

        public string Name { get; set; }

        public string Accent { get; set; }

        public int Rating { get; set; }

        public override string ToString()
        {
            return $"{Name} (Rating: {Rating})";
        }

    }
}
