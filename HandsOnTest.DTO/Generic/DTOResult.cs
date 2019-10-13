using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.DTO.Generic
{
    public class DTOResult<T> where T:class
    {
        private string message { get; set; }
        private T response { get; set; }
        private bool result { get; set; }
        
        public string Message { get => message; set => message = value; }
        public T Response { get => response; set => response = value; }
        public bool Result { get => result; set => result = value; }

    }
}
