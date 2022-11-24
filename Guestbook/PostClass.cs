using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook
{
    public class Post
    {
        // fields
        private string g_name;
        private string g_text;
        public string G_name // property
        {
            set { this.g_name = value; } // set method
            get { return this.g_name; } // get method
        }

        public string G_text // property
        {
            set { this.g_text = value; } // set method
            get { return this.g_text; } // get method
        }

    }

}

