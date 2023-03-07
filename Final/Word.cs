﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Word
    {
        public string Name { get; set; }
        public List<string> Interpretations { get; set; } = new List<string>();

        public Word() 
        {
            Name = "Not set";
            Interpretations = new List<string>();
        }
        public Word(string name) { Name = name; }
        public Word(List<string> interpretations) { Interpretations = interpretations; }
        public Word(string name, List<string> interpretations)
        {
            Name = name;
            Interpretations = interpretations;
        }


        public override string ToString()
        {
            string str = "Name: ";

            str += Name;
            str += "\nInterpretations: ";
            for (int i = 0; i < Interpretations.Count; i++)
            {
                if (Interpretations[i].Count() != 1 && i < Interpretations.Count() - 1)
                {
                    str += Interpretations[i];
                    str += ", ";
                }
                else
                    str += Interpretations[i];
            }
            str += "\n";

            return str;
        }
    }
}
