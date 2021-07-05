using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Components.Forms;

namespace DynamicTest.Tests.MockData
{
    public static class BrowserFileMocked
    {
        internal class File : IBrowserFile
        {
            public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = new CancellationToken())
            {
                var stream = new MemoryStream();
                return stream;
            }

            public string Name { get; }
            public DateTimeOffset LastModified { get; }
            public long Size { get; }
            public string ContentType { get; }
        }
    }
}