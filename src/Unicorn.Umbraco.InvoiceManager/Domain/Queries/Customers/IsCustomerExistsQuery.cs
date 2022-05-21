﻿using Unicorn.Umbraco.InvoiceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicorn.Umbraco.InvoiceManager.Queries
{
    public class IsCustomerExistsQuery : IQuery<bool>
    {
        public string PhoneNumber { get; set; }
    }
}
