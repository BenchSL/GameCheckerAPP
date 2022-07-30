using System;
using System.Xml.Serialization;
using GameDatabaseFiller.Data;
using GameDatabaseFiller.ClassesM;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameDatabaseFiller
{
    internal class Program
    {
        const string FILENAME = "Data.xml";
        static void Main(string[] args)
        {
            GameModelDbContext dbContext = new GameModelDbContext();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameConverter.Response));

            FileStream fs = new FileStream(FILENAME, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            GameConverter.Response responseObj = (GameConverter.Response)xmlSerializer.Deserialize(reader);

            List<GameModel> gameModelList = new List<GameModel>();

            foreach(var i in responseObj.Games.Message)
            {
                GameModel newModel = new GameModel();

                newModel.Appid = i.Appid;
                newModel.Name = i.Name;
                newModel.PlaytimeForever = i.PlaytimeForever;
                newModel.HasCommunityVisibleStats = i.HasCommunityVisibleStats;
                newModel.ImgIconUrl = i.ImgIconUrl;

                dbContext.Add(newModel);
                dbContext.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
