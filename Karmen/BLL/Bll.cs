﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Bll
    {
        Dal dal = new Dal();
        public void test ()
        {
            dal.SaveNewColour();
        }
    }
}
