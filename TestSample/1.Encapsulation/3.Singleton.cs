﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Singleton
    {
        private static Singleton instance;
        private Singleton() { }

        public static Singleton GetInstance()
        {
            return instance ??= new Singleton();
        }
    }

}
