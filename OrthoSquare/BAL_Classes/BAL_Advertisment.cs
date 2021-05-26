using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Advertisment
    {
        
        General objGeneral = new General();
        DataSet ds = new DataSet();
        private string strQuery = string.Empty;
        public int Add_Advertisment(long AId, string Title, string AdvImage)
        {
            int isInserted = -1;
            General objGeneral = new General();
            try
            {
                if (AId > 0)
                {

                    strQuery = "Update AdvertismentMaster set Title =@Title , AdImage=@AdvImage where Aid=@AId";

                }
                else
                {

                    strQuery = "insert into AdvertismentMaster (Title,AdImage,IsActive)values (@Title,@AdvImage,1)";

                }


                objGeneral.AddParameterWithValueToSQLCommand("@AId", AId);
                objGeneral.AddParameterWithValueToSQLCommand("@Title", Title);
                objGeneral.AddParameterWithValueToSQLCommand("@AdvImage", AdvImage);
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }
            catch (Exception ex)
            {

               // objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return isInserted;
        }

        public DataTable GetAdvertisment(int Adid)
        {
            DataTable dt = new DataTable();
            General objGeneral = new General();
            try
            {
                strQuery = "Select * from AdvertismentMaster where IsActive =1";
                if (Adid > 0)
                    strQuery += " and  Aid=@AId";
                objGeneral.AddParameterWithValueToSQLCommand("@AId", Adid);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
               // objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return dt;
        }
        public int DeleteAdvertisment(int Adid)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                strQuery = "Update AdvertismentMaster set IsActive =0  where Aid=@AId";
                objGeneral.AddParameterWithValueToSQLCommand("@AId", Adid);
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                _isDeleted = 1;
            }
            catch (Exception ex)
            {

                //objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return _isDeleted;
        }

    }
}