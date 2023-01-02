﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wb.DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public  DateTime CreatedDate { get; set; }
    }
}
