using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EmailConfirmHelper.Config
{
    public class CommandElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        [ConfigurationProperty("CommandText", IsRequired = true, IsKey = false)]
        public string CommandText
        {
            get { return (string)this["CommandText"]; }
        }

        [ConfigurationProperty("ConnectionName", IsRequired = true, IsKey = false)]
        public string ConnectionName
        {
            get { return (string)this["ConnectionName"]; }
        }

        [ConfigurationProperty("Args", IsRequired = true, IsKey = false)]
        public CommandArgumentElementCollection Args
        {
            get { return (CommandArgumentElementCollection)this["Args"]; }
        }
    }
}