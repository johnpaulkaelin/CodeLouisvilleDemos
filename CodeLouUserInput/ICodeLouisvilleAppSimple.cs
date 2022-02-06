using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvilleLibrary
{
    public interface ICodeLouisvilleAppSimple
    {

        public int Prompt4Integer(string prompt);

        public bool PromptYesNo(string prompt);

        public string Prompt4MenuItem(string prompt, List<KeyValuePair<string, string>> menu);

    }
}
