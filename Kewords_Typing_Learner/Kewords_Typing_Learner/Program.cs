﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kewords_Typing_Learner
{
   

    internal class Program
    {
        static void Main(string[] args)
        {
            App main = new App();
            main.ReadFileFromPath();
            main.WriteWordsToFile();
        }
    }
}
