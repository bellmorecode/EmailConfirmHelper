using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmailConfirmHelper.Config
{
    public class CommandArgumentElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        [ConfigurationProperty("Order", IsRequired = true, IsKey = false)]
        public Int32 Order
        {
            get { return (Int32)this["Order"]; }
        }
    }
}