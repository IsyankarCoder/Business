using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations
    .Schema;

namespace Global.Core.Domain.Models.Base
{

   [Serializable]
   public abstract class BaseEntity
    {
        [XmlIgnore]
        public int? CreatedBy { get; set; }

        [XmlIgnore]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [XmlIgnore]
        public int? UpdatedBy { get; set; }

        [XmlIgnore]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }


        [XmlIgnore]        
        public int RecordStatus { get; set; }

        [Timestamp]
        [XmlIgnore]
        public Byte[] TimeStamp { get; set; }

    }
}
