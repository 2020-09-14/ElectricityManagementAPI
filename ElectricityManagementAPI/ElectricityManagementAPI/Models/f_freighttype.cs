﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityManagementAPI.Models
{
    /// <summary>
    /// 运费类型表
    /// </summary>
    public class f_freighttype
    {
        public int Fid { get; set; }//运费类型id
        public string Fname { get; set; }//运费名称
    }
}
