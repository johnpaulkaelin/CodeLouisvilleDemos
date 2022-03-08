using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleLibrary;

namespace ObjectSaveExample.Classes
{
    public class SampleProject : CodeLouisvilleAppBase
    {
        private MentorRepository mentorRepo = new MentorRepository();

        public SampleProject() : base("Mentor Recommendation Program")
        {

        }

        protected override bool Main()
        {
            bool bContinue = true;

            Menu<int> mainMenu = new Menu<int>();
            mainMenu.AddMenuItem(1, "Recommend Mentor");
            mainMenu.AddMenuItem(2, "Quit");

            int userSelection = Prompt4MenuItem<int>("Please select an option ", mainMenu);

            switch(userSelection)
            {
                case 1:
                    Console.Clear();

                    IEnumerable<Mentor> mentors = mentorRepo.GetAllAsync().Result;

                    Menu<char> mentorMenu = new Menu<char>();
                    mentorMenu.AddMenuItem('A', "Recommend a good mentor with a cool, Russian accent ");
                    mentorMenu.AddMenuItem('L', "Recommend a good mentor without a Russian accent ");
                    mentorMenu.AddMenuItem('J', "Recommend a bad mentor");

                    char mentorMenuSelection = Prompt4MenuItem<char>("Please select an option ", mentorMenu);

                    switch(mentorMenuSelection)
                    {
                        case 'A':
                            var aMentor = mentors.FirstOrDefault(m => m.Accent == "Russian" && m.Rating >= 75);
                            if (aMentor != null)
                                Console.WriteLine($"We recommend {aMentor}");
                            else
                                Console.WriteLine("Sorry we have no good mentors with Russian accents at this time");
                            break;
                        case 'L':
                            var lMentor = mentors.FirstOrDefault(m => m.Accent == "" && m.Rating >= 75);
                            if (lMentor != null)
                                Console.WriteLine($"We recommend {lMentor}");
                            else
                                Console.WriteLine("Sorry we have no good mentors with no accents at this time");
                            break;
                        case 'J':
                            var jMentor = mentors.FirstOrDefault(m => m.Rating < 75);
                            if (jMentor != null)
                                Console.WriteLine($"We do NOT recommend {jMentor} but you did ask for a bad one.");
                            else
                                Console.WriteLine("Sorry we don't have any bad mentors at this time");
                            break;
                        default:
                            var dMentor = mentors.FirstOrDefault(m => m.Rating < 0);
                            if (dMentor != null)
                                Console.WriteLine($"Since you didn't pick a valid option we are going to recommend the worst: {dMentor}.");
                            else
                                Console.WriteLine("We can't make a recommendation because you picked an invalid selection.");
                            break;
                    }

                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 2:
                    bContinue = false;
                    break;
                default:
                    Console.Write("Invalid Selection. Press any key to try again: ");
                    Console.ReadKey();
                    Console.Clear();
                    break;     
            }

            return bContinue;
        }
    }
}
