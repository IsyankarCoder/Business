using System;
using System.Collections.Generic;
using System.Text;
using Global.Core.Domain.Models.Base;

namespace Global.Core.Domain.Models
{
    public abstract class BaseParameter 
        : BaseEntity
    {
        public int ParameterId { get; set; }

        public int? ParameterGroupId { get; set; }
        public string Code { get; set; }
        public string Value { get; set; } 
    }
}
