using ClassicRockSong.Interfaces;

namespace ClassicRockSong.InstrumentClasses
{
    public class Drums : IInstrument
    {
        public string Play()
        {
            return "Drum: Beating";
        }
    }
}
