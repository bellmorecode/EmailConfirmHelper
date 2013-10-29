using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmailConfirmHelper.Config
{
    [ConfigurationCollection(typeof(CommandElement), AddItemName="Command")]
    public class CommandElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CommandElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CommandElement).CommandText;
        }
    }
}