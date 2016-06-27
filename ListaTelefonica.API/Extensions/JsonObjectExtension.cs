using System;
using System.Web.Script.Serialization;

namespace ListaTelefonica.API.Extensions
{
    public static class JsonObjectExtension
    {
        public static String ToJSON(this Object obj)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(obj);
        }

    }
}