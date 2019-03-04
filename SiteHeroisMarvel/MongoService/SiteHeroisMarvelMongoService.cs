using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SiteHeroisMarvel.MongoService
{
    public class SiteHeroisMarvelMongoService
    {
        private readonly IMongoCollection<Personagem> _personagem;

        public SiteHeroisMarvelMongoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConexaoMongo"));
            var database = client.GetDatabase("mongo_herois_marvel");
            _personagem = database.GetCollection<Personagem>("herois");
        }

        public Personagem Create(Personagem personagem)
        {
            _personagem.InsertOne(personagem);
            return personagem;
        }

    }

}