using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    public class Content
    {
        public String Name { get; private set; }
        public String Prefix { get; private set; }
        public String Platform { get; private set; }
        public int LightLevel { get; private set; }
        public int Frequency { get; private set; }
        public ContentType ContentType { get; private set; }

        public Content(String name, String prefix, String platform, int lightlevel, int frequency, ContentType contentType)
        {
            Name = name;
            Prefix = prefix;
            Platform = platform;
            LightLevel = lightlevel;
            Frequency = frequency;
            ContentType = contentType;
        }
    }
}
