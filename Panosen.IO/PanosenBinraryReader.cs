using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Panosen.IO
{
    public class PanosenBinraryReader : BinaryReader
    {
        public PanosenBinraryReader(Stream input) : base(input)
        {
        }

        public PanosenBinraryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public PanosenBinraryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public long Position
        {
            get
            {
                return base.BaseStream.Position;
            }
        }

        public string ReadASCII(int length)
        {
            var bytes = base.ReadBytes(length);
            return new string(bytes.Select(b => (char)b).ToArray(), 0, length).Replace("\0", string.Empty);
        }

        public string ReadString(int length, Encoding encoding)
        {
            var bytes = ReadBytes(length);
            return encoding.GetString(bytes).Replace("\0", string.Empty);
        }

        public void Skip(int count)
        {
            this.BaseStream.Seek(count, SeekOrigin.Current);
        }

        public void Seek(long offset, SeekOrigin origin)
        {
            this.BaseStream.Seek(offset, origin);
        }

        #region BigEndian

        public short ReadInt16BigEndian()
        {
            return BitConverter.ToInt16(ReadBytesBigEndian(2), 0);
        }

        public ushort ReadUInt16BigEndian()
        {
            return BitConverter.ToUInt16(ReadBytesBigEndian(2), 0);
        }

        public int ReadInt32BigEndian()
        {
            return BitConverter.ToInt32(ReadBytesBigEndian(4), 0);
        }

        public uint ReadUInt32BigEndian()
        {
            return BitConverter.ToUInt32(ReadBytesBigEndian(4), 0);
        }

        public byte[] ReadBytesBigEndian(int count)
        {
            var bytes = base.ReadBytes(count);
            Array.Reverse(bytes);
            return bytes;
        }

        #endregion
    }
}