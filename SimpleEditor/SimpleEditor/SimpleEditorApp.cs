using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleLibrary;

namespace SimpleEditor
{
    public class SimpleEditorApp : CodeLouisvilleAppBase
    {
        public SimpleEditorApp() : base("Simple Editor")
        {

        }

        protected override bool Play()
        {
            Console.Clear();

            Console.WriteLine("This is a simple text editor.  It will automatically 'wrap' after 15 chars\n");
            List<string> lines = new List<string>();
            ConsoleKeyInfo keyInfo;

            do
            {
                StringBuilder line = new StringBuilder();
                Console.Write("(ESC to exit): ");
                do
                {
                    keyInfo = Console.ReadKey();
                    if(keyInfo.Key != ConsoleKey.Escape)
                    {
                        line.Append(keyInfo.KeyChar);
                    }
                } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Enter && line.Length <= 15);
                lines.Add(line.ToString());
                Console.WriteLine();
            } while (keyInfo.Key != ConsoleKey.Escape);

            Console.WriteLine();
            Console.Write("The text you entered was: ");
            foreach(string line in lines)
            {
                Console.Write(line);
            }

            Console.WriteLine();

            return Prompt4YesNo("Do you want to create another file?");
        }
    }
}
