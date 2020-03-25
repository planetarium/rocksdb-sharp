using System;
using System.Runtime.InteropServices;

namespace RocksDbSharp
{
    public class RocksDbException : RocksDbSharpException
    {
        public RocksDbException(IntPtr errptr)
            : base(Marshal.PtrToStringUni(errptr))
        {
            Native.Instance.rocksdb_free(errptr);
        }
    }
}