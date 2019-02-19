﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Models;

namespace BLL
{
    public class Bll
    {
        //Links
        Dal dal = new Dal();
       

        //Get All Data From the necessaary tables in Db for Main DropDownList in all Punkts of Navigation
        public List<T> BllGetAllDataTableFromDb<T>(T TypeOfData)
        {
            List<T> dataDb = dal.DalGetAllDataTableFromDb<T>(TypeOfData);
            return (dataDb);
        }

        public int SaveNewNoteBll<T> (T someClassForSave, out string nameOfClass)
        {
            int res = 0;
            var nameOfClassModel = someClassForSave.GetType().Name;
            //Split the ClassName on [0] - ClassName && [1]-Bll
            var temp= nameOfClassModel.Split(new char[] { '_' });
            nameOfClass = temp[0];
            //Select the necessary action
            switch (nameOfClassModel)
            {
                case "Colour_Bll":
                    Colour_Bll colour_Bll = new Colour_Bll();
                    colour_Bll = someClassForSave as Colour_Bll;
                    res =dal.DalSaveNewColour(colour_Bll.Colour);
                break;

                case "Component_Bll":
                    Component_Bll component_Bll = new Component_Bll();
                    component_Bll = someClassForSave as Component_Bll;
                    //listOfFields = component_Bll.GetType().GetFields().Select(field => field.GetValue(component_Bll)).ToList();
                    res = dal.DalSaveNewComponent(component_Bll.TypeOfComponent, component_Bll.IdColour, component_Bll.Size,component_Bll.UseUnuse,
                                                    component_Bll.CrossReference,component_Bll.AdditionalInformation,component_Bll.IdMaterilOfCovering,
                                                        component_Bll.Height,component_Bll.Width,component_Bll.Form,component_Bll.Type);
                break;

                case "FootBed_Bll":
                    FootBed_Bll footBed_Bll = new FootBed_Bll();
                    footBed_Bll = someClassForSave as FootBed_Bll;
                    res= dal.DalSaveNewFootBed(footBed_Bll.Type,footBed_Bll.CrossReference,footBed_Bll.AdditionalInformation);
                break;

                case "Furniture_Bll":
                    Furniture_Bll furniture_Bll = new Furniture_Bll();

                break;

                case "KindOfBlock_Bll":
                    KindOfBlock_Bll kindOfBlock_Bll = new KindOfBlock_Bll();

                break;

                case "Lining_Bll":
                    Lining_Bll lining_Bll = new Lining_Bll();

                break;

                case "MaterialOfSole_Bll":
                    MaterialOfSole_Bll materialOfSole_Bll = new MaterialOfSole_Bll();

                break;

                case "Pad_Bll":
                    Pad_Bll pad_Bll = new Pad_Bll();

                break;

                case "Pattern_Bll":
                    Pattern_Bll pattern_Bll = new Pattern_Bll();

                break;

                case "TopMaterial_Bll":
                    TopMaterial_Bll topMaterial_Bll = new TopMaterial_Bll();

                break;
            }                        
            return res;
        }
    }
}
