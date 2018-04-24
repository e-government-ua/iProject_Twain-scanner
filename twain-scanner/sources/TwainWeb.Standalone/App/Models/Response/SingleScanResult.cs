﻿using System;
using System.IO;
using System.Text;
using TwainWeb.Standalone.App.Models.Request;

namespace TwainWeb.Standalone.App.Models.Response
{
	class SingleScanResult : ScanResult
	{
		public SingleScanResult(string error) : base(error) { }
		public SingleScanResult() { }
        
        public void FillContent(DownloadFile file)
        {
            if (file == null) throw new ArgumentNullException("file");

            Content = Encoding.UTF8.GetBytes(string.Format("{{\"file\": \"{0}\", \"temp\": \"{1}\"}}", file.FileName, file.TempFile));
        }


        public void FillContent(DownloadFile file, string Base64)
		{
			if (file == null) throw new ArgumentNullException("file");                       

            Content = Encoding.UTF8.GetBytes(string.Format("{{\"file\": \"{0}\", \"temp\": \"{1}\",  \"base64\": \"{2}\"}}", file.FileName, file.TempFile, Base64));
        }
	}
}
