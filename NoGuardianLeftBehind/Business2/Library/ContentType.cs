using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    public class ContentType
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        public int Fireteam_Size { get; private set; }
        public int Frequency { get; private set; }

        public ContentType(String name, String description, int fireteam_size, int frequency)
        {
            Name = name;
            Description = description;
            Fireteam_Size = fireteam_size;
            Frequency = frequency;
        }
    }
}
