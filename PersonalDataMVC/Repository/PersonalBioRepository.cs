using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using PersonalDataMVC.Models;

namespace PersonalDataMVC.Repository
{
    public class PersonalBioRepository
    {
        public readonly string connectionString;


        public PersonalBioRepository()
        {

            connectionString = @"Data Source = DESKTOP-21TGVVO; Initial Catalog = PersonalData; Integrated Security = True";
        }

        public PersonalDataModel DynamicDataModel()
        {
            PersonalDataModel ObjPersonalBio = new PersonalDataModel();

            Console.WriteLine("enter id");
            ObjPersonalBio.id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter fist name");
            ObjPersonalBio.Name = Console.ReadLine();

            Console.WriteLine("enter your last name name");
            ObjPersonalBio.LastName = Console.ReadLine();

            Console.WriteLine("enter age");
            ObjPersonalBio.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter address");
            ObjPersonalBio.Address = Console.ReadLine();


            return ObjPersonalBio;
        }


        public void InsertPersonalData(PersonalDataModel bio)
        {
            try
            {

                SqlConnection connectionObject = new SqlConnection(connectionString);

                connectionObject.Open();
                connectionObject.Execute($"exec InsertPersonalBio '{bio.Name}', '{bio.LastName}',{bio.Age},'{bio.Address}' ");


                connectionObject.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<PersonalDataModel> Select()

        {
            try
            {
                List<PersonalDataModel> ListofPersonalData = new List<PersonalDataModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<PersonalDataModel>("exec SelectPersonalBio", connectionString).ToList();
                connection.Close();



                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }








        public void ubdate(PersonalDataModel bio)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);



                connectionObject.Open(); // Age = @Age, Address = @Address where id = @id

                connectionObject.Execute($"  exec UbdatePersonalBio '{bio.Name}','{bio.LastName}',{bio.Age},'{bio.Address}','{bio.id}' ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void delete(int Id)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);

               /* Console.WriteLine("enter a id  to delete record");
                int del = Convert.ToInt32(Console.ReadLine());
*/
                connectionObject.Open();
                connectionObject.Execute($"exec DeletePersonalBio {Id} ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public PersonalDataModel SelectSP(int id)

        {
            try
            {


                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                var res = connection.QueryFirst<PersonalDataModel>($"exec selects {id}");
                connection.Close();

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }




}

