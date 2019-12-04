﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBazigar8amBatchDemo1.CustomFilter
{
    public static class myhtmlhelper
    {
        public static IHtmlString MyLabel(string content)
        {
            string htmlstring = String.Format("<label>{0}</label>", content);
            return new HtmlString(htmlstring);
        }
        public static IHtmlString createUrControl(this HtmlHelper helper, string content)
        {
            string htmlstring = "<input type=" + content + ">";
            return new HtmlString(htmlstring);
        }

    }
}