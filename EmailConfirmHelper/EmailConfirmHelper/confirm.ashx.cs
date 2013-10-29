using EmailConfirmHelper.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EmailConfirmHelper
{
    /// <summary>
    /// Summary description for confirm
    /// </summary>
    public class confirm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/HTML";
            string status = "Success";
            string message = "Operation Completed Successfully!";

            try
            {
                // args
                var op = (context.Request.QueryString["op"] ?? string.Empty).ToLower();

                var cmds = ConfigurationManager.GetSection("DynamicCommands") as Config.CommandsSection;
                Debug.Assert(cmds != null);
                var targetCommand = cmds.Commands.Cast<CommandElement>().ToList().FirstOrDefault(q => q.Name.ToLower().Equals(op));
                if (targetCommand == null)
                {
                    throw new InvalidOperationException("unknown operation: " + op);
                }
                var cnElement = ConfigurationManager.ConnectionStrings[targetCommand.ConnectionName];
                if (cnElement == null)
                {
                    throw new InvalidOperationException("Connection not found: " + targetCommand.ConnectionName);
                }
                var connString = cnElement.ConnectionString;
                using (var cn = new SqlConnection(connString))
                {
                    cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = targetCommand.CommandText;

                        var args = targetCommand.Args.Cast<CommandArgumentElement>().OrderBy(q => q.Order).ToList();
                        foreach(var arg in args)
                        {
                            var value = context.Request.QueryString[arg.Name];
                            cmd.Parameters.AddWithValue(arg.Name, value);
                        }

                        // add parameters
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                status = "Failure";
                message = ex.Message;
            }

            context.Response.Write(string.Format("<html><head></head><body><h2>{0}</h2><p>{1}</p></body></html>", status, message));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}