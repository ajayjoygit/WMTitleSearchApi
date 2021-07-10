using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WarnerMediaWebApi.DTO
{
    [DataContract]
	public class TitlesDTO
    {
		[DataMember]
        public int TitleId { get; set; }
		[DataMember]
		public string TitleName { get; set; }
		[DataMember]
		public string TitleNameSortable { get; set; }
		[DataMember]
		public int ?TitleTypeId  { get; set; }
		[DataMember]
		public int ReleaseYear { get; set; }
		[DataMember]
		public DateTime ProcessedDateTimeUTC { get; set; }
    }
}
