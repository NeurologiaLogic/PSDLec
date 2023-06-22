using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationLab.Models;
namespace KpopZtationLab.Factory
{
    public class CustomerFactory
    {

        public static Customer Create(string CustomerEmail, string CustomerName, string CustomerPassword,string CustomerAddress,string CustomerGender,string CustomerRole)
        {
            var customer = new Customer();
            customer.CustomerName = CustomerName;
            customer.CustomerEmail = CustomerEmail;
            customer.CustomerPassword = CustomerPassword;
            customer.CustomerAddress = CustomerAddress;
            customer.CustomerGender = CustomerGender;
            customer.CustomerRole = "CSTM";
            return customer;
        }
    }
}