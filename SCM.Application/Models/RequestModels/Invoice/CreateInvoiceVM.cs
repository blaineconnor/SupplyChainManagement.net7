﻿using System.Numerics;

namespace SCM.Application.Models.RequestModels.Invoice
{
    public class CreateInvoiceVM
    {
        public Int64 RequestId { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
