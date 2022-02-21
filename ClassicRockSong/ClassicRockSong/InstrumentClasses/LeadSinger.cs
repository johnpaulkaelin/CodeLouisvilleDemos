using ClassicRockSong.Interfaces;

namespace ClassicRockSong.InstrumentClasses
{
    public class LeadSinger : IInstrument
    {
        public string Play()
        {
            return "Lead Singer: Singing";
        }
    }
}
