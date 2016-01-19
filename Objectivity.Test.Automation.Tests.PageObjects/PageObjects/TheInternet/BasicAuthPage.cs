﻿/*
The MIT License (MIT)

Copyright (c) 2015 Objectivity Bespoke Software Specialists

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet
{
    using System.Globalization;

    using NLog;

    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Extensions;
    using Objectivity.Test.Automation.Common.Helpers;
    using Objectivity.Test.Automation.Common.Types;
    using Objectivity.Test.Automation.Tests.PageObjects;

    public class BasicAuthPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Basic Auth']"),
                                        congratulationsInfo = new ElementLocator(Locator.CssSelector, ".example>p");

        public BasicAuthPage(DriverContext driverContext)
            : base(driverContext)
        {
            Logger.Info("Waiting for page to open");
            this.Driver.IsElementPresent(this.pageHeader, BaseConfiguration.ShortTimeout);
        }


        public string GetCongratulationsInfo
        {
            get
            {
                var text = this.Driver.GetElement(this.congratulationsInfo).Text;
                Logger.Info(CultureInfo.CurrentCulture, "Text from page '{0}'", text);
                return text;
            }
        }

        public void SaveSourcePage()
        {
            this.DriverContext.SavePageSource(this.DriverContext.TestTitle);
        }

        public void CheckIfPageSourceSaved(string newNameOfFile)
        {
            FilesHelper.WaitForFileOfGivenName(this.Driver, 3, this.DriverContext.TestTitle + FilesHelper.ReturnFileExtension(FileType.Html), this.DriverContext.PageSourceFolder);
            FilesHelper.RenameFile(this.Driver, 2, FilesHelper.GetLastFile(this.DriverContext.PageSourceFolder, FileType.Html).Name, newNameOfFile, this.DriverContext.PageSourceFolder);
        }

    }
}
