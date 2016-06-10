using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BlogApplication.Models
{
    public static class HtmlHelpers
    {
        public static IHtmlString RawJsonModel<TModel>(this HtmlHelper<TModel> html)
        {
            var serializedModel = JsonConvert.SerializeObject(html.ViewData.Model);
            return html.Raw(serializedModel);
        }
    }
}