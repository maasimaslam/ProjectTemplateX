using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml;

namespace ProjectTemplate.HTMLHelpers
{
    public static class ValidationMessageExtensions
    {
        public static MvcHtmlString ProjectTemplateValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage)
        {
            var s = htmlHelper.ValidationMessageFor(expression).ToString();
            var x = GetElement(s);

            if (!String.IsNullOrEmpty(x.InnerText))
            {
                return MvcHtmlString.Create(String.Format("<span class=\"validation-message-tooltip\" title=\"{0}\" data-toggle=\"tooltip\" data-placement=\"top\" >*</span>", x.InnerText));
            }

            return MvcHtmlString.Create(String.Format("<span></span>", x.InnerText));

            //var builder = new TagBuilder("p");

            //builder.AddCssClass("text-danger");

            //var s = htmlHelper.ValidationMessageFor(expression).ToString();
            //var x = GetElement(s);

            //if (!String.IsNullOrEmpty(x.InnerText))
            //{
            //    builder.MergeAttribute("title", x.InnerText);
            //    builder.InnerHtml = "<span>*</span>";

            //}



            //return MvcHtmlString.Create(builder.ToString(TagRenderMode.EndTag));
        }

        private static XmlElement GetElement(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }
    }
}
