using NGLB_CMS.Business.Containers;
using NGLBCMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace NGLB_CMS.Models
{
    public class GetCharactersModel : RenderModel
    {
        public GetCharactersModel(IPublishedContent content) : base(content)
        { }

        public List<CharacterSelection> Characters { get; set; }
        public ProfilePreferences Settings { get; set; }
    }
}