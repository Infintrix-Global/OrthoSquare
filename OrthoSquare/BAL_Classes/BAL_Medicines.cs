using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Medicines
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int AddMedicines(long MedicinesId,int MaterialTypeId, string MedicinesName, string MedicinesCompany,int UnitId,string Price)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesId", MedicinesId);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", MaterialTypeId);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", MedicinesName);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesCompany", MedicinesCompany);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", UnitId);
                objGeneral.AddParameterWithValueToSQLCommand("@Price", Price);
                if (MedicinesId > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);

                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Medicines");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isInserted;
        }


        public DataTable GetAllMedicines(string MedicinesName, string MaterialTypeId)
        {
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", MaterialTypeId);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", MedicinesName);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesCompany", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Price", "0");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Medicines");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }



        public int DeleteMedicines(int MedicinesId)
        {
            int _isDeleted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesId", MedicinesId);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesCompany", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Price", "0");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_Medicines");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _isDeleted;
        }


        public DataTable GetSelectMedicines(int MedicinesId)
        {
            try
            {
                General objGeneral = new General();
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesId", MedicinesId);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialTypeId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MedicinesCompany", "");
                objGeneral.AddParameterWithValueToSQLCommand("@UnitId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Price", "0");

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_Medicines");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }
    }
}