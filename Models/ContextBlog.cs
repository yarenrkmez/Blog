using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
   
    public class Context
    {
        private static BlogYeni link;

        public static BlogYeni Link
        {
            get
            {
                if (link == null)
                {
                    link = new BlogYeni();
                }
                return link;
            }
            set { link = value; }
        }

    }
}