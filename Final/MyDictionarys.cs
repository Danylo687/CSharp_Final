using Dictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Final
{
    [Serializable]
    public class MyDictionarys
    {
        public List<MyDictionary> Dictionarys { get; set; } = new List<MyDictionary>();
        Logger logger = LogManager.GetCurrentClassLogger();

        public MyDictionarys() { Dictionarys = new List<MyDictionary>(); }
        public MyDictionarys(List<MyDictionary> dictionarys)
        {
            Dictionarys = dictionarys;
        }
        public MyDictionarys(MyDictionary dictionary)
        {
            Dictionarys.Add(dictionary);
        }
        // ------------------------------------------

        public void AddWord()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;

            // ----------------------------------------------
            Console.Clear();
            if (selectedDictionary != -1)
            {
                Word addedWord = new Word();
                Console.Write("Enter word: ");
                addedWord.Name = Console.ReadLine();
                List<string> translations = new List<string>();
                Console.Write("Enter the number of word translations: ");
                int countOfTranslations = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < countOfTranslations; i++)
                {
                    int j = i + 1;
                    Console.Write($"Enter {j} translation: ");
                    addedWord.Interpretations.Add(Console.ReadLine());
                }

                Dictionarys[selectedDictionary].Words.Add(addedWord);


                Console.Clear();
            }
        }
        public void AddTranslation()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;

            // ------------------------------------
            bool added = false, isCorrect = true;
            do
            {
                Console.Clear();
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        Console.Write("Enter translation: ");
                        Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)).Interpretations.Add(Console.ReadLine());
                        isCorrect = true;
                        added = true;
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            } while (!added);

        }

        // ---------------------------------------------------------------------------------------------------------------------------
        public void ChangeWord()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();

            // -----------------------------------
            bool added = false, isCorrect = true;
            while (!added && selectedDictionary != -1)
            {
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        Word newWord = new Word();

                        Console.Write("Enter word: ");
                        newWord.Name = Console.ReadLine();
                        List<string> translations = new List<string>();
                        Console.Write("Enter the number of word translations: ");
                        int countOfTranslations = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < countOfTranslations; i++)
                        {
                            int j = i + 1;
                            Console.Write($"Enter {j} translation: ");
                            newWord.Interpretations.Add(Console.ReadLine());
                        }

                        Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)] = newWord;

                        isCorrect = true;
                        added = true;
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            }

        }
        public void ChangeTranslation()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;

            // ------------------------------------
            bool added = false, isCorrect = true;
            do
            {
                Console.Clear();
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        // =======
                        do {
                            Console.Clear();
                            if (!isCorrect) Console.WriteLine("Incorrect translation!!!");

                            Console.Write("Enter translation: ");
                            string searchTranslation = Console.ReadLine();

                            if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)).Interpretations.Find(x => x == searchTranslation) != null)
                            {
                                Console.Write("Enter translation: ");

                                Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)].Interpretations[
                                    Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)].myFindIndex(searchTranslation)] = Console.ReadLine();


                                isCorrect = true;
                                added = true;
                            }
                            else isCorrect = false;
                        } while(!isCorrect);

                        Console.Clear();
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            } while (!added);

        }
        
        // ---------------------------------------------------------------------------------------------------------------------------
        public void DeleteWord()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            // -----------------------------------

            bool added = false, isCorrect = true;
            while (!added && selectedDictionary != -1)
            {
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        Dictionarys[selectedDictionary].Words.Remove(Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)));

                        isCorrect = true;
                        added = true;
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            }

        }
        public void DeleteTranslation()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            // -----------------------------------

            bool added = false, isCorrect = true;
            do
            {
                Console.Clear();
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        isCorrect = true;
                        // =======
                        do
                        {
                            Console.Clear();
                            if (!isCorrect) Console.WriteLine("Incorrect translation!!!");

                            Console.Write("Enter translation: ");
                            string searchTranslation = Console.ReadLine();

                            if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)).Interpretations.Find(x => x == searchTranslation) != null)
                            {
                                if (Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)].Interpretations.Count > 1)
                                {
                                    Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)].Interpretations.Remove(searchTranslation);
                                }
                                else
                                {
                                    Console.WriteLine("This word has only one translation, you cannot delete this translation");
                                    Console.ReadKey();
                                }


                                isCorrect = true;
                                added = true;
                            }
                            else isCorrect = false;
                        } while (!isCorrect);

                        Console.Clear();
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            } while (!added);

        }

        // ---------------------------------------------------------------------------------------------------------------------------
        public void FindTranslation()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            // -----------------------------------

            bool added = false, isCorrect = true;
            while (!added && selectedDictionary != -1)
            {
                if (!isCorrect) Console.WriteLine("Incorrect word!!!");
                if (selectedDictionary != -1)
                {
                    Console.Write("Enter word: ");
                    string searchWord = Console.ReadLine();

                    if (Dictionarys[selectedDictionary].Words.Find(x => (x.Name == searchWord)) != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine(Dictionarys[selectedDictionary].Words[Dictionarys[selectedDictionary].myFindIndex(searchWord)]);
                        Console.ReadKey();

                        isCorrect = true;
                        added = true;
                    }
                    else isCorrect = false;

                    Console.Clear();
                }
            }
        }
        
        // ---------------------------------------------------------------------------------------------------------------------------
        public void SortDictionary()
        {
            Console.Clear();
            Console.WriteLine("Choose dictionary");
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < Dictionarys.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine($"{j} - {Dictionarys[i].Name}");
            }
            Console.WriteLine("0 - Back");
            Console.WriteLine(new string('-', 30));

            Console.Write("Enter choice: ");
            int selectedDictionary = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            // -----------------------------------

            if (selectedDictionary != -1)
            {
                //Console.WriteLine(Dictionarys[selectedDictionary]);
                Dictionarys[selectedDictionary].Words.Sort((x, y) => x.Name.CompareTo(y.Name));
                //Console.WriteLine(new string('-', 50));
                logger.Info("Sort");
                Console.WriteLine(Dictionarys[selectedDictionary]);
                Console.ReadKey();
                Console.Clear();
            }

        }


        // --------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            string str = "";

            foreach (var dictionary in Dictionarys)
            {
                str += dictionary.ToString();
                str += new string('-', 50);
                str += "\n\n";
            }

            return str;
        }
    }
}
