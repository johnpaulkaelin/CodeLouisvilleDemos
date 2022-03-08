using CodeLouisvilleLibrary.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace ObjectSaveExample.Classes
{
    public class MentorRepository : EntitySerializationService<Mentor>
    {
        // Mentors.json is the name of the file that contains the list of Mentors
        public MentorRepository() : base("Mentors.json")
        {
            Initialize();
        }

        private void Initialize()
        {
            // if the mentors File doesn't exist yet then we need to create it
            // and populate it with Mentors
            if (!File.Exists(this.FileName))
            {
                Mentor andrei = this.SaveAsync(new Mentor() { Name = "Andrea Surzhan", Accent = "Russian", Rating = 100 }).Result;
                Mentor logan =  this.SaveAsync(new Mentor() { Name = "Logan Wells", Accent = "", Rating = 100 }).Result;
                Mentor john = this.SaveAsync(new Mentor() { Name = "John Kaelin", Accent = "", Rating = -999 }).Result;
            }
        }
    }
}
