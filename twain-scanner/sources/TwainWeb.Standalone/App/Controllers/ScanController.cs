﻿using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using TwainWeb.Standalone.App.Binders;
using TwainWeb.Standalone.App.Cache;
using TwainWeb.Standalone.App.Commands;
using TwainWeb.Standalone.App.Models;
using TwainWeb.Standalone.App.Models.Request;
using TwainWeb.Standalone.App.Models.Response;
using TwainWeb.Standalone.App.Queries;
using TwainWeb.Standalone.App.Scanner;

namespace TwainWeb.Standalone.App.Controllers
{
    public class ScanController
    {
        public ScanController(object markerAsync)
        {
            _markerAsync = markerAsync;
        }

        private readonly object _markerAsync;

        public ActionResult Scan(ScanForm command, IScannerManager scannerManager)
        {
            var scanResult = new ScanCommand(command, scannerManager).Execute(_markerAsync);

            if (scanResult.Validate())
                return new ActionResult { Content = scanResult.Content, ContentType = "text/json" };

            throw new Exception(scanResult.Error);
        }

        public ActionResult GetScannerParameters(IScannerManager scannerManager, CacheSettings cashSettings, int? sourceIndex)
        {
            var queryResult = new GetScannerParametersQuery(scannerManager, cashSettings, sourceIndex).Execute(_markerAsync);

            if (queryResult.Validate())
                return new ActionResult { Content = Encoding.UTF8.GetBytes(queryResult.Serialize()), ContentType = "text/json" };

            throw new Exception(queryResult.Error);
        }

        public ActionResult RestartWia()
        {
            var sc = new ServiceController("stisvc");
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    if (sc.CanStop)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(20));
                        sc.Refresh();
                    }
                    break;
                case ServiceControllerStatus.Stopped:
                    break;
            }
            Thread.Sleep(1000);
            sc.Start();
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(20));

            return new ActionResult { Content = Encoding.UTF8.GetBytes("{\"status\":\"Ok\"}"), ContentType = "text/json" };
        }
        public ActionResult Restart()
        {
            var proc = new Process();
            var psi = new ProcessStartInfo();

            psi.CreateNoWindow = true;
            psi.FileName = "TwainWeb.ServiceManager.exe";
            psi.Arguments = 
                //Settings.Default.ServiceName + " "+
                "-restart";
            psi.LoadUserProfile = false;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo = psi;
            proc.Start();

            return new ActionResult { Content = Encoding.UTF8.GetBytes("{\"status\":\"Ok\"}"), ContentType = "text/json" };
        }
    }
}
