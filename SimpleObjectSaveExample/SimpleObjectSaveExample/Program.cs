using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeLouisvilleLibrary.Serialization;
using System.IO;

namespace SimpleObjectSaveExample
{
    class Program
    {
        private const string C_MENTORFILENAME = "Mentors.json";
        private static EntitySerializationService<Mentor> mentorRepo = new EntitySerializationService<Mentor>(C_MENTORFILENAME);

        static async Task Main(string[] args)
        {
            await CreateMentors();

            IEnumerable<Mentor> mentors = await mentorRepo.GetAllAsync();
            foreach (Mentor mentor in mentors)
                Console.WriteLine(mentor);
        }

        static async Task CreateMentors()
        {
            if (File.Exists(C_MENTORFILENAME))
                File.Delete(C_MENTORFILENAME);

            Mentor andrei = new Mentor();
            andrei.Name = "Andrei Surzhan";
            andrei.Accent = "Russian";
            andrei.Rating = 100;

            await mentorRepo.SaveAsync(andrei);

            Mentor logan = new Mentor();
            logan.Name = "Logan Wells";
            logan.Accent = "";
            logan.Rating = 100;

            await mentorRepo.SaveAsync(logan);

            Mentor john = new Mentor();
            john.Name = "John Kaelin";
            john.Accent = "";
            john.Rating = -999;

            await mentorRepo.SaveAsync(john);
        }
    }
}
