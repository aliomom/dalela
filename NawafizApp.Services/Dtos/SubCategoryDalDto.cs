﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class SubCategoryDalDto
    {
        public int Id { set; get; }
        public int? num { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public byte[] icon { set; get; }
        public byte[] iconEn { set; get; }
        public byte[] iconFr { set; get; }
        public byte[] iconPersian { set; get; }
        public byte[] iconRuss { set; get; }
        public int MainCategoryDalId { set; get; }
        public string MainCategoryDalName { set; get; }
    }
}
