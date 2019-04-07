using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeFirstApi.Controllers
{
    public class TransactionsController : ApiController
    {

        [HttpPost]
        public void IPN(Subscription model)
        {
            if (!ModelState.IsValid)
            {

                // if you want to use the PayPal sandbox change this from false to true
                /*   string response = GetPayPalResponse(model, true);

                    if (response == "VERIFIED")
                    {

                    }
                    */
            }

        }

    }
}