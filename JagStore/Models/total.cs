using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jagstore.Models
{
    public class Total
    {
        public double[] Value= new double[100];
        public double Tax()
        {            
            return Value.Sum() * .10;
        }

        public double SubTotal()
        {
            return Value.Sum() + Tax();
        }
        
    }
}