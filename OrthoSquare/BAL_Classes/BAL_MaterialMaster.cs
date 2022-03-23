using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrthoSquare.BAL_Classes;
using System.Data;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_MaterialMaster
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();


        private string strQuery = string.Empty;
        public int AddMaterial(long Mid, string MaterialName, int BrandId, int PackId, string Price)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", MaterialName);

                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", BrandId);
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", PackId);
                objGeneral.AddParameterWithValueToSQLCommand("@Price", Price);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId ", Mid);

                if (Mid > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MaterialMaster");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public DataTable MaterialSelectID(string MaterialName)
        {
            DataTable dt = new DataTable();
            try
            {
                General objGeneral = new General();


                strQuery = "Select * from MaterialMaster where  IsActive =1 ";
                strQuery += " and MaterialName like '%" + MaterialName + "%'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetAllMaterial(int Mid)
        {
           
                strQuery = " Select * from MaterialMaster MM left join ManageMaterialStock S on S.MaterialId=MM.MaterialId join BrandMaster BM on MM.BrandId=BM.BrandId Join PackMaster PM on MM.PackId=PM.PackId    where MM.IsActive =1 ";
                if(Mid > 0)
                    strQuery += " and MM.MaterialId ='" + Mid + "'";
            strQuery += "  ORDER BY MM.MaterialId DESC";
                return objGeneral.GetDatasetByCommand(strQuery);

                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                //objGeneral.AddParameterWithValueToSQLCommand("@MaterialName","");
                //objGeneral.AddParameterWithValueToSQLCommand("@BrandId", "");
                //objGeneral.AddParameterWithValueToSQLCommand("@PackId", "");
                //objGeneral.AddParameterWithValueToSQLCommand("@Price", "");

                //objGeneral.AddParameterWithValueToSQLCommand("@MaterialId ", 0);
                //objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
          
        
        }

        public DataTable GetAllMaterialSelect(int Mid)
        {
            try
            {
                //objGeneral.AddParameterWithValueToSQLCommand("@IsActive", true);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Price", "");

                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId ", Mid);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                ds = objGeneral.GetDatasetByCommand_SP("SP_MaterialMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public DataTable GetAllMaterialDetliat(int Mid)
        {
            strQuery = "Select * from MaterialMaster MM Join BrandMaster BM on BM.BrandId =MM.BrandId where MaterialId ='" + Mid + "'";
           return objGeneral.GetDatasetByCommand(strQuery);

        }



        public int DeleteMaterial(int MID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", "");
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Price", "");
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId ", MID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_MaterialMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public int UpdateMaterial(string MaterialName, int BrandId, int PackId, string Price, int MID)
        {
            int isUpdated = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialName", MaterialName);
                objGeneral.AddParameterWithValueToSQLCommand("@BrandId", BrandId);
                objGeneral.AddParameterWithValueToSQLCommand("@PackId", PackId);
                objGeneral.AddParameterWithValueToSQLCommand("@Price", Price);
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId ", MID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                isUpdated = objGeneral.GetExecuteScalarByCommand_SP("SP_MaterialMaster");
            }
            catch (Exception ex)
            {
            }
            return isUpdated;
        }



        public DataTable GetAllinoutmaterial(int Vid, int Mid)
        {
            
                General objGeneral = new General();

                strQuery = "Select *, D.FirstName +' '+ D.LastName as Dname from InOutMaterialMaster IOM Join MaterialMaster MM on MM.MaterialId =IOM.MaterialId  join BrandMaster BM on MM.BrandId=BM.BrandId Join PackMaster PM on MM.PackId=PM.PackId ";
                strQuery += " Join VendorMaster VM on VM.VendorID =IOM.VendorID Join tbl_ClinicDetails C on C.ClinicID =IOM.ClinicID Join tbl_DoctorDetails D on D.DoctorID =IOM.DoctorID  where IOM.IsActive ='1' ";
                if (Mid > 0)
                    strQuery += " and  IOM.MaterialId ='" + Mid + "'";
                if (Vid > 0)
                    strQuery += " and  IOM.VendorID ='" + Vid + "'";

                strQuery += " order by InoutID DESC";

                return objGeneral.GetDatasetByCommand(strQuery);

           
        }


        public DataTable GetAllinoutmaterialSelect(long IOID)
        {
           // int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderDate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@InoutID ", IOID);
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);

                ds = objGeneral.GetDatasetByCommand_SP("SP_OutMaterialMaster");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public int DeleteINOUTMaterial(int IOID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderDate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@InoutID ", IOID);
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderPrice", "");
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", "");
              
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_OutMaterialMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }



        public int AddInOutMaterial(int Mid, int vid, string OrderDate,int orderQty,int OderPrice,int Cid,int Did)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();



                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", Mid);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID", vid);
                objGeneral.AddParameterWithValueToSQLCommand("@OrderQty",orderQty);
                objGeneral.AddParameterWithValueToSQLCommand("@OrderDate", objGeneral .getDatetime(OrderDate));
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty","");
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderPrice", OderPrice);
                objGeneral.AddParameterWithValueToSQLCommand("@InoutID ",0);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
              
              


                  objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

               


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_OutMaterialMaster");
              //  isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int AddInOutMaterialStock(int Mid, string OrderDate, int orderQty, int Cid, int Did,string UnitName)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();
                string Date1 = "";
                if(OrderDate !="")
                {
                    Date1 = OrderDate;
                }
                else
                {
                    Date1 = "01-01-1990";

                }

                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", Mid);
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderQty", orderQty);
                objGeneral.AddParameterWithValueToSQLCommand("@OrderDate", objGeneral.getDatetime(Date1));
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderPrice", "");
                objGeneral.AddParameterWithValueToSQLCommand("@InoutID ", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@UnitName", UnitName);


                
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_OutMaterialStockMaster");
                //  isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int AddInOutMaterialReceive(int IOID, string Receiveddate, int ReceiveQty)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();



                objGeneral.AddParameterWithValueToSQLCommand("@MaterialId", "");
                objGeneral.AddParameterWithValueToSQLCommand("@VendorID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderQty", "");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderDate","");
                objGeneral.AddParameterWithValueToSQLCommand("@OrderPrice", "");
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", ReceiveQty);
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", objGeneral .getDatetime(Receiveddate));
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", "");
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", "");
              

                objGeneral.AddParameterWithValueToSQLCommand("@InoutID ", IOID);

              
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);

              


                ds = objGeneral.GetDatasetByCommand_SP("SP_OutMaterialMaster");
                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public int AddInOutMaterialClinicReceive(int IOID,int Cid,int Did, string Receiveddate, int ReceiveQty)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                strQuery = "Insert into ReceivedMaterial (InoutID,ClinicID,DoctorID,ReceiveQty,ReceiveDate)values(@IOID,@Cid,@Did,@ReceiveQty,@Receiveddate)";

                objGeneral.AddParameterWithValueToSQLCommand("@IOID", IOID);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
               
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", ReceiveQty);
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", objGeneral.getDatetime(Receiveddate));

                objGeneral.GetExecuteNonQueryByCommand(strQuery);

              
              
                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public int UpdateInOutMaterialClinicReceive(int IOID, int ReceiveQty)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

              

                strQuery = "Update InOutMaterialMaster set ReceiveQty=@ReceiveQty where InoutID =@IOID"; 

                objGeneral.AddParameterWithValueToSQLCommand("@IOID", IOID);
               

                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", ReceiveQty);
               

                objGeneral.GetExecuteNonQueryByCommand(strQuery);



                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }



        public DataTable GetAllDocterinoutMaterialReport(int Cid, int Did)
        {
            strQuery = "Select RM.ReceiveQty ,RM.ReceiveDate,MaterialName,D.FirstName+' '+ D.LastName as DName ,C.ClinicName    from ReceivedMaterial RM left join InOutMaterialMaster IOM on IOM.InoutID =RM.InoutID ";
            strQuery += " join MaterialMaster MM on MM.MaterialId = IOM.MaterialId  join tbl_ClinicDetails C on C.ClinicID = RM.ClinicID  join tbl_DoctorDetails D on D.DoctorID = RM.DoctorID   where IOM.IsActive =1  ";

            if (Cid > 0)
                strQuery += " and RM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and RM.DoctorID='" + Did + "'";
            strQuery += " Order by RM.ReceiveQtyID DESC ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetAllDocterStockMaterialReport(int Cid, int Did)
        {
            strQuery = "Select sum(RM.ReceiveQty) ReceiveQty,MaterialName,D.FirstName+' '+ D.LastName as DName ,C.ClinicName    from ReceivedMaterial RM left join InOutMaterialMaster IOM on IOM.InoutID =RM.InoutID ";
            strQuery += " join MaterialMaster MM on MM.MaterialId = IOM.MaterialId  join tbl_ClinicDetails C on C.ClinicID = RM.ClinicID  join tbl_DoctorDetails D on D.DoctorID = RM.DoctorID   where IOM.IsActive =1  ";

            if (Cid > 0)
                strQuery += " and RM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and RM.DoctorID='" + Cid + "'";
            strQuery += " group by MaterialName,D.FirstName,D.LastName,C.ClinicName ";

            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public int GetAllMaterialOder1(int Mid)
        {
            strQuery = "Select IsNull(sum(ReceiveQty),0)  OrderQty from InOutMaterialMaster where MaterialId='" + Mid + "'";

            return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(strQuery));

        }


        public int GetMaterialOderRecvered(int InoutID)
        {
            strQuery = "Select IsNull((ReceiveQty),0)  OrderQty from InOutMaterialMaster where InoutID='" + InoutID + "'";

            return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));

        }


        public DataTable GetmaterialstocRecvered(int Mid)
        {
            strQuery = "Select *  from ManageMaterialStock where MaterialId='" + Mid + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public DataTable GetMaterialpurchased(int Cid, int Did, string ToDate, string FromDate)
        {
            strQuery = " Select Sum(RM.ReceiveQty* M.Price) as Total ,D.FirstName + ' ' + D.LastName as Dname,D.Line1 + ' ' + D.Line2 as Address,D.Mobile1 as Mobile,CD.ClinicName  from ReceivedMaterial RM left Join InOutMaterialMaster IOM on IOM.InoutID = RM.InoutID ";
            strQuery += " left Join MaterialMaster M on M.MaterialId = IOM.MaterialId left join ";
            strQuery += " tbl_DoctorDetails D on D.DoctorID =RM.DoctorID left join tbl_ClinicDetails CD on CD.ClinicID =RM.ClinicID  where IOM.IsActive=1 ";

            if (Cid > 0)
                strQuery += " and RM.ClinicID='" + Cid + "'";
            if (Did > 0)
                strQuery += " and RM.DoctorID='" + Did + "'";
          
            if (FromDate != "" && ToDate != "")
                strQuery += " and convert(date,RM.ReceiveDate,105) between convert(date,'" + FromDate + "',105) and convert(date,'" + ToDate + "',105)";




            strQuery += " Group By D.FirstName,D.LastName,D.Line1, D.Line2,D.Mobile1,CD.ClinicName";
            return objGeneral.GetDatasetByCommand(strQuery);

        }



        public DataTable GetmaterialRecvered11(int InoutID)
        {
            strQuery = "Select *  from InOutMaterialMaster where InoutID='" + InoutID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

        }

        public int AddmaterialstocReceive(int F,int Mid, int TotalMaterial)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                if (F == 1)
                {
                    strQuery = "insert into ManageMaterialStock (MaterialId,TotalMaterial)values(@Mid,@TotalMaterial)";
                }
                else
                {
                    strQuery = "Update ManageMaterialStock set TotalMaterial=@TotalMaterial where MaterialId =@Mid";

                }
                objGeneral.AddParameterWithValueToSQLCommand("@Mid", Mid);


                objGeneral.AddParameterWithValueToSQLCommand("@TotalMaterial", TotalMaterial);


                objGeneral.GetExecuteNonQueryByCommand(strQuery);



                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }





        public int AddUsedMaterial(int Mid, int Cid, int Did,int Pid,string Receiveddate , int ReceiveQty)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                strQuery = "Insert into UsedMaterial (MaterialId,ClinicID,DoctorID,patientid,ReceiveQty,CreateDate)values(@Mid,@Cid,@Did,@Pid,@ReceiveQty,@Receiveddate)";

                objGeneral.AddParameterWithValueToSQLCommand("@Mid", Mid);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@Pid", Pid);
                objGeneral.AddParameterWithValueToSQLCommand("@ReceiveQty", ReceiveQty);
                objGeneral.AddParameterWithValueToSQLCommand("@Receiveddate", objGeneral.getDatetime(Receiveddate));

                objGeneral.GetExecuteNonQueryByCommand(strQuery);



                isInserted = 1;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }
    }
}