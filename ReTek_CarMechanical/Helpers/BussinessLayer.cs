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

        public bool UploadNewCar(Car newCar)
        {
            int rowsUpdated = 0;
            try
            {
                oracleConnection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO CARS (CAR_PLATE_NUM, CAR_TYPE, CAR_DATE_OF_PROD, " +
                    "CAR_VIN, CAR_OWNER)" +
                    " VALUES (:CarPlateNum, :CarType, :CarDateOfProd, :CarVin, :CarOwner )";
                cmd.Parameters.Add(new OracleParameter(":CarPlateNum", newCar.CarPlateNumber));
                cmd.Parameters.Add(new OracleParameter(":CarType", newCar.CarType));
                cmd.Parameters.Add(new OracleParameter(":CarDateOfProd", newCar.CarDateofProduce));
                cmd.Parameters.Add(new OracleParameter(":CarVin", newCar.CarVIN));
                cmd.Parameters.Add(new OracleParameter(":CarOwner", newCar.CarOwner));
                cmd.Connection = oracleConnection;
                rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                oracleConnection.Close();
            }

            return rowsUpdated > 0 ? true : false;
        }

        public bool UpdateExistingCar(Car existingCar)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCar()
        {
            List<Car> allCars = new List<Car>();
            oracleConnection = new OracleConnection(oracleDbConnectionString);
            try
            {
                oracleConnection.Open();
                var commandText = "SELECT * FROM Cars";
                using (OracleCommand command = new OracleCommand(commandText, oracleConnection))
                {
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Car oneCar = new Car()
                        {
                            CarID = dr.GetInt32(0),
                            CarPlateNumber = dr.GetString(1),
                            CarType = dr.GetString(2),
                            CarDateofProduce = dr.GetDateTime(3),
                            CarVIN = dr.GetString(4),
                            CarOwner = dr.GetInt32(5)
                        };
                        allCars.Add(oneCar);
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
            return allCars;
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
            finally
            {
                oracleConnection.Close();
            }
            return allClients;
        }

        public bool UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public bool AddClient(Client client)
        {
            int rowsUpdated = 0;
            try
            {
                oracleConnection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO CLIENTS (FIRST_NAME, LAST_NAME, BIRTH_DATE, " +
                    "BIRTH_PLACE, SOCIAL_SEC_NUM, TAX_NUM, DATE_REGISTERED)" +
                    " VALUES (:FirstName, :LastName, :BirthDate, :BirthPlace, :SocialSecNum, :TaxNum, :DateRegistered, :PartId )";
                cmd.Parameters.Add(new OracleParameter(":FirstName", client.FirstName));
                cmd.Parameters.Add(new OracleParameter(":LastName", client.LastName));
                cmd.Parameters.Add(new OracleParameter(":BirthDate", client.BirthDate));
                cmd.Parameters.Add(new OracleParameter(":BirthPlace", client.BirthPlace));
                cmd.Parameters.Add(new OracleParameter(":SocialSecNum", client.SocialSecNum));
                cmd.Parameters.Add(new OracleParameter(":TaxNum", client.TaxNum));
                cmd.Parameters.Add(new OracleParameter(":DateRegistered", client.DateRegistered));
                cmd.Connection = oracleConnection;
                rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                oracleConnection.Close();
            }

            return rowsUpdated > 0 ? true : false;
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
                            PartName = dr.GetString(1),
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
            finally
            {
                oracleConnection.Close();
            }
            return allParts;
        }

        public bool AddPart(Part part)
        {
            int rowsUpdated = 0;
            try
            {
                oracleConnection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO PARTS (PART_NAME, PRICE, QUANTITY)" +
                    " VALUES (:PartName, :Price, :Quantity )";
                cmd.Parameters.Add(new OracleParameter(":PartName", part.PartName));
                cmd.Parameters.Add(new OracleParameter(":Price", part.Price));
                cmd.Parameters.Add(new OracleParameter(":Quantity", part.Quantity));
                cmd.Connection = oracleConnection;
                rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                oracleConnection.Close();
            }

            return rowsUpdated > 0 ? true : false;
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
            int rowsUpdated = 0;
            try
            {
                oracleConnection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO SERVICES (SERVICE_NAME, PRICE)" +
                    " VALUES (:ServiceName, :Price )";
                cmd.Parameters.Add(new OracleParameter(":ServiceName", service.ServiceName));
                cmd.Parameters.Add(new OracleParameter(":Price", service.ServicePrice));
                cmd.Connection = oracleConnection;
                rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsUpdated > 0 ? true : false;
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

        public List<Worksheet> GetAllWorksheet()
        {
            List<Worksheet> allWorksheets = new List<Worksheet>();
            oracleConnection = new OracleConnection(oracleDbConnectionString);
            try
            {
                oracleConnection.Open();
                var commandText = "SELECT * FROM Worksheets";
                using (OracleCommand command = new OracleCommand(commandText, oracleConnection))
                {
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Worksheet oneWorksheet = new Worksheet()
                        {
                            WorksheetID = dr.GetInt32(0),
                            WorkStart = dr.GetDateTime(1),
                            ExpectedEnd = dr.GetDateTime(2),
                            WorkActualEnd = dr.GetDateTime(3),
                            KilometerState = dr.GetInt32(4),
                            UniqueId = dr.GetString(5),
                            CarID = dr.GetInt32(6),
                            ServiceID = dr.GetInt32(7),
                            PartID = dr.GetInt32(8)
                        };
                        allWorksheets.Add(oneWorksheet);
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
            return allWorksheets;
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

