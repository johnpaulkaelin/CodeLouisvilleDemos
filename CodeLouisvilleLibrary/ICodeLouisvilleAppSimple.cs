using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvilleLibrary
{
    public interface ICodeLouisvilleAppSimple
    {

        int Prompt4Integer(string prompt);

        bool PromptYesNo(string prompt);

        string Prompt4MenuItem(string prompt, List<KeyValuePair<string, string>> menu);

    }
}
