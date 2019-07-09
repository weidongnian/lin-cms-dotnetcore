﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinCms.Web.Areas.Cms.Models.Users
{
    public class LoginInputDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "登录名为必填项")]
        public string Nickname { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码为必填项")]
        public string Password { get; set; }
    }
}