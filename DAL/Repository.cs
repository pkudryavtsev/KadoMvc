using System;
using OrderDb;
using ProductDb;

namespace DAL
{
    public class Repo
    {
        private readonly ProductDbContext _productContext;
        internal ProductDbContext ProductContext 
        {
            get 
            {
                return _productContext;
            }
        }

        private readonly OrderDbContext _orderContext;
        internal OrderDbContext OrderContext
        {
            get
            {
                return _orderContext;
            }
        }

        

        public Repo(ProductDbContext productContext, OrderDbContext orderContext)
        {
            _productContext = productContext;
            _orderContext = orderContext;
        }
    }
}