using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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

        public void BllSaveNewColour(string colour)
        {
            dal.DalSaveNewColour(colour);
        }
    }
}
