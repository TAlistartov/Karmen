using BLL.Models;
using Karmen.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;

namespace Karmen.Helpers
{
    public class HelpMethods
    {
         //Dictionary of matchig id selected punkt in UI --> class name model
         public Dictionary<string, Type> matchIdUIvsClasses = new Dictionary<string, Type>()
        {
             //{"colour", typeof(Colour_Bll) }
             ["colour"] = typeof(ColourModel),
             ["pattern"] = typeof(PatternModel),
             ["lining"] = typeof(LiningModel),
             ["footbed"] = typeof(FootBedModel),
             ["pad"] = typeof(PadModel),
             ["kindOfBlock"] = typeof(KindOfBlockModel),
             ["topMaterial"] = typeof(TopMaterialModel),
             ["furniture"] = typeof(FurnitureModel),
             ["materialOfSole"] = typeof(MaterialOfSoleModel),
             ["component"] = typeof(ComponentModel)
         };

        //Dictionary of matchig Model Classes UI --> BLL Classes
        public Dictionary<Type, Type> matchClassesBllvsClassesDal = new Dictionary<Type, Type>()
        {
            { typeof(ColourModel),typeof(Colour_Bll)},
            { typeof(PatternModel),typeof(Pattern_Bll)},
            { typeof(LiningModel),typeof(Lining_Bll)},
            { typeof(FootBedModel),typeof(FootBed_Bll)},
            { typeof(PadModel),typeof(Pad_Bll)},
            { typeof(KindOfBlockModel),typeof(KindOfBlock_Bll)},
            { typeof(TopMaterialModel),typeof(TopMaterial_Bll)},
            { typeof(FurnitureModel),typeof(Furniture_Bll)},
            { typeof(MaterialOfSoleModel),typeof(MaterialOfSole_Bll)},
            { typeof(ComponentModel),typeof(Component_Bll)}
        };

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

        ////Help method for DropDownList Creating
        //public List<SelectListItem> MakeDropDownList(Dictionary<int,string> seasons)
        //{
        //    var items = new List<SelectListItem>();
        //    foreach (KeyValuePair<int, string> keyValue in seasons)
        //    {
        //        items.Add(new SelectListItem { Text = keyValue.Value , Value=keyValue.Key.ToString()});
        //    }
        //    return items;
        //}

        //Deserialisation Json format to object
       
        public object DeserializationJsonData(string jsonData, string typeOfSaveData) 
        {
            var deserializatedData = new object { };
            foreach (KeyValuePair<string,Type> keyValue in matchIdUIvsClasses)
            {
                if (keyValue.Key== typeOfSaveData)
                {
                    var method = typeof(JsonConvert).GetMethods().FirstOrDefault(
                            x => x.Name.Equals("DeserializeObject", StringComparison.OrdinalIgnoreCase) &&
                                x.IsGenericMethod && x.GetParameters().Length == 1 &&
                                    x.GetParameters()[0].ParameterType == typeof(string));
                    var classType = method.MakeGenericMethod(keyValue.Value);
                    deserializatedData=  classType.Invoke(null, new object[] { jsonData });
                }               
            }

            return deserializatedData;            
        }


    }
}