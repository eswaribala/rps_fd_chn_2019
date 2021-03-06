﻿using CQRSDemo.Events;
using CQRSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    public class UpdateCustomerCommand : Command
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<CreatePhoneCommand> Phones { get; set; }
        public CustomerUpdatedEvent ToCustomerEvent()
        {
            return new CustomerUpdatedEvent
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                Phones = this.Phones.Select(phone => new PhoneCreatedEvent
                {
                    Type = phone.Type,
                    AreaCode = phone.AreaCode,
                    Number = phone.Number
                }).ToList()
            };
        }
        public CustomerRecord ToCustomerRecord(CustomerRecord record)
        {
            record.Name = this.Name;
            record.Age = this.Age;
            record.Phones = this.Phones.Select(phone => new PhoneRecord
            {
                Type = phone.Type,
                AreaCode = phone.AreaCode,
                Number = phone.Number
            }).ToList()
                ;
            return record;
        }
    }
}
