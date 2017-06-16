﻿using System;
using Microsoft.Extensions.Options;
using TDX.Api.Models;
using TDX.Api.Repositories;
using TDX.Api.Services;

namespace TDX.Api.Tests
{
    public class ServiceFixture : IDisposable
    {
        public DataService<Note> Notes { get; private set; }

        public ServiceFixture()
        {
            var settings = Options.Create(new AppSettings
            {
                MongoDbSettings = new MongoDbSettings
                {
                    ConnectionString = "mongodb://localhost:27017",
                    Database = "TDX-API"
                }
            });

            var ctx = new MongoDbContext(settings);

            Notes = new NoteService(new Repository<Note>(ctx));
        }

        public void Dispose()
        {

        }
    }
}