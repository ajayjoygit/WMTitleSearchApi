using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarnerMedia.Data.Entities
{
	public class OtherName
	{
		public int Id { get; set; }
		public int TitleId { get; set; }
		public string TitleNameLanguage { get; set; }
		public string TitleNameType { get; set; }
		public string TitleNameSortable { get; set; }
		public string TitleName { get; set; }
	}
}
