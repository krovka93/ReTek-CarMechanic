using Oracle.ManagedDataAccess.Client;
using ReTek_CarMechanical.Interfaces;
using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace ReTek_CarMechanical.Helpers
{
    class BussinessLayer : ICar, IClient, IPart, IService, IWorksheet
    {
        #region Private fields and Constructors
        private static BussinessLayer instance = null;
        private static readonly object padlock = new object();
        private static readonly string oracleDbConnectionString = "Data Source=193.225.33.71;User Id=zzhkiy;Password=szelektcsillag;";
        private static OracleConnection oracleConnection;

        BussinessLayer()
        {
            oracleConnection = new OracleConnection(oracleDbConnectionString);
        }

        #endregion

        #region Interface implementations
        public static BussinessLayer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BussinessLayer();
                    }
                    return instance;
                }
            }
        }

        public string Test()
        {
            return "Tesztszöveg a BussinessLayer-en keresztül";
        }

        public bool UploadNewCar(Car newCar)
        {
            throw new NotImplementedException();
        }

        public bool UpdateExistingCar(Car existingCar)
        {
            throw new NotImplementedException();
        }

        public Car GetSingleCar(Car oneCar)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCar()
        {
            throw new NotImplementedException();
        }

        public Client GetSingleClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClient()
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public bool AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Part GetSinglePart(Part part)
        {
            throw new NotImplementedException();
        }

        public List<Part> GetAllPart()
        {
            throw new NotImplementedException();
        }

        public bool AddPart(Part part)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePart(Part part)
        {
            throw new NotImplementedException();
        }

        public bool UpdateService(Service service)
        {
            throw new NotImplementedException();
        }

        public bool AddNewService(Service service)
        {
            throw new NotImplementedException();
        }

        public Service GetSingleService(Service service)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllService()
        {
            throw new NotImplementedException();
        }

        public bool UploadWorksheet(Worksheet worksheet)
        {
            int rowsUpdated = 0;
            try
            {
                oracleConnection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO WORKSHEET (START_DATE, EXPECTED_END, ACTUAL_END, KILOMETER_STATE, " +
                    "UNIQUE_ID, CAR_ID, SERVICE_ID, PART_ID)" +
                    " VALUES (:StartDate, :ExpectedEnd, :ActualEnd, :KilometerState, :UniqueId, :CarId, :ServiceId, :PartId )";
                cmd.Parameters.Add(new OracleParameter(":Worksheet", worksheet.WorkStart));
                cmd.Parameters.Add(new OracleParameter(":StartDate", worksheet.WorkStart));
                cmd.Parameters.Add(new OracleParameter(":ExpectedEnd", worksheet.ExpectedEnd));
                cmd.Parameters.Add(new OracleParameter(":ActualEnd", worksheet.WorkActualEnd));
                cmd.Parameters.Add(new OracleParameter(":KilometerState", worksheet.KilometerState));
                cmd.Parameters.Add(new OracleParameter(":UniqueId", "TESTUNIQUEID"));
                cmd.Parameters.Add(new OracleParameter(":CarId", worksheet.CarID));
                cmd.Parameters.Add(new OracleParameter(":ServiceId", worksheet.ServiceID));
                cmd.Parameters.Add(new OracleParameter(":PartId", worksheet.PartID));
                rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                oracleConnection.Close();
            }

            return rowsUpdated > 0 ? true : false;
        }

        public Worksheet GetSingleWorksheet(Worksheet worksheet)
        {
            throw new NotImplementedException();
        }

        public List<Worksheet> GetAllWorksheet()
        {
            throw new NotImplementedException();
        }
        public List<Car> GetAllCarByUser(Client selectedClient)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods

        #endregion
    }
}

