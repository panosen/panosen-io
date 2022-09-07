using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Panosen.IO.MSTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var random = new Random();

            var bytes = new byte[10];
            random.NextBytes(bytes);

            using (var stream = new MemoryStream(bytes))
            {
                using (var reader = new PanosenBinraryReader(stream))
                {
                    var a = reader.ReadByte();
                    Assert.AreEqual(bytes[0], a);

                    var b = reader.ReadUInt16BigEndian();
                    Assert.AreEqual((bytes[1] << 8) + bytes[2], b);

                    var c = reader.ReadUInt32BigEndian();
                    Assert.AreEqual(((uint)bytes[3] << 24) + ((uint)bytes[4] << 16) + ((uint)bytes[5] << 8) + (uint)bytes[6], c);
                }
            }
        }
    }
}