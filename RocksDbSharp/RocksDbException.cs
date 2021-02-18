using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RocksDbSharp
{
    public class RocksDbException : RocksDbSharpException
    {
        public RocksDbException(IntPtr errptr)
            : base(ReadNullTerminatedString(errptr, Encoding.UTF8))
        {
            Native.Instance.rocksdb_free(errptr);
        }

        private static unsafe string ReadNullTerminatedString(IntPtr ptr, Encoding encoding)
        {
            int size = 0;
            for (byte* p = (byte*)ptr.ToPointer(); *p != 0; ++p)
            {
                ++size;
            }

            byte[] buffer = new byte[size];
            Marshal.Copy(
                ptr,
                buffer,
                0,
                size);

            return encoding.GetString(buffer);
        }
    }
}
