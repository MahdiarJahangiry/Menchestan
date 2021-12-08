using System;
namespace Menchestan
{
    namespace Server
    {
        [Serializable]
        public class Response<T>
        {
            public int status;
            public T data;
            public string message;
            public int totalpage;
            public bool IsSuccessfull
            {
                get
                {
                    return (status >= 200 && status < 300);
                }
            }
        }
    }
}