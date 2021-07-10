using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarnerMedia.Data.Entities
{
    public class TitleParticipant
    {
		public int Id { get; set; }
		public int TitleId { get; set; }

		public int ParticipantId { get; set; }
		public bool IsKey { get; set; }
		public string RoleType { get; set; }
		public bool IsOnScreen { get; set; }
	}
}
