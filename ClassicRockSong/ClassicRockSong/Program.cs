using ClassicRockSong.InstrumentClasses;
using ClassicRockSong.Interfaces;
using ClassicRockSong.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClassicRockSong
{
    class Program
    {
        // see WriteAtPosition and SongPart.Play
        internal static object lockObject = new object();

        static async Task Main(string[] args)
        {
            var band = new Dictionary<string, IInstrument>();

            band.Add("Drums", new Drums());
            band.Add("Guitar 1", new ElectricGuitar());
            band.Add("Guitar 2", new ElectricGuitar());
            band.Add("Lead Singer", new LeadSinger());
            band.Add("Backup Singer 1", new BackupSinger());
            band.Add("Backup Singer 2", new BackupSinger());
            band.Add("Sax", new Saxophone());
            band.Add("Piano", new Piano());
            band.Add("Bass", new Bass());

            Console.CursorVisible = false;

            // show music playing.  We don't await this because
            // we want to play the music while the characters
            // are being displayed on the screen
            // this will run in the background until we tell it to stop
            CancellationTokenSource cs = new CancellationTokenSource();
            ShowMusicPlaying(cs.Token);

            Console.SetCursorPosition(0, 5);

            // during intro, only drums and Guitar 1 play
            // we await here because we don't want to play the next
            // part of the song until the intro is finished
            var Intro = new SongPart("Intro", band, new string[] { "Drums", "Guitar 1" }, 30);
            await Intro.Play();

            Console.Clear(); 
            Console.SetCursorPosition(0, 5);

            // drums, Guitar 1, Guitar 2, Base, and Lead Singer play during the verse
            // we await here because we don't want to play the next
            // part of the song until the verse is finished
            var Verse = new SongPart("Verse", band, new string[] { "Drums", "Guitar 1", "Guitar 2", "Bass", "Lead Singer" }, 60);
            await Verse.Play();

            Console.Clear();
            Console.SetCursorPosition(0, 5);

            // the whole band plays the chorus
            // we await here because we don't want to play the next
            // part of the song until the chorus is finished
            var Chorus = new SongPart("Chorus", band, band.Keys.ToArray(), 45);
            await Chorus.Play();

            Console.Clear();
            Console.SetCursorPosition(0, 5);

            // now we do a sax solo
            // we await here because we don't want to play the next
            // part of the song until the sax solo is finished
            var SaxSolo = new SongPart("Sax Solo", band, new string[] { "Sax" }, 30);
            await SaxSolo.Play();

            Console.Clear();
            Console.SetCursorPosition(0, 5);

            // now play the exit
            // we await here because we don't want to stop
            // the animation and exit the program until the outro is complete
            var Outro = new SongPart("Outro", band, new string[] { "Drums", "Guitar 1", "Lead Singer", "Backup Singer 1", "Backup Singer 2" }, 15);
            await Outro.Play();

            // stop showing the music playing
            cs.Cancel();

        }

        static async Task ShowMusicPlaying(CancellationToken ct)
        {
            int priorLeft = 0;
            int left = 0;
            int noteCharIndex = 0;
            while(!ct.IsCancellationRequested)
            {
                WriteAtPosition(priorLeft, 0, ' ');

                char[] noteChars = new char[] { '@', '#', '%', '$', '^', '*' };
                WriteAtPosition(left, 0, noteChars[noteCharIndex]);

                priorLeft = left;
                left = ++left % Console.WindowWidth;
                noteCharIndex = ++noteCharIndex % noteChars.Length;

                await Task.Delay(200);
            }
        }

        static void WriteAtPosition(int left, int top, char c)
        {
            // we need to make sure that all of this executed at once.
            // this method has to have control of the console the whole
            // time it's executing.  Otherwise, ANOTHER TASK might do
            // a Console.Write BETWEEN when THIS METHOD 
            // does a Console.SetCursorPosition and a Console.Write
            lock(lockObject)
            {
                // rememeber the prior position
                int priorLeft = Console.CursorLeft;
                int priorTop = Console.CursorTop;

                Console.SetCursorPosition(left, top);
                Console.Write(c);

                // restore the prior position
                Console.SetCursorPosition(priorLeft, priorTop);
            }
        }
    }
}
