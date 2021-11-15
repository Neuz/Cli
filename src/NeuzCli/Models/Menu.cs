﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuzCli.Models
{
    public class MenuCls
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Action<Dictionary<string, object>> Action { get; set; }

        public IEnumerable<MenuCls> SubMenus { get; set; } = new List<MenuCls>();

        public override string ToString()
        {
            return Description;
        }
    }
}
