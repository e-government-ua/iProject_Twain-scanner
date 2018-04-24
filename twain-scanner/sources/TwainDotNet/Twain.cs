﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using TwainDotNet.TwainNative;
using TwainDotNet.Win32;
using System.Drawing;

namespace TwainDotNet
{
    public class Twain
    {
        DataSourceManager _dataSourceManager;

        public Twain(IWindowsMessageHook messageHook)
        {
            ScanningComplete += delegate { };
            TransferImage += delegate { };

            _dataSourceManager = new DataSourceManager(DataSourceManager.DefaultApplicationId, messageHook);
            _dataSourceManager.ScanningComplete += delegate(object sender, ScanningCompleteEventArgs args)
            {
                ScanningComplete(this, args);
            };
            _dataSourceManager.TransferImage += delegate(object sender, TransferImageEventArgs args)
            {
                TransferImage(this, args);
            };
        }

        /// <summary>
        /// Notification that the scanning has completed.
        /// </summary>
        public event EventHandler<ScanningCompleteEventArgs> ScanningComplete;

        public event EventHandler<TransferImageEventArgs> TransferImage;

        /// <summary>
        /// Starts scanning.
        /// </summary>
        public void StartScanning(ScanSettings settings)
        {
            _dataSourceManager.StartScan(settings);
        }

        /// <summary>
        /// Shows a dialog prompting the use to select the source to scan from.
        /// </summary>
        public void SelectSource()
        {
            _dataSourceManager.SelectSource();
        }

        /// <summary>
        /// Selects a source based on the product name string.
        /// </summary>
        /// <param name="sourceName">The source product name.</param>
        public void SelectSource(string sourceName)
        {
			var source = _dataSourceManager.GetSource(
                sourceName,
                _dataSourceManager.ApplicationId,
                _dataSourceManager.MessageHook);

            _dataSourceManager.SelectSource(source);
        }

	    /// <summary>
		/// Gets the settings of a source based on the product name string.
	    /// </summary>
		/// <param name="sourceName">The source product name.</param>
	    /// <returns></returns>
	    public SourceSettings GetAwailableSourceSettings(string sourceName)
	    {
		    SourceSettings settings;
		    try
		    {
			    SelectSource(sourceName);
			    _dataSourceManager.DataSource.OpenSource();
			    settings = _dataSourceManager.DataSource.GetAwailableSourceSettings();
		    }
		    catch (Exception e)
		    {
			    throw;
		    }
		    finally
		    {
			    _dataSourceManager.DataSource.Close();
		    }

		    return settings;
	    }

        /// <summary>
        /// Gets the product name for the default source.
        /// </summary>
        public string DefaultSourceName
        {
            get
            {
				using (var source = _dataSourceManager.GetDefault(_dataSourceManager.ApplicationId))
                {
                    return source.SourceId.ProductName;
                }
            }
        }

        /// <summary>
        /// Gets a list of source product names.
        /// </summary>
        public IList<string> SourceNames
        {
            get
            {
                var result = new List<string>();
				var sources = _dataSourceManager.GetAllSources();

                foreach (var source in sources)
                {
                    result.Add(source.SourceId.ProductName);
                 //   source.Dispose();
                }

                return result;
            }
        }
    }
}
