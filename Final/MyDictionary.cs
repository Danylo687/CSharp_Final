using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NLog;

namespace Dictionary
{
    [Serializable]
    public class MyDictionary
    {
        public string Name { get; set; }
        public List<Word> Words { get; set; }
        // NLog
        Logger logger = LogManager.GetCurrentClassLogger();

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

        public void LoadDataFromXml()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(MyDictionary));
            using (FileStream stream = new FileStream(@"en-ua.xml", FileMode.Open))
            {
                MyDictionary thisDictionary = (MyDictionary)deserializer.Deserialize(stream);
                Name = thisDictionary.Name;
                Words = thisDictionary.Words;
            }
        }
        public void SaveDataToXml()
        {
            XmlSerializer serializerName = new XmlSerializer(typeof(MyDictionary));
            using (FileStream stream = new FileStream(@"en-ua.xml", FileMode.Truncate))
            {
                MyDictionary thisDictionary = new MyDictionary(Name, Words);
                serializerName.Serialize(stream, thisDictionary);
            }

        }

        public int myFindIndex(string name)
        {
            for (int i = 0; i < Words.Count(); i++)
            {
                if (Words[i].Name == name) return i;
            }
            return -1;
        }
        public Word myFind(string name)
        {
            for (int i = 0; i < Words.Count(); i++)
            {
                if (Words[i].Name == name) return Words[i];
            }
            return null;
        }

        public override string ToString()
        {
            string str = "Dictionary: ";
            str += Name;
            str += "\nWords: \n\n";
            foreach (Word word in Words)
            {
                str += word.ToString();
                str += "\n";
            }

            return str;
        }
    }
}
