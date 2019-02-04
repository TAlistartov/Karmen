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
        public static List<ComponentModel> allComponentsModel { get; set; }

    }
}