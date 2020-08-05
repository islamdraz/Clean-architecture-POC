using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.CustomValidations
{
    public class RequestInValidException:Exception
    {

        

        public  string ErrorTemplate => "DTE_{0}_{1}";

        public string[] ErrorCodes { get; }

        
        public RequestInValidException(DataTypeExceptionError[] errors) : base(null)
        { 
            StringBuilder Code=new StringBuilder("Errors_");
            ErrorCodes = errors.Select(x => $"{Code + string.Format(ErrorTemplate, x.Code, x.PropertyName)}")
                .ToArray();
        }


        public class DataTypeExceptionError
        {
            public string PropertyName { get; set; }
            public string Code { get; set; }
        }
    }
}
