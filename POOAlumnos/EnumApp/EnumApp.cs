﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOAlumnos.EnumApp
{
    public static class EnumApp
    {
        public enum OpcMenType
        {
            Exit = 0,
            Create = 1,
            Config = 2,
            Cont = 3
        };

        public enum OpcTypeFile
        {
            Txt = 1,
            Json = 2,
            Xml = 3
        }
    }
}
