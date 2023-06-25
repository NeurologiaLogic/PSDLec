using KpopZtationLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace KpopZtationLab.Pattern
{
    public class repo
    {
        static ProductRepository albumRepository;
        static CategoryRepository artistRepository;
        static CartRepository cartRepository;
        static CustomerRespository customerRespository;
        static TransactionHeaderRepository thRepository;
        static TransactionDetailsRepository tdRepository;
        public static ProductRepository albums
        {
            get
            {
                if (albumRepository == null)
                {
                    return albumRepository = new ProductRepository();
                }
                return albumRepository;

            }
        }
        public static CategoryRepository artists
        {
            get
            {
                if (artistRepository == null)
                {
                    return artistRepository = new CategoryRepository();
                }
                return artistRepository;

            }
        }
        public static CartRepository carts
        {
            get
            {
                if (cartRepository == null)
                {
                    return cartRepository = new CartRepository();
                }
                return cartRepository;
            }
        }
        public static CustomerRespository customers
        {
            get
            {
                if (customerRespository == null)
                {
                    return customerRespository = new CustomerRespository();
                }
                return customerRespository;
            }
        }
        public static TransactionDetailsRepository transactionDetails
        {
            get
            {
                if (tdRepository == null)
                {
                    return tdRepository = new TransactionDetailsRepository();
                }
                return tdRepository;
            }
        }
        public static TransactionHeaderRepository transactionHeaders
        {
            get
            {
                if (thRepository == null)
                {
                    return thRepository = new TransactionHeaderRepository();
                }
                return thRepository;
            }
        }

    }
}