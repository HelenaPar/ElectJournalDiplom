using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class ParamsToTableViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }
    }
}
