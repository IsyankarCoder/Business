using System;
using System.Collections.Generic;
using System.Text;
namespace Global.Core.Domain.Models
{
    public class Parameter
        : BaseParameter
    {
        public Parameter()
        {

        }
        public virtual ParameterGroup ParameterGroup { get; set; }
        

    }
}
