using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.CoreUI
{
    public class MenuItem
    {
        public IconChar IconChar { get; set; }
        required public string Title { get; set; }
        required public UserControl Content { get; set; }

    }
}
