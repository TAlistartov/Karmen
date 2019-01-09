﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class KindOfBlockModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdditionalInformation { get; set; }
        public string CrossReference { get; set; }

        public List<SelectListItem> AllKindsOfBlockFromDb { get; set; }
        public string SelectedKindOfBlock { get; set; }
    }
}