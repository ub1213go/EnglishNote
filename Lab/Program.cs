// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlClient;
using System.Net;
using EnglishNote.DB;
using EnglishNote.Lab;
using SqlSugar;

Console.WriteLine("Hello World");

var dbm = new DBManager();
var db = dbm.Connect("EnglishNote");

TEST t = new TEST();
foreach(var item in t.EnglishTestData)
{
    item.Insert(db);
}

