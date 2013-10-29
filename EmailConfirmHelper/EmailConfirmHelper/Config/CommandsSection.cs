using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmailConfirmHelper.Config
{
    public class CommandsSection : ConfigurationSection
    {
        [ConfigurationProperty("Commands", IsRequired = true)]
        public CommandElementCollection Commands
        {
            get { return (CommandElementCollection)this["Commands"]; }
            set { this["Commands"] = value; }
        }
    }
}