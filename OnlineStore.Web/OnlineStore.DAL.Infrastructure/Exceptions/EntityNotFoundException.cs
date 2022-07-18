using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Infrastructure.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException()
		{ }
		public EntityNotFoundException(string message)
			: base(String.Format(message))
		{ }
	}
}
