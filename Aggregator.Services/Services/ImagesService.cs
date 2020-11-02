using Aggregator.Configuration;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Aggregator.Services
{
    public class ImagesService
    {
        public string UploadImage( IFormFileCollection files )
        {
            var extImg = Path.GetExtension(files[ 0 ].FileName);

            string fileNameImg = Guid.NewGuid().ToString();

            using( var client = new AmazonS3Client(AppConfiguration.AccessKeyAS3, AppConfiguration.SecretKeyAS3, RegionEndpoint.USEast1) )
            {
                var fileTransferUtility = new TransferUtility(client);

                using( var newMemoryStream = new MemoryStream() )
                {
                    var imageObj = files[ 0 ]; 

                    imageObj.CopyTo(newMemoryStream);
                    var uploadImageRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = fileNameImg + extImg,
                        BucketName = "agregator-project"
                    };

                    fileTransferUtility.Upload(uploadImageRequest);
                }
            }

            return $"{AppConfiguration.FileStorageHostname}{AppConfiguration.BucketName}/{fileNameImg}{extImg}";
        }

    }
}
