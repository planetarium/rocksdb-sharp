using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RocksDbSharp
{
    public class RocksDbException : RocksDbSharpException
    {
        public RocksDbException(IntPtr errptr)
            : base(Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(errptr))))
        {
            Native.Instance.rocksdb_free(errptr);
        }
    }
}