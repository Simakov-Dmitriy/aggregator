using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Configuration
{
    public static class AppConfiguration
    {
        public static string ConectionString => "Server=.;Database=aspnet-AggregatorProject.Core;Integrated Security=True";
        public static string BucketName => "agregator-project";
        public static string FileStorageHostname => "https://s3.us-west-1.amazonaws.com/";
        public static string AccessKeyAS3 => "AKIAJHFIEWQWVGQ2ZOFA";
        public static string SecretKeyAS3 => "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";
        public static string ApiLoginId => "74WKwa3C";
        public static string ApiTransactionKey => "442AU3F3k46Wyf3b";
    }
}
