using ClassicRockSong.Interfaces;

namespace ClassicRockSong.InstrumentClasses
{
    public class Piano : IInstrument
    {
        public string Play()
        {
            return "Piano: Tickling the Ivories";
        }
    }
}
