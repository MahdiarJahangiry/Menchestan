using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Menchestan
{
    namespace Server
    {
        public class RequestCallback<T>
        {

            private Action<T, string, int> _Success;
            public Action<T, string, int> Success
            {
                get { return _Success; }
                set { this._Success = value; }
            }

            private Action<string, int> _Error;

            public Action<string, int> Error
            {
                get { return _Error; }
                set { this._Error = value; }
            }
        }
    }
}