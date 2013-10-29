using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmailConfirmHelper.Config
{
    [ConfigurationCollection(typeof(CommandArgumentElement), AddItemName = "Arg")]
    public class CommandArgumentElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CommandArgumentElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CommandArgumentElement).Name;
        }
    }
}