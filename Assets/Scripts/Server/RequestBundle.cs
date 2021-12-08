using System;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Server
    {
        public class RequestBundle
        {
            public int id;
            public int activeReqCount;
            private int reqCount;
            public Action<bool, RequestBundle> callback;
            public List<IRequest> requests;
            public bool resStaus = true;
            public System.Diagnostics.Stopwatch bundleWatch = new System.Diagnostics.Stopwatch();
            private float progressValue;
            private float ProgressValue
            {
                get
                {
                    return progressValue;
                }
                set
                {
                    progressValue = value;
                    OnProgressChanged?.Invoke(progressValue);
                }
            }
            public Action<float> OnProgressChanged;
            private RequestBundle childReqBundle;
            public RequestBundle ChildReqBundle
            {
                get
                {
                    if (childReqBundle == null)
                    {
                        childReqBundle = new RequestBundle();
                        childReqBundle.parent = this;
                    }
                    return childReqBundle;
                }
                set
                {
                    childReqBundle = value;
                }
            }
            private RequestBundle parent;
            public RequestBundle Parent
            {
                get
                {
                    if (parent == null)
                        parent = new RequestBundle();
                    return parent;
                }
                set
                {
                    parent = value;
                }
            }
            private void AddProgressValue(float delta)
            {
                ProgressValue += delta / reqCount;
            }
            public RequestBundle()
            {
                requests = new List<IRequest>();
            }
            public void Put<T>(Request<T> request)
            {
                if (request != null)
                {
                    request.OnDownloadProgressChanged += AddProgressValue;
                    requests.Add(request);
                    activeReqCount++;
                    RequestBundle tmp = this;
                    while (tmp != null)
                    {
                        reqCount++;
                        tmp = tmp.parent;
                    }
                }
            }
            public void PutIntoChild<T>(Request<T> request)
            {
                if (request != null)
                {
                    ChildReqBundle.Parent = this;
                    request.OnDownloadProgressChanged += AddProgressValue;
                    ChildReqBundle.requests.Add(request);
                    ChildReqBundle.activeReqCount++;
                    RequestBundle tmp = ChildReqBundle;
                    while (tmp != null)
                    {
                        reqCount++;
                        tmp = tmp.parent;
                    }
                }
            }
            public Request<T> Get<T>(int index)
            {
                return requests[index] as Request<T>;
            }
            public RequestBundle(List<IRequest> requests, Action<bool, RequestBundle> callback)
            {
                this.requests = new List<IRequest>();
                this.requests = requests;
                foreach (var request in this.requests)
                {
                    request.OnDownloadProgressChanged += AddProgressValue;
                }
                this.callback = callback;
                activeReqCount = requests.Count;
                reqCount += requests.Count;
            }
            public RequestBundle(IRequest request)
            {
                requests = new List<IRequest>();
                request.OnDownloadProgressChanged += AddProgressValue;
                requests.Add(request);
                callback = null;
                activeReqCount++;
                reqCount++;
            }
            public RequestBundle(IRequest request, Action<bool, RequestBundle> callback)
            {
                requests = new List<IRequest>();
                request.OnDownloadProgressChanged += AddProgressValue;
                requests.Add(request);
                this.callback = callback;
                activeReqCount++;
                reqCount++;
            }
        }
    }
}