using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerScienceServer.Models
{
	public class ErrorLog
	{
		//Auto increment id
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Location { get; set; }
		public string ExceptionMessage { get; set; }
		public DateTime Timestamp { get; set; }

		public ErrorLog()
		{
			Timestamp = DateTime.Now;
		}

		public ErrorLog(WebApiContext context, string exceptionMessage, string location)
		{
			ExceptionMessage = exceptionMessage;
			Location = location;
			Timestamp = DateTime.Now;
			context.ErrorLog.Add(this);
			context.SaveChanges();
		}
	}
}
