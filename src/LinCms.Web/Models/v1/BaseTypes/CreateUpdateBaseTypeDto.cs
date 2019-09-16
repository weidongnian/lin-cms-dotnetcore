﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinCms.Web.Models.v1.BaseTypes
{
    public class CreateUpdateBaseTypeDto
    {
        [Required(ErrorMessage = "类别编码为必填项")]
        public string TypeCode { get; set; }
        [Required(ErrorMessage = "类别名称为必填项")]
        public string FullName { get; set; }
        public int? SortCode { get; set; }
    }
}