using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Core.Domain.Models.Base
{
    public abstract class BaseParameterGroup
        : BaseEntity
    {
        public int ParameterGroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
