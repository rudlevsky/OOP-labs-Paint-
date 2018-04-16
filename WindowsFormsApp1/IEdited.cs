using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface IEdited
    {
        void rewrite(int x_cord, int y_cord);
        void chng_size(string key_name);
    }
}
