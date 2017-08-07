using NGLBCMS.Models;
using NGLB_CMS.Business.Containers;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace NGLB_CMS.Models
{
    public class DailyWeeklyFinderContentModel : RenderModel
    {
        public DailyWeeklyFinderContentModel(IPublishedContent content) : base(content)
        { }

        public DailyWeeklyFinderContentResult Activities { get; set; }
        public ProfilePreferences Settings { get; set; }
    }
}