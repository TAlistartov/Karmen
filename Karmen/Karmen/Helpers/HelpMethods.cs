using Karmen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Helpers
{
    public class HelpMethods
    {
        //Map function
        public List<A> HandMapper<A, B>(A OutClassType, List<B> InputDataList) where A : new()
                                                                                    where B : class
        {
            //Create empty List<SomeResultClass>
            List<A> outTypeClass = new List<A>();
            //Get all properties class A and class B
            var targetProperties = OutClassType.GetType().GetProperties();
            var inputProperties = typeof(B).GetProperties();
            //Get equals properties betwen A&B classes 
            var commonproperties = from sp in targetProperties
                                   join dp in inputProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };
            //go through all collection
            foreach (var th in InputDataList)
            {
                A newClass = new A();
                //Get fields
                foreach (var match in commonproperties)
                {
                    //Get equal field and set value
                    match.sp.SetValue(newClass, match.dp.GetValue(th, null), null);
                }
                outTypeClass.Add(newClass);
            }
            return (outTypeClass);
        }

        //Help method for DropDownList Creating
        public List<SelectListItem> MakeDropDownList<T>(List<T> classCollection) where T : ISelectListItem
        {
            var items = new List<SelectListItem>();
            foreach (var item in classCollection)
            {
                items.Add(item.MapToSelectListItem());
            }
            return items;
        }
    }
}