using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class MyDictionary
    {
        public string Name { get; set; }
        List<Word> Words { get; set; } = new List<Word>();

        public MyDictionary() 
        {
            Name = "Not set";
            Words = new List<Word>();
        }
        public MyDictionary(string name) { Name = name; Words = new List<Word>(); }
        public MyDictionary(List<Word> words) { Words = words; }
        public MyDictionary(string name, List<Word> words)
        {
            Name = name;
            Words = words;
        }


    }
}
