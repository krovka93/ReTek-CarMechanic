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
            List<Client> allClients = new List<Client>();
            oracleConnection = new OracleConnection(oracleDbConnectionString);
            try
            {
                oracleConnection.Open();
                var commandText = "SELECT * FROM Clients";
                using (OracleCommand command = new OracleCommand(commandText, oracleConnection))
                {
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Client oneClient = new Client()
                        {
                            ClientID = dr.GetInt32(0),
                            FirstName = dr.GetString(1),
                            LastName = dr.GetString(2),
                            BirthDate = dr.GetDateTime(3),
                            BirthPlace = dr.GetString(4),
                            SocialSecNum = dr.GetString(5),
                            TaxNum = dr.GetString(6),
                            DateRegistered = dr.GetDateTime(7)
                        };
                        allClients.Add(oneClient);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return allClients;
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
            List<Part> allParts = new List<Part>();
            oracleConnection = new OracleConnection(oracleDbConnectionString);
            try
            {
                oracleConnection.Open();
                var commandText = "SELECT * FROM Parts";
                using (OracleCommand command = new OracleCommand(commandText, oracleConnection))
                {
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Part onePart = new Part()
                        {
                            PartID = dr.GetInt32(0),
                            PartName = dr. GetString(1),
                            Price = dr.GetInt32(2),
                            Quantity = dr.GetInt32(3)
                        };
                        allParts.Add(onePart);
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return allParts;
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
            List<Service> allServices = new List<Service>();
            oracleConnection = new OracleConnection(oracleDbConnectionString);
            try
            {
                oracleConnection.Open();
                var commandText = "SELECT * FROM Services";
                using (OracleCommand command = new OracleCommand(commandText, oracleConnection))
                {
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Service oneService = new Service()
                        {
                            ServiceID = dr.GetInt32(0),
                            ServiceName = dr.GetString(1),
                            ServicePrice = dr.GetInt32(2)
                        };
                        allServices.Add(oneService);
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                oracleConnection.Close();
            }
            return allServices;
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

