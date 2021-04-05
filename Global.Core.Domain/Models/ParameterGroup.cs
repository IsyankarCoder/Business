using Global.Core.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Core.Domain.Models
{
    public class ParameterGroup
        : BaseParameterGroup
    {

        public ParameterGroup()
        {
           // Parameters = new HashSet<Parameter>();
        }

        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
