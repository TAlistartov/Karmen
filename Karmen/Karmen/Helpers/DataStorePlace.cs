using Karmen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Helpers
{
    public static class DataStorePlace
    {
        //Lists of stored data
        public static List<ColourModel> allColoursModel { get; set; }
        public static List<SelectListItem> AllColoursFromDb { get; set; }

        public static List<PatternModel> allPatternsModel { get; set; }
        public static List<LiningModel> allLiningsModel { get; set; }
        public static List<FurnitureModel> allFurnituresModel { get; set; }
        public static List<FootBedModel> allFootBesModel { get; set; }
        public static List<PadModel> allPadsModel { get; set; }
        public static List<KindOfBlockModel> allKindOfBlocksModel { get; set; }
        public static List<MaterialOfSoleModel> allMaterialsOfSoleModel { get; set; }

        public static List<TopMaterialModel> allTopMaterialsModel { get; set; }
        public static List<SelectListItem> AllTopMaterialsFromDb { get; set; }

        public static List<ComponentModel> allComponentsModel { get; set; }
        public static List<SelectListItem> AllComponentsFromDb { get; set; }

        //Dictionary for seasons
        //public static Dictionary<int, string> seasons = new Dictionary<int, string>()
        //{
        //    {0,"зима"},
        //    {1,"весна"},
        //    {2,"лето"},
        //    {3,"осень"},
        //    {4,"всесезоннка"}
        //};
        public static List<SelectListItem> season = new List<SelectListItem>()
        {
            new SelectListItem(){ Text="зима", Value="зима"},
            new SelectListItem(){ Text="весна", Value="весна"},
            new SelectListItem(){ Text="лето", Value="лето"},
            new SelectListItem(){ Text="осень", Value="осень"},
            new SelectListItem(){ Text="всесезонка", Value="всесезонка"}
        };
        

    }
}