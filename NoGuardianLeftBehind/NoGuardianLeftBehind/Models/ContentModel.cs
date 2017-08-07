using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoGuardianLeftBehind.Models
{
    public class ContentModel
    {
        public String NAME { get; private set; }
        public HtmlString DESCRIPTION { get; private set; }

        /// <summary>
        ///     USED FOR IMAGE ASSOCIATING
        /// </summary>
        public String CLASS { get; private set; }

        public ContentModel(String _name, String _description, String _class)
        {
            NAME = _name;
            DESCRIPTION = new HtmlString(_description);
            CLASS = _class;
        }

    }
}