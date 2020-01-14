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
            var kutya = GetAllPart();
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
            throw new NotImplementedException();
        }

        public bool UploadWorksheet(Worksheet worksheet)
        {
            throw new NotImplementedException();
        }

        public Worksheet GetSingleWorksheet(Worksheet worksheet)
        {
            throw new NotImplementedException();
        }

        public List<Worksheet> GetAllWorksheet()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods
        private void InitializeDataBaseConnection()
        {
            try
            {
                oracleConnection = new OracleConnection(oracleDbConnectionString);
                oracleConnection.Open();
                if (oracleConnection.State == ConnectionState.Open)
                {
                    oracleConnection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}

