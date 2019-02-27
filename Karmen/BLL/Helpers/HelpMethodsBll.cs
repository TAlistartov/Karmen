using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Models;
using System.Reflection;

namespace BLL.Helpers
{
    public class HelpMethodsBll
    {
        //Dictionary of matchig BLL Models--> Methods In Dal
        public Dictionary<Type, string> matchClassesvsDalMethods = new Dictionary<Type, string>()
        {
            [typeof(Colour_Bll)] = "Dal_Colour",
            [typeof(Pattern_Bll)] = "Dal_Pattern",
            [typeof(Lining_Bll)] = "Dal_Lining",
            [typeof(FootBed_Bll)] = "Dal_FootBed",
            [typeof(Pad_Bll)] = "Dal_Pad",
            [typeof(KindOfBlock_Bll)] = "Dal_KindOfBlock",
            [typeof(TopMaterial_Bll)] = "Dal_TopMaterial",
            [typeof(Furniture_Bll)] = "Dal_Furniture",
            [typeof(MaterialOfSole_Bll)] = "Dal_MaterialOfSole",
            [typeof(Component_Bll)] = "Dal_Component"
        };

        //Dictionary of matchig BLL Classes--> DAL Classes
        public Dictionary<Type, Type> matchClassesBllvsClassesDal = new Dictionary<Type, Type>()
        {
            { typeof(Colour_Bll),typeof(Colour_Dal)},
            { typeof(Pattern_Bll),typeof(Pattern_Dal)},
            { typeof(Lining_Bll),typeof(Lining_Dal)},
            { typeof(FootBed_Bll),typeof(FootBed_Dal)},
            { typeof(Pad_Bll),typeof(Pad_Dal)},
            { typeof(KindOfBlock_Bll),typeof(KindOfBlock_Dal)},
            { typeof(TopMaterial_Bll),typeof(TopMaterial_Dal)},
            { typeof(Furniture_Bll),typeof(Furniture_Dal)},
            { typeof(MaterialOfSole_Bll),typeof(MaterialOfSole_Dal)},
            { typeof(Component_Bll),typeof(Component_Dal)}
        };

        //Maping Bll Class on equal Dal Class
        public object HandMappingUseReflection <B> ( Type typeOfClass, B someClassForSave) 
        {
            object inst = null;
            foreach (KeyValuePair<Type, Type> keyValue in matchClassesBllvsClassesDal)
            {
                if (keyValue.Key == typeOfClass)
                {
                    PropertyInfo[] propBll = typeOfClass.GetProperties();
                    PropertyInfo[] propDal = keyValue.Value.GetProperties();

                    var commonproperties = from sp in propDal
                                           join dp in propBll on new { sp.Name, sp.PropertyType } equals
                                               new { dp.Name, dp.PropertyType }
                                           select new { sp, dp };

                    inst = Activator.CreateInstance(keyValue.Value);
                   
                    //Get fields
                    foreach (var match in commonproperties)
                    {
                        //Get equal field and set value
                        match.sp.SetValue(inst, match.dp.GetValue(someClassForSave, null), null);
                    }

                }

            }

            return inst;
        }

        //Select Necessary Method from another assembly
        public object SelectActionMethod (Type typeOfClass, string necessaryAction, object dataToDal)
        {
            string[] t = null;
            object resultOfAction=null;
            string finalAction;
            foreach (KeyValuePair<Type, string> keyValue in matchClassesvsDalMethods)
            {
                if (keyValue.Key == typeOfClass)
                {
                    t = keyValue.Value.Split(new char[] { '_' });
                    //Name of calling Method in Dal
                    finalAction = t[0] + necessaryAction + t[1];
                    //Get assembli
                    Assembly asm = Assembly.Load("DAL");
                    //Get type of class
                    Type g = asm.GetType("DAL.Dal");
                    //Get Method which has name finalAction  
                    var methodInfo = g.GetMethod(finalAction);
                    //Exception - if Method is not finded
                    if (methodInfo == null) // the method doesn't exist
                    {
                        throw new InvalidOperationException(
                                string.Format("Unknown method {0}.", methodInfo));
                    }
                    //Create instance of the non static class
                    var o = Activator.CreateInstance(g);
                    //Call the method from DAL.Dal
                    resultOfAction = methodInfo.Invoke(o, new object[] { dataToDal });
                    break;
                }
            }
            return resultOfAction;
        }

    }
}
