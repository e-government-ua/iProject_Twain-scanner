﻿using System;
using System.Collections.Generic;
using System.Text;
using TwainWeb.Standalone.App.Models.Request;
using log4net;

namespace TwainWeb.Standalone.App.Models.Response
{
	class MultipleScanResult : ScanResult
	{

        private readonly ILog _log = LogManager.GetLogger(typeof(MultipleScanResult));

        public MultipleScanResult(string error) : base(error) { }
		public MultipleScanResult() { }
	

		public void FillContent(List<DownloadFile> files)
		{
			if (files == null) throw new ArgumentNullException("files");

			var sb = new StringBuilder();
			sb.Append("{\"files\": [");

			foreach (var downloadFile in files)
			{
				sb.Append(string.Format("{{\"file\": \"{0}\", \"temp\": \"{1}\"}}", downloadFile.FileName, downloadFile.TempFile));
				if (downloadFile != files[files.Count - 1])
				{
					sb.Append(",");
				}

                _log.Info("сформированный multi-json" + sb.ToString());
            }
			sb.Append("]}");
            Content = Encoding.UTF8.GetBytes(sb.ToString());
        }		
	}
}
