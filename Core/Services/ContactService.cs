﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int contactId);
    }

    public class ContactService : IContactService
    {
        public IEnumerable<Contact> GetAll()
        {
            var serializer = new JsonSerializer();
            using(var stream = typeof(ContactService).GetTypeInfo().Assembly
                .GetManifestResourceStream("Core.Resources.data.json"))
            using (var reader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<IEnumerable<Contact>>(jsonTextReader);
            }
        }

        public Contact Get(int contactId)
        {
            return GetAll().FirstOrDefault(x => x.Id == contactId);
        }
    }
}
