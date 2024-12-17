using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data.Dto
{
    public class BaseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
    }
}
