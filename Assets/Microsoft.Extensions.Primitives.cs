using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Extensions.Primitives
{
    public interface IChangeToken
    {
        bool ActiveChangeCallbacks { get; }
        bool HasChanged { get; }
        IDisposable RegisterChangeCallback(Action<object> callback, object state);
    }

}