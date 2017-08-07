using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    [Serializable]
    public class AdditionalOptions
    {
        public AdditionalOptions(List<String> checkPoints)
        {
            CheckPoints = checkPoints;
        }

        public List<String> CheckPoints { get; private set; }

    }
}
