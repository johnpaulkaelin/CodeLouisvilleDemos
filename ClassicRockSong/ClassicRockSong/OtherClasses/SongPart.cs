using ClassicRockSong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicRockSong.OtherClasses
{
    public class SongPart
    {
        private string Name;
        private List<IInstrument> Instruments = new List<IInstrument>();
        private int Duration;

        public SongPart(string name, Dictionary<string, IInstrument> band, string[] instrumentNameList, int duration)
        {
            Name = name;
            foreach(string instrumentName in instrumentNameList)
            {
                if (!band.ContainsKey(instrumentName)) throw new ArgumentException($"There is no instrument, {instrumentName}, in the band.");

                Instruments.Add(band[instrumentName]);
            }
            Duration = duration;
        }

        public async Task Play()
        {
            string header = $"Playing the {Name} ({Duration} seconds)";

            // this method needs control of the console until it is finished.
            // we don't want another task changing the position of the cursor
            // until this task is done writing to the console.  That's the reason
            // for the lock
            lock (Program.lockObject)
            {
                Console.WriteLine(header);
                Console.WriteLine("".PadLeft(header.Length, '_'));
                Console.WriteLine();

                foreach (IInstrument instrument in Instruments)
                {
                    Console.WriteLine($"\t{instrument.Play()}");
                }
            }

            await Task.Delay(Duration * 1000);
        }
    }
}
