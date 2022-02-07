using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvilleLibrary
{
    interface ICodeLouisvilleAppAdvanced
    {
        bool TryPrompt4Integer(out int value, string prompt = "", uint maxAttempts = 0, int minValue = int.MinValue, int maxValue = int.MaxValue);

        bool TryPromptYesNo(string prompt, out bool response, uint maxAttempts = 0, string yesResponse = "Y", string noResponse = "N");

        bool TryPrompt4MenuItem<T>(string prompt, List<KeyValuePair<T, string>> menu, out T menuSelection, uint maxAttempts = 0);
    }
}
