using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal
    {

        //Get Data from the necessary table in Db for DropDownList 
        #region
        //T TypeOfData - Type of DAL Model for identify of the necessary table in Db
        public List<T> DalGetAllDataTableFromDb <T> (T TypeOfData)
        {          
            List<T> temp = new List<T>();
            string convertData = TypeOfData.GetType().Name; //Here takes name of Class model
                                                                // Colours, Patterns etc.
            using (KarmenDbContext db = new KarmenDbContext())
            {
                switch (convertData)
                {
                    case "Colours":
                        temp = db.Colour.ToList() as List<T>;
                        break;
                    case "Patterns":
                        temp = db.Pattern.ToList() as List<T>;
                        break;
                    case "Linings":                        
                        temp = db.Lining.ToList() as List<T>;
                        break;
                    case "Footbeds":
                        temp = db.Footbed.ToList() as List<T>;
                        break;
                    case "Pads":
                        temp = db.Pad.ToList() as List<T>;
                        break;
                    case "KindOfBlocks":
                        temp = db.KindOfBlock.ToList() as List<T>;
                        break;
                    case "TopMaterials":
                        temp = db.TopMaterial.ToList() as List<T>;
                        break;
                    case "Furnitures":
                        temp = db.Furniture.ToList() as List<T>;
                        break;
                    case "MaterialsOfSole":
                        temp = db.MaterialOfSole.ToList() as List<T>;
                        break;
                    case "Components":
                        temp = db.Component.ToList() as List<T>;
                        break;
                }               
            }
            return (temp);
        }
        #endregion

        //Save New Data for all tables of DB
        #region
        public int DalSaveNewColour(object colour)
        {            
            int res = 0;
            Colour_Dal colour_dal = new Colour_Dal();
            colour_dal = colour as Colour_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Colour.Any(c => c.Colour == colour_dal.Colour);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Colour.Add(new Colours { Colour = colour_dal.Colour });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Colour.Any(c => c.Colour == colour_dal.Colour);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewComponent(object component)
        {
            int res = 0;
            Component_Dal component_dal = new Component_Dal();
            component_dal = component as Component_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Component.Any(c => c.TypeOfComponent == component_dal.TypeOfComponent && c.CrossReference== component_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Component.Add(new Components { TypeOfComponent= component_dal.TypeOfComponent,
                                                      IdColour= component_dal.IdColour,
                                                      Size= component_dal.Size,
                                                      UseUnuse= component_dal.UseUnuse,
                                                      CrossReference= component_dal.CrossReference,
                                                      AdditionalInformation= component_dal.AdditionalInformation,
                                                      IdMaterilOfCovering= component_dal.IdMaterilOfCovering,
                                                      Height= component_dal.Height,
                                                      Width= component_dal.Width,
                                                      Form= component_dal.Form,
                                                      Type= component_dal.Type
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Component.Any(c => c.TypeOfComponent == component_dal.TypeOfComponent && c.CrossReference == component_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewFootBed(object footBed)
        {
            int res = 0;
            FootBed_Dal footBed_dal = new FootBed_Dal();
            footBed_dal = footBed as FootBed_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Footbed.Any(c => c.Type == footBed_dal.Type && c.CrossReference== footBed_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Footbed.Add(new Footbeds { Type = footBed_dal.Type,
                                                  CrossReference= footBed_dal.CrossReference,
                                                  AdditionalInformation= footBed_dal.AdditionalInformation
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Footbed.Any(c => c.Type == footBed_dal.Type && c.CrossReference == footBed_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int  DalSaveNewFurniture(object furniture)
        {
            int res = 0;
            Furniture_Dal furniture_dal = new Furniture_Dal();
            furniture_dal = furniture as Furniture_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Furniture.Any(c => c.Type == furniture_dal.Type && c.CrossReference == furniture_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Furniture.Add(new Furnitures
                    {
                        IdColour= furniture_dal.IdColour,
                        Type = furniture_dal.Type,
                        UseUnuse= furniture_dal.UseUnuse,
                        CrossReference = furniture_dal.CrossReference
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Furniture.Any(c => c.Type == furniture_dal.Type && c.CrossReference == furniture_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewKindOfBlock(object kindOfBlock)
        {
            int res = 0;
            KindOfBlock_Dal kindOfBlock_dal = new KindOfBlock_Dal();
            kindOfBlock_dal = kindOfBlock as KindOfBlock_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.KindOfBlock.Any(c => c.Name == kindOfBlock_dal.Name && c.CrossReference == kindOfBlock_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.KindOfBlock.Add(new KindOfBlocks
                    {
                        Name = kindOfBlock_dal.Name,
                        AdditionalInformation = kindOfBlock_dal.AdditionalInformation,                        
                        CrossReference = kindOfBlock_dal.CrossReference
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.KindOfBlock.Any(c => c.Name == kindOfBlock_dal.Name && c.CrossReference == kindOfBlock_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewLining(object lining)
        {
            int res = 0;
            Lining_Dal lining_dal = new Lining_Dal();
            lining_dal = lining as Lining_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Lining.Any(c => c.Name == lining_dal.Name && c.CrossReference == lining_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Lining.Add(new Linings
                    {
                        Name = lining_dal.Name,
                        Season = lining_dal.Season,
                        AdditionalInformation= lining_dal.AdditionalInformation,
                        CrossReference = lining_dal.CrossReference,
                        UseUnuse= lining_dal.UseUnuse
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Lining.Any(c => c.Name == lining_dal.Name && c.CrossReference == lining_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewMaterialOfSole(object materialOfSole)
        {
            int res = 0;
            MaterialOfSole_Dal materialOfSole_dal = new MaterialOfSole_Dal();
            materialOfSole_dal = materialOfSole as MaterialOfSole_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.MaterialOfSole.Any(c => c.Name == materialOfSole_dal.Name && c.CrossReference == materialOfSole_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.MaterialOfSole.Add(new MaterialsOfSole
                    {
                        Name = materialOfSole_dal.Name,
                        IdColour = materialOfSole_dal.IdColour,                        
                        CrossReference = materialOfSole_dal.CrossReference,
                        UseUnuse = materialOfSole_dal.UseUnuse
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.MaterialOfSole.Any(c => c.Name == materialOfSole_dal.Name && c.CrossReference == materialOfSole_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewPad(object pad)
        {
            int res = 0;
            Pad_Dal pad_dal = new Pad_Dal();
            pad_dal = pad as Pad_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Pad.Any(c => c.Kind == pad_dal.Kind && c.PadSize == pad_dal.PadSize);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Pad.Add(new Pads
                    {
                        Kind = pad_dal.Kind,
                        PadSize = pad_dal.PadSize,                        
                        UseUnuse = pad_dal.UseUnuse,
                        AdditionalInformation= pad_dal.AdditionalInformation
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Pad.Any(c => c.Kind == pad_dal.Kind && c.PadSize == pad_dal.PadSize);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewPattern(object pattern)
        {
            int res = 0;
            Pattern_Dal pattern_dal = new Pattern_Dal();
            pattern_dal = pattern as Pattern_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Pattern.Any(c => c.CrossReference == pattern_dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.Pattern.Add(new Patterns
                    {
                        CrossReference = pattern_dal.CrossReference,
                        UseUnuse = pattern_dal.UseUnuse,
                        AdditionalInformation = pattern_dal.AdditionalInformation
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Pattern.Any(c => c.CrossReference == pattern_dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }

        public int DalSaveNewTopMaterial(object topMaterial)
        {
            int res = 0;
            TopMaterial_Dal topMaterial_Dal = new TopMaterial_Dal();
            topMaterial_Dal = topMaterial as TopMaterial_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.TopMaterial.Any(c => c.Type == topMaterial_Dal.Type && c.CrossReference == topMaterial_Dal.CrossReference);
                if (temp == false)
                {
                    // Add new element to Db
                    db.TopMaterial.Add(new TopMaterials
                    {
                        IdColour= topMaterial_Dal.IdColour,
                        Type= topMaterial_Dal.Type,
                        CrossReference = topMaterial_Dal.CrossReference,
                        UseUnuse = topMaterial_Dal.UseUnuse                        
                    });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.TopMaterial.Any(c => c.Type == topMaterial_Dal.Type && c.CrossReference == topMaterial_Dal.CrossReference);
                    res = (users == false) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }
        #endregion

        //Change Existed Data for all tables of DB
        #region
        public int DalChangeExistedColour(object colour)
        {
            int res = 0;
            Colour_Dal colour_dal = new Colour_Dal();
            colour_dal = colour as Colour_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Colour.FirstOrDefault(c => c.Id == colour_dal.Id);
                //Change selected data
                temp.Colour = colour_dal.Colour;
                //Save changes
                db.SaveChanges();
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedComponent(object component)
        {
            int res = 0;
            Component_Dal component_dal = new Component_Dal();
            component_dal = component as Component_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Component.FirstOrDefault(c => c.Id == component_dal.Id);
                //Change selected data
                temp.TypeOfComponent = component_dal.TypeOfComponent;
                temp.IdColour = component_dal.IdColour;
                temp.Size = component_dal.Size;
                temp.UseUnuse = component_dal.UseUnuse;
                temp.CrossReference = component_dal.CrossReference;
                temp.AdditionalInformation = component_dal.AdditionalInformation;
                temp.IdMaterilOfCovering = component_dal.IdMaterilOfCovering;
                temp.Height = component_dal.Height;
                temp.Width = component_dal.Width;
                temp.Form = component_dal.Form;
                temp.Type = component_dal.Type;
                //Save changes   
                db.SaveChanges();
                            
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedFootBed(object footBed)
        {
            int res = 0;
            FootBed_Dal footBed_dal = new FootBed_Dal();
            footBed_dal = footBed as FootBed_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Footbed.FirstOrDefault(c => c.Id == footBed_dal.Id);

                //Change selected data
                temp.Type = footBed_dal.Type;
                temp.CrossReference = footBed_dal.CrossReference;
                temp.AdditionalInformation = footBed_dal.AdditionalInformation;
                //Save changes
                db.SaveChanges();
                   
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedFurniture(object furniture)
        {
            int res = 0;
            Furniture_Dal furniture_dal = new Furniture_Dal();
            furniture_dal = furniture as Furniture_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Furniture.FirstOrDefault(c => c.Id == furniture_dal.Id);

                // Change data
                temp.IdColour = furniture_dal.IdColour;
                temp.Type = furniture_dal.Type;
                temp.UseUnuse = furniture_dal.UseUnuse;
                temp.CrossReference = furniture_dal.CrossReference;
                //Save changes    
                db.SaveChanges();                    
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedKindOfBlock(object kindOfBlock)
        {
            int res = 0;
            KindOfBlock_Dal kindOfBlock_dal = new KindOfBlock_Dal();
            kindOfBlock_dal = kindOfBlock as KindOfBlock_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.KindOfBlock.FirstOrDefault(c => c.Id == kindOfBlock_dal.Id);

                // Change data
                temp.Name = kindOfBlock_dal.Name;
                temp.AdditionalInformation = kindOfBlock_dal.AdditionalInformation;
                temp.CrossReference = kindOfBlock_dal.CrossReference;
                //Save changes    
                db.SaveChanges();                      
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedLining(object lining)
        {
            int res = 0;
            Lining_Dal lining_dal = new Lining_Dal();
            lining_dal = lining as Lining_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Lining.FirstOrDefault(c => c.Id == lining_dal.Id);

                // Change data
                temp.Name = lining_dal.Name;
                temp.Season = lining_dal.Season;
                temp.AdditionalInformation = lining_dal.AdditionalInformation;
                temp.CrossReference = lining_dal.CrossReference;
                temp.UseUnuse = lining_dal.UseUnuse;
                //Save changes    
                db.SaveChanges();
                           
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedMaterialOfSole(object materialOfSole)
        {
            int res = 0;
            MaterialOfSole_Dal materialOfSole_dal = new MaterialOfSole_Dal();
            materialOfSole_dal = materialOfSole as MaterialOfSole_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.MaterialOfSole.FirstOrDefault(c => c.Id == materialOfSole_dal.Id);
                // Change data
                temp.Name = materialOfSole_dal.Name;
                temp.IdColour = materialOfSole_dal.IdColour;
                temp.CrossReference = materialOfSole_dal.CrossReference;
                temp.UseUnuse = materialOfSole_dal.UseUnuse;
                //Save changes
                db.SaveChanges();                          
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedPad(object pad)
        {
            int res = 0;
            Pad_Dal pad_dal = new Pad_Dal();
            pad_dal = pad as Pad_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Pad.FirstOrDefault(c => c.Id == pad_dal.Id);
                // Change data
                temp.Kind = pad_dal.Kind;
                temp.PadSize = pad_dal.PadSize;
                temp.UseUnuse = pad_dal.UseUnuse;
                temp.AdditionalInformation = pad_dal.AdditionalInformation;
                //Save changes   
                db.SaveChanges();                              
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedPattern(object pattern)
        {
            int res = 0;
            Pattern_Dal pattern_dal = new Pattern_Dal();
            pattern_dal = pattern as Pattern_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Pattern.FirstOrDefault(c => c.Id == pattern_dal.Id);
                // Change data
                temp.CrossReference = pattern_dal.CrossReference;
                temp.UseUnuse = pattern_dal.UseUnuse;
                temp.AdditionalInformation = pattern_dal.AdditionalInformation;
                //Save changes   
                db.SaveChanges();                              
            }
            res = 1;
            return (res);
        }

        public int DalChangeExistedTopMaterial(object topMaterial)
        {
            int res = 0;
            TopMaterial_Dal topMaterial_Dal = new TopMaterial_Dal();
            topMaterial_Dal = topMaterial as TopMaterial_Dal;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.TopMaterial.FirstOrDefault(c => c.Id == topMaterial_Dal.Id);
                //Change data
                temp.IdColour = topMaterial_Dal.IdColour;
                temp.Type = topMaterial_Dal.Type;
                temp.CrossReference = topMaterial_Dal.CrossReference;
                temp.UseUnuse = topMaterial_Dal.UseUnuse;
                //Save changes  
                db.SaveChanges();                    
            }
            res = 1;
            return (res);
        }
        #endregion
    }
}
