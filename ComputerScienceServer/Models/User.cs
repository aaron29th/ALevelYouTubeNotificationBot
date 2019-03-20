using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerScienceServer.Models
{
	public class User
	{
		//Auto increment id
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public DateTime Registered { get; set; }
	}
}
