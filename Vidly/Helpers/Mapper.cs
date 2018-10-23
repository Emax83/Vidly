using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Helpers
{
    public static class Mapper
    {
        public static void Map(object source, object destination)
        {
            foreach (System.Reflection.PropertyInfo property in source.GetType().GetProperties())
            {
                System.Reflection.PropertyInfo info = destination.GetType().GetProperty(property.Name);
                if (info != null)
                    info.SetValue(destination, property.GetValue(source));
            }
        }

        //public static void MapFormcollection(System.Web.Mvc.FormCollection collection, object destination)
        //{
        //    foreach (string key in collection.AllKeys)
        //    {
        //        System.Reflection.PropertyInfo info = destination.GetType().GetProperty(key);
        //        if (info != null)
        //            info.SetValue(destination, collection[key]);
        //    }
        //}

    }
}