using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WarnerMediaWebApi.DTO
{
    [DataContract]
	public class StatusDTO
    {
		[DataMember]
        public int StatusCode { get; set; }
		[DataMember]
		public string StatusMessage { get; set; }
		
    }
}
