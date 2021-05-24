using DataLibrary.DbAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class UsersDB
    {
        public static void createUser(string _Email, string _Phone,  string _name, string _surname,
            int _age, string _city, string _announcement, string _password)
        {
            UsersModel user = new UsersModel
            {
                Phone = _Phone,
                Email = _Email,
                name = _name,
                surname = _surname,
                age = _age,
                city = _city,
                announcement = _announcement,
                password = _password
            };

            string sql = @"INSERT INTO dbo.Users(Email,Phone ,Name, Surname, Age, City, Announcement, Password) 
            VALUES(@Email,@Phone ,@name, @surname, @age, @city, @announcement, @password)";

            SqlWorkflow.saveData(sql, user);
        }



        public static void createRequest(string _annemail, string _email, string _phone, string _name, string _surname, int _age, string _request)
        {
            RequestModel req = new RequestModel
            {
                annemail = _annemail,
                email = _email,
                phone = _phone,
                name = _name,
                surname = _surname,
                age = _age,
                request = _request
            };

            string sql = @"INSERT INTO dbo.req(annemail,email ,phone, name, surname, age, request) 
            VALUES(@annemail,@email ,@phone, @name, @surname, @age, @request)";

            SqlWorkflow.saveData(sql, req);
        }


        public static void createPlace(string _city, string _place, string _description)
        {
            PlacesModel pla = new PlacesModel
            {
                city = _city,
                place = _place,
                description = _description
            };

            string sql = @"INSERT INTO dbo.places(city,place ,description) 
            VALUES(@city ,@place, @description)";

            SqlWorkflow.saveData(sql, pla);
        }


        public static List<PlacesModel> Searchplace(string s)
        {
            string sql = $@"SELECT * FROM dbo.places WHERE city =N'" + s + "' ";
            return SqlWorkflow.loadData<PlacesModel>(sql);
        }



        //Отображение таблицы заявок
        public static List<RequestModel> loadUReq(string s, string p)
        {
            string sql = @"SELECT req.annemail, req.email , req.phone, req.name, req.surname, req.age, req.request
                         FROM dbo.req, dbo.Users 
                         WHERE req.annemail=N'" + s + "' and Users.Email=N'" + s+"' and Users.Password=N'"+p+"' ";
            return SqlWorkflow.loadData<RequestModel>(sql);
        }
        //req.annemail, req.email , req.phone, req.name, req.surname, req.age, req.request




        //Отображение таблицы зарегистрировшихся
        public static List<UsersModel> loadUsers() 
        {
            string sql = @"SELECT * FROM dbo.Users";
            return SqlWorkflow.loadData<UsersModel>(sql);
        }



        //Поиск записи по городу
        public static List<UsersModel> CitySearch(string s)
        {
            string sql = $@"SELECT * FROM dbo.Users WHERE City =N'" + s + "' ";
            return SqlWorkflow.loadData<UsersModel>(sql);
        }



        //Авторизация
        public static List<UsersModel> Ассaccount(string login, string password)
        {
            string sql = $@"SELECT * FROM dbo.Users WHERE Email =N'" + login + "' and Password=N'" + password + "' ";
            return SqlWorkflow.loadData<UsersModel>(sql);
        }




        public static List<UsersModel> Deletes(string login, string password)
        {
            string sql = @"DELETE  FROM dbo.Users WHERE Email =N'" + login + "' and Password=N'" + password + "' ";
            return SqlWorkflow.loadData<UsersModel>(sql);
        }

    }
}
